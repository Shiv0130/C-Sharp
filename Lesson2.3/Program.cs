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

/*int[] numbers = { 10, 20, 30, 40, 50 };
int total = 0;
foreach (int num in numbers)
{
    total += num;
}
Console.WriteLine($"The sum of the numbers above are:{total}");*/

/*while (condition) 
{
    //code to repeat
}*/

//Reading input until a number is valid
/* Console.WriteLine("Enter a positive number");
 int number = int.Parse(Console.ReadLine());

 while (number <= 0) 
 {
     Console.WriteLine("That's not a positve. Try again");
     Console.WriteLine("Enter a positive number:");
     number = int.Parse(Console.ReadLine());
 }
 Console.WriteLine($"Thank you. You entered {number}");
*/

//Countdown Using While
/*int counter = 5;
while (counter > 0) 
{
    Console.WriteLine(counter);
    counter--;
}
Console.WriteLine("Blast off!");
*/

/*do
{
    //Code to repeat
} while (condtion);*/

//string choice;

//do
//{
//    Console.WriteLine("\nMenu:");
//    Console.WriteLine("1. Say Hello");
//    Console.WriteLine("2. Say Goodbye");
//    Console.WriteLine("3. Exit");
//    Console.WriteLine("Choose an option:");

//    choice = Console.ReadLine();
//    if (choice == "1")
//    {
//        Console.WriteLine("Hello");
//    }
//    else if (choice == "2")
//    {
//        Console.WriteLine("Goodbye");
//    }
//    else if (choice == "3")
//    {
//        Console.WriteLine("Exiting...");
//    }
//    else
//    {
//        Console.WriteLine("Invalid option. Try again");
//    }
//}
//while (choice != "3");

//Code runs atleast one time
//int number;

//do 
//{
//    Console.WriteLine("Enter a positive number:");
//    number = int.Parse(Console.ReadLine());

//    if (number <= 0) 
//    {
//        Console.WriteLine("That's not a postive. Please Try again");
//    }

//} while (number <= 0);

//Console.WriteLine($"You have entered number{number}");

//Break to Early exit
//for (int i = 1; i<=10; i++)
//{
//    if (i == 5) 
//    {
//        Console.WriteLine("Breaking at 5");
//        break;
//    }
//    Console.WriteLine();
//}
////Output: 1,2,3,4 (then "Breaking at 5")

//Continue to skip iteration
//for (int i = 1; i <= 5; i++)
//{
//    if (i == 3)
//    {
//        Console.WriteLine("Breaking at 5");
//        continue;
//    }
//    Console.WriteLine();
//}
////Output: 1,2, "skipping 3" ,4,5 (then "Breaking at 5")

//Using break in a while loop
//int sum = 0;
//while (true) // Infinite loop, but we'll break inside
//{
//    Console.WriteLine("Enter a number (0 to stop):");
//    int number = int.Parse(Console.ReadLine());

//    if (number == 0 ) 
//    {
//        break; //Exit the loop
//    }

//    sum += number;
//    Console.WriteLine($"Total sum: {sum}");

//}

//Loops exercises

//1. My attempt
//Console.WriteLine("Enter number:");
//int number = int.Parse(Console.ReadLine());

//for (int i = 1; i <= 10; i++)
//{
//    number = i * number;
//    Console.WriteLine(number);

//}

//Correction
//Console.WriteLine("Enter number:");
//int number = int.Parse(Console.ReadLine());
//for(int i =1; i<= 10;i++) 
//{
//    int result = number * i;
//    Console.WriteLine(result);
//}

//Sum of even numbers my attempt
//Console.WriteLine("How many numbers you want to add:");
//int N = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter +ve number(s) -ve number to break:");
//int sum = 0;

//for (int i = 0; i < N; i++)
//{
//    if (N<0) 
//    {
//        Console.WriteLine("You entered a -ve number");
//        break;
//    }
//    else if (i % 2 == 0)
//    {
//        int number = int.Parse(Console.ReadLine());
//        sum += number;
//    }


//}
//Console.WriteLine($" The sum of even numbers with {N} numbers are: {sum} ");

/*This is the prompt:As an IT expert help me with this code: Exercise 6: Sum of Even Numbers
Scenario: Ask the user for a positive integer N. Use a for loop to calculate the sum of all
even numbers from 1 to N. Here is my attempt: Console.WriteLine("How many numbers you want to add:");
int N = int.Parse(Console.ReadLine());
Console.WriteLine("Enter +ve number(s) -ve number to break:");
int sum = 0;

for (int i = 0; i < N; i++)
{
    if (N<0) 
    {
        Console.WriteLine("You entered a -ve number");
        break;
    }
    else if (i % 2 == 0)
    {
        int number = int.Parse(Console.ReadLine());
        sum += number;
    }


}
Console.WriteLine($" The sum of even numbers with {N} numbers are: {sum} "); Please correct and tell me where i went off*/

//Sum of even numbers correct version
//Console.WriteLine("Enter a positive integer:");
//int N = int.Parse(Console.ReadLine());

//if (N < 0)
//{
//    Console.WriteLine("Please enter a positive number.");
//    return;
//}

//int sum = 0;

//for (int i = 1; i <= N; i++)
//{
//    if (i % 2 == 0)
//    {
//        sum += i;
//    }
//}

//Console.WriteLine($"The sum of even numbers from 1 to {N} is: {sum}");

//Factorial 

//Console.WriteLine("=== Factorial Calculator ===");

//// Prompt user for a non-negative integer
//Console.Write("Enter a non-negative integer: ");
//string input = Console.ReadLine();

//// Validate input
//if (!int.TryParse(input, out int number) || number < 0)
//{
//    Console.WriteLine("Invalid input. Please enter a non-negative integer.");
//    return;
//}

//// Factorial calculation using for loop
//long factorial = 1; // Use long to handle larger results
//for (int i = 1; i <= number; i++)
//{
//    factorial *= i;
//}

//// Display result
//Console.WriteLine($"{number}! = {factorial}");

//Array Average

//int[] Nums = { 12, 45, 67, 23, 9 };
//int total = 0;

//foreach (int Num in Nums)
//{
//    total += Num;
//}
//Console.WriteLine(total);

//Word character counter
//Console.WriteLine("Enter sentence:");
//int count = 0;
//string sentence = Console.ReadLine();

//foreach (char syllable in sentence)
//{
//    //Console.WriteLine(syllable);

//    if (syllable == 'A')
//    {
//        count++;
//    }
//    else if (syllable == 'E') 
//    {
//        count++;
//    }
//    else if(syllable == 'I') 
//    {
//        count++;
//    }
//    else if (syllable == 'O')
//    {
//        count++;
//    }
//    else if (syllable == 'U')
//    {
//        count++;
//    }
//    Console.WriteLine($"The number of vowels are:{count}");
//}

//Correction word character counter
//Console.WriteLine("Enter sentence:");
//string sentence = Console.ReadLine();

//int count = 0;

//foreach (char syllable in sentence)
//{
//    /*char ch = char.ToLower(syllable);

//    if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
//    {
//        count++;
//    }*/

//    if ("aeiou".Contains(char.ToLower(syllable)))
//    {
//        count++;
//    }
//}

//Console.WriteLine($"The number of vowels are: {count}");

//Guess the number
//Random random = new Random();
////int randomNumber = random.Next();
////Console.WriteLine(randomNumber);
//// Generates a number between 0 and 99
////int randomNumberLessThan100 = random.Next(100);
////Console.WriteLine(randomNumberLessThan100); 

//Console.WriteLine("Enter number(0-100):");
//double num = double.Parse(Console.ReadLine());

//double randomNumber = random.NextDouble();
//while (num!=randomNumber)
//{
//    Console.WriteLine("Enter number(0-100):");
//     num = double.Parse(Console.ReadLine());

//    if (num == randomNumber)
//    {
//        Console.WriteLine("Congratulations you guessed it right");
//    }
//    else if (num < randomNumber)
//    {
//        Console.WriteLine("Too low");
//    }
//    else if (num > randomNumber)
//    {
//        Console.WriteLine("Too high");
//    }
//    else 
//    {
//        Console.WriteLine("Enter a valid numver ");
//    }

//}

//Correction Guess the number: Please keep the number in scope of 1-100 strictly // Correct the correction
//Random random = new Random();
//int randomNumber = random.Next(1, 101);

//Console.WriteLine("Enter number (1-100):");
//int num = int.Parse(Console.ReadLine());

//while (num != randomNumber)
//{
//    if (num < 1 || num > 100)
//    {
//        Console.WriteLine("Please enter a number between 1 and 100.");
//    }
//    else if (num < randomNumber)
//    {
//        Console.WriteLine("Too low");
//    }
//    else
//    {
//        Console.WriteLine("Too high");
//    }

//    Console.WriteLine("Enter number (1-100):");
//    num = int.Parse(Console.ReadLine());
//}

//Console.WriteLine("🎉 Congratulations you guessed it right");

//Digit Sum Calculator (while loop)
//Console.WriteLine("Enter a positive integer:");
//int number = int.Parse(Console.ReadLine());

//int sum = 0;

//while (number > 0)
//{
//    int digit = number % 10; // get last digit
//    sum += digit;            // add to sum
//    number /= 10;            // remove last digit
//}

//Console.WriteLine("Sum of digits = " + sum);

//Menu Driven Program (do-while)
//int choice;

//do
//{
//    Console.WriteLine("\n--- MENU ---");
//    Console.WriteLine("1. Say Hello");
//    Console.WriteLine("2. Display Current Time");
//    Console.WriteLine("3. Exit");
//    Console.Write("Enter choice: ");

//    choice = int.Parse(Console.ReadLine());

//    switch (choice)
//    {
//        case 1:
//            Console.WriteLine("Hello 👋");
//            break;

//        case 2:
//            Console.WriteLine("Current Time: " + DateTime.Now);
//            break;

//        case 3:
//            Console.WriteLine("Exiting program...");
//            break;

//        default:
//            Console.WriteLine("Invalid choice!");
//            break;
//    }

//} while (choice != 3);

//Password Checker (do-while)
//string correctPassword = "csharp123";
//string input;
//int attempts = 0;

//do
//{
//    Console.Write("Enter password: ");
//    input = Console.ReadLine();
//    attempts++;

//    if (input == correctPassword)
//    {
//        Console.WriteLine("Access granted ✅");
//        break;
//    }
//    else
//    {
//        Console.WriteLine("Incorrect password ❌");
//    }

//} while (attempts < 3);

//if (attempts == 3 && input != correctPassword)
//{
//    Console.WriteLine("🚫 Too many attempts. You are locked out.");
//}

//Mini Project: Student Exam Analyzer
        List<string> results = new List<string>();
        string choice;

        do
        {
            Console.Write("\nEnter student name: ");
            string name = Console.ReadLine();

            int total = 0;

            // Input 3 test scores
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"Enter score {i}: ");
                int score = int.Parse(Console.ReadLine());
                total += score;
            }

            double average = total / 3.0;

            // Assign grade
            string grade;

            switch (average)
            {
                case >= 75:
                    grade = "A";
                    break;
                case >= 60:
                    grade = "B";
                    break;
                case >= 50:
                    grade = "C";
                    break;
                default:
                    grade = "F";
                    break;
            }

            string result = $"Name: {name}, Average: {average:F2}, Grade: {grade}";
            results.Add(result);

            Console.Write("\nDo you want to enter another student? (Y/N): ");
            choice = Console.ReadLine().ToUpper();

        } while (choice == "Y");

        // Display summary
        Console.WriteLine("\n--- Summary ---");
        foreach (string res in results)
        {
            Console.WriteLine(res);
        }

