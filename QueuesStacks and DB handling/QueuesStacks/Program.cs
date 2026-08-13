//// Bringing in the custom namespace 'QueuesStacks' where the Customer class is defined
//using QueuesStacks;

//// ============================================================================
//// PART 1: WORKING WITH A CUSTOM OBJECT QUEUE
//// ============================================================================

//// Instantiating a generic Queue collection specifically strongly-typed to hold 'Customer' objects.
//// Queues operate on a FIFO (First-In, First-Out) basis.
//Queue<Customer> customers = new Queue<Customer>();

//// Instantiating three distinct Customer objects using the parameterized constructor (passing Name and Age)
//Customer customer1 = new Customer("Alice", 30);
//Customer customer2 = new Customer("Bob", 25);
//Customer customer3 = new Customer("Charlie", 35);

//// Enqueueing adds items to the tail/end of the queue.
//// The sequence order inside the queue structure becomes: [Alice] -> [Bob] -> [Charlie]
//customers.Enqueue(customer1);
//customers.Enqueue(customer2);
//customers.Enqueue(customer3);

//// A while loop configured to execute continuously as long as the collection contains items (Count is greater than 0)
//while (customers.Count > 0)
//{
//    // Dequeue removes and returns the object sitting at the head/front of the queue (First-In, First-Out).
//    // Note: This loop extracts the objects but does not display output to the console.
//    customers.Dequeue();
//}

//// ============================================================================
//// PART 2: WORKING WITH A STANDARD STRING QUEUE WITH CONSOLE VERIFICATION
//// ============================================================================

//// Instantiating a generic Queue strongly-typed to store primitive 'string' values
//Queue<string> customerQueue = new Queue<string>();

//// Appending raw string literals onto the back of the queue sequence
//customerQueue.Enqueue("Alice");   // Position 1 (Head)
//customerQueue.Enqueue("Bob");     // Position 2
//customerQueue.Enqueue("Charlie"); // Position 3 (Tail)

//// Simulating a system processor that clears out the waiting queue sequentially
//while (customerQueue.Count > 0)
//{
//    // Dequeue() retrieves the front string item ("Alice" first, then "Bob", then "Charlie") and assigns it to 'customer'
//    string customer = customerQueue.Dequeue();

//    // Utilizing string interpolation ($"") to output processing updates directly to the console interface
//    Console.WriteLine($"Serving {customer}");

//    // Dynamically tracks the declining line count via the collection's 'Count' property as items get permanently cleared
//    Console.WriteLine($"Customers Waiting: {customerQueue.Count}");
//}

//// ============================================================================
//// PART 3: APPLICATION STABILITY & CRASH PREVENTION (TRY-CATCH)
//// ============================================================================

//try
//{
//    // Block targeted for risky input/output (I/O) transactions or operations prone to runtime vulnerabilities.
//    // Place logic here to create, read, update, or delete (CRUD) data involving an external data layer or local DB.
//}
//catch (Exception ex)
//{
//    // Intercepts any thrown Exception or system failure that took place inside the preceding 'try' block.
//    // Captures the exception details in the variable 'ex' and logs the system-generated message to protect software flow.
//    Console.WriteLine($"An error occurred: {ex.Message}");
//}

using QueuesStacks;

var connectionString = "Server=localhost;Database=ProductsDb;Trusted_Connection=True;";
SqlProductRepository sqlProductRepository = new SqlProductRepository(connectionString);



bool exitApplication = false;

while(exitApplication == false)
{
    Console.Clear();

    Console.WriteLine("Product Management System");
    Console.WriteLine("=========================");
    Console.WriteLine("1. Manage Categories");
    Console.WriteLine("2. Manage Products");
    Console.WriteLine("3. Exit");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1": 
            ManageCategory(); 
            break;
        case "2": 
            ManageProducts();
            break;
        case "3":
            exitApplication = true; 
            break;

    }


}

void ManageCategory() 
{
    Console.Clear();
    Console.WriteLine("Category Management");
    Console.WriteLine("===================");
    Console.WriteLine("1. View Categories");
    Console.WriteLine("2. Add Category");
    Console.WriteLine("3. Update Category");
    Console.WriteLine("4. Delete Category");
    Console.WriteLine("5. Back to Main Menu");

    string input = Console.ReadLine();
    switch (input) 
    {
        case "1": var categories = sqlProductRepository.GetAllCategories();
            foreach (var category in categories) 
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}, Description: {category.Description}");
            }
            break;
        case "2":
            Console.WriteLine("Enter category name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter category description:");
            string description = Console.ReadLine();
            break;
        case "3":
            Console.WriteLine("Enter cateegory ID to update:");
            int updateId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new category name:");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter new category description:");
            string newDescription = Console.ReadLine();
            break;
        case "4":
            Console.WriteLine("Are you sure you want to delete(y/n)");
            string confirmation = Console.ReadLine();
            if (confirmation.ToLower() == "y")
            {
                Console.WriteLine("Enter category ID to delete:");
                int deleteId = int.Parse(Console.ReadLine());
            }
            else 
            {
                Console.WriteLine("Deletion cancelled.");
            }
                break;
        case "5": 
            return;
            


    }
}

void ManageProducts()
{
    Console.Clear();
    Console.WriteLine("Product Management");
    Console.WriteLine("===================");
    Console.WriteLine("1. View Products");
    Console.WriteLine("2. Add Product");
    Console.WriteLine("3. Update Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Back to Main Menu");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            var products = sqlProductRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Category ID: {product.CategoryId}");
            }
            break;

        case "2":
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter category ID for the product:");
            int categoryId = int.Parse(Console.ReadLine());
            break;

        case "3": 
            Console.WriteLine("Enter product ID to update:");
            int updateId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new product name:");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter new product price:");
            decimal newPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter new category ID for the product:");
            int newCategoryId = int.Parse(Console.ReadLine());
            break; 
        
        case "4":
            Console.WriteLine("Enter product ID to delete:");
            int deleteId = int.Parse(Console.ReadLine());
            break;

        case "5": return;

    }
}



