//Date arithmetic 
//DateTime today = DateTime.Today;

////Add 10 days 
//DateTime future = today.AddDays(10);

//Console.WriteLine($"10 days from today: {future}");

////Subtract 1 month 
//DateTime past = today.AddMonths(-1);
//Console.WriteLine($" 1 month ago: {past}");

////Add 2 hours and 30 minutes
//DateTime later = today.AddHours(2).AddMinutes(30);

//Console.WriteLine($"Today at 2:30 AM: {later}");

////Difference between 2 dates NB: Returns the timespan

//DateTime start = new DateTime(2025, 1, 1);
//DateTime end = new DateTime(2025, 12, 31);

//TimeSpan differnce = end - start;

//Console.WriteLine($"Days in 2025: {differnce.Days}");

//Exercise 1:
//DateTime moment = DateTime.Now;
//Console.WriteLine(moment);

//Console.WriteLine($"The current moment:{moment}");

//DateOnly date = DateOnly.FromDateTime(DateTime.Now);
//Console.WriteLine(date);

//Correction:
// Exercise 1: Display current date and time components
//using System;
//DateTime now = DateTime.Now; // Get current system date and time//
//// Display the full date and time
// Console.WriteLine($"Current date and time: {now}");

//// Extract and display individual components
// Console.WriteLine($"Year: {now.Year}"); // 4-digit year (e.g., 2026)
// Console.WriteLine($"Month: {now.Month}"); // Month number (1-12)
// Console.WriteLine($"Day: {now.Day}"); // Day of the month (1-31)
// Console.WriteLine($"Hour: {now.Hour}"); // Hour (0-23)
// Console.WriteLine($"Minute: {now.Minute}"); // Minute (0-59)
// Console.WriteLine($"Second: {now.Second}"); // Second (0-59)

// Exercise 2: Create specific DateTime instances
// using System;// Create a DateTime for August 15, 2025 at 9:30 AM
// DateTime specificDateTime = new DateTime(2025, 8, 15, 9, 30, 0);
// Console.WriteLine($"Specific date/time: {specificDateTime}");

//// Create the same date but at midnight (00:00)
// DateTime midnight = new DateTime(2025, 8, 15, 0, 0, 0);
// Console.WriteLine($"Same date at midnight: {midnight}");

// Exercise 3: Add and subtract days
// using System;
// Console.Write("Enter year: ");
// int year = int.Parse(Console.ReadLine());
// Console.Write("Enter month: ");
// int month = int.Parse(Console.ReadLine());
//Console.Write("Enter day: ");
// int day = int.Parse(Console.ReadLine());
//// Create a DateTime from user input (no validation for simplicity; in real code use TryParse)
// DateTime originalDate = new DateTime(year, month, day);
// Console.WriteLine($"Original date: {originalDate:yyyy-MM-dd}");
// Console.Write("How many days to add? ");
// int daysToAdd = int.Parse(Console.ReadLine());

////Add the specified number of days
//DateTime newDate = originalDate.AddDays(daysToAdd);
//Console.WriteLine($"After adding {daysToAdd} days: {newDate:yyyy-MM,dd}");

////Subtract 30 days using negative argument
//DateTime thirtyDaysBefore = originalDate.AddDays(-30);
//Console.WriteLine($"30 days before:{thirtyDaysBefore:yyyy-MM-dd}");

//Exercise 4: Calculate Age in years and days 
//using System;
//Console.WriteLine("Enter birth year:");
//int birthYear = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter birth month:");
//int birthMonth = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter day:");
//int birthDay = int.Parse(Console.ReadLine());

//DateTime birthDate = new DateTime(birthYear,birthMonth,birthDay);
//DateTime today = DateTime.Now;

//Calculate difference as Timespan
//Timespan ageInDays = today - birtDate;
//double totalDays = ageInDays.TotalDays;

//Approximate years (accounting for leap years)
//double ageYears = totalDays / 365.25;

//Console.WriteLine($"Your approximate age:{ageYears:F1} years");
//Console.WriteLine($"You have lived exactly {totalDays:F0} days.");

//Exercise 5: Subscription xpiry using AddMonths
//using System;

//Console.WriteLine("Enter subscription start date (yyyy-mm-dd)");
//DateTime startDate = DateTime.Parse(Console.ReadLine());

////Add 6 months for expiry
//DateTime expiryDate = startDate.AddMonths(6);
////Add 3 more months for reminder (9 months after start)
//DateTime reminderDate = expiryDate.AddMonths(3);

//Console.WriteLine($"Subscription start: {startDate: yyyy-MM-dd}");
//Console.WriteLine($"Expiry day: {expiryDate: yyyy-MM-dd}");
//Console.WriteLine($"Reminder date (3 months after expiry): {reminderDate: yyyy-MM-dd}");

////Note: AddMonths automatically adjusts for month lengths.
//// For example, Jan 31 +1 month = Feb 28 (or 29 in leap year).

// Exercise 6: Determine if a date/time is past, future, or present
//using System;

//Console.Write("Enter a date and time (yyyy-mm-dd hh:mm): ");
//DateTime userDate = DateTime.Parse(Console.ReadLine());

//DateTime now = DateTime.Now;

//if (userDate < now)
//    Console.WriteLine("That moment is in the past.");
//else if (userDate > now)
//    Console.WriteLine("That moment is in the future.");
//else
//    Console.WriteLine("That moment is exactly now (or within a second).");

// Exercise 7: Check if a date is within a range
//using System;

//Console.Write("Enter start date (yyyy-mm-dd): ");
//DateTime start = DateTime.Parse(Console.ReadLine());

//Console.Write("Enter end date (yyyy-mm-dd): ");
//DateTime end = DateTime.Parse(Console.ReadLine());

//if (start > end)
//{
//    (start, end) = (end, start);
//    Console.WriteLine("Swapped start and end so that start <= end.");
//}

//Console.Write("Enter check date (yyyy-mm-dd): ");
//DateTime check = DateTime.Parse(Console.ReadLine());

//if (check >= start && check <= end)
//    Console.WriteLine("The check date is within the range.");
//else
//    Console.WriteLine("The check date is outside the range.");

// Exercise 8: Compare two dates (only date part)
//using System;

//Console.Write("Enter first date (yyyy-mm-dd): ");
//DateTime d1 = DateTime.Parse(Console.ReadLine());

//Console.Write("Enter second date (yyyy-mm-dd): ");
//DateTime d2 = DateTime.Parse(Console.ReadLine());

//if (d1.Date < d2.Date)
//    Console.WriteLine($"{d1:yyyy-MM-dd} is earlier than {d2:yyyy-MM-dd}");
//else if (d1.Date > d2.Date)
//    Console.WriteLine($"{d2:yyyy-MM-dd} is earlier than {d1:yyyy-MM-dd}");
//else
//    Console.WriteLine("Both dates are the same.");

// Exercise 9: Display date/time in various formats
//using System;

//DateTime now = DateTime.Now;

//Console.WriteLine($"Long date (D): {now:D}");
//Console.WriteLine($"Short date (d): {now:d}");
//Console.WriteLine($"Long time (T): {now:T}");
//Console.WriteLine($"Short time (t): {now:t}");
//Console.WriteLine($"Full date/time (f): {now:f}");

//Console.WriteLine($"Custom (dd/MM/yyyy HH:mm): {now:dd/MM/yyyy HH:mm}");
//Console.WriteLine($"Custom with weekday and month: {now:dddd, MMMM dd, yyyy}");

// Exercise 10: Parse exact format with error handling
//using System;
//using System.Globalization;

//DateTime date;
//bool valid;

//do
//{
//    Console.Write("Enter a date (yyyy-mm-dd): ");
//    string input = Console.ReadLine();

//    valid = DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

//    if (!valid)
//    {
//        Console.WriteLine("Invalid format. Please use yyyy-mm-dd (e.g., 2026-03-18).");
//    }
//} while (!valid);

//Console.WriteLine($"You entered: {date:dd MMMM yyyy}");

// Exercise 11: Age calculation using DateOnly (no time part)
//using System;

//Console.Write("Enter birth year: ");
//int birthYear = int.Parse(Console.ReadLine());

//Console.Write("Enter birth month: ");
//int birthMonth = int.Parse(Console.ReadLine());

//Console.Write("Enter birth day: ");
//int birthDay = int.Parse(Console.ReadLine());

//DateOnly birth = new DateOnly(birthYear, birthMonth, birthDay);
//DateOnly today = DateOnly.FromDateTime(DateTime.Now);

//int age = today.Year - birth.Year;

//if (today.Month < birth.Month || (today.Month == birth.Month && today.Day < birth.Day))
//    age--;

//Console.WriteLine($"You are {age} years old.");

// Exercise 12: Compare a user-provided time with a fixed alarm time
//using System;

//TimeOnly alarm = new TimeOnly(7, 30);

//Console.Write("Enter hour (0-23): ");
//int hour = int.Parse(Console.ReadLine());

//Console.Write("Enter minute (0-59): ");
//int minute = int.Parse(Console.ReadLine());

//TimeOnly userTime = new TimeOnly(hour, minute);

//if (userTime < alarm)
//    Console.WriteLine($"{userTime} is before the alarm at {alarm}");
//else if (userTime > alarm)
//    Console.WriteLine($"{userTime} is after the alarm at {alarm}");
//else
//    Console.WriteLine("That's exactly the alarm time!");

// Exercise 13: Combine DateOnly and TimeOnly to get a DateTime
using System;

Console.Write("Enter year: ");
int year = int.Parse(Console.ReadLine());

Console.Write("Enter month: ");
int month = int.Parse(Console.ReadLine());

Console.Write("Enter day: ");
int day = int.Parse(Console.ReadLine());

Console.Write("Enter hour (0-23): ");
int hour = int.Parse(Console.ReadLine());

Console.Write("Enter minute (0-59): ");
int minute = int.Parse(Console.ReadLine());

DateOnly datePart = new DateOnly(year, month, day);
TimeOnly timePart = new TimeOnly(hour, minute);

DateTime combined = datePart.ToDateTime(timePart);
Console.WriteLine($"Combined DateTime: {combined:yyyy-MM-dd HH:mm:ss}");