<<<<<<< HEAD
﻿/*Exercise 1 – Customer Service Call Centre
Scenario: A call centre in Johannesburg handles customer calls. Calls arrive at random times and are placed in a single queue. Agents pick the next call from the front of the queue when they become free.
Tasks:
1. Represent the call queue using a queue data structure.
2. Write a function AddCall(callId) that adds a new call to the queue.
3. Write a function AnswerCall() that removes and returns the next call to be answered.
4. Write a function ShowWaitingCalls() that displays all waiting call IDs without removing them.
5. Simulate 5 calls arriving (e.g., call IDs: “C001”, “C002”, …), then answer 3 of them. Print each action.
 */

//// Create a queue to represent the call queue
//Queue<string> callQueue = new Queue<string>();


//// Function to add a new call to the queue
//void AddCall(string callId) 
//{
//    // Add the call ID to the queue
//    callQueue.Enqueue(callId);
//}

//// Function to answer the next call in the queue
//string AnswerCall() 
//{
//    // Check if there are calls in the queue
//    if (callQueue.Count>0) 
//    {
//        // Remove and return the next call ID from the front of the queue
//        return callQueue.Dequeue();
//    }
//    else
//    {
//        // If there are no calls to answer, return a message
//        return "No calls to answer";
//    }
//}

//// Function to show all waiting call IDs without removing them
//void ShowWaitingCalls() 
//{
//    // Check if there are calls in the queue
//    if (callQueue.Count>0) 
//    {
//        // Display all waiting call IDs without removing them
//        foreach (string callId in callQueue) 
//        {
//            Console.WriteLine(callId);
//        }
//    }
//    else
//    {
//        // If there are no waiting calls, display a message
//        Console.WriteLine("No waiting calls");
//    }

//    //Why does this make sense for callId in callQueue? Because callQueue is a queue data structure that stores the call IDs in the order they were added.
//    //When we use a foreach loop to iterate over callQueue, we can access each call ID in the order they were added without removing them from the queue.
//    //This allows us to display all waiting call IDs without affecting the state of the queue.
//}

//// Simulate 5 calls arriving
//// Do i use a user input or these fixed values for the above?
////You can use fixed values for the simulation of the 5 calls arriving, as specified in the exercise.
////This will allow you to demonstrate the functionality of your queue without requiring user input.
////Here's how you can simulate the calls and answer some of them:

////Okay lets do it the array first and then we can do the user input after that.

//// with array of fixed call IDs
//string[] callsId = {"C001", "C002", "C003", "C004", "C005" };

//// Add the calls to the queue and print each action
//foreach (string calls in callsId) 
//{
//    AddCall(calls);
//    Console.WriteLine($"Added call: {calls}");
//}

////or with for loop
//{
//    string callId = $"C00{i}";
//    AddCall(callId);
//    Console.WriteLine($"Added call: {callId}"); 

//}*/

//// with user input
//Console.WriteLine("Enter 5 call IDs (e.g., C001, C002, ...):");
//string callsID = Console.ReadLine();


/*Exercise 2 – Printer Job Queue at a School
Scenario: A school computer lab has one printer. Students submit print jobs. Each job has a student name and a number of pages. The printer processes jobs in first-come, first-served order.
Tasks:
1. Create a PrintJob class with properties StudentName (e.g., “Thabo”, “Lerato”) and PageCount. 
2. Implement a queue that holds PrintJob objects.
3. Write SubmitJob(PrintJob job) to add a job to the queue.
4. Write ProcessNextJob() that removes and returns the next job, and prints a message like "Printing [StudentName]'s job ([PageCount] pages)".
5. Add three jobs, then process them one by one until the queue is empty.
 */

//using QueueExercises;
//// Create a queue to hold PrintJob objects
//Console.WriteLine("Enter student name:");
//string studentName = Console.ReadLine();
//Console.WriteLine("Enter number of pages: ");
//int pageCount = int.Parse(Console.ReadLine());

//Queue<PrintJob> printQueue = new Queue<PrintJob>();

//// Function to submit a new print job to the queue
//void submitJob(PrintJob job) 
//{
//    Console.WriteLine($"Submitting job for {job.Name} with {job.PageCount} pages.");
//    printQueue.Enqueue(job);
//}

//// Function to process the next job in the queue
//void ProcessNextJob() 
//{
//    if (printQueue.Count > 0) 
//    {
//        PrintJob nextJob = printQueue.Dequeue();
//        Console.WriteLine($"Printing {nextJob.Name}'s job ({nextJob.PageCount} pages).");
//    }
//    else
//    {
//        Console.WriteLine("No jobs to process.");
//    }
//}

//// Add three jobs to the queue
//submitJob(new PrintJob("Thabo", 10));
//submitJob(new PrintJob("Lerato", 5));
//submitJob(new PrintJob("Sipho", 15));
//// Process the jobs one by one until the queue is empty
//// why is there four process next job calls?
//// Because we have three jobs in the queue, and we want to process them one by one until the queue is empty.
//// The fourth call to ProcessNextJob() is to demonstrate that when the queue is empty, it will print a message indicating that there are no jobs to process.
//// This helps to show that the function handles the case of an empty queue gracefully.
//ProcessNextJob();
//ProcessNextJob();
//ProcessNextJob();
//ProcessNextJob();
//ProcessNextJob();

/*Exercise 3 – Ticket Booth at a Concert
Scenario: People line up to buy tickets at a single booth. Each person has a name and wants to buy a certain number of tickets. The booth sells tickets one at a time. After buying
one ticket, the person goes to the back of the queue if they still need more tickets. This is known as a circular / re-queue process.
Tasks:
1. Represent each person as an object with Name (use South African names like “Thabo”, “Lerato”, “Sipho”, “Naledi”) and TicketsNeeded.
2. Simulate the process:
o Dequeue the first person.
o They buy one ticket (decrease TicketsNeeded by 1).
o If TicketsNeeded > 0, re-enqueue that person.
o If TicketsNeeded == 0, they leave and are not re-added.
3. Continue until the queue is empty.
4. Print each transaction, e.g., "Thabo bought a ticket, still needs 2", "Lerato bought a ticket and finished".
Example initial queue: [Thabo:2, Lerato:1, Sipho:4]
 */

using QueueExercises;

string [] names = { "Thabo", "Lerato", "Sipho", "Naledi" };
Queue<Person> ticketQueue = new Queue<Person>();
// Simulate the process of people buying tickets
foreach (string name in names)
{
    Console.WriteLine($"Enter the number of tickets {name} needs:");
    int ticketsNeeded = int.Parse(Console.ReadLine());
    ticketQueue.Enqueue(new Person { Name = name, TicketsNeeded = ticketsNeeded });

=======
﻿/*Exercise 1 – Customer Service Call Centre
Scenario: A call centre in Johannesburg handles customer calls. Calls arrive at random times and are placed in a single queue. Agents pick the next call from the front of the queue when they become free.
Tasks:
1. Represent the call queue using a queue data structure.
2. Write a function AddCall(callId) that adds a new call to the queue.
3. Write a function AnswerCall() that removes and returns the next call to be answered.
4. Write a function ShowWaitingCalls() that displays all waiting call IDs without removing them.
5. Simulate 5 calls arriving (e.g., call IDs: “C001”, “C002”, …), then answer 3 of them. Print each action.
 */

//// Create a queue to represent the call queue
//Queue<string> callQueue = new Queue<string>();


//// Function to add a new call to the queue
//void AddCall(string callId) 
//{
//    // Add the call ID to the queue
//    callQueue.Enqueue(callId);
//}

//// Function to answer the next call in the queue
//string AnswerCall() 
//{
//    // Check if there are calls in the queue
//    if (callQueue.Count>0) 
//    {
//        // Remove and return the next call ID from the front of the queue
//        return callQueue.Dequeue();
//    }
//    else
//    {
//        // If there are no calls to answer, return a message
//        return "No calls to answer";
//    }
//}

//// Function to show all waiting call IDs without removing them
//void ShowWaitingCalls() 
//{
//    // Check if there are calls in the queue
//    if (callQueue.Count>0) 
//    {
//        // Display all waiting call IDs without removing them
//        foreach (string callId in callQueue) 
//        {
//            Console.WriteLine(callId);
//        }
//    }
//    else
//    {
//        // If there are no waiting calls, display a message
//        Console.WriteLine("No waiting calls");
//    }

//    //Why does this make sense for callId in callQueue? Because callQueue is a queue data structure that stores the call IDs in the order they were added.
//    //When we use a foreach loop to iterate over callQueue, we can access each call ID in the order they were added without removing them from the queue.
//    //This allows us to display all waiting call IDs without affecting the state of the queue.
//}

//// Simulate 5 calls arriving
//// Do i use a user input or these fixed values for the above?
////You can use fixed values for the simulation of the 5 calls arriving, as specified in the exercise.
////This will allow you to demonstrate the functionality of your queue without requiring user input.
////Here's how you can simulate the calls and answer some of them:

////Okay lets do it the array first and then we can do the user input after that.

//// with array of fixed call IDs
//string[] callsId = {"C001", "C002", "C003", "C004", "C005" };

//// Add the calls to the queue and print each action
//foreach (string calls in callsId) 
//{
//    AddCall(calls);
//    Console.WriteLine($"Added call: {calls}");
//}

////or with for loop
//{
//    string callId = $"C00{i}";
//    AddCall(callId);
//    Console.WriteLine($"Added call: {callId}"); 

//}*/

//// with user input
//Console.WriteLine("Enter 5 call IDs (e.g., C001, C002, ...):");
//string callsID = Console.ReadLine();


/*Exercise 2 – Printer Job Queue at a School
Scenario: A school computer lab has one printer. Students submit print jobs. Each job has a student name and a number of pages. The printer processes jobs in first-come, first-served order.
Tasks:
1. Create a PrintJob class with properties StudentName (e.g., “Thabo”, “Lerato”) and PageCount. 
2. Implement a queue that holds PrintJob objects.
3. Write SubmitJob(PrintJob job) to add a job to the queue.
4. Write ProcessNextJob() that removes and returns the next job, and prints a message like "Printing [StudentName]'s job ([PageCount] pages)".
5. Add three jobs, then process them one by one until the queue is empty.
 */

//using QueueExercises;
//// Create a queue to hold PrintJob objects
//Console.WriteLine("Enter student name:");
//string studentName = Console.ReadLine();
//Console.WriteLine("Enter number of pages: ");
//int pageCount = int.Parse(Console.ReadLine());

//Queue<PrintJob> printQueue = new Queue<PrintJob>();

//// Function to submit a new print job to the queue
//void submitJob(PrintJob job) 
//{
//    Console.WriteLine($"Submitting job for {job.Name} with {job.PageCount} pages.");
//    printQueue.Enqueue(job);
//}

//// Function to process the next job in the queue
//void ProcessNextJob() 
//{
//    if (printQueue.Count > 0) 
//    {
//        PrintJob nextJob = printQueue.Dequeue();
//        Console.WriteLine($"Printing {nextJob.Name}'s job ({nextJob.PageCount} pages).");
//    }
//    else
//    {
//        Console.WriteLine("No jobs to process.");
//    }
//}

//// Add three jobs to the queue
//submitJob(new PrintJob("Thabo", 10));
//submitJob(new PrintJob("Lerato", 5));
//submitJob(new PrintJob("Sipho", 15));
//// Process the jobs one by one until the queue is empty
//// why is there four process next job calls?
//// Because we have three jobs in the queue, and we want to process them one by one until the queue is empty.
//// The fourth call to ProcessNextJob() is to demonstrate that when the queue is empty, it will print a message indicating that there are no jobs to process.
//// This helps to show that the function handles the case of an empty queue gracefully.
//ProcessNextJob();
//ProcessNextJob();
//ProcessNextJob();
//ProcessNextJob();
//ProcessNextJob();

/*Exercise 3 – Ticket Booth at a Concert
Scenario: People line up to buy tickets at a single booth. Each person has a name and wants to buy a certain number of tickets. The booth sells tickets one at a time. After buying
one ticket, the person goes to the back of the queue if they still need more tickets. This is known as a circular / re-queue process.
Tasks:
1. Represent each person as an object with Name (use South African names like “Thabo”, “Lerato”, “Sipho”, “Naledi”) and TicketsNeeded.
2. Simulate the process:
o Dequeue the first person.
o They buy one ticket (decrease TicketsNeeded by 1).
o If TicketsNeeded > 0, re-enqueue that person.
o If TicketsNeeded == 0, they leave and are not re-added.
3. Continue until the queue is empty.
4. Print each transaction, e.g., "Thabo bought a ticket, still needs 2", "Lerato bought a ticket and finished".
Example initial queue: [Thabo:2, Lerato:1, Sipho:4]
 */

using QueueExercises;

string [] names = { "Thabo", "Lerato", "Sipho", "Naledi" };
Queue<Person> ticketQueue = new Queue<Person>();
// Simulate the process of people buying tickets
foreach (string name in names)
{
    Console.WriteLine($"Enter the number of tickets {name} needs:");
    int ticketsNeeded = int.Parse(Console.ReadLine());
    ticketQueue.Enqueue(new Person { Name = name, TicketsNeeded = ticketsNeeded });

>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
}