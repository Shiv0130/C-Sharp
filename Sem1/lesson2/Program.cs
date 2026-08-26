//Switch statements: Traditional
/*Console.WriteLine("Enter a day number(1-7):");
int dayNumber = int.Parse(Console.ReadLine());

string dayName;

switch (dayNumber)
{
    case 1:
        dayName = "Monday";
        break;
    case 2:
        dayName = "Tuesday";
        break;
    case 3:
        dayName = "Wednesday";
        break;
    case 4:
        dayName = "Thursday";
        break;
    case 5:
        dayName = "Friday";
        break;
    case 6:
        dayName = "Saturday";
        break;
    case 7:
        dayName = "Sunday";
        break;
    default:
        dayName = "Invalid day";
        break;
}
Console.WriteLine(dayName);
*/

//Switch statements: C# way
/*Console.WriteLine("Enter a day number(1-7):");
int dayNumber = int.Parse(Console.ReadLine());

string dayName = dayNumber switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    4 => "Thursday",
    5 => "Friday",
    6 => "Saturday",
    7 => "Sunday",
    _ => "Invaild day"
};

Console.WriteLine(dayName);*/

/*int temperature = 25;

string feeling = temperature switch
{
    < 10 => "Freezing cold",
    >= 10 and < 20 => "Chilly",
    >= 20 and < 30 => "Pleasant",
    >= 30 => "Hot",
    _ => "Unknown"  // This arm is actually unreachable
                    // here, but kept for completness
};
Console.WriteLine(feeling);
*/

/*int temperature = 25;

string feeling = temperature switch
{
    < 10 => "Freezing cold",
    >= 10 and < 20 => "Chilly",
    >= 20 and < 30 => "Pleasant",
    >= 30 and < 100 => "Hot",
    _ => "Unknown"
};

Console.WriteLine(feeling);
*/

/*
Console.Write("Enter first boolean (true/false):");
bool a = bool.Parse(Console.ReadLine());
Console.Write("Enter second boolean (true/false):");
bool b = bool.Parse(Console.ReadLine());

string result = (a, b) switch
{
    (true, true) => "Both true",
    (true, false) => "First true, second false",
    (false, true) => "First false, second true",
    (false, false) => "Both false"
};

Console.WriteLine(result);
*/

//Exercise 1: Weekday Activity Planner
/*Console.WriteLine("Enter a day number(1-7):");
int dayNumber = int.Parse(Console.ReadLine());

string dayName = dayNumber switch
{
    1 => "Study C#",
    2 => "Attend coding meetup",
    3 => "Solve practice problems",
    4 => "Work on group project",
    5 => "Review the week",
    6 => "Outdoor Sport",
    7 => "Rest and Plan",
    _ => "Invaild day"
};

Console.WriteLine(dayName); 
*/

//Exercise 2: Simple Calculator

/*using System.Runtime.ConstrainedExecution;
Console.WriteLine("Simple Calculator");
Console.WriteLine("Enter first number:");
double num1 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter second number :");
double num2 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Enter symbol + - / * %:");
string operation = Console.ReadLine();
double result;

switch (operation) {
    case "+": 
        result = num1 + num2;
        Console.WriteLine(result);
        break;

    case "-":
        result = num1 - num2;
        Console.WriteLine(result);
        break;

    case "/":
        result = num1 / num2;
        Console.WriteLine(result);
        break;

        case "*":
        result = num1 * num2;
        Console.WriteLine(result);
        break;

    case "%":
        result = num1 / num2;
        Console.WriteLine(result);
        break;

    default:
        Console.WriteLine("Please enter a valid operator");
        break;
}*/

//Exercise 3:Rating to description
/*Console.WriteLine("Rate this out of 5:");
int rateNumber = int.Parse(Console.ReadLine());

string rateStar = rateNumber switch
{ 1=> "Very poor",
  2=> "Poor",
  3=> "Average",
  4=> "Good",
  5=> "Excellent",
  _=> "Invalid rating"
};
Console.WriteLine(rateStar);
*/

//Exercise 4: Shipping Cost

/*Console.WriteLine("Enter zone:");
double zoneNumber = Convert.ToDouble(Console.ReadLine());
string zone = zoneNumber switch
{
    1 => $"R  {10.00}",
    2 => $"R  {15.50}",
    3 => $"$  {22.72}",
    _ => $"Any other zone"
};
Console.WriteLine(zone);
*/

//continuing off with loops

// Structure of Loops
/*for (intialization;condition,itrator) 
{
// Code to execute
}
*/


//Example 1-5
/*for (int i = 0; i < 5; i++)
{
    Console.WriteLine($" Iteration {i} ");

}*/

//Example Summing numbers Entered by User
/*Console.WriteLine("How many numbers you want to add:");
int count = int.Parse(Console.ReadLine());
Console.WriteLine("Enter number(s):");
int sum = 0;

for (int i = 0; i < count; i++)
{
    int number = int.Parse(Console.ReadLine());
    sum += number;

}
Console.WriteLine($" The sum of {count} numbers are: {sum} ");*/

//Infinite loop (ommitted true)
/*for (; ; ) 
{
    Console.WriteLine("This will run forever unless you break out");
    break; //we'll cover break shortly
}*/

/*foreach (Type element in collection)  
{ 
    //Use element

}*/

/*string message = "Hello";
foreach (char ch in message) 
{
    Console.WriteLine(ch);
}*/

int[] numbers = { 10, 20, 30, 40, 50 };
int total = 0;
foreach (int num in numbers) 
{ 
    total += num;
}
Console.WriteLine($"The sum of the numbers above are:{total}");




