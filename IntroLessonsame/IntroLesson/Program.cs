// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//Do fundamentals here 

//namespace Demo_App
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int a = 10;
//            int b = a;

//            b = 20;

//            Console.WriteLine(a);
//            Console.WriteLine(b);

//            int[] array1 = new int[] { 1, 2, 3 };
//            int[] array2 = array1;

//            array2[0] = 99;

//            Console.WriteLine($"");
//            Console.WriteLine(array1[0]);
//            Console.WriteLine(array2[0]);

//            Console.WriteLine($"");

//            Console.Write("Enter your fullname?: ");
//            string? fullname = Console.ReadLine();

//            Console.Write("Enter your age: ");
//            int? age = int.Parse(Console.ReadLine());

//            Console.Write("Enter the number of courses you are doing?: ");
//            int? courses = int.Parse(Console.ReadLine());

//            Console.Write("Enter your qualification?: ");

//            string? qualification = Console.ReadLine();

//            string? message = $"Hello, my name is {fullname} and I'm {age} years old. I do {courses} courses. I am {qualification}.";
//            Console.WriteLine(message);

//            Console.Write($"");

//            bool hasLicense = true;
//            bool isInsured = true;

//            Console.Write($"Enter your age: ");
//            int? age1 = int.Parse(Console.ReadLine());

//            if (age1 >= 18 && hasLicense && isInsured)
//            {

//                Console.Write("You can drive");
//                Console.Write($"");
//                Console.Write($"Do you have a car: ");
//                bool? hasCar = bool.Parse(Console.ReadLine());
//                Console.Write("Do you have insurance: ");
//                isInsured = bool.Parse(Console.ReadLine());
//                Console.WriteLine($" Car: " + hasCar);
//                Console.WriteLine($"Insurance: " + isInsured);


//            }
//            else
//            {
//                Console.Write($"You can't drive");
//            }



//        }
//    }
//}

//Do activity here.

// Exercise 1: Student welcome system
//Console.WriteLine("Enter you full name:");
//string full_name = Console.ReadLine();
//if (full_name == null)
//{
//    Console.WriteLine("Please enter your full name");
//}
//else { 
//Console.WriteLine(full_name +"\n");
//}

//Console.WriteLine("Enter Course name:");
//string course_name = Console.ReadLine();
//if (course_name == null) {
//    Console.WriteLine("Please enter your course name:");

//} else { 
//    Console.WriteLine(course_name +"\n");
//}

//Console.WriteLine($"Welcome {full_name}  in {course_name} ");
////DateTime dateTime = DateTime.Now;// returns date and time.
//DateTime dateTime = DateTime.Today; //returns today's date
//Console.WriteLine("Today is " + dateTime);

//// Correction Exercise 1: Student welcome system

//Console.WriteLine("Enter your full name:");
//string full_name = Console.ReadLine();

//if (string.IsNullOrEmpty(full_name))
//{
//    Console.WriteLine("Please enter your full name");
//}
//else
//{
//    Console.WriteLine(full_name + "\n");
//}

//Console.WriteLine("Enter course name:");
//string course_name = Console.ReadLine();

//if (string.IsNullOrEmpty(course_name))
//{
//    Console.WriteLine("Please enter your course name");
//}
//else
//{
//    Console.WriteLine(course_name + "\n");
//}

//Console.WriteLine($"Welcome {full_name} in {course_name}");

//DateTime dateTime = DateTime.Today;
//Console.WriteLine("Today is " + dateTime);


//Execise 2: Mini POS Reciept
//Console.WriteLine("Tuck Shop POS");
//Console.WriteLine("Enter item name:");
//string item_name = Console.ReadLine();
//double price = 0.00;
//if (item_name == "Pepsi")
//{
//    price = 10.00;

//}
//else if (item_name == "Fanta")
//{
//    price = 20.00;
//}
//else {
//    Console.WriteLine("We currently only have stock of Fanta and Pepsi please choose one of the two");
//}
//Console.WriteLine($"Reciept: {item_name}  R{price} \t");

//// Coreection Exercise 2: Mini POS Receipt

//Console.WriteLine("Tuck Shop POS");

//Console.WriteLine("Enter item name:");
//string item_name = Console.ReadLine();

//Console.WriteLine("Enter item price:");
//double price = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Enter quantity:");
//int quantity = Convert.ToInt32(Console.ReadLine());

//double total = price * quantity;

//Console.WriteLine("\n------ RECEIPT ------");
//Console.WriteLine($"Item: {item_name}");
//Console.WriteLine($"Price: R{price}");
//Console.WriteLine($"Quantity: {quantity}");
//Console.WriteLine($"Total: R{total}");
//Console.WriteLine("---------------------");

////Exercise 3: School profile 
//Console.WriteLine("Enter school name:");
//string school_name = Console.ReadLine();
//Console.WriteLine("Enter number of students:");
//int num = Convert.ToInt32(Console.ReadLine());
//double pass_rate = 80;
//Console.WriteLine("Enter student mark:");
//double studentMark = double.Parse(Console.ReadLine());
//Console.WriteLine("Enter school name:");
//string schoolName = Console.ReadLine();
//bool isSchool = false;
//Console.WriteLine("School type,Public/Private");
//string schoolType = Console.ReadLine();

//if (schoolType == "Public") {
//    isSchool = true;

//}
//if (studentMark >= 80)
//{
//    Console.WriteLine("You have reached or surpassed the pass rate. Well done");
//}
//else {
//    Console.WriteLine("You probably passed but rememver there is always room for improvement");
//}

//// Correction Exercise 3: School profile

//Console.WriteLine("Enter school name:");
//string school_name = Console.ReadLine();

//Console.WriteLine("Enter number of students:");
//int numStudents = Convert.ToInt32(Console.ReadLine());

//double pass_rate = 80;

//Console.WriteLine("Enter school type (Public/Private):");
//string schoolType = Console.ReadLine();

//bool isPublicSchool = false;

//if (schoolType == "Public")
//{
//    isPublicSchool = true;
//}

//int studentsPassed = (int)(numStudents * (pass_rate / 100));

//Console.WriteLine("\n--- School Profile ---");
//Console.WriteLine($"School Name: {school_name}");
//Console.WriteLine($"Number of Students: {numStudents}");
//Console.WriteLine($"Pass Rate: {pass_rate}%");
//Console.WriteLine($"Public School: {isPublicSchool}");
//Console.WriteLine($"Students Passed: {studentsPassed}");

//Exercise 4 NEA: Bank Account Simulator
//Console.WriteLine("Enter account holder name:");
//string accountName = Console.ReadLine();

//Console.WriteLine("Enter current balance:");
//double balance = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Enter deposit amount:");
//double deposit = Convert.ToDouble(Console.ReadLine());

//balance = balance + deposit;

//Console.WriteLine($"Balance after deposit: R{balance}");

//Console.WriteLine("Enter withdrawal amount:");
//double withdraw = Convert.ToDouble(Console.ReadLine());

//balance = balance - withdraw;

//Console.WriteLine($"Balance after withdrawal: R{balance}");

//Console.WriteLine($"\nAccount Holder: {accountName}");
//Console.WriteLine($"Final Balance: R{balance}");

//// Exercise 5: Using var

//Console.WriteLine("Enter account holder name:");
//var accountName = Console.ReadLine(); // string

//Console.WriteLine("Enter current balance:");
//var balance = Convert.ToDouble(Console.ReadLine()); // double

//Console.WriteLine("Enter deposit amount:");
//var deposit = Convert.ToDouble(Console.ReadLine()); // double

//balance = balance + deposit;

//Console.WriteLine($"Balance after deposit: R{balance}");

//Console.WriteLine("Enter withdrawal amount:");
//var withdraw = Convert.ToDouble(Console.ReadLine()); // double

//balance = balance - withdraw;

//Console.WriteLine($"Balance after withdrawal: R{balance}");

//Console.WriteLine($"\nAccount Holder: {accountName}");
//Console.WriteLine($"Final Balance: R{balance}");

//Exercise 6: Student ID Card

//Console.WriteLine("Enter full name:");
//string fullName = Console.ReadLine();

//Console.WriteLine("Enter student number:");
//string studentNumber = Console.ReadLine();

//Console.WriteLine("Enter qualification:");
//string qualification = Console.ReadLine();

//Console.WriteLine("\n----------------------");
//Console.WriteLine("STUDENT ID CARD");
//Console.WriteLine("----------------------");
//Console.WriteLine($"Name: {fullName}");
//Console.WriteLine($"Student Number: {studentNumber}");
//Console.WriteLine($"Qualification: {qualification}");
//Console.WriteLine("----------------------");

//Exercise 7: Verbatim Strings

//string companyAddress = @"ABC Technologies
//45 Innovation Street
//Sandton
//Johannesburg
//South Africa";

//Console.WriteLine(companyAddress);

//Exercise 8: Age Verification

//Console.WriteLine("Enter your age:");
//int age = Convert.ToInt32(Console.ReadLine());

//if (age >= 18)
//{
//    Console.WriteLine("You are allowed to register independently.");
//}
//else
//{
//    Console.WriteLine("Parental consent required.");
//}

//Exercise 9: Soccer Eligibility

//Console.WriteLine("Enter your age:");
//int playerAge = Convert.ToInt32(Console.ReadLine());

//Console.WriteLine("Have you paid? (true/false)");
//bool hasPaid = Convert.ToBoolean(Console.ReadLine());

//if (playerAge >= 16 && hasPaid == true)
//{
//    Console.WriteLine("Registration successful. You can play.");
//}
//else
//{
//    Console.WriteLine("Registration failed. Age or payment requirement not met.");
//}

//Exercise 10: Exam Pass Checker

//Console.WriteLine("Enter theory mark:");
//double theoryMark = Convert.ToDouble(Console.ReadLine());

//Console.WriteLine("Enter practical mark:");
//double practicalMark = Convert.ToDouble(Console.ReadLine());

//double average = (theoryMark + practicalMark) / 2;

//if (theoryMark >= 50 && practicalMark >= 50)
//{
//    Console.WriteLine("You passed the exam.");

//    if (average >= 60)
//    {
//        Console.WriteLine("You achieved a distinction.");
//    }
//}
//else
//{
//    Console.WriteLine("You failed the exam.");
//}

//Exercise 11: Electricity Bill Calculator

//Console.WriteLine("Enter number of electricity units used:");
//int units = Convert.ToInt32(Console.ReadLine());

//double pricePerUnit = 0;
//double total = 0;

//if (units <= 100)
//{
//    pricePerUnit = 1.50;
//}
//else if (units <= 300)
//{
//    pricePerUnit = 2.00;
//}
//else
//{
//    pricePerUnit = 3.00;
//}

//total = units * pricePerUnit;

//Console.WriteLine($"Units Used: {units}");
//Console.WriteLine($"Price Per Unit: R{pricePerUnit}");
//Console.WriteLine($"Total Bill: R{total}");

//Exercise 12: Retail Discount System

//Console.WriteLine("Enter purchase amount:");
//double amount = Convert.ToDouble(Console.ReadLine());

//double discount = 0;
//double finalTotal = 0;

//if (amount >= 1000)
//{
//    discount = amount * 0.20;
//}
//else if (amount >= 500)
//{
//    discount = amount * 0.10;
//}

//finalTotal = amount - discount;

//Console.WriteLine($"Original Amount: R{amount}");
//Console.WriteLine($"Discount: R{discount}");
//Console.WriteLine($"Final Total: R{finalTotal}");

//Exercise 13: Simple Login System

//string correctUsername = "admin";
//string correctPassword = "1234";

//Console.WriteLine("Enter username:");
//string username = Console.ReadLine();

//Console.WriteLine("Enter password:");
//string password = Console.ReadLine();

//if (username == correctUsername && password == correctPassword)
//{
//    Console.WriteLine("Login successful. Welcome!");
//}
//else
//{
//    Console.WriteLine("Login failed. Incorrect username or password.");
//}

//Exercise 14: Career Recommendation

//Console.WriteLine("Do you enjoy programming? (true/false)");
//bool likesProgramming = Convert.ToBoolean(Console.ReadLine());

//Console.WriteLine("Do you enjoy helping people solve problems? (true/false)");
//bool likesHelping = Convert.ToBoolean(Console.ReadLine());

//if (likesProgramming == true && likesHelping == true)
//{
//    Console.WriteLine("Recommended Career: Software Engineer");
//}
//else if (likesHelping == true)
//{
//    Console.WriteLine("Recommended Career: Teacher or Consultant");
//}
//else
//{
//    Console.WriteLine("Recommended Career: Explore creative or business fields.");
//}

//Final Mini Project: Student Registration Console App

Console.WriteLine("Student Registration System");

//Capture student details
Console.WriteLine("Enter your full name:");
string fullName = Console.ReadLine();

Console.WriteLine("Enter your age:");
int age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter chosen course:");
string course = Console.ReadLine();

Console.WriteLine("Enter registration fee paid:");
double feePaid = Convert.ToDouble(Console.ReadLine());

//Validation rules
bool ageValid = false;
bool paymentValid = false;

if (age >= 17)
{
    ageValid = true;
}

if (feePaid >= 1500)
{
    paymentValid = true;
}

//Registration result
if (ageValid == true && paymentValid == true)
{
    Console.WriteLine("\nRegistration Successful!");
}
else
{
    Console.WriteLine("\nRegistration Failed.");

    if (ageValid == false)
    {
        Console.WriteLine("Reason: Student must be at least 17 years old.");
    }

    if (paymentValid == false)
    {
        Console.WriteLine("Reason: Registration fee must be at least R1500.");
    }
}

//Summary
Console.WriteLine("\n------ Registration Summary ------");
Console.WriteLine($"Name: {fullName}");
Console.WriteLine($"Age: {age}");
Console.WriteLine($"Course: {course}");
Console.WriteLine($"Fee Paid: R{feePaid}");
Console.WriteLine("----------------------------------");