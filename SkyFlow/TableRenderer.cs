namespace SkyFlow
{

    public static class TableRenderer
    {
        // - Main render method 
        public static void Render(string[] headers, List<string[]> rows)
        {
            if (headers.Length == 0) return;

            // Step 1: Calculate the max width for each column
            // Start with header widths, then check each data row
            int[] widths = new int[headers.Length];
            for (int i = 0; i < headers.Length; i++)
                widths[i] = headers[i].Length;

            foreach (var row in rows)
                for (int i = 0; i < row.Length && i < widths.Length; i++)
                    if (row[i].Length > widths[i])
                        widths[i] = row[i].Length;

            // Step 2: Build the separator line   e.g. +------+-------+
            string separator = BuildSeparator(widths);

            // Step 3: Print header
            Console.WriteLine(separator);
            Console.Write("|");
            for (int i = 0; i < headers.Length; i++)
                Console.Write($" {headers[i].PadRight(widths[i])} |");
            Console.WriteLine();
            Console.WriteLine(separator);

            // Step 4: Print each data row
            if (rows.Count == 0)
            {
                // Empty result – show a friendly message
                int totalWidth = widths.Sum() + (widths.Length * 3) + 1;
                string msg = " No records found.";
                Console.WriteLine("|" + msg.PadRight(totalWidth - 1) + "|");
            }
            else
            {
                foreach (var row in rows)
                {
                    Console.Write("|");
                    for (int i = 0; i < headers.Length; i++)
                    {
                        string cell = (i < row.Length) ? row[i] : "";
                        Console.Write($" {cell.PadRight(widths[i])} |");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine(separator);
            Console.WriteLine($"  {rows.Count} record(s) found.\n");
        }

        // Build the +---+---+ separator line from column widths
        private static string BuildSeparator(int[] widths)
        {
            var sb = new System.Text.StringBuilder();
            sb.Append('+');
            foreach (int w in widths)
            {
                sb.Append(new string('-', w + 2)); // +2 for the spaces around content
                sb.Append('+');
            }
            return sb.ToString();
        }

        // - Convenience methods 

        // Render a list of flights as a table
        public static void RenderFlights(IEnumerable<Flight> flights)
        {
            string[] headers = { "ID", "Flight No", "Origin", "Destination", "Departure", "Arrival", "Capacity", "Occupancy", "Status" };
            var rows = flights.Select(f => new string[]
            {
                f.FlightId.ToString(),
                f.FlightNumber,
                f.Origin,
                f.Destination,
                f.DepartureTime.ToString("dd/MM/yyyy HH:mm"),
                f.ArrivalTime?.ToString("dd/MM/yyyy HH:mm") ?? "N/A",
                f.Capacity.ToString(),
                f.CurrentOccupancy.ToString(),
                f.Status
            }).ToList();

            Render(headers, rows);
        }

        // Render a list of bookings (flight manifest) as a table
        public static void RenderManifest(IEnumerable<Booking> bookings)
        {
            string[] headers = { "Booking ID", "Passenger", "Passport", "Seat", "Status", "Check-In", "Boarding" };
            var rows = bookings.Select(b => new string[]
            {
                b.BookingID.ToString(),
                b.PassengerName,
                b.PassportNumber,
                b.SeatNumber,
                b.BookingStatus,
                b.CheckInTime?.ToString("HH:mm") ?? "-",
                b.BoardingTime?.ToString("HH:mm") ?? "-"
            }).ToList();

            Render(headers, rows);
        }

        // Render a list of staff users as a table
        public static void RenderStaff(IEnumerable<User> staff)
        {
            string[] headers = { "ID", "Username", "Full Name", "Role", "Email", "Created" };
            var rows = staff.Select(u => new string[]
            {
                u.UserId.ToString(),
                u.UserName,
                u.FullName,
                u.Role,
                u.Email,
                u.CreatedAt.ToString("dd/MM/yyyy")
            }).ToList();

            Render(headers, rows);
        }
    }
}