////15.
//using Dapper;
//using Microsoft.Data.SqlClient;
//using StudyguidePractice;

//namespace StudyguidePractice
//{
//    // Customer model - maps to the Customers table
//    public class Customer
//    {
//        public int CustomerId { get; set; }
//        public string FirstName { get; set; } = string.Empty;
//        public string LastName { get; set; } = string.Empty;
//        public string Email { get; set; } = string.Empty;
//    }

//    public class CustomerRepository
//    {
//        // Connection string injected via constructor
//        // NOT hard-coded - promotes flexibility and security
//        private readonly string _connectionString;

//        public CustomerRepository(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        // Helper - opens a new connection each time
//        private SqlConnection Connect() => new SqlConnection(_connectionString);


//        // ── GET SINGLE CUSTOMER BY ID ─────────────────────────
//        // QueryFirstOrDefault used because the customer
//        // might not exist - returns null instead of crashing
//        public Customer? GetById(int id)
//        {
//            using var conn = Connect();
//            return conn.QueryFirstOrDefault<Customer>(
//                "SELECT * FROM Customers WHERE CustomerId = @id",
//                new { id });
//        }


//        // ── GET ALL CUSTOMERS ─────────────────────────────────
//        // Query<T> returns IEnumerable - ToList() materialises it
//        public List<Customer> GetAll()
//        {
//            using var conn = Connect();
//            return conn.Query<Customer>(
//                "SELECT * FROM Customers ORDER BY LastName")
//                .ToList();
//        }


//        // ── ADD NEW CUSTOMER ──────────────────────────────────
//        // Returns the new auto-generated CustomerId
//        // SCOPE_IDENTITY() gets the ID SQL Server just created
//        public int Add(Customer customer)
//        {
//            using var conn = Connect();
//            const string sql = @"
//                INSERT INTO Customers (FirstName, LastName, Email)
//                VALUES (@FirstName, @LastName, @Email);
//                SELECT CAST(SCOPE_IDENTITY() AS INT)";

//            return conn.QuerySingle<int>(sql, new
//            {
//                customer.FirstName,
//                customer.LastName,
//                customer.Email
//            });
//        }


//        // ── UPDATE EXISTING CUSTOMER ──────────────────────────
//        // Execute returns rows affected
//        // > 0 means update was successful
//        // == 0 means CustomerId was not found
//        public bool Update(Customer customer)
//        {
//            using var conn = Connect();
//            const string sql = @"
//                UPDATE Customers
//                SET FirstName = @FirstName,
//                    LastName  = @LastName,
//                    Email     = @Email
//                WHERE CustomerId = @CustomerId";

//            return conn.Execute(sql, customer) > 0;
//        }


//        // ── DELETE CUSTOMER BY ID ─────────────────────────────
//        // Returns true if a row was deleted
//        // Returns false if no customer with that ID existed
//        public bool Delete(int id)
//        {
//            using var conn = Connect();
//            return conn.Execute(
//                "DELETE FROM Customers WHERE CustomerId = @id",
//                new { id }) > 0;
//        }
//    }
//}


//// ── USAGE EXAMPLE ─────────────────────────────────────────────
//string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=SkyFlowDB;" +
//                 "Trusted_Connection=True;TrustServerCertificate=True;";

//CustomerRepository repo = new CustomerRepository(connStr);

//// Add a new customer
//Customer newCustomer = new Customer
//{
//    FirstName = "Shivaar",
//    LastName = "Naidoo",
//    Email = "shivaar@email.com"
//};
//int newId = repo.Add(newCustomer);
//Console.WriteLine($"New customer ID: {newId}");

//// Get all customers
//List<Customer> all = repo.GetAll();
//foreach (Customer c in all)
//    Console.WriteLine($"{c.CustomerId} | {c.FirstName} {c.LastName} | {c.Email}");

//// Get single customer
//Customer? found = repo.GetById(1);
//if (found != null)
//    Console.WriteLine($"Found: {found.FirstName} {found.LastName}");

//// Update
//newCustomer.CustomerId = newId;
//newCustomer.Email = "updated@email.com";
//bool updated = repo.Update(newCustomer);
//Console.WriteLine($"Updated: {updated}");

//// Delete
//bool deleted = repo.Delete(newId);
//Console.WriteLine($"Deleted: {deleted}");