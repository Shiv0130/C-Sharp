using Dapper;
using Microsoft.Data.SqlClient;

namespace SkyFlow
{

    public class SqlRepository : IDataRepository
    {
        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // - Helper: open connection 
        private SqlConnection Connect() => new SqlConnection(_connectionString);

        
        //  AUTHENTICATION
        
        public User? Login(string username, string password)
        {
            using var conn = Connect();
            const string sql = @"
                SELECT UserId, Username, PasswordHash, Role,
                       Email, FirstName, LastName, CreatedAt
                FROM Users
                WHERE Username = @username AND PasswordHash = @password";

            // Query returns a dynamic row – we map to correct User subclass
            var row = conn.QueryFirstOrDefault(sql, new { username, password });
            if (row == null) return null;

            // Polymorphism: create the RIGHT type based on Role
            User user = ((string)row.Role) switch
            {
                "Admin" => new Admin(),
                "GateAgent" => new GateAgent(),
                _ => throw new Exception("Unknown role")
            };

            user.UserId = row.UserId;
            user.UserName = row.Username;
            user.Email = row.Email ?? "";
            user.FirstName = row.FirstName;
            user.LastName = row.LastName;
            user.CreatedAt = row.CreatedAt;

            return user;
        }

        
        //  FLIGHTS
        
        public IEnumerable<Flight> GetAllFlights()
        {
            using var conn = Connect();
            const string sql = @"
                SELECT FlightId, FlightNumber, Origin, Destination,
                       DepartureTime, ArrivalTime, Capacity,
                       CurrentOccupancy, Status, GateAgentId
                FROM Flights
                ORDER BY DepartureTime";

            var rows = conn.Query(sql);
            return rows.Select(MapFlight).ToList();
        }

        public Flight? GetFlightById(int flightId)
        {
            using var conn = Connect();
            var row = conn.QueryFirstOrDefault(
                "SELECT * FROM Flights WHERE FlightId = @flightId",
                new { flightId });
            return row == null ? null : MapFlight(row);
        }

        public Flight? GetFlightByNumber(string flightNumber)
        {
            using var conn = Connect();
            var row = conn.QueryFirstOrDefault(
                "SELECT * FROM Flights WHERE FlightNumber = @flightNumber",
                new { flightNumber });
            return row == null ? null : MapFlight(row);
        }

        public int CreateFlight(Flight flight)
        {
            using var conn = Connect();
            const string sql = @"
                INSERT INTO Flights
                    (FlightNumber, Origin, Destination, DepartureTime,
                     ArrivalTime, Capacity, Status, GateAgentId)
                VALUES
                    (@FlightNumber, @Origin, @Destination, @DepartureTime,
                     @ArrivalTime, @Capacity, @Status, @GateAgentId);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            return conn.QuerySingle<int>(sql, new
            {
                flight.FlightNumber,
                flight.Origin,
                flight.Destination,
                flight.DepartureTime,
                flight.ArrivalTime,
                flight.Capacity,
                Status = flight.Status,
                flight.GateAgentId
            });
        }

        public bool UpdateFlightStatus(int flightId, string newStatus)
        {
            using var conn = Connect();
            const string sql = @"
                UPDATE Flights
                SET Status = @newStatus
                WHERE FlightId = @flightId";
            return conn.Execute(sql, new { flightId, newStatus }) > 0;
        }

        public bool DeleteFlight(int flightId)
        {
            using var conn = Connect();
            return conn.Execute(
                "DELETE FROM Flights WHERE FlightId = @flightId",
                new { flightId }) > 0;
        }

        
        //  PASSENGERS
        
        public IEnumerable<Passenger> GetAllPassengers()
        {
            using var conn = Connect();
            const string sql = @"
                SELECT p.PassengerId, p.UserId, p.PassportNumber,
                       p.DateOfBirth, p.Nationality, p.ContactNumber,
                       u.FirstName, u.LastName
                FROM Passengers p
                INNER JOIN Users u ON p.UserId = u.UserId";

            return conn.Query(sql).Select(MapPassenger).ToList();
        }

        public Passenger? GetPassengerByPassport(string passportNumber)
        {
            using var conn = Connect();
            const string sql = @"
                SELECT p.PassengerId, p.UserId, p.PassportNumber,
                       p.DateOfBirth, p.Nationality, p.ContactNumber,
                       u.FirstName, u.LastName
                FROM Passengers p
                INNER JOIN Users u ON p.UserId = u.UserId
                WHERE p.PassportNumber = @passportNumber";

            var row = conn.QueryFirstOrDefault(sql, new { passportNumber });
            return row == null ? null : MapPassenger(row);
        }

        
        //  BOOKINGS
        
        public IEnumerable<Booking> GetBookingsByFlight(int flightId)
        {
            using var conn = Connect();
            const string sql = @"
                SELECT b.BookingId, b.FlightId, b.PassengerId,
                       b.SeatNumber, b.BookingStatus, b.BookingDate,
                       b.CheckInTime, b.BoardingTime,
                       u.FirstName + ' ' + u.LastName AS PassengerName,
                       p.PassportNumber,
                       f.FlightNumber
                FROM Bookings b
                INNER JOIN Passengers p ON b.PassengerId = p.PassengerId
                INNER JOIN Users      u ON p.UserId      = u.UserId
                INNER JOIN Flights    f ON b.FlightId    = f.FlightId
                WHERE b.FlightId = @flightId
                ORDER BY b.SeatNumber";

            return conn.Query<Booking>(sql, new { flightId }).ToList();
        }

        public Booking? GetBookingByPassportAndFlight(string passport, int flightId)
        {
            using var conn = Connect();
            const string sql = @"
                SELECT b.BookingId, b.FlightId, b.PassengerId,
                       b.SeatNumber, b.BookingStatus, b.BookingDate,
                       b.CheckInTime, b.BoardingTime,
                       u.FirstName + ' ' + u.LastName AS PassengerName,
                       p.PassportNumber
                FROM Bookings b
                INNER JOIN Passengers p ON b.PassengerId = p.PassengerId
                INNER JOIN Users      u ON p.UserId      = u.UserId
                WHERE p.PassportNumber = @passport
                  AND b.FlightId       = @flightId";

            return conn.QueryFirstOrDefault<Booking>(sql, new { passport, flightId });
        }

        public bool UpdateBookingStatus(int bookingId, string newStatus, DateTime? timeStamp)
        {
            using var conn = Connect();

            // Update the right timestamp column depending on status
            string sql = newStatus switch
            {
                "CheckedIn" => @"UPDATE Bookings
                                 SET BookingStatus = @newStatus,
                                     CheckInTime   = @timeStamp
                                 WHERE BookingId = @bookingId",

                "Boarded" => @"UPDATE Bookings
                                 SET BookingStatus = @newStatus,
                                     BoardingTime  = @timeStamp
                                 WHERE BookingId = @bookingId",

                _ => @"UPDATE Bookings
                                 SET BookingStatus = @newStatus
                                 WHERE BookingId = @bookingId"
            };

            return conn.Execute(sql, new { bookingId, newStatus, timeStamp }) > 0;
        }

        
        //  STAFF (Admin only)
        
        public IEnumerable<User> GetAllStaff()
        {
            using var conn = Connect();
            const string sql = @"
                SELECT UserId, Username, Role, Email, FirstName, LastName, CreatedAt
                FROM Users
                ORDER BY Role, LastName";

            return conn.Query(sql).Select(row =>
            {
                User u = ((string)row.Role) switch
                {
                    "Admin" => new Admin(),
                    "GateAgent" => new GateAgent(),
                    _ => new Admin()
                };
                u.UserId = row.UserId;
                u.UserName = row.Username;
                u.Email = row.Email ?? "";
                u.FirstName = row.FirstName;
                u.LastName = row.LastName;
                u.CreatedAt = row.CreatedAt;
                return u;
            }).ToList();
        }

        public int CreateStaff(User user, string password)
        {
            using var conn = Connect();
            const string sql = @"
                INSERT INTO Users (Username, PasswordHash, Role, Email, FirstName, LastName)
                VALUES (@Username, @Password, @Role, @Email, @FirstName, @LastName);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";

            return conn.QuerySingle<int>(sql, new
            {
                user.UserName,
                Password = password,
                user.Role,
                user.Email,
                user.FirstName,
                user.LastName
            });
        }

        public bool DeleteStaff(int userId)
        {
            using var conn = Connect();
            return conn.Execute(
                "DELETE FROM Users WHERE UserId = @userId",
                new { userId }) > 0;
        }

        //  PRIVATE MAPPING HELPERS
        //  Convert dynamic Dapper rows to strongly-typed objects

        private static Flight MapFlight(dynamic row)
        {
            var f = new Flight
            {
                FlightId = row.FlightId,
                FlightNumber = row.FlightNumber,
                Origin = row.Origin,
                Destination = row.Destination,
                DepartureTime = row.DepartureTime,
                ArrivalTime = row.ArrivalTime,
                Capacity = row.Capacity,
                CurrentOccupancy = row.CurrentOccupancy,
                GateAgentId = row.GateAgentId
            };
            f.SetStatusFromDb((string)row.Status);
            return f;
        }

        private static Passenger MapPassenger(dynamic row)
        {
            return new Passenger
            {
                Passengerid = row.PassengerId,
                UserId = row.UserId,
                PassportNumber = row.PassportNumber,
                DateOfBirth = row.DateOfBirth,
                Nationality = row.Nationality,
                ContactNumber = row.ContactNumber,
                FirstName = row.FirstName,
                LastName = row.LastName
            };
        }

    }
}