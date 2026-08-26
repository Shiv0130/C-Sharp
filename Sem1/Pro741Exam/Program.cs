<<<<<<< HEAD
﻿//Question 1:
// Explain value tyoes in C# and provide example(5 marks).
// In C#, value types are data types that hold their value directly in memory.
// They are typically stored on the stack, which allows for efficient memory allocation and deallocation.
// Value types include simple types like integers, floating-point numbers, and structures.
// When a value type is assigned to another variable, a copy of the value is made, meaning that changes to one variable do not affect the other.
// Example of value types in C#:
using Pro741Exam;

int x = 0; // x is a value type (int)
double y = 3.14; // y is a value type (double)

// Question 2:
// What is the purpose of the virtual and override keywords in C#? Explain how they enable
//polymorphism and provide a brief code example(5 marks).

// The virtual keyword in C# is used to declare a method or property in a base class that can be overridden in derived classes.
// It allows derived classes to provide their own implementation of the method or property, enabling polymorphism.
// The override keyword is used in the derived class to indicate that it is providing a new implementation for a virtual method or property defined in the base class.

//Question 3: Describe the null‑conditional operator ( ?. ) and the null‑coalescing operator ( ?? ).
// The null-conditional operator (?.) is used to perform member access or method invocation on an object only if that object is not null.
// If the object is null,
// the operation returns null instead of throwing a NullReferenceException.
// This helps to avoid null reference errors in code.

//4: What is an interface in C#? How does it differ from an abstract class? Provide a scenario where using
//an interface is more appropriate than using an abstract class.
// A interface is a contract that defines a set of methods,properties,events, or indexers that a class or struct must implement.
// It does not provide any implementation itself. Abstract classes, on the other hand, can provide both method signatures and implementations,
// allowing derived classes to inherit and override them.

//5.Explain the concept of encapsulation in object‑oriented programming. How do access modifiers like
//private , protected , and public support encapsulation? Provide a brief example.*/
// In terms of encapsulation, it is a fundamental principle of object-oriented programming that restricts direct access to an object's internal state and behavior.
// private access modifier allows members of a class to be accessed only within that class, preventing external code from modifying the internal state directly.
//protected access modifier allows members to be accessed within the class and by derived classes, providing controlled access to the internal state.
//public access modifier allows members to be accessed from any code, providing full access to the internal state.

//6. What is the difference between a List<T> and an Array in C#? Describe at least two /scenarios
//where a List<T> would be preferred over an array.
// A List<T> is a generic collection that can dynamically resize itself, while an array has a fixed size once it is created.

//7. Explain the purpose of the finally block in exception handling. Provide a scenario where /a
//finally` block is essential for proper resource cleanup.
// The purpose of the finally block in exception handling is to ensure that a specific section of code is executed regardless of whether an exception occurs or not. 
// It is typically used for resource cleanup, such as closing file streams, releasing database connections, or freeing unmanaged resources.

//8. What is a Reference Type in C#? Provide one example.
// A Reference Type in C# is a data type that holds a reference to the actual data rather than the data itself. Reference types are typically stored on the heap, and when a reference type variable is assigned to another variable, both variables point to the same object in memory. Changes made through one variable will affect the other since they reference the same object.

//9. Describe the difference between a Queue<T> and a Stack<T> in C#. Provide a real‑world scenario for
//each data structure.
// The difference between a Queue<T> and Stack<T> in C# lies in their order of processing elements.
// A Queue<T> follows the First-In-First-Out (FIFO) principle, meaning that the first element added to the queue will be the first one to be removed.
// In contrast, a Stack<T> follows the Last-In-First-Out (LIFO) principle, meaning that the last element added to the stack will be the first one to be removed.

//10. What is Dapper and how does it reduce boilerplate code compared to raw ADO.NET? List two specific
//operations that Dapper simplifies.
// Dapper is a lightweight Object-Relational Mapping (ORM) library for .NET that simplifies data access by providing a simple API for executing SQL queries and mapping the results to C# objects.
// It reduces boilerplate code compared to raw ADO.NET by handling common tasks such as parameter binding, result mapping, and connection management automatically.


//11. Creating instances of the Book and DVD classes and demonstrating polymorphism through the CalculateFee method.

LibraryItem book  = new Book("The Great Gatsby", "F. Scott Fitzgerald", 180);
LibraryItem dvd = new DVD("Inception", "Christopher Nolan", 148);

book.CalculateFee(5); // Calls the overridden method in Book class
dvd.CalculateFee(5); // Calls the overridden method in DVD class

Console.WriteLine($"Book name:{book.Title},Book author:{book.Author},Book Fee: {book.CalculateFee(5)}");

Console.WriteLine($"DVD name:{dvd.Title},DVD Author:{dvd.Author},DVD Fee: {dvd.CalculateFee(5)}");

//Did not complete everything yet. So far theory and  and 1 code for classes done. 
// 5 more questions to go.
=======
﻿//Question 1:
// Explain value tyoes in C# and provide example(5 marks).
// In C#, value types are data types that hold their value directly in memory.
// They are typically stored on the stack, which allows for efficient memory allocation and deallocation.
// Value types include simple types like integers, floating-point numbers, and structures.
// When a value type is assigned to another variable, a copy of the value is made, meaning that changes to one variable do not affect the other.
// Example of value types in C#:
using Pro741Exam;

int x = 0; // x is a value type (int)
double y = 3.14; // y is a value type (double)

// Question 2:
// What is the purpose of the virtual and override keywords in C#? Explain how they enable
//polymorphism and provide a brief code example(5 marks).

// The virtual keyword in C# is used to declare a method or property in a base class that can be overridden in derived classes.
// It allows derived classes to provide their own implementation of the method or property, enabling polymorphism.
// The override keyword is used in the derived class to indicate that it is providing a new implementation for a virtual method or property defined in the base class.

//Question 3: Describe the null‑conditional operator ( ?. ) and the null‑coalescing operator ( ?? ).
// The null-conditional operator (?.) is used to perform member access or method invocation on an object only if that object is not null.
// If the object is null,
// the operation returns null instead of throwing a NullReferenceException.
// This helps to avoid null reference errors in code.

//4: What is an interface in C#? How does it differ from an abstract class? Provide a scenario where using
//an interface is more appropriate than using an abstract class.
// A interface is a contract that defines a set of methods,properties,events, or indexers that a class or struct must implement.
// It does not provide any implementation itself. Abstract classes, on the other hand, can provide both method signatures and implementations,
// allowing derived classes to inherit and override them.

//5.Explain the concept of encapsulation in object‑oriented programming. How do access modifiers like
//private , protected , and public support encapsulation? Provide a brief example.*/
// In terms of encapsulation, it is a fundamental principle of object-oriented programming that restricts direct access to an object's internal state and behavior.
// private access modifier allows members of a class to be accessed only within that class, preventing external code from modifying the internal state directly.
//protected access modifier allows members to be accessed within the class and by derived classes, providing controlled access to the internal state.
//public access modifier allows members to be accessed from any code, providing full access to the internal state.

//6. What is the difference between a List<T> and an Array in C#? Describe at least two /scenarios
//where a List<T> would be preferred over an array.
// A List<T> is a generic collection that can dynamically resize itself, while an array has a fixed size once it is created.

//7. Explain the purpose of the finally block in exception handling. Provide a scenario where /a
//finally` block is essential for proper resource cleanup.
// The purpose of the finally block in exception handling is to ensure that a specific section of code is executed regardless of whether an exception occurs or not. 
// It is typically used for resource cleanup, such as closing file streams, releasing database connections, or freeing unmanaged resources.

//8. What is a Reference Type in C#? Provide one example.
// A Reference Type in C# is a data type that holds a reference to the actual data rather than the data itself. Reference types are typically stored on the heap, and when a reference type variable is assigned to another variable, both variables point to the same object in memory. Changes made through one variable will affect the other since they reference the same object.

//9. Describe the difference between a Queue<T> and a Stack<T> in C#. Provide a real‑world scenario for
//each data structure.
// The difference between a Queue<T> and Stack<T> in C# lies in their order of processing elements.
// A Queue<T> follows the First-In-First-Out (FIFO) principle, meaning that the first element added to the queue will be the first one to be removed.
// In contrast, a Stack<T> follows the Last-In-First-Out (LIFO) principle, meaning that the last element added to the stack will be the first one to be removed.

//10. What is Dapper and how does it reduce boilerplate code compared to raw ADO.NET? List two specific
//operations that Dapper simplifies.
// Dapper is a lightweight Object-Relational Mapping (ORM) library for .NET that simplifies data access by providing a simple API for executing SQL queries and mapping the results to C# objects.
// It reduces boilerplate code compared to raw ADO.NET by handling common tasks such as parameter binding, result mapping, and connection management automatically.


//11. Creating instances of the Book and DVD classes and demonstrating polymorphism through the CalculateFee method.

LibraryItem book  = new Book("The Great Gatsby", "F. Scott Fitzgerald", 180);
LibraryItem dvd = new DVD("Inception", "Christopher Nolan", 148);

book.CalculateFee(5); // Calls the overridden method in Book class
dvd.CalculateFee(5); // Calls the overridden method in DVD class

Console.WriteLine($"Book name:{book.Title},Book author:{book.Author},Book Fee: {book.CalculateFee(5)}");

Console.WriteLine($"DVD name:{dvd.Title},DVD Author:{dvd.Author},DVD Fee: {dvd.CalculateFee(5)}");

//Did not complete everything yet. So far theory and  and 1 code for classes done. 
// 5 more questions to go.
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
