using SkyFlow;

const string CONNECTION_STRING =
    "Server=(localdb)\\MSSQLLocalDB;Database=SkyFlowDB;Trusted_Connection=True;TrustServerCertificate=True;";

// Build the repository (abstraction – UI talks to interface only)
IDataRepository repo = new SqlRepository(CONNECTION_STRING);


//  APPLICATION LOOP

bool running = true;

Console.Clear();
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("       SKYFLOW TERMINAL MANAGER               ");
Console.WriteLine("       Richfield Graduate Institute            ");
Console.ResetColor();

while (running)
{
    // - Phase 1: Authentication 
    User? currentUser = null;

    while (currentUser == null)
    {
        Console.WriteLine("\nSkyFlow > Please enter your username:");
        Console.Write("Username: ");
        string username = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Password: ");
        string password = ReadPasswordMasked(); // hides input with *

        currentUser = repo.Login(username, password);

        if (currentUser == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid credentials. Please try again.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAuthentication successful. Role: {currentUser.Role}");
            Console.ResetColor();
        }
    }

    // - Phase 2: Role-Specific Dashboard Loop 
    
    bool loggedIn = true;

    while (loggedIn)
    {
        currentUser.DisplayWelcome();
        currentUser.DisplayDashboard();

        Console.Write("\nSkyFlow > Enter choice: ");
        string choice = Console.ReadLine()?.Trim() ?? "";

        // Route to the right workflow based on actual object type
        if (currentUser is Admin admin)
        {
            loggedIn = HandleAdminChoice(choice, repo);
        }
        else if (currentUser is GateAgent agent)
        {
            loggedIn = HandleGateAgentChoice(choice, repo);
        }

        if (loggedIn)
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Ask if another user wants to log in or exit
    Console.Write("\nReturn to login? (Y/N): ");
    string cont = Console.ReadLine()?.Trim().ToUpper() ?? "N";
    if (cont != "Y") running = false;
}

Console.WriteLine("\nSkyFlow Terminal closed. Goodbye!");



//  ADMIN WORKFLOW HANDLERS

static bool HandleAdminChoice(string choice, IDataRepository repo)
{
    switch (choice)
    {
        case "1": ManageFlights(repo); break;
        case "2": SystemOverview(repo); break;
        case "3": ManageStaff(repo); break;
        case "4": return false; // logout
        default:
            Console.WriteLine("Invalid option. Please choose 1-4.");
            break;
    }
    return true;
}

static void ManageFlights(IDataRepository repo)
{
    Console.Clear();
    
    Console.WriteLine("        MANAGE FLIGHTS        ");
    Console.WriteLine("  1. View All Flights         ");
    Console.WriteLine("  2. Add New Flight           ");
    Console.WriteLine("  3. Update Flight Status     ");
    Console.WriteLine("  4. Delete Flight            ");
    Console.WriteLine("  5. Back                     ");
    Console.Write("Choice: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1":
            // View all flights using TableRenderer (15 mark requirement)
            var flights = repo.GetAllFlights().ToList();
            Console.WriteLine("\n── ALL FLIGHTS ──");
            TableRenderer.RenderFlights(flights);
            break;

        case "2":
            // Add new flight
            Console.Write("Flight Number (e.g. SF106): ");
            string flightNum = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Origin: ");
            string origin = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Destination: ");
            string destination = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Departure (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime departure))
            {
                Console.WriteLine("Invalid date format.");
                break;
            }

            Console.Write("Capacity: ");
            if (!int.TryParse(Console.ReadLine(), out int capacity))
            {
                Console.WriteLine("Invalid capacity.");
                break;
            }

            var newFlight = new Flight
            {
                FlightNumber = flightNum,
                Origin = origin,
                Destination = destination,
                DepartureTime = departure,
                Capacity = capacity
            };
            // Status defaults to Scheduled (private field default in Flight class)

            int newId = repo.CreateFlight(newFlight);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ Flight created with ID: {newId}");
            Console.ResetColor();
            break;

        case "3":
            // Update flight status
            Console.Write("Enter Flight ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int fId))
            {
                Console.WriteLine("Invalid ID.");
                break;
            }

            var flt = repo.GetFlightById(fId);
            if (flt == null) { Console.WriteLine("Flight not found."); break; }

            Console.WriteLine($"Current status: {flt.Status}");
            Console.WriteLine("New status options: Scheduled | Boarding | Departed");
            Console.Write("Enter new status: ");
            string newStatus = Console.ReadLine()?.Trim() ?? "";

            bool updated = repo.UpdateFlightStatus(fId, newStatus);
            Console.ForegroundColor = updated ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(updated ? "✅ Status updated." : "❌ Update failed.");
            Console.ResetColor();
            break;

        case "4":
            // Delete flight
            Console.Write("Enter Flight ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int delId))
            {
                Console.WriteLine("Invalid ID.");
                break;
            }

            Console.Write("Are you sure? (Y/N): ");
            if (Console.ReadLine()?.Trim().ToUpper() == "Y")
            {
                bool deleted = repo.DeleteFlight(delId);
                Console.ForegroundColor = deleted ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(deleted ? "✅ Flight deleted." : "❌ Delete failed.");
                Console.ResetColor();
            }
            break;
    }
}

static void SystemOverview(IDataRepository repo)
{
    Console.Clear();
    Console.WriteLine("── SYSTEM OVERVIEW – ALL FLIGHTS ──\n");
    var flights = repo.GetAllFlights().ToList();
    TableRenderer.RenderFlights(flights);
}

static void ManageStaff(IDataRepository repo)
{
    Console.Clear();
    Console.WriteLine("        MANAGE STAFF          ");
    Console.WriteLine("  1. View All Staff           ");
    Console.WriteLine("  2. Add New Staff Member     ");
    Console.WriteLine("  3. Remove Staff Member      ");
    Console.WriteLine("  4. Back                     ");
    Console.Write("Choice: ");

    switch (Console.ReadLine()?.Trim())
    {
        case "1":
            var staff = repo.GetAllStaff();
            TableRenderer.RenderStaff(staff);
            break;

        case "2":
            Console.Write("Username: ");
            string uName = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Password: ");
            string pWord = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Role (Admin/GateAgent): ");
            string role = Console.ReadLine()?.Trim() ?? "GateAgent";

            Console.Write("First Name: ");
            string fName = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Last Name: ");
            string lName = Console.ReadLine()?.Trim() ?? "";

            Console.Write("Email: ");
            string email = Console.ReadLine()?.Trim() ?? "";

            User newUser = role == "Admin" ? new Admin() : new GateAgent();
            newUser.UserName = uName;
            newUser.FirstName = fName;
            newUser.LastName = lName;
            newUser.Email = email;

            int staffId = repo.CreateStaff(newUser, pWord);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✅ Staff member created with ID: {staffId}");
            Console.ResetColor();
            break;

        case "3":
            Console.Write("Enter Staff User ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int removeId))
            {
                Console.WriteLine("Invalid ID.");
                break;
            }
            Console.Write("Are you sure? (Y/N): ");
            if (Console.ReadLine()?.Trim().ToUpper() == "Y")
            {
                bool removed = repo.DeleteStaff(removeId);
                Console.ForegroundColor = removed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(removed ? "✅ Staff removed." : "❌ Remove failed.");
                Console.ResetColor();
            }
            break;
    }
}



//  GATE AGENT WORKFLOW HANDLERS

static bool HandleGateAgentChoice(string choice, IDataRepository repo)
{
    switch (choice)
    {
        case "1": FlightManifest(repo); break;
        case "2": PassengerCheckIn(repo); break;
        case "3": UpdateFlightStatus(repo); break;
        case "4": return false; // logout
        default:
            Console.WriteLine("Invalid option. Please choose 1-4.");
            break;
    }
    return true;
}

static void FlightManifest(IDataRepository repo)
{
    Console.Clear();
    Console.WriteLine("── FLIGHT MANIFEST ──");

    // First show all flights so agent can pick one
    var flights = repo.GetAllFlights().ToList();
    TableRenderer.RenderFlights(flights);

    Console.Write("Gate Agent > Enter Flight ID to view manifest: ");
    if (!int.TryParse(Console.ReadLine(), out int flightId))
    {
        Console.WriteLine("Invalid input.");
        return;
    }

    var bookings = repo.GetBookingsByFlight(flightId).ToList();
    Console.WriteLine($"\n── MANIFEST FOR FLIGHT ID {flightId} ──");
    TableRenderer.RenderManifest(bookings);
}

static void PassengerCheckIn(IDataRepository repo)
{
    Console.Clear();
    Console.WriteLine("── PASSENGER CHECK-IN ──");

    // Show flights
    var flights = repo.GetAllFlights().ToList();
    TableRenderer.RenderFlights(flights);

    Console.Write("Gate Agent > Enter Flight ID: ");
    if (!int.TryParse(Console.ReadLine(), out int flightId))
    {
        Console.WriteLine("Invalid Flight ID.");
        return;
    }

    // Check the flight exists and is not departed
    var flight = repo.GetFlightById(flightId);
    if (flight == null)
    {
        Console.WriteLine("Flight not found.");
        return;
    }
    if (flight.Status == "Departed")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Cannot check in – flight has already departed.");
        Console.ResetColor();
        return;
    }
    if (flight.IsFull)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Cannot check in – flight is full.");
        Console.ResetColor();
        return;
    }

    Console.Write("Gate Agent > Enter Passport Number: ");
    string passport = Console.ReadLine()?.Trim().ToUpper() ?? "";

    var booking = repo.GetBookingByPassportAndFlight(passport, flightId);
    if (booking == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ No booking found for passport {passport} on this flight.");
        Console.ResetColor();
        return;
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"\nPassenger found: {booking.PassengerName} (Seat {booking.SeatNumber})");
    Console.WriteLine($"Current status: {booking.BookingStatus}");
    Console.ResetColor();

    // Validate business rule – can only check in if Confirmed
    if (booking.BookingStatus != "Confirmed")
    {
        Console.WriteLine($"Passenger is already {booking.BookingStatus}. No update needed.");
        return;
    }

    Console.Write("Update status to CheckedIn? (Y/N): ");
    if (Console.ReadLine()?.Trim().ToUpper() == "Y")
    {
        bool ok = repo.UpdateBookingStatus(booking.BookingID, "CheckedIn", DateTime.Now);
        Console.ForegroundColor = ok ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(ok ? "✅ Status updated to CheckedIn successfully." : "❌ Update failed.");
        Console.ResetColor();
    }
}

static void UpdateFlightStatus(IDataRepository repo)
{
    Console.Clear();
    Console.WriteLine("── UPDATE FLIGHT STATUS / BOARDING GATE ──");

    var flights = repo.GetAllFlights().ToList();
    TableRenderer.RenderFlights(flights);

    Console.Write("Gate Agent > Enter Flight ID: ");
    if (!int.TryParse(Console.ReadLine(), out int flightId))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    var flight = repo.GetFlightById(flightId);
    if (flight == null) { Console.WriteLine("Flight not found."); return; }

    Console.WriteLine($"Current status: {flight.Status}");
    Console.WriteLine("1. Set to Boarding");
    Console.WriteLine("2. Set to Departed");
    Console.Write("Choice: ");

    string statusChoice = Console.ReadLine()?.Trim() ?? "";
    string newStatus = statusChoice switch
    {
        "1" => "Boarding",
        "2" => "Departed",
        _ => ""
    };

    if (string.IsNullOrEmpty(newStatus))
    {
        Console.WriteLine("Invalid choice.");
        return;
    }

    // Apply business rule via Flight model methods
    bool validTransition = newStatus == "Boarding"
        ? flight.SetBoarding()
        : flight.DepartFlight();

    if (!validTransition) return; // Flight model already printed the error

    bool updated = repo.UpdateFlightStatus(flightId, newStatus);
    Console.ForegroundColor = updated ? ConsoleColor.Green : ConsoleColor.Red;
    Console.WriteLine(updated
        ? $"✅ Flight {flight.FlightNumber} status updated to {newStatus}."
        : "❌ Update failed.");
    Console.ResetColor();
}



//  HELPER: Read password without showing characters

static string ReadPasswordMasked()
{
    string password = "";
    ConsoleKeyInfo key;

    do
    {
        key = Console.ReadKey(intercept: true); // don't print the key
        if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
        {
            password += key.KeyChar;
            Console.Write("*"); // show * instead of actual character
        }
        else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
        {
            password = password[..^1]; // remove last character
            Console.Write("\b \b");    // erase the * on screen
        }
    } while (key.Key != ConsoleKey.Enter);

    Console.WriteLine();
    return password;
}