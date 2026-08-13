//Defining a queue of integers
using QueueYT;

Queue<int> myQueue = new Queue<int>();
//Enqueue - Adding elements to the queue
myQueue.Enqueue(1);
//Printing the elements in front of the queue
// peek() method is used to return the element at the front of the queue without removing it.
Console.WriteLine("Element at the front of the queue: {0} " + myQueue.Peek());
myQueue.Enqueue(2);
Console.WriteLine("Top value in the is: {0}",myQueue.Peek());
myQueue.Enqueue(3);
// Dequeue - Removing elements from the queue
//int queueItem = myQueue.Dequeue();
Console.WriteLine("Top value in the queue is : {0}", myQueue.Peek());

while (myQueue.Count>0) 
{
    Console.WriteLine("The front value {0} was removed from the queue", myQueue.Dequeue());
    //print the queue count
    Console.WriteLine("Current queue count is: {0}", myQueue.Count);
}

 Order[] RecievedOrdersFromBranch1() 
{
    Order[] orders = new Order[]
    {
        new Order(1, 5),
        new Order(2, 4),
        new Order(6, 10),
    };
    return orders;
}

 Order[] RecievedOrdersFromBranch2()
{
    Order[] orders = new Order[]
    {
        new Order(3, 5),
        new Order(4, 4),
        new Order(5, 10),
    };
    return orders;

}

// Why is it when i remove the Removeordersfrombranch2() it highlits all my text in red. Like there is issue with the code.
//I think it is because the method is not being used anywhere in the code. If you remove it, the compiler will not be able to find a reference to it and will throw an error.

Queue<Order> orderQueue = new Queue<Order>();

foreach (Order o in RecievedOrdersFromBranch1()) 
{
    // add each ordr to the queue
    orderQueue.Enqueue(o);
}

foreach (Order o in RecievedOrdersFromBranch2())
{
    // add each ordr to the queue
    orderQueue.Enqueue(o);
}

//as long as the queue is not empty
while (orderQueue.Count > 0) 
{
    // remove th order At the front of the queue
    // and store it in a variable called currentOrder
    Order currentOrder = orderQueue.Dequeue();
    //process the order
    currentOrder.ProcessOrder();
}
