<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public interface IDataRepository
    {
        // - Authenitcation
        User? Login(string username,string password);

        // - Flights

        IEnumerable<Flight> GetAllFlights();
        Flight? GetFlightById(int flightId);
        Flight? GetFlightByNumber(string flightNumber);

        int CreateFlight(Flight flight);
        bool UpdateFlightStatus(int flightId, string newStatus);
        bool DeleteFlight(int flightId);

        // Passengers
        IEnumerable<Passenger> GetAllPassengers();

        Passenger? GetPassengerByPassport(string passportNumber);

        //Bookings 
        IEnumerable<Booking> GetBookingsByFlight(int flightID);
        Booking? GetBookingByPassportAndFlight(string passport, int flightId);
        bool UpdateBookingStatus(int bookingId, string newStatus, DateTime? timeStamp);

        //Staff (Admin only)
        IEnumerable<User> GetAllStaff();
        int CreateStaff(User user, string password);
        bool DeleteStaff(int userId);


    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFlow
{
    public interface IDataRepository
    {
        // - Authenitcation
        User? Login(string username,string password);

        // - Flights

        IEnumerable<Flight> GetAllFlights();
        Flight? GetFlightById(int flightId);
        Flight? GetFlightByNumber(string flightNumber);

        int CreateFlight(Flight flight);
        bool UpdateFlightStatus(int flightId, string newStatus);
        bool DeleteFlight(int flightId);

        // Passengers
        IEnumerable<Passenger> GetAllPassengers();

        Passenger? GetPassengerByPassport(string passportNumber);

        //Bookings 
        IEnumerable<Booking> GetBookingsByFlight(int flightID);
        Booking? GetBookingByPassportAndFlight(string passport, int flightId);
        bool UpdateBookingStatus(int bookingId, string newStatus, DateTime? timeStamp);

        //Staff (Admin only)
        IEnumerable<User> GetAllStaff();
        int CreateStaff(User user, string password);
        bool DeleteStaff(int userId);


    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
