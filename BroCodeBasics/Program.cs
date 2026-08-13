
//using System;

//namespace BroCodeBasics
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("I like pizza");
//            Console.WriteLine("It's really good pizza");
//            Console.Beep(); // cool feature
//        }
//    }
//}

//using System;
//namespace BroCodeBasics
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int x; //declaration
//            x = 123; // intialization

//            int y = 321; //declaration + intialization
//            int x = x + y;

//            double height = 300.5; // decimal number;
//            bool alive = true; // values that are only true or false;

//            char symbol = '@';
//            String name = "Bro";

//            //Console.WriteLine(x);
//            //Console.WriteLine(y);
//            //Console.WriteLine(z);

//            Console.WriteLine("Hello " + name);
//            Console.WriteLine("Your age is " + age);
//            Console.WriteLine("Your height is " + height + "cm");
//            Console.WriteLine("Are you alive?" + alive);
//            Console.WriteLine("Your symbol is:" + symbol);

//            String userName = symbol + name;


//            Console.WriteLine("Your username");
//        }
//    }
//}

////Correction
//using System;
//namespace BroCodeBasics
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int x; //declaration
//            x = 123; // intialization

//            int y = 321; //declaration + intialization
//            int z = x + y;
//            int age = 21; // whole integer;

//            double height = 300.5; // decimal number;
//            bool alive = true; // values that are only true or false;

//            char symbol = '@';
//            String name = "Bro";

//            //Console.WriteLine(x);
//            //Console.WriteLine(y);
//            //Console.WriteLine(z);

//            Console.WriteLine("Hello " + name);
//            Console.WriteLine("Your age is " + age);
//            Console.WriteLine("Your height is " + height + "cm");
//            Console.WriteLine("Are you alive?" + alive);
//            Console.WriteLine("Your symbol is:" + symbol);

//            String userName = symbol + name;


//            Console.WriteLine("Your username" + userName);
//        }
//    }
//}

//using System;

//namespace BroCodeBasics
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //constants = immutable values which are known at compile time
//            //             and do not change for the life of the program

//            const double pi = 3,14159;

//            Console.WriteLine(pi);

//        }
//    }
//}

//Correction

//constants = immutable values which are known at compile time
//             and do not change for the life of the program

//const double pi = 3.14159;

//Console.WriteLine(pi);

//type casting = Converting a value to a different data type
//                Usful when we accept user input (string)
//                 Different data types can do different things

//double a = 3.14;
//int b = Convert.ToInt32(a);

//Console.WriteLine(b);

//int e = 321;
//String f = Convert.ToString(e);

//Full code
// type casting = Converting a value to a different data type
//                Useful when we accept user input (string)
//                Different data types can do different things

//double a = 3.14;
//int b = Convert.ToInt32(a);

//int c = 123;
//double d = Convert.ToDouble(c);

//int e = 321;
//String f = Convert.ToString(e);

//String g = "$";
//char h = Convert.ToChar(g);

//String i = "true";
//bool j = Convert.ToBoolean(i);

//Console.WriteLine(b.GetType());
//Console.WriteLine(d.GetType());
//Console.WriteLine(f.GetType());
//Console.WriteLine(h.GetType());
//Console.WriteLine(j.GetType());



// Provided everything is there JUST CODE!

//Console.WriteLine("What's your name?");
//String name = Console.ReadLine();

//Console.WriteLine("What is your age?");
//int age = IntToParse(Console.ReadLine());

//Console.WriteLine("Hello " + name);
//Console.WriteLine("Your age is: " + age);

//Correction


//Console.WriteLine("What's your name?");
//String name = Console.ReadLine();

//Console.WriteLine("What is your age?");
//int age = int.Parse(Console.ReadLine());

//Console.WriteLine("Hello " + name);
//Console.WriteLine("Your age is: " + age);



// if statement =  a basic form of decision making
//Console.WriteLine("Please enter your age: ");
//int age = Int.Parse(Console.ReadLine());
//if (age > 18)
//{
//    Console.WriteLine("You are signed up");
//}

//else if (age < 0)
//{
//    Console.WriteLine("You ar too young");
//}

//else if (age > 100)
//{
//    Console.WriteLine("You are too old");
//}

//else
//{
//    Console.WriteLine("You must be 18+ to sign up");
//}

//Correction
// if statement =  a basic form of decision making

//Console.WriteLine("Please enter your age: ");
//int age = int.Parse(Console.ReadLine());

//if (age > 18)
//{
//    Console.WriteLine("You are signed up");
//}

//else if (age < 0)
//{
//    Console.WriteLine("You ar too young");
//}

//else if (age > 100)
//{
//    Console.WriteLine("You are too old");
//}

//else
//{
//    Console.WriteLine("You must be 18+ to sign up");
//}

//Console.WriteLine("Please enter your name: ");
//String name = Console.ReadLine();
//if (name == "")
//{
//    Console.WriteLine("You did not enter your name");
//}
//else
//{
//    Console.WriteLine("Hello" + name);
//}

// or 
//Console.WriteLine("Please enter your name: ");
//String name = Console.ReadLine();
//if (name != "")
//{
//    Console.WriteLine("Hello" + name);
//}
//else
//{
//    Console.WriteLine("You did not enter your name");
//}

//Console.WriteLine("What day is it today?");
//String day = Console.ReadLine();

//if (day == "Monday")
//{
//    Console.WriteLine("It's Monday!");
//}
//else if (day == "Tuesday")
//{
//    Console.WriteLine("It's Tuesday!");
//}
//else if (day == "Wednesday")
//{
//    Console.WriteLine("It's Wednesday!");
//}
//else if (day == "Thursday")
//{
//    Console.WriteLine("It's Thursday!");
//}
//else if (day == "Friday")
//{
//    Console.WriteLine("It's Friday!");
//}
//else if (day == "Saturday")
//{
//    Console.WriteLine("It's Saturday!");
//}
//else if (day == "Sunday")
//{
//    Console.WriteLine("It's Sunday!");
//}
//else
//{
//    Console.WriteLine(day + " is not a day!");
//}

//switch = an efficient alternative to many else if statements

//Console.WriteLine("What day is it today?");
//String day = Console.ReadLine();

//switch (day)
//{
//    case "Monday":
//        Console.WriteLine("It's Monday!");
//    break;
//    case "Tuesday":
//        Console.WriteLine("It's Tuesday");
//        break;
//    case "Wednesday":
//        Console.WriteLine("It's Wednesday");
//        break;
//    case "Thursday":
//        Console.WriteLine("It's Thursday");
//        break;
//    case "Friday":
//        Console.WriteLine("It's Friday");
//        break;
//    case "Saturday":
//        Console.WriteLine("It's Saturday");
//        break;
//    case "Sunday":
//        Console.WriteLine("It's Sunday");
//        break;
//    default:
//        Console.WriteLine($"{day} is not a valid day of the week");
//        break;
//}

// logical operators = Can be used to check if more than 1 condition is true/false

//&& (AND)
// || (OR)


//Console.WriteLine("What's the temperature outside: (C)");
//double temp = double.Parse(Console.ReadLine());

//if (temp >= 10 && temp <= 25)
//{
//    Console.WriteLine("It's warm outside"); // Both must be true for this to b successful T^T = T

//}

//else if (temp <= -50 || temp >= 50)
//{
//    Console.WriteLine("DO NOT go outside!");//Either or can be true for the statment to be true.   
//}

/*Loops*/
// while loop = repeats some code while some condition remains true

//String name = "";

//while (name == "")
//{
//    Console.Write("Enter your name: ");
//    name = Console.ReadLine();
//}

//Console.WriteLine("Hello " + name);


//// for loop = repeats some code a FINITE amount of times

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}


//for (int i = 0; i < 10; i += 1)
//{
//    Console.WriteLine(i);
//}
////or

//for (int i = 1; i < 10; i += 1)
//{
//    Console.WriteLine(i);
//}


//for (int i = 0; i < 10; i += 2)
//{
//    Console.WriteLine(i);
//}
////or

//for (int i = 1; i < 10; i += 2)
//{
//    Console.WriteLine(i);
//}


//for (int i = 0; i < 10; i += 3)
//{
//    Console.WriteLine(i);
//}
////or

//for (int i = 1; i < 10; i += 3)
//{
//    Console.WriteLine(i);
//}

////New year countdown
//for (int i = 10; i > 0; i--)
//{
//    Console.WriteLine(i);
//}
//Console.WriteLine("HAPPY NEW YEAR!");

//nested loops = loops insider of other for loops
//               Users vary. Used a lot of sorting algorthtims

//Console.WriteLine("How many rows?");
//int rows = int.Parse(Console.ReadLine());

//Console.WriteLine("How many columns?");
//int cols = int.Parse(Console.ReadLine());

//Console.WriteLine("What symbol?");
//String symbol = Console.ReadLine();

//for (int i = 0; i < rows; i++)
//{
//    for (int j = 0; j < cols; j++)
//    {
//        Console.Write(symbol);
//    }
//    Console.WriteLine();
//}


//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine("Happy birthday dear YOU!");
//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine();

//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine("Happy birthday dear YOU!");
//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine();

//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine("Happy birthday dear YOU!");
//Console.WriteLine("Happy birthday to you!");
//Console.WriteLine();

//method = performs a section of code, whenever it's called "invoked".
//        benefit = Let's us reuse code w/o writing it multiple times

//String name = "Bro";
//int age = 21;
//static void singHappyBirthday(String Name, int Age)
//{
//    //Console.WriteLine("Happy birthday to you!");
//    //Console.WriteLine("Happy birthday to you!");
//    //Console.WriteLine("Happy birthday dear YOU!");
//    //Console.WriteLine("Happy birthday to you!");
//    //Console.WriteLine();

//    Console.WriteLine("Happy birthday to you!");
//    Console.WriteLine("Happy birthday to you!");
//    Console.WriteLine($"Happy birthday dear {Name}");
//    Console.WriteLine($"You are {Age} years old!");
//    Console.WriteLine("Happy birthday to you!");
//    Console.WriteLine();


//}

//singHappyBirthday();
//singHappyBirthday();
//singHappyBirthday();
//singHappyBirthday(name,age);


//return = returns data back to the place where a method is invoked.

//double Multiply(double x, double y)
//{
//    double z = x * y;
//    return z;
//}

// We don't need to store the result in a new variable, we can just directly print it out
//double Multiply(double x, double y)
//{
//    return x*y;
//}


//Console.WriteLine("Enter number 1:");
//double x = double.Parse(Console.ReadLine());

//Console.WriteLine("Enter number 2:");
//double y = double.Parse(Console.ReadLine());

//double result = Multiply(x, y);
//Multiply(10, 2);
//Console.WriteLine("The product of the two numbers are:");


//// array = a variable that can store multiple values. Fixed size

//String[] cars = { "BMW", "Mustang", "Corvette" };

////To update element at first position
//cars[0] = "Tesla";

////Console.WriteLine(cars[0]);// was BMW now Tesla
////Console.WriteLine(cars[1]); // Mustang
////Console.WriteLine(cars[2]); // Corvette

////or

////String[] cars = new string[3];
////cars[0] = "Tesla";
////cars[1] = "Mustang";
////cars[2] = "Corvette";

////Better approach is to use for loop or for each loop.
////for(int i =0; i<cars.Length();i++)
////{
////   Console.WriteLine(cars[i]);   
////}
//// with for loop we can go backwards,fowards or skip iterations.

//// foreach loop = a simpler way to iterate over an array, but it's less flexible
//foreach(string car in cars)
//{
//   Console.WriteLine(car);
//}

// Multidimensional arrays is an array of arrays with fiex number of rows and columns
//String[,] = parkingLot = {
//                            {"Mustang","F-150","Exploerer"},
//                            { "Corvette","Camaro","Silverado"},
//                            { "Corrola","Camry","Rav4"}
//                         };

//// to change an element
//parkingLot[0, 2] = "Fusion";
//parkingLot[2, 0] = "Tacoma";

//foreach(String car in parkingLot)
//{
//   Console.WriteLine(car);
//}
//*/

////or for a grid like format
//// we use nested for loops

//// Here we will use the GetLength and pass in the dimension
////in this case we pass 0 because the first row of elements are 0
//// we also pass
//for (int r = 0; r < parkingLot.GetLength(0); r++)
//{
//    for (int c = 0; c < parkingLot.GetLength(1); c++)
//    {
//        Console.Write(parkingLot[r, c] + " ");
//    }
//    Console.WriteLine();
//}

////Correction 
//// Multidimensional arrays is an array of arrays with fiex number of rows and columns
//String[,] parkingLot = {
//                            {"Mustang","F-150","Exploerer"},
//                            {"Corvette","Camaro","Silverado"},
//                            {"Corrola","Camry","Rav4"}
//                         };

//// to change an element
//parkingLot[0, 2] = "Fusion";
//parkingLot[2, 0] = "Tacoma";

//foreach(String car in parkingLot)
//{
//   Console.WriteLine(car);
//}
//*/

////or for a grid like format
//// we use nested for loops

//// Here we will use the GetLength and pass in the dimension
////in this case we pass 0 because the first row of elements are 0
//// we also pass
//for (int r = 0; r < parkingLot.GetLength(0); r++)
//{
//    for (int c = 0; c < parkingLot.GetLength(1); c++)
//    {
//        Console.Write(parkingLot[r, c] + " ");
//    }
//    Console.WriteLine();
//}

//calling class in main program class

//calling class in main program class

//using BroCodeBasics;

//Messages message = new Messages();
//message.Hello();
//message.Waiting();
//message.Bye();

//using BroCodeBasics;

//Human human1 = new Human();
//Human human2 = new Human();

//human1.name = "Rick";
//human1.age = 65;

//human2.name = "Morty";
//human2.age = 16;

//human1.Eat();
//human1.Sleep();

//human2.Eat();
//human2.Sleep();

using BroCodeBasics;

Car car1 = new Car("Ford", "Mustang", 2022, "red");
Car car2 = new Car("Chevy", "Corvette", 2021, "blue");

car1.Drive();
car2.Drive();





