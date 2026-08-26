<<<<<<< HEAD
﻿////Topic 1: C# Basics
////1. Two main methods of the Net platform
//// a. Main method: The entry point of a console application where the program starts executing.
//// b. startup method: The entry point of a web application where the application is congigured and started.

////2. Console.Write() is used to write output to the console without adding a new line at the end,
////while Console.WriteLine() adds a new line after writing the output.

////3.Console.Readline() is used to read line of input from the console.
////It returns a string.

////4.value types are stored on the stack and hold their data directly, while reference types are stored on the heap and hold a reference to their data.
////Value types include primitive types like int, float, and structs, while reference types include classes, arrays, and strings.

////5. The output of the code snippet will be 5. This is because when we assign the value of 'a' to 'b',
////we are creating a copy of the value.
////Therefore, when we change the value of 'b' to 10, it does not affect the value of 'a', which remains 5.
////int a = 5;
////int b = a;
////b = 10;
////Console.WriteLine(a); // Output: 5

////6.
////String name = "Shivaar";
////int age = 23;
////Console.WriteLine($"My name is {name} and I am {age} years old.");

////7.A verbatim string is a string literal that is prefixed with the @ symbol.
////It allows you to include special characters and line breaks without needing to escape them. @C:\Users\Student\Documents\notes.txt

////8. given x = 10 and y =5 and z =0
////(x>y)&&(y>z) will evaluate to true because both conditions are true.
//// (x<y) || (z==0) will also evaluate to true because the second condition (z==0) is true, even though the first condition (x<y) is false.
//// !(x==y) will evaluate to true because x is not equal to y.

////9. null- coalescing operator (??) is used to provide a default value when a nullable type or reference type is null.
////It returns the left-hand operand if it is not null;
////otherwise, it returns the right-hand operand.Example of null-coalescing operator:
////null-conditional operator (?.) is used to access members of an object that may be null without throwing a NullReferenceException.

////10. There is an error in the code snippet because the variable 'name' is declared as a nullable string (string?)
////but is not assigned a value before being used in the null-coalescing operator.
////string? name = null;
////string display = name ?? "Guest";
////Console.WriteLine(display); // Output: Guest

////11. 
//using StudyguidePractice;
//using System;
//using System.Reflection.Metadata;
//using System.Xml.Linq;

//int temperature = 25;

//if (temperature < 0)
//{
//    Console.WriteLine("Freezing");
//}
//else if (temperature >= 0 && temperature <= 15)
//{
//    Console.WriteLine("Cold");
//}
//else if (temperature>=16 && temperature<= 25) 
//{
//    Console.WriteLine("Warm");
//}
//else if (temperature > 25 )
//{
//    Console.WriteLine("Hot");
//}

////12. 
//int age = 20;
//string status = age >= 18 ? "Adult" : "Minor";
////13. 
//int dayNumber = 3;
//string dayName = dayNumber switch
//{
//    1 => "Monday",
//    2 => "Tuesday",
//    3 => "Wednesday",
//    _=> "Unknown"
//};

////14.
//for (int i =10;i>0;i--) 
//{
//    Console.WriteLine(i);
//}
////15.
//int i=0;
////prefix-entry controlled checks the condition before running.
//while (i<5) 
//{
//    Console.WriteLine(i);
//    i++;
//}
////post-fix is exit controlled in where the condition runs and then it checks.
//do
//{
//    Console.WriteLine(i);
//    i++;
//} while (i < 5);

////16.break statement stops executing when the condition is met. Continue statement is when a condition skips over an iteration and continues to execute.

////17.Add 30 days
//DateTime startDate = DateTime.Now;
//DateTime endDate = startDate.AddDays(30);

////Topic 2:
////1. The four main parts of a method are: The datatype,method name,variable,parameters

////2.A parameter is a variable that is used to pass information into a method when it is called.
////A argument is the actual value that is passed to the method when it is called.

////3."pass by value" means that a copy of the variable's value is passed to the method.

////4. output of the code below:

//void ChangeValue(int x) 
//{
//    x = 100;
//}

//int number = 5;
//ChangeValue(number);
//Console.WriteLine(number); // Output: 5

////5. return keyword in a non-void method is used to returņ a value from the method to the caller. If you omit it then the method will not return any valu and will cause a compile-time error.
////6.Tradtional version
///*bool IsEven(int number) 
//{
//    if (number % 2 == 0)
//    {
//        return true;
//    }
//    else 
//    {
//        return false;
//    }
//}*/

////Expression-bodied version
//bool IsEven(int number) => number % 2 == 0;

////7. variable scope refers to the region of code where a variable is defined and can be accessed.
////It determines the visibility and lifetime of a variable.
////Variables declared within a method have local scope and can only be accessed within that method,
////while variables declared at the class level have class scope and can be accessed by all methods within the class.

//void Calculate() 
//{
//    int a = 5;
//    if (a>0) 
//    {
//        string message = "Positive";
//        Console.WriteLine(message);
//    }
//    //Console.WriteLine(message); // This will cause an error cause message is out of scope.
//}

////8. A class is a blueprint for creating objects that encapsulates data and behavior,
////while an object is an instance of a class that represents a specific entity with its own state and behavior.

////9. Four common access modifiers in C# are:
////private: this allows for the access specifier to be protected from external views and are accessible only within that class
////,public: access specifies that are accessible to any class.
////,protected:access specifiers that are accessible to that class and a derived class, and
////internal: access specifiers that are accessible within the same assembly but not from another assembly.

////10. Encapsulation is the principle of bundling data and methods that operate on that data within a single unit,
////such as a class, and restricting access to the internal details of the class.
////It is important in object-oriented programming because
////it helps to protect the integrity of the data and promotes modularity and maintanability of the code.

////11.The members that are accessible from the BankAccount class are:  
////Owner: This is a public property, so it can be accessed from anywhere.
////Balance: This is a protected property, so it can be accessed within the BankAccount class and any derived classes.
////CreatedDate: This is an internal property, so it can be accessed within the same assembly but not from another assembly.

////12. Static means that the member belongs to the class itself rather than an instance of the class.
////You access it by using the class name followed by the member name, like ClassName.
////MemberName. instance members belong to a specific instance of a class and are accessed through an object of that class,like objectName.MemberName.

////13. created a static method called Square in the MathUtilities class that takes an integer as a parameter and returns the square of that integer.
//MathUtilities.Square(5);

////14.A, C, E. int, DateTime, and Guid are likely implemented as structs in .NET because they are value types that hold their data directly. string is a reference type and List<T> is a generic collection class, so they are not implemented as structs.

////15.No, a struct cannot inherit from another struct or class because it is a value type and does not support inheritance.
////However, a struct can implement interfaces, which allows it to define behavior that can be shared across different types.

////Topic 3
////1. Inheritance is a fundamental principle of object-oriented programming that allows a new class (called a derived class or a child class) to inherit properties and behaviors (fields and methods) from an existing class (called a base class or a parent).

////2. Found in dog and animal class. Dog is a derived class that inherits from the base class Animal. This means that Dog can access the public and protected members of the Animal class, and can also override or extend the functionality of the Animal class.

////3. The purpose of a protected access modifier is to allow access to a member of a class from within the class itself and from any derived classes, while preventing access from outside the class hierarchy. An example of when it might be used is when you want to allow derived classes to access and modify a member of the base class,but the member should not be accessible to other classes that are not part of the inheritance hierarchy.

////4.Refer to animal and dog class again: 
////(a) This will work because Name is a public property in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.
////(b) This will cause an error because Age is a private field in the Animal class and cannot be accessed directly from the Dog class.
////(c) This will work because Species is a protected field in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.

////5.Refer to vehicle and car class.

////6. Polymorphism is the ability of objects of different types to be treated as object of a common base type.
////Compile time polymorphism (also known as method overloading) occurs when multiple methods in the same class have the same name but different parameters,
////and the method is chosen at compile time based on the arguments passed.
////Runtime polymorphism (also known as method overriding) occurs when a derived class provides a specific implementation of a method that is already defined in its base class,
////and the method could be called through a base class reference, and the actual method that gets executed is determined at runtime based on the type of the object being referenced.

////7. The virtual keyword is used in a base class to indicate that a method can be overridden in a derived class.
////It allows for runtime polymorphism by enabling derived classes to provide their own implementation of the method.

////8.Instantiating an  object:
//Animal a1 = new Dog();
//Animal a2 = new Cat();
//a1.Speak(); // Output: Dog barks
//a2.Speak(); // Output: Cat meows

////9. Area of circle and rectangle stored in a list.
//Circle circle = new Circle();
//Rectangle rectangle = new Rectangle();
//List<Shape> shapes = new List<Shape>();

//shapes.Add(circle);
//shapes.Add(rectangle);

//foreach (Shape shape in shapes) 
//{
//    shape.CalculateArea();
//}

////10. An abstract class is a class that cannot be instantiated and is meant to be inherited by other classes.

////11. An interface is a contract that defines a set of members (methods, properties, events, or indexers) that a class must implement if it chooses to implement the interface.

////12.1. An abstract class can have both abstract and non-abstract members, while an interface can only have abstract members (until C# 8.0, which introduced default implementations in interfaces).
//// 2. A class can inherit from only one abstract class, but it can implement multiple interfaces. 3. An abstract class can have constructors and fields, while an interface cannot have constructors or fields.
//// 3. An abstract class can provide a default implementation for some of its members, while an interface cannot provide any implementation (until C# 8.0, which introduced default implementations in interfaces).

////13.Calling music and video player.
//MusicPlayer musicplayer = new MusicPlayer();
//VideoPlayer videoPlayer = new VideoPlayer();
//musicplayer.Play();
//videoPlayer.Play();

////expected output:
////Music is playing...
////Music is paused.

////Video is playing...
////Video is paused.

////14.
//Appliance appliance = new WashingMachine();
//appliance.TurnOn();

////15.You would use virtual methods when you want to provide a default implementation that can be optionally overridden by derived classes. This allows users of your framework to extend the functionality without being forced to implement every method.
////You would use an abstract class with abstract methods when you want to define a common interface for a group of related classes and require that they implement certain methods. This is useful when you want to enforce a contract that all derived classes must follow, ensuring that they provide specific functionality while still allowing for some shared implementation in the abstract class.

////Topic 4
////1.Output is 6 below because arrays are zero-indexed, meaning that the first element is at index 0, the second element is at index 1, and so on. Therefore, numbers[2] refers to the third element of the array, which is 6.
////int[] numbers = {2,4,6,8 };
////Console.WriteLine(numbers[2]); 

////2. Changing second element of the array to yellow.
//string[] colours = {"red","green","blue" };
//colours[1] = "yellow";


////3.Output will be 10;
//int[] numbers = new int[10];
//int length = numbers.Length;

////4.Explain the difference between a multidimensional array (int[,]) and a jagged array (int[][]).
//// A multidimensional array (int[,]) is a rectangular array where all rows have the same number of columns,
//// while a jagged array (int[][]) is an array of arrays, where each row can have a different number of columns.
//// In a multidimensional array, you access elements using two indices (e.g., array[0,1]),
//// while in a jagged array, you access elements using two sets of indices (e.g., jaggedArray[0][1]).


////5.
//int sum = 0;
//int[] values = {1, 2, 3, 4, 5};
////foreach (int value in values)
////{
////    sum += value;
////}


////or
////for (int v = 0; v < values.Length; v++) 
////{ 
////    sum += values[v];
////}
//Console.WriteLine(sum);


////6.What is the main difference between an array and a List<T>?
//// The main difference between an array and a List<T> is that an array has a fixed size, meaning that once it is created, its size cannot be changed.
//// In contrast, a List<T> is a dynamic collection that can grow or shrink in size as needed.
//// Additionally, List<T> provides more functionality and methods for manipulating the collection compared to arrays, such as adding, removing, and searching for elements.

////7.expected output: Alen,David,Banele
//List<string> names = new List<string> { "Alen", "Tracey", "Banele" };
//names.Insert(1,"David");
//names.Remove("Tracey");
//Console.WriteLine(string.Join(",", names));

////8.
//// ════════════════════════════════════════════════════════════
////  EXERCISE - Dictionary<string, int> with TryGetValue
////  Data Structure used:
////      Dictionary<string, int>
////      KEY   = person's name  (e.g. "Alice")
////      VALUE = their age      (e.g. 25)
////
////  Think of it like this:
////      "Alice" → 25
////      "Bob"   → 30
////      "Ravi"  → 22
//// ════════════════════════════════════════════════════════════

//// ── Create the dictionary ────────────────────────────────────
//// string = the name (KEY)
//// int    = the age  (VALUE)
//// Starts empty – no entries yet
//Dictionary<string, int> ages = new Dictionary<string, int>();

//// ── Add three entries ────────────────────────────────────────
//// ages[key] = value → adds the entry if key doesn't exist
////                   → overwrites the value if key already exists
//ages["Alice"] = 25;   // dictionary now: { "Alice" → 25 }
//ages["Bob"] = 30;   // dictionary now: { "Alice" → 25, "Bob" → 30 }
//ages["Ravi"] = 22;   // dictionary now: { "Alice" → 25, "Bob" → 30, "Ravi" → 22 }

//// ── Safely retrieve Alice's age using TryGetValue ────────────
//// WHY TryGetValue and not ages["Alice"] directly?
////
////   ages["Alice"]         → works IF key exists
////                         → throws KeyNotFoundException and CRASHES if key missing
////
////   ages.TryGetValue(...) → NEVER crashes
////                         → returns true  + fills 'age' if key is found
////                         → returns false + age stays 0  if key is NOT found
////
//// 'out int age' → the method writes the value INTO this variable for us
////                 so after TryGetValue runs, age already holds 25

//if (ages.TryGetValue("Alice", out int age))
//{
//    // true → key was found, age has been filled with Alice's value
//    Console.WriteLine($"Alice was found! Age: {age}");
//    // → Alice was found! Age: 25
//}
//else
//{
//    // false → key doesn't exist, age defaults to 0
//    Console.WriteLine("Alice was not found in the dictionary.");
//}

//// ── Bonus: test with a name that does NOT exist ──────────────
//// Shows TryGetValue handling a missing key gracefully
//// If we had used ages["Ghost"] directly it would crash here
//if (ages.TryGetValue("Ghost", out int missingAge))
//{
//    Console.WriteLine($"Ghost was found! Age: {missingAge}");
//}
//else
//{
//    // This block runs – "Ghost" was never added
//    Console.WriteLine("Ghost was not found in the dictionary.");
//    // → Ghost was not found in the dictionary.
//}

//// ── Display all entries ──────────────────────────────────────
//Console.WriteLine("\n===== All Entries =====");
//foreach (KeyValuePair<string, int> entry in ages)
//{
//    // entry.Key   = the name  (string)
//    // entry.Value = the age   (int)
//    Console.WriteLine($"{entry.Key} → {entry.Value}");
//    // → Alice → 25
//    // → Bob   → 30
//    // → Ravi  → 22
//}

////9.Removing even numbers from list

//List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 10 };
//nums.RemoveAll(n => n % 2 == 0);

//Topic 5:
//// 1. An exception is an unexpected or error condition during execution.
//// 2. The purpose of try is to test if the code is valid, the purpose of catch is to ensure if there is any errors and finally means that the file has completed it's task this is mostly used for closing staements.
//// 3. If the user enters "0" then it will display that the user cannot divide by 0.
//try
//{
//    Console.WriteLine("Enter a number");
//    int number = int.Parse(Console.ReadLine());
//    Console.WriteLine(10 / number);
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Cannot divide by 0");
//}
//catch (FormatException)
//{
//    Console.WriteLine("Invalid number format");
//}
//finally
//{
//    Console.WriteLine("Operation attempted");
//}

////    If the user enters "abc" it is not a valid integer value it is a different data type therefore it will return that the expected format is wrong. 
////    If the user enters "5" it will  use "5" as a denominator and then return a value. Note that with all of these the finally block will still execute.

////4.   It looks at that exception first when it compiles

////5.   Throw can throw any thing whereas throw ex is set for throwing an exception

////6.
//InvalidTemperatureException invTemp;
//Console.WriteLine(invTemp.ReadTemp());


////7. The finally block is guarenteed to run regardless. A good example would be when we close a file we use file.Close();

////8. Writing throw expressions
//private string _name;
//public string Name
//{
//    get => _name;
//    set => _name = value ?? throw new ArgumentNullException(nameof(value));
//}

////In a method
//public int GetValue(int? input) => input ?? throw new ArgumentNullEException(nameof(input));

//// In the null-coalescing operator
//string text = GetInput() ?? throw new InvalidOperationException("Input cannot be null");

////9. You should throw an excpetion when you expect the program to run into an error so it can then override it.

////10. Output of the ffg will be:
//try
//{
//    try
//    {
//        Console.Write("Enter value: ");
//        string input = Console.ReadLine();
//        if (string.IsNullOrEmpty(input))
//        {
//            throw new ArgumentNullException("input");
//        }
//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Format error");
//        throw; //rethrow
//    }
//}
//catch (ArgumentNullException ex)
//{
//    Console.WriteLine("Null input detected");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"General error: {ex.Message}");
//}
//finally
//{
//    Console.WriteLine("Done");
//}

////10.1 It will return it's null
////10.2 It will return "abc"
////10.3 It will return as a string

//Correction
//1.An exception is an unexpected or error condition during execution. If an exception is not handled, the program terminates immediately with an error message.
//The runtime looks up the call stack for a matching catch block
//— if none is found, the program crashes.

//2.try — wraps code that might throw an exception. If an exception occurs inside, execution jumps immediately to the matching catch block
//catch — handles a specific exception type. Multiple catch blocks can be chained, checked top to bottom — the first matching one runs, the rest are skipped
//finally — always runs regardless of whether an exception occurred or not. Used for cleanup like closing files or database connections
//Order of execution: try → catch (if exception) → finally (always)

//3. For the below:
//  When the code input is "0", it will throw a DivideByZeroException, which is caught by the first catch block, and the message
//  "Cannot divide by 0" is printed.
//  Then, the finally block executes, printing "Operation attempted".
//When the code input is "abc", it will throw a FormatException,
//which is caught by the second catch block, and the message
// When the code input is "5", it will successfully parse the number and perform the division,
// printing "2" to the console.
// Then, the finally block executes, printing "Operation attempted".

//try
//{
//    Console.WriteLine("Enter a number");
//    int number = int.Parse(Console.ReadLine());
//    Console.WriteLine(10 / number);
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Cannot divide by 0");
//}
//catch (FormatException)
//{
//    Console.WriteLine("Invalid number format");
//}
//finally
//{
//    Console.WriteLine("Operation attempted");
//}

//4. C# checks catch blocks from top to bottom and executes the first one that matches. If you put catch (Exception ex) first, it catches EVERYTHING — the more specific blocks below it like DivideByZeroException or FormatException will never be reached and the compiler warns you they are unreachable. Always go most specific → most general.
//catch(DivideByZeroException) { }  // most specific first
//catch (FormatException)       { }  // still specific
//catch (Exception ex)          { }  // catch-all LAST

//5.throw; — rethrows the exception while preserving the original stack trace. The debugger still shows exactly where the error originally happened
//throw ex; — rethrows but resets the stack trace to the current line, losing the original call site information. This makes debugging much harder

//catch (Exception ex)
//{
//    // Log it
//    throw;     // ✅ preserves original stack trace
//    // throw ex; ❌ destroys original stack trace
//}

//6. 
// Instantiate the components
//using StudyguidePractice;

/////*bool IsEven(int number) 
//TemperatureModel model = new TemperatureModel();
//TemperatureView view = new TemperatureView();

//// Pass the model and view into the controller
//TemperatureController controller = new TemperatureController(model, view);

//// Execute the application logic
//controller.Run();

//7.The finally block is guarenteed to run regardless. A good example would be when we close a file we use file.Close();
//SqlConnection conn = new SqlConnection(connectionString);
//try
//{
//    conn.Open();
//    // do database work
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"DB Error: {ex.Message}");
//}
//finally
//{
//    conn.Close(); // ALWAYS closes even if exception occurred
//}

//8.
// Property setter
//using System.Xml.Linq;

/////*bool IsEven(int number) 
//private string _name = string.Empty;
//public string Name
//{
//    get => _name;
//    set => _name = value ?? throw new ArgumentNullException(nameof(value));
//}

//// Expression-bodied method
//public int GetValue(int? input) =>
//    input ?? throw new ArgumentNullException(nameof(input));

//// Null-coalescing
//string text = GetInput() ?? throw new InvalidOperationException("Input cannot be null");

//9.
/*
 Throw when:

Input validation fails at a public method boundary (ArgumentNullException, ArgumentException)
An object is in an invalid state for an operation (InvalidOperationException)
A condition is truly unexpected and cannot be recovered from locally

Do NOT throw when:

Controlling normal program flow (don't use exceptions instead of if/else)
The situation is expected and can be handled with a simple check
Performance matters — exceptions are expensive to create and throw
 */

//10.
//try                              // OUTER try
//{
//    try                          // INNER try
//    {
//        Console.Write("Enter value: ");
//        string input = Console.ReadLine();
//        if (string.IsNullOrEmpty(input))
//            throw new ArgumentNullException("input");
//    }
//    catch (FormatException)      // INNER catch - only catches FormatException
//    {
//        Console.WriteLine("Format error");
//        throw;
//    }
//}
//catch (ArgumentNullException ex) // OUTER catch 1
//{
//    Console.WriteLine("Null input detected");
//}
//catch (Exception ex)             // OUTER catch 2
//{
//    Console.WriteLine($"General error: {ex.Message}");
//}
//finally
//{
//    Console.WriteLine("Done");
//}

////10.1 If the user enters nothing and just presses Enter, it will throw an ArgumentNullException, which is caught by the outer catch block, printing "Null input detected".
////Then the finally block executes, printing "Done".

////10.2. If the user enters "abc", it will throw a FormatException, which is caught by the inner catch block, printing "Format error".
////Then it rethrows the exception, which is caught by the outer catch block, printing "General error: Input string was not in a correct format."
////Finally, the finally block executes, printing "Done".

////10.3.User types "42", it successfully parses the number and does not throw any exceptions, so neither catch block executes.









// 1. Get your connection string
using StudyguidePractice;

///*bool IsEven(int number) 
///*bool IsEven(int number) 

///Topic 6

///1. A Data Access Layer (DAL) is a layer of code that handles the interaction with the database or any data source. 
///   It is responsible for performing CRUD (Create, Read, Update, Delete) operations on the data. Separating the DAL from business logic is important because it promotes separation of concerns, making the code more modular and maintainable. It allows developers to change the data access implementation without affecting the business logic, and vice versa. 
///   This separation also makes it easier to test each layer independently.

///2. A connection string is a string that specifies information about a data source and how to connect to it. 
///Server=(localdb)\MSSQLLocalDB;Database=SkyFlowDB;
///Trusted_Connection = True; TrustServerCertificate = True;
///   Three common pieces of information found in a SQL Server connection string are:
/// - Server name or address
/// - Database name
/// - Authentication details (such as username and password)

/// 3. In raw ADO.NET, the "boilerplate problem" refers to the repetitive and verbose code that developers have to write for every database operation. 
/// This includes tasks such as: 
/// - Creating and opening a database connection  
/// - Creating a command object
/// - Executing the command
/// - Reading the results
/// - Closing the connection

/// 4. The using statement is critical when working with database connections because it ensures that the connection is properly closed and disposed of, even if an exception occurs. If you forget to use it, 
/// you might end up with open connections that are not released back to the connection pool, 
/// which can lead to resource leaks and eventually exhaust the available connections, 
/// causing your application to fail when trying to connect to the database.

/// 5. Dapper is a micro-ORM (Object-Relational Mapper) that provides a simple and efficient way to execute SQL queries and map the results to C# objects. 
///    It solves the boilerplate problem by using extension methods on the IDbConnection interface,allowing developers to write concise code for executing queries and mapping results without having to manually create command objects, execute them, and read results. 
///    Dapper uses dynamic code generation and caching to maintain high performance, 
///    making it one of the fastest ORMs available while still providing a simple API for data access.

/// 6. To install the Dapper NuGet package using the .NET CLI, you can run the following command in your terminal: dotnet add package Dapper
/// To use Dapper's extension methods, include the following using directive in your C# file:
/// using Dapper;


/// 7. Given a Product class with ProductID, ProductName, and UnitPrice properties, write a Dapper query that retrieves all products and maps them to a List<Product>. 
//Error here for GetAllProducts();
//// 1. Get your connection string
//var connectionString = "Server=YOUR_SERVER;Database=InventoryDb;Trusted_Connection=True;";

//// 2. Instantiate the repository
//var repository = new ProductRepository(connectionString);

//// 3. Call the method
//var myProducts = repository.GetAllProducts();

//// 4. Use the data
//foreach (var product in myProducts)
//{
//    Console.WriteLine(product.Name);
//}

/// 8. - QueryFirstOrDefault<T> returns the first row of the result set, or the default value if no rows are returned. 
/// It   does not throw an exception if multiple rows are returned. Use when You expect 0 or 1 results — e.g. search by ID that might not exist


/// - QuerySingle<T> expects exactly one row to be returned. If no rows are returned, it throws an exception.
/// If more than one row is returned, it also throws an exception. Use when You expect EXACTLY 1 result — e.g. looking up a unique config value

/// 9. Dapper handles SQL parameters by allowing you to pass an anonymous object with properties that match the parameter names in your SQL query. 
///    This approach is safer than string concatenation because it automatically handles escaping and prevents SQL injection attacks.

/// 10. Write a Dapper method that inserts a new Product and returns the auto-generated identity value. Include the SQL and the C# code.
/// 
//var repo = new ProductRepository(connectionString);

//// Create a new object
//var newProduct = new Product
//{
//    Name = "Webcam",
//    Description = "1080p HD",
//    Price = 45.00m,
//    StockQuantity = 20
//};

//// Use the repo to save it
//int newId = repo.AddProduct(newProduct);

//Console.WriteLine($"Product added successfully with ID: {newId}");

/// 11. Dapper's Execute method returns the number of rows affected by the command. You can use this return value to verify that an update was successful by checking if it is greater than 0, which indicates that at least one row was updated. 
///     A good example of this is when you execute an update statement and want to confirm that the intended record was updated.
//Error connectionString(),ProductName,UnitPrice 
//// 1. Initialize your repository
//var repo = new ProductRepository(connectionString);

//// 2. Fetch the product you want to update 
//// (e.g., let's say we are updating the product with ID 1)
//var productToUpdate = repo.GetProductById(1);

//if (productToUpdate != null)
//{
//    // 3. Modify the properties
//    productToUpdate.ProductName = "Updated Laptop Name";
//    productToUpdate.UnitPrice = 1150.00m;

//    // 4. Send the updated object to the repository
//    bool wasUpdated = repo.UpdateProduct(productToUpdate);

//    if (wasUpdated)
//    {
//        Console.WriteLine("Update successful!");
//    }
//    else
//    {
//        Console.WriteLine("Update failed (Product might not exist).");
//    }
//}
//else
//{
//    Console.WriteLine("Product not found, cannot update.");
//}

/// 12. Write a Dapper method that updates the price of a product. Use parameters and show  the complete method. 
/*Separation of concerns — database code is in one place, business logic doesn't know or care how data is stored
Testability — you can swap SqlRepository for a fake/mock repository during unit testing without changing any business logic
Maintainability — if the database changes, only the repository needs updating
 */

/// 13. The repository pattern is a design pattern that provides a way to separate the data access logic from the business logic in an application. 
///     It acts as an intermediary between the data source and the business logic, allowing for more modular and maintainable code.

///14.  Accepting the connection string in the constructor rather than hard-coding it is a best practice because it promotes flexibility and separation of concerns.
/*— security. Hard-coding a connection string means it's visible in your source code and could end up in version control (GitHub etc.) 
 * where anyone can see your database credentials. Passing it in means it can come from a config file or environment variable that is kept secret.
 */

///15. Write a complete CustomerRepository class with the following methods (assume a Customer class with CustomerID, FirstName, LastName, Email; Includeproper using statements and connection management.): 
// GetById(int id) – returns a single customer. 
// GetAll() – returns all customers. 
// Add(Customer customer) – inserts a new customer and returns the new ID.
// Update(Customer customer) – updates an existing customer,returns bool indicating success. 
// Delete(int id) – deletes a customer, returns bool indicating success.
=======
﻿////Topic 1: C# Basics
////1. Two main methods of the Net platform
//// a. Main method: The entry point of a console application where the program starts executing.
//// b. startup method: The entry point of a web application where the application is congigured and started.

////2. Console.Write() is used to write output to the console without adding a new line at the end,
////while Console.WriteLine() adds a new line after writing the output.

////3.Console.Readline() is used to read line of input from the console.
////It returns a string.

////4.value types are stored on the stack and hold their data directly, while reference types are stored on the heap and hold a reference to their data.
////Value types include primitive types like int, float, and structs, while reference types include classes, arrays, and strings.

////5. The output of the code snippet will be 5. This is because when we assign the value of 'a' to 'b',
////we are creating a copy of the value.
////Therefore, when we change the value of 'b' to 10, it does not affect the value of 'a', which remains 5.
////int a = 5;
////int b = a;
////b = 10;
////Console.WriteLine(a); // Output: 5

////6.
////String name = "Shivaar";
////int age = 23;
////Console.WriteLine($"My name is {name} and I am {age} years old.");

////7.A verbatim string is a string literal that is prefixed with the @ symbol.
////It allows you to include special characters and line breaks without needing to escape them. @C:\Users\Student\Documents\notes.txt

////8. given x = 10 and y =5 and z =0
////(x>y)&&(y>z) will evaluate to true because both conditions are true.
//// (x<y) || (z==0) will also evaluate to true because the second condition (z==0) is true, even though the first condition (x<y) is false.
//// !(x==y) will evaluate to true because x is not equal to y.

////9. null- coalescing operator (??) is used to provide a default value when a nullable type or reference type is null.
////It returns the left-hand operand if it is not null;
////otherwise, it returns the right-hand operand.Example of null-coalescing operator:
////null-conditional operator (?.) is used to access members of an object that may be null without throwing a NullReferenceException.

////10. There is an error in the code snippet because the variable 'name' is declared as a nullable string (string?)
////but is not assigned a value before being used in the null-coalescing operator.
////string? name = null;
////string display = name ?? "Guest";
////Console.WriteLine(display); // Output: Guest

////11. 
//using StudyguidePractice;
//using System;
//using System.Reflection.Metadata;
//using System.Xml.Linq;

//int temperature = 25;

//if (temperature < 0)
//{
//    Console.WriteLine("Freezing");
//}
//else if (temperature >= 0 && temperature <= 15)
//{
//    Console.WriteLine("Cold");
//}
//else if (temperature>=16 && temperature<= 25) 
//{
//    Console.WriteLine("Warm");
//}
//else if (temperature > 25 )
//{
//    Console.WriteLine("Hot");
//}

////12. 
//int age = 20;
//string status = age >= 18 ? "Adult" : "Minor";
////13. 
//int dayNumber = 3;
//string dayName = dayNumber switch
//{
//    1 => "Monday",
//    2 => "Tuesday",
//    3 => "Wednesday",
//    _=> "Unknown"
//};

////14.
//for (int i =10;i>0;i--) 
//{
//    Console.WriteLine(i);
//}
////15.
//int i=0;
////prefix-entry controlled checks the condition before running.
//while (i<5) 
//{
//    Console.WriteLine(i);
//    i++;
//}
////post-fix is exit controlled in where the condition runs and then it checks.
//do
//{
//    Console.WriteLine(i);
//    i++;
//} while (i < 5);

////16.break statement stops executing when the condition is met. Continue statement is when a condition skips over an iteration and continues to execute.

////17.Add 30 days
//DateTime startDate = DateTime.Now;
//DateTime endDate = startDate.AddDays(30);

////Topic 2:
////1. The four main parts of a method are: The datatype,method name,variable,parameters

////2.A parameter is a variable that is used to pass information into a method when it is called.
////A argument is the actual value that is passed to the method when it is called.

////3."pass by value" means that a copy of the variable's value is passed to the method.

////4. output of the code below:

//void ChangeValue(int x) 
//{
//    x = 100;
//}

//int number = 5;
//ChangeValue(number);
//Console.WriteLine(number); // Output: 5

////5. return keyword in a non-void method is used to returņ a value from the method to the caller. If you omit it then the method will not return any valu and will cause a compile-time error.
////6.Tradtional version
///*bool IsEven(int number) 
//{
//    if (number % 2 == 0)
//    {
//        return true;
//    }
//    else 
//    {
//        return false;
//    }
//}*/

////Expression-bodied version
//bool IsEven(int number) => number % 2 == 0;

////7. variable scope refers to the region of code where a variable is defined and can be accessed.
////It determines the visibility and lifetime of a variable.
////Variables declared within a method have local scope and can only be accessed within that method,
////while variables declared at the class level have class scope and can be accessed by all methods within the class.

//void Calculate() 
//{
//    int a = 5;
//    if (a>0) 
//    {
//        string message = "Positive";
//        Console.WriteLine(message);
//    }
//    //Console.WriteLine(message); // This will cause an error cause message is out of scope.
//}

////8. A class is a blueprint for creating objects that encapsulates data and behavior,
////while an object is an instance of a class that represents a specific entity with its own state and behavior.

////9. Four common access modifiers in C# are:
////private: this allows for the access specifier to be protected from external views and are accessible only within that class
////,public: access specifies that are accessible to any class.
////,protected:access specifiers that are accessible to that class and a derived class, and
////internal: access specifiers that are accessible within the same assembly but not from another assembly.

////10. Encapsulation is the principle of bundling data and methods that operate on that data within a single unit,
////such as a class, and restricting access to the internal details of the class.
////It is important in object-oriented programming because
////it helps to protect the integrity of the data and promotes modularity and maintanability of the code.

////11.The members that are accessible from the BankAccount class are:  
////Owner: This is a public property, so it can be accessed from anywhere.
////Balance: This is a protected property, so it can be accessed within the BankAccount class and any derived classes.
////CreatedDate: This is an internal property, so it can be accessed within the same assembly but not from another assembly.

////12. Static means that the member belongs to the class itself rather than an instance of the class.
////You access it by using the class name followed by the member name, like ClassName.
////MemberName. instance members belong to a specific instance of a class and are accessed through an object of that class,like objectName.MemberName.

////13. created a static method called Square in the MathUtilities class that takes an integer as a parameter and returns the square of that integer.
//MathUtilities.Square(5);

////14.A, C, E. int, DateTime, and Guid are likely implemented as structs in .NET because they are value types that hold their data directly. string is a reference type and List<T> is a generic collection class, so they are not implemented as structs.

////15.No, a struct cannot inherit from another struct or class because it is a value type and does not support inheritance.
////However, a struct can implement interfaces, which allows it to define behavior that can be shared across different types.

////Topic 3
////1. Inheritance is a fundamental principle of object-oriented programming that allows a new class (called a derived class or a child class) to inherit properties and behaviors (fields and methods) from an existing class (called a base class or a parent).

////2. Found in dog and animal class. Dog is a derived class that inherits from the base class Animal. This means that Dog can access the public and protected members of the Animal class, and can also override or extend the functionality of the Animal class.

////3. The purpose of a protected access modifier is to allow access to a member of a class from within the class itself and from any derived classes, while preventing access from outside the class hierarchy. An example of when it might be used is when you want to allow derived classes to access and modify a member of the base class,but the member should not be accessible to other classes that are not part of the inheritance hierarchy.

////4.Refer to animal and dog class again: 
////(a) This will work because Name is a public property in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.
////(b) This will cause an error because Age is a private field in the Animal class and cannot be accessed directly from the Dog class.
////(c) This will work because Species is a protected field in the Animal class and can be accessed from the Dog class, which is a derived class of Animal.

////5.Refer to vehicle and car class.

////6. Polymorphism is the ability of objects of different types to be treated as object of a common base type.
////Compile time polymorphism (also known as method overloading) occurs when multiple methods in the same class have the same name but different parameters,
////and the method is chosen at compile time based on the arguments passed.
////Runtime polymorphism (also known as method overriding) occurs when a derived class provides a specific implementation of a method that is already defined in its base class,
////and the method could be called through a base class reference, and the actual method that gets executed is determined at runtime based on the type of the object being referenced.

////7. The virtual keyword is used in a base class to indicate that a method can be overridden in a derived class.
////It allows for runtime polymorphism by enabling derived classes to provide their own implementation of the method.

////8.Instantiating an  object:
//Animal a1 = new Dog();
//Animal a2 = new Cat();
//a1.Speak(); // Output: Dog barks
//a2.Speak(); // Output: Cat meows

////9. Area of circle and rectangle stored in a list.
//Circle circle = new Circle();
//Rectangle rectangle = new Rectangle();
//List<Shape> shapes = new List<Shape>();

//shapes.Add(circle);
//shapes.Add(rectangle);

//foreach (Shape shape in shapes) 
//{
//    shape.CalculateArea();
//}

////10. An abstract class is a class that cannot be instantiated and is meant to be inherited by other classes.

////11. An interface is a contract that defines a set of members (methods, properties, events, or indexers) that a class must implement if it chooses to implement the interface.

////12.1. An abstract class can have both abstract and non-abstract members, while an interface can only have abstract members (until C# 8.0, which introduced default implementations in interfaces).
//// 2. A class can inherit from only one abstract class, but it can implement multiple interfaces. 3. An abstract class can have constructors and fields, while an interface cannot have constructors or fields.
//// 3. An abstract class can provide a default implementation for some of its members, while an interface cannot provide any implementation (until C# 8.0, which introduced default implementations in interfaces).

////13.Calling music and video player.
//MusicPlayer musicplayer = new MusicPlayer();
//VideoPlayer videoPlayer = new VideoPlayer();
//musicplayer.Play();
//videoPlayer.Play();

////expected output:
////Music is playing...
////Music is paused.

////Video is playing...
////Video is paused.

////14.
//Appliance appliance = new WashingMachine();
//appliance.TurnOn();

////15.You would use virtual methods when you want to provide a default implementation that can be optionally overridden by derived classes. This allows users of your framework to extend the functionality without being forced to implement every method.
////You would use an abstract class with abstract methods when you want to define a common interface for a group of related classes and require that they implement certain methods. This is useful when you want to enforce a contract that all derived classes must follow, ensuring that they provide specific functionality while still allowing for some shared implementation in the abstract class.

////Topic 4
////1.Output is 6 below because arrays are zero-indexed, meaning that the first element is at index 0, the second element is at index 1, and so on. Therefore, numbers[2] refers to the third element of the array, which is 6.
////int[] numbers = {2,4,6,8 };
////Console.WriteLine(numbers[2]); 

////2. Changing second element of the array to yellow.
//string[] colours = {"red","green","blue" };
//colours[1] = "yellow";


////3.Output will be 10;
//int[] numbers = new int[10];
//int length = numbers.Length;

////4.Explain the difference between a multidimensional array (int[,]) and a jagged array (int[][]).
//// A multidimensional array (int[,]) is a rectangular array where all rows have the same number of columns,
//// while a jagged array (int[][]) is an array of arrays, where each row can have a different number of columns.
//// In a multidimensional array, you access elements using two indices (e.g., array[0,1]),
//// while in a jagged array, you access elements using two sets of indices (e.g., jaggedArray[0][1]).


////5.
//int sum = 0;
//int[] values = {1, 2, 3, 4, 5};
////foreach (int value in values)
////{
////    sum += value;
////}


////or
////for (int v = 0; v < values.Length; v++) 
////{ 
////    sum += values[v];
////}
//Console.WriteLine(sum);


////6.What is the main difference between an array and a List<T>?
//// The main difference between an array and a List<T> is that an array has a fixed size, meaning that once it is created, its size cannot be changed.
//// In contrast, a List<T> is a dynamic collection that can grow or shrink in size as needed.
//// Additionally, List<T> provides more functionality and methods for manipulating the collection compared to arrays, such as adding, removing, and searching for elements.

////7.expected output: Alen,David,Banele
//List<string> names = new List<string> { "Alen", "Tracey", "Banele" };
//names.Insert(1,"David");
//names.Remove("Tracey");
//Console.WriteLine(string.Join(",", names));

////8.
//// ════════════════════════════════════════════════════════════
////  EXERCISE - Dictionary<string, int> with TryGetValue
////  Data Structure used:
////      Dictionary<string, int>
////      KEY   = person's name  (e.g. "Alice")
////      VALUE = their age      (e.g. 25)
////
////  Think of it like this:
////      "Alice" → 25
////      "Bob"   → 30
////      "Ravi"  → 22
//// ════════════════════════════════════════════════════════════

//// ── Create the dictionary ────────────────────────────────────
//// string = the name (KEY)
//// int    = the age  (VALUE)
//// Starts empty – no entries yet
//Dictionary<string, int> ages = new Dictionary<string, int>();

//// ── Add three entries ────────────────────────────────────────
//// ages[key] = value → adds the entry if key doesn't exist
////                   → overwrites the value if key already exists
//ages["Alice"] = 25;   // dictionary now: { "Alice" → 25 }
//ages["Bob"] = 30;   // dictionary now: { "Alice" → 25, "Bob" → 30 }
//ages["Ravi"] = 22;   // dictionary now: { "Alice" → 25, "Bob" → 30, "Ravi" → 22 }

//// ── Safely retrieve Alice's age using TryGetValue ────────────
//// WHY TryGetValue and not ages["Alice"] directly?
////
////   ages["Alice"]         → works IF key exists
////                         → throws KeyNotFoundException and CRASHES if key missing
////
////   ages.TryGetValue(...) → NEVER crashes
////                         → returns true  + fills 'age' if key is found
////                         → returns false + age stays 0  if key is NOT found
////
//// 'out int age' → the method writes the value INTO this variable for us
////                 so after TryGetValue runs, age already holds 25

//if (ages.TryGetValue("Alice", out int age))
//{
//    // true → key was found, age has been filled with Alice's value
//    Console.WriteLine($"Alice was found! Age: {age}");
//    // → Alice was found! Age: 25
//}
//else
//{
//    // false → key doesn't exist, age defaults to 0
//    Console.WriteLine("Alice was not found in the dictionary.");
//}

//// ── Bonus: test with a name that does NOT exist ──────────────
//// Shows TryGetValue handling a missing key gracefully
//// If we had used ages["Ghost"] directly it would crash here
//if (ages.TryGetValue("Ghost", out int missingAge))
//{
//    Console.WriteLine($"Ghost was found! Age: {missingAge}");
//}
//else
//{
//    // This block runs – "Ghost" was never added
//    Console.WriteLine("Ghost was not found in the dictionary.");
//    // → Ghost was not found in the dictionary.
//}

//// ── Display all entries ──────────────────────────────────────
//Console.WriteLine("\n===== All Entries =====");
//foreach (KeyValuePair<string, int> entry in ages)
//{
//    // entry.Key   = the name  (string)
//    // entry.Value = the age   (int)
//    Console.WriteLine($"{entry.Key} → {entry.Value}");
//    // → Alice → 25
//    // → Bob   → 30
//    // → Ravi  → 22
//}

////9.Removing even numbers from list

//List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 10 };
//nums.RemoveAll(n => n % 2 == 0);

//Topic 5:
//// 1. An exception is an unexpected or error condition during execution.
//// 2. The purpose of try is to test if the code is valid, the purpose of catch is to ensure if there is any errors and finally means that the file has completed it's task this is mostly used for closing staements.
//// 3. If the user enters "0" then it will display that the user cannot divide by 0.
//try
//{
//    Console.WriteLine("Enter a number");
//    int number = int.Parse(Console.ReadLine());
//    Console.WriteLine(10 / number);
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Cannot divide by 0");
//}
//catch (FormatException)
//{
//    Console.WriteLine("Invalid number format");
//}
//finally
//{
//    Console.WriteLine("Operation attempted");
//}

////    If the user enters "abc" it is not a valid integer value it is a different data type therefore it will return that the expected format is wrong. 
////    If the user enters "5" it will  use "5" as a denominator and then return a value. Note that with all of these the finally block will still execute.

////4.   It looks at that exception first when it compiles

////5.   Throw can throw any thing whereas throw ex is set for throwing an exception

////6.
//InvalidTemperatureException invTemp;
//Console.WriteLine(invTemp.ReadTemp());


////7. The finally block is guarenteed to run regardless. A good example would be when we close a file we use file.Close();

////8. Writing throw expressions
//private string _name;
//public string Name
//{
//    get => _name;
//    set => _name = value ?? throw new ArgumentNullException(nameof(value));
//}

////In a method
//public int GetValue(int? input) => input ?? throw new ArgumentNullEException(nameof(input));

//// In the null-coalescing operator
//string text = GetInput() ?? throw new InvalidOperationException("Input cannot be null");

////9. You should throw an excpetion when you expect the program to run into an error so it can then override it.

////10. Output of the ffg will be:
//try
//{
//    try
//    {
//        Console.Write("Enter value: ");
//        string input = Console.ReadLine();
//        if (string.IsNullOrEmpty(input))
//        {
//            throw new ArgumentNullException("input");
//        }
//    }
//    catch (FormatException)
//    {
//        Console.WriteLine("Format error");
//        throw; //rethrow
//    }
//}
//catch (ArgumentNullException ex)
//{
//    Console.WriteLine("Null input detected");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"General error: {ex.Message}");
//}
//finally
//{
//    Console.WriteLine("Done");
//}

////10.1 It will return it's null
////10.2 It will return "abc"
////10.3 It will return as a string

//Correction
//1.An exception is an unexpected or error condition during execution. If an exception is not handled, the program terminates immediately with an error message.
//The runtime looks up the call stack for a matching catch block
//— if none is found, the program crashes.

//2.try — wraps code that might throw an exception. If an exception occurs inside, execution jumps immediately to the matching catch block
//catch — handles a specific exception type. Multiple catch blocks can be chained, checked top to bottom — the first matching one runs, the rest are skipped
//finally — always runs regardless of whether an exception occurred or not. Used for cleanup like closing files or database connections
//Order of execution: try → catch (if exception) → finally (always)

//3. For the below:
//  When the code input is "0", it will throw a DivideByZeroException, which is caught by the first catch block, and the message
//  "Cannot divide by 0" is printed.
//  Then, the finally block executes, printing "Operation attempted".
//When the code input is "abc", it will throw a FormatException,
//which is caught by the second catch block, and the message
// When the code input is "5", it will successfully parse the number and perform the division,
// printing "2" to the console.
// Then, the finally block executes, printing "Operation attempted".

//try
//{
//    Console.WriteLine("Enter a number");
//    int number = int.Parse(Console.ReadLine());
//    Console.WriteLine(10 / number);
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Cannot divide by 0");
//}
//catch (FormatException)
//{
//    Console.WriteLine("Invalid number format");
//}
//finally
//{
//    Console.WriteLine("Operation attempted");
//}

//4. C# checks catch blocks from top to bottom and executes the first one that matches. If you put catch (Exception ex) first, it catches EVERYTHING — the more specific blocks below it like DivideByZeroException or FormatException will never be reached and the compiler warns you they are unreachable. Always go most specific → most general.
//catch(DivideByZeroException) { }  // most specific first
//catch (FormatException)       { }  // still specific
//catch (Exception ex)          { }  // catch-all LAST

//5.throw; — rethrows the exception while preserving the original stack trace. The debugger still shows exactly where the error originally happened
//throw ex; — rethrows but resets the stack trace to the current line, losing the original call site information. This makes debugging much harder

//catch (Exception ex)
//{
//    // Log it
//    throw;     // ✅ preserves original stack trace
//    // throw ex; ❌ destroys original stack trace
//}

//6. 
// Instantiate the components
//using StudyguidePractice;

/////*bool IsEven(int number) 
//TemperatureModel model = new TemperatureModel();
//TemperatureView view = new TemperatureView();

//// Pass the model and view into the controller
//TemperatureController controller = new TemperatureController(model, view);

//// Execute the application logic
//controller.Run();

//7.The finally block is guarenteed to run regardless. A good example would be when we close a file we use file.Close();
//SqlConnection conn = new SqlConnection(connectionString);
//try
//{
//    conn.Open();
//    // do database work
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"DB Error: {ex.Message}");
//}
//finally
//{
//    conn.Close(); // ALWAYS closes even if exception occurred
//}

//8.
// Property setter
//using System.Xml.Linq;

/////*bool IsEven(int number) 
//private string _name = string.Empty;
//public string Name
//{
//    get => _name;
//    set => _name = value ?? throw new ArgumentNullException(nameof(value));
//}

//// Expression-bodied method
//public int GetValue(int? input) =>
//    input ?? throw new ArgumentNullException(nameof(input));

//// Null-coalescing
//string text = GetInput() ?? throw new InvalidOperationException("Input cannot be null");

//9.
/*
 Throw when:

Input validation fails at a public method boundary (ArgumentNullException, ArgumentException)
An object is in an invalid state for an operation (InvalidOperationException)
A condition is truly unexpected and cannot be recovered from locally

Do NOT throw when:

Controlling normal program flow (don't use exceptions instead of if/else)
The situation is expected and can be handled with a simple check
Performance matters — exceptions are expensive to create and throw
 */

//10.
//try                              // OUTER try
//{
//    try                          // INNER try
//    {
//        Console.Write("Enter value: ");
//        string input = Console.ReadLine();
//        if (string.IsNullOrEmpty(input))
//            throw new ArgumentNullException("input");
//    }
//    catch (FormatException)      // INNER catch - only catches FormatException
//    {
//        Console.WriteLine("Format error");
//        throw;
//    }
//}
//catch (ArgumentNullException ex) // OUTER catch 1
//{
//    Console.WriteLine("Null input detected");
//}
//catch (Exception ex)             // OUTER catch 2
//{
//    Console.WriteLine($"General error: {ex.Message}");
//}
//finally
//{
//    Console.WriteLine("Done");
//}

////10.1 If the user enters nothing and just presses Enter, it will throw an ArgumentNullException, which is caught by the outer catch block, printing "Null input detected".
////Then the finally block executes, printing "Done".

////10.2. If the user enters "abc", it will throw a FormatException, which is caught by the inner catch block, printing "Format error".
////Then it rethrows the exception, which is caught by the outer catch block, printing "General error: Input string was not in a correct format."
////Finally, the finally block executes, printing "Done".

////10.3.User types "42", it successfully parses the number and does not throw any exceptions, so neither catch block executes.









// 1. Get your connection string
using StudyguidePractice;

///*bool IsEven(int number) 
///*bool IsEven(int number) 

///Topic 6

///1. A Data Access Layer (DAL) is a layer of code that handles the interaction with the database or any data source. 
///   It is responsible for performing CRUD (Create, Read, Update, Delete) operations on the data. Separating the DAL from business logic is important because it promotes separation of concerns, making the code more modular and maintainable. It allows developers to change the data access implementation without affecting the business logic, and vice versa. 
///   This separation also makes it easier to test each layer independently.

///2. A connection string is a string that specifies information about a data source and how to connect to it. 
///Server=(localdb)\MSSQLLocalDB;Database=SkyFlowDB;
///Trusted_Connection = True; TrustServerCertificate = True;
///   Three common pieces of information found in a SQL Server connection string are:
/// - Server name or address
/// - Database name
/// - Authentication details (such as username and password)

/// 3. In raw ADO.NET, the "boilerplate problem" refers to the repetitive and verbose code that developers have to write for every database operation. 
/// This includes tasks such as: 
/// - Creating and opening a database connection  
/// - Creating a command object
/// - Executing the command
/// - Reading the results
/// - Closing the connection

/// 4. The using statement is critical when working with database connections because it ensures that the connection is properly closed and disposed of, even if an exception occurs. If you forget to use it, 
/// you might end up with open connections that are not released back to the connection pool, 
/// which can lead to resource leaks and eventually exhaust the available connections, 
/// causing your application to fail when trying to connect to the database.

/// 5. Dapper is a micro-ORM (Object-Relational Mapper) that provides a simple and efficient way to execute SQL queries and map the results to C# objects. 
///    It solves the boilerplate problem by using extension methods on the IDbConnection interface,allowing developers to write concise code for executing queries and mapping results without having to manually create command objects, execute them, and read results. 
///    Dapper uses dynamic code generation and caching to maintain high performance, 
///    making it one of the fastest ORMs available while still providing a simple API for data access.

/// 6. To install the Dapper NuGet package using the .NET CLI, you can run the following command in your terminal: dotnet add package Dapper
/// To use Dapper's extension methods, include the following using directive in your C# file:
/// using Dapper;


/// 7. Given a Product class with ProductID, ProductName, and UnitPrice properties, write a Dapper query that retrieves all products and maps them to a List<Product>. 
//Error here for GetAllProducts();
//// 1. Get your connection string
//var connectionString = "Server=YOUR_SERVER;Database=InventoryDb;Trusted_Connection=True;";

//// 2. Instantiate the repository
//var repository = new ProductRepository(connectionString);

//// 3. Call the method
//var myProducts = repository.GetAllProducts();

//// 4. Use the data
//foreach (var product in myProducts)
//{
//    Console.WriteLine(product.Name);
//}

/// 8. - QueryFirstOrDefault<T> returns the first row of the result set, or the default value if no rows are returned. 
/// It   does not throw an exception if multiple rows are returned. Use when You expect 0 or 1 results — e.g. search by ID that might not exist


/// - QuerySingle<T> expects exactly one row to be returned. If no rows are returned, it throws an exception.
/// If more than one row is returned, it also throws an exception. Use when You expect EXACTLY 1 result — e.g. looking up a unique config value

/// 9. Dapper handles SQL parameters by allowing you to pass an anonymous object with properties that match the parameter names in your SQL query. 
///    This approach is safer than string concatenation because it automatically handles escaping and prevents SQL injection attacks.

/// 10. Write a Dapper method that inserts a new Product and returns the auto-generated identity value. Include the SQL and the C# code.
/// 
//var repo = new ProductRepository(connectionString);

//// Create a new object
//var newProduct = new Product
//{
//    Name = "Webcam",
//    Description = "1080p HD",
//    Price = 45.00m,
//    StockQuantity = 20
//};

//// Use the repo to save it
//int newId = repo.AddProduct(newProduct);

//Console.WriteLine($"Product added successfully with ID: {newId}");

/// 11. Dapper's Execute method returns the number of rows affected by the command. You can use this return value to verify that an update was successful by checking if it is greater than 0, which indicates that at least one row was updated. 
///     A good example of this is when you execute an update statement and want to confirm that the intended record was updated.
//Error connectionString(),ProductName,UnitPrice 
//// 1. Initialize your repository
//var repo = new ProductRepository(connectionString);

//// 2. Fetch the product you want to update 
//// (e.g., let's say we are updating the product with ID 1)
//var productToUpdate = repo.GetProductById(1);

//if (productToUpdate != null)
//{
//    // 3. Modify the properties
//    productToUpdate.ProductName = "Updated Laptop Name";
//    productToUpdate.UnitPrice = 1150.00m;

//    // 4. Send the updated object to the repository
//    bool wasUpdated = repo.UpdateProduct(productToUpdate);

//    if (wasUpdated)
//    {
//        Console.WriteLine("Update successful!");
//    }
//    else
//    {
//        Console.WriteLine("Update failed (Product might not exist).");
//    }
//}
//else
//{
//    Console.WriteLine("Product not found, cannot update.");
//}

/// 12. Write a Dapper method that updates the price of a product. Use parameters and show  the complete method. 
/*Separation of concerns — database code is in one place, business logic doesn't know or care how data is stored
Testability — you can swap SqlRepository for a fake/mock repository during unit testing without changing any business logic
Maintainability — if the database changes, only the repository needs updating
 */

/// 13. The repository pattern is a design pattern that provides a way to separate the data access logic from the business logic in an application. 
///     It acts as an intermediary between the data source and the business logic, allowing for more modular and maintainable code.

///14.  Accepting the connection string in the constructor rather than hard-coding it is a best practice because it promotes flexibility and separation of concerns.
/*— security. Hard-coding a connection string means it's visible in your source code and could end up in version control (GitHub etc.) 
 * where anyone can see your database credentials. Passing it in means it can come from a config file or environment variable that is kept secret.
 */

///15. Write a complete CustomerRepository class with the following methods (assume a Customer class with CustomerID, FirstName, LastName, Email; Includeproper using statements and connection management.): 
// GetById(int id) – returns a single customer. 
// GetAll() – returns all customers. 
// Add(Customer customer) – inserts a new customer and returns the new ID.
// Update(Customer customer) – updates an existing customer,returns bool indicating success. 
// Delete(int id) – deletes a customer, returns bool indicating success.
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
