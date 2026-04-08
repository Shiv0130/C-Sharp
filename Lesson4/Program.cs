//int Add(int a, int b) 
//{
//    int sum = a+b;
//    return sum;

//}

////Call the method
//int result = Add(5,3);
//Console.WriteLine(result);


// I matched study guide here but the order ot functions and statements do not matter
//Console.WriteLine("Welcome to the calculator");

//int a = GetNumber("Enter first number:");
//int b = GetNumber("Enter second number:");

//int sum = Add(a, b);
//Console.WriteLine($"Sum: {sum}");

//int product = Multiply(a, b);
//Console.WriteLine($"Product: {product}");

//int GetNumber(string prompt)
//{
//    Console.WriteLine(prompt);
//    string input = Console.ReadLine();
//    return int.Parse(input);
//}

//int Add(int x, int y) => x + y;
//int Multiply(int x, int y) => x * y;

//Exercise 1:Smart Greeting system
//string getGreeting(int hour)
//{
//    if (hour < 12)
//    {
//        return "Good morning";

//    }
//    else if (hour < 18)
//    {
//        return "Good Afternoon";

//    }
//    else 
//    {
//        return "Good Evening";
//    }

//}

// Exercise 2: Day-Bs
//int currentHour = DateTime.Now.Hour;

//string greeting = getGreeting(currentHour);

//Console.WriteLine($"{greeting}");

//string GetDiscount(DayOfWeek day) 
//{
//    return day switch
//    {
//        DayOfWeek.Monday => "10%",
//        DayOfWeek.Tuesday => "20%",
//        DayOfWeek.Saturday => "30%",
//        DayOfWeek.Sunday => "30%",
//         _ => "5%"
//    };
//}
//DayOfWeek today = DateTime.Now.DayOfWeek;
//string discount = GetDiscount(today);
//Console.WriteLine($"{today} is today");
//Console.WriteLine($"{discount} is discount");

//Login attempt checker
//string IsWithinWorkingHours(int hour) 
//{
//    if (hour >= 8 && hour <= 17)
//    {
//        return "Access granted";
//    }
//    else 
//    {
//        return "Access denied";
//    }

//}

//int currentHour = DateTime.Now.Hour;
//string workhours = IsWithinWorkingHours(currentHour);

//Console.WriteLine($" it is now {currentHour} so {workhours}");

//Menu-Based Calculator
//using System;

//double Add(double a, double b) => a + b;
//double Subtract(double a, double b) => a - b;
//double Multiply(double a, double b) => a * b;
//double Divide(double a, double b) => b != 0 ? a / b : double.NaN;

//Console.WriteLine("1. Add");
//Console.WriteLine("2. Subtract");
//Console.WriteLine("3. Multiply");
//Console.WriteLine("4. Divide");
//Console.Write("Choose an option: ");
//string choice = Console.ReadLine();

//Console.Write("Enter first number: ");
//double num1 = double.Parse(Console.ReadLine());

//Console.Write("Enter second number: ");
//double num2 = double.Parse(Console.ReadLine());

//double result = choice switch
//{
//    "1" => Add(num1, num2),
//    "2" => Subtract(num1, num2),
//    "3" => Multiply(num1, num2),
//    "4" => Divide(num1, num2),
//    _ => double.NaN
//};

//if (double.IsNaN(result))
//    Console.WriteLine("Invalid input or division by zero.");
//else
//    Console.WriteLine($"Result: {result}");

//using System;

//bool IsWeekend(DayOfWeek day)
//{
//    if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
//        return true;
//    else
//        return false;
//}

//DayOfWeek today = DateTime.Now.DayOfWeek;

//if (IsWeekend(today))
//    Console.WriteLine("It's the weekend!");
//else
//    Console.WriteLine("It's a weekday.");

//using System;

//bool IsWeekend(DayOfWeek day)
//{
//    if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
//        return true;
//    else
//        return false;
//}

//DayOfWeek today = DateTime.Now.DayOfWeek;

//if (IsWeekend(today))
//    Console.WriteLine("It's the weekend!");
//else
//    Console.WriteLine("It's a weekday.");

//using System;

//bool CanWriteExam(int mark, DayOfWeek day)
//{
//    if (mark >= 50 && day != DayOfWeek.Sunday)
//        return true;
//    else
//        return false;
//}

//Console.Write("Enter your mark: ");
//int mark = int.Parse(Console.ReadLine());

//DayOfWeek today = DateTime.Now.DayOfWeek;

//if (CanWriteExam(mark, today))
//    Console.WriteLine("You are eligible to write the exam.");
//else
//    Console.WriteLine("You are not eligible to write the exam.");

//Time-Based Fee Calculator
using System;

int CalculateFee(int hour)
{
    return hour switch
    {
        >= 0 and <= 6 => 10,
        >= 7 and <= 18 => 20,
        _ => 15
    };
}

int currentHour = DateTime.Now.Hour;
int fee = CalculateFee(currentHour);
Console.WriteLine($"Current hour: {currentHour}. Parking fee: R{fee}");
