// what is a stack?
// Stack is a type pf data structure that follows the principle last in forst out(LIFO)

//Creating a stack

//empty stack of integers
//Stack<int> numbers = new Stack<int>();

//// stack woth intial capacity
//Stack<string> history = new Stack<string>(50);

//// Stack initialized with elements
//Stack<string> browserBackStack = new Stack<string>(new[] { "Page1", "Page2", "Page 3" });

//Push() - Adding an element to the top of the stack

//Pop() - Removing and returning the element at the top of the stack
//Peek() - Returns the element at the top of the stack without removing it

// Create a stack of strings
Stack<string> stack = new Stack<string>();

// Push items onto the stack
stack.Push("First");
stack.Push("Second");
stack.Push("Third");

Console.WriteLine("Stack contents:");
foreach (var item in stack)
{
    Console.WriteLine(item);
}

// Peek at the top item
Console.WriteLine($"\nTop of stack: {stack.Peek()}");

// Pop items off the stack
Console.WriteLine($"\nPopped: {stack.Pop()}");
Console.WriteLine($"Popped: {stack.Pop()}");

// Remaining items
Console.WriteLine("\nRemaining stack:");
foreach (var item in stack)
{
    Console.WriteLine(item);
}

