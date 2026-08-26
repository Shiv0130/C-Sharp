<<<<<<< HEAD
﻿//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//namespace ExamDapperCRUD
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly string _connectionString;

//        public ProductRepository(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public IEnumerable<Product> GetAllProducts()
//        {
//            using (var connection = new SqlConnection(_connectionString)) 
//            { 
//                connection.Open();
//                return connection.Query<Product>("SELECT * FROM Products");
//            }
//        }
//        public int AddProduct(Product product) 
//        {
//            using (var connection = new SqlConnection(_connectionString)) 
//            {
//                connection.Open();
//                var addsql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int)";
//                return connection.QuerySingle<int>(addsql, product);

//            }

//        }

//        public bool UpdateProduct(Product product)
//        {
//            using (var connection = new SqlConnection(_connectionString))
//            {
//                connection.Open();
//                var updatesql = "UPDATE Products Set Name = @Name, Price = @Price , WHERE Id = @Id";
//                var rowsAffected = connection.Execute(updatesql, product);
//                return rowsAffected > 0;
//            }
//        }

//            public bool DeleteProduct(Product product) 
//        {
//            using (var connection = new SqlConnection(_connectionString)) 
//            {
//                connection.Open();
//                var deletesql = "DELETE FROM Products WHERE Id = @Id";
//                var rowsAffected = connection.Execute(deletesql, product);
//                return rowsAffected > 0;
//            }

//        }


//    }
//}

//correction
using Dapper;
// FIX: changed from System.Data.SqlClient to Microsoft.Data.SqlClient
// System.Data.SqlClient is obsolete in .NET 6+
// Microsoft.Data.SqlClient is the current supported package
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperCRUD
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        // Constructor: accepts connection string from outside
        // Best practice - never hard-code connection strings
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ── GET SINGLE PRODUCT BY ID ─────────────────────────
        // FIX: renamed from GetProduct(int id) to GetProductById(int id)
        // to match the interface definition
        // QueryFirstOrDefault returns null if no product found
        // instead of throwing an exception - safer
        public Product? GetProductById(int id)
        {
            // FIX: simplified using statement (no brackets needed in C# 8+)
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Product>(
                "SELECT * FROM Products WHERE Id = @id",
                new { id });
        }

        // ── GET ALL PRODUCTS ─────────────────────────────────
        // Query<Product> maps each row from the result set
        // directly to a Product object using property name matching
        public IEnumerable<Product> GetAllProducts()
        {
            // FIX: simplified using statement
            // FIX: removed connection.Open() - Dapper opens and closes
            // the connection automatically when you call Query/Execute
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>("SELECT * FROM Products").ToList();
        }

        // ── ADD NEW PRODUCT ───────────────────────────────────
        // Returns the auto-generated Id of the newly inserted row
        // SCOPE_IDENTITY() gets the last identity value inserted
        // in the current session
        public int AddProduct(Product product)
        {
            // FIX: simplified using statement
            using var connection = new SqlConnection(_connectionString);

            // FIX: added Stock to the INSERT - it is NOT NULL in the DB
            // so inserting without it causes a SQL error
            var sql = @"INSERT INTO Products (Name, Price, Stock) 
                        VALUES (@Name, @Price, @Stock); 
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

            // QuerySingle because INSERT + SCOPE_IDENTITY always
            // returns exactly one row with the new ID
            return connection.QuerySingle<int>(sql, product);
        }

        // ── UPDATE EXISTING PRODUCT ───────────────────────────
        // Returns true if at least one row was updated
        // Returns false if the Id was not found
        public bool UpdateProduct(Product product)
        {
            // FIX: simplified using statement
            using var connection = new SqlConnection(_connectionString);

            // FIX: removed the rogue comma before WHERE
            // Original: "SET Name = @Name, Price = @Price , WHERE Id = @Id"
            // The comma before WHERE caused a SQL syntax error
            var sql = @"UPDATE Products 
                        SET Name  = @Name, 
                            Price = @Price,
                            Stock = @Stock 
                        WHERE Id = @Id";

            // Execute returns the number of rows affected
            // > 0 means the update succeeded
            var rowsAffected = connection.Execute(sql, product);
            return rowsAffected > 0;
        }

        // ── DELETE PRODUCT BY ID ──────────────────────────────
        // FIX: changed parameter from Product product to int id
        // to match the interface - you only need the ID to delete
        // Returns true if a row was deleted
        // Returns false if no product with that Id existed
        public bool DeleteProduct(int id)
        {
            // FIX: simplified using statement
            using var connection = new SqlConnection(_connectionString);

            var sql = "DELETE FROM Products WHERE Id = @id";

            // Pass id as anonymous object so Dapper maps @id correctly
            var rowsAffected = connection.Execute(sql, new { id });
            return rowsAffected > 0;
        }
    }
=======
﻿//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//namespace ExamDapperCRUD
//{
//    public class ProductRepository : IProductRepository
//    {
//        private readonly string _connectionString;

//        public ProductRepository(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public IEnumerable<Product> GetAllProducts()
//        {
//            using (var connection = new SqlConnection(_connectionString)) 
//            { 
//                connection.Open();
//                return connection.Query<Product>("SELECT * FROM Products");
//            }
//        }
//        public int AddProduct(Product product) 
//        {
//            using (var connection = new SqlConnection(_connectionString)) 
//            {
//                connection.Open();
//                var addsql = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int)";
//                return connection.QuerySingle<int>(addsql, product);

//            }

//        }

//        public bool UpdateProduct(Product product)
//        {
//            using (var connection = new SqlConnection(_connectionString))
//            {
//                connection.Open();
//                var updatesql = "UPDATE Products Set Name = @Name, Price = @Price , WHERE Id = @Id";
//                var rowsAffected = connection.Execute(updatesql, product);
//                return rowsAffected > 0;
//            }
//        }

//            public bool DeleteProduct(Product product) 
//        {
//            using (var connection = new SqlConnection(_connectionString)) 
//            {
//                connection.Open();
//                var deletesql = "DELETE FROM Products WHERE Id = @Id";
//                var rowsAffected = connection.Execute(deletesql, product);
//                return rowsAffected > 0;
//            }

//        }


//    }
//}

//correction
using Dapper;
// FIX: changed from System.Data.SqlClient to Microsoft.Data.SqlClient
// System.Data.SqlClient is obsolete in .NET 6+
// Microsoft.Data.SqlClient is the current supported package
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperCRUD
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        // Constructor: accepts connection string from outside
        // Best practice - never hard-code connection strings
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ── GET SINGLE PRODUCT BY ID ─────────────────────────
        // FIX: renamed from GetProduct(int id) to GetProductById(int id)
        // to match the interface definition
        // QueryFirstOrDefault returns null if no product found
        // instead of throwing an exception - safer
        public Product? GetProductById(int id)
        {
            // FIX: simplified using statement (no brackets needed in C# 8+)
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Product>(
                "SELECT * FROM Products WHERE Id = @id",
                new { id });
        }

        // ── GET ALL PRODUCTS ─────────────────────────────────
        // Query<Product> maps each row from the result set
        // directly to a Product object using property name matching
        public IEnumerable<Product> GetAllProducts()
        {
            // FIX: simplified using statement
            // FIX: removed connection.Open() - Dapper opens and closes
            // the connection automatically when you call Query/Execute
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>("SELECT * FROM Products").ToList();
        }

        // ── ADD NEW PRODUCT ───────────────────────────────────
        // Returns the auto-generated Id of the newly inserted row
        // SCOPE_IDENTITY() gets the last identity value inserted
        // in the current session
        public int AddProduct(Product product)
        {
            // FIX: simplified using statement
            using var connection = new SqlConnection(_connectionString);

            // FIX: added Stock to the INSERT - it is NOT NULL in the DB
            // so inserting without it causes a SQL error
            var sql = @"INSERT INTO Products (Name, Price, Stock) 
                        VALUES (@Name, @Price, @Stock); 
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

            // QuerySingle because INSERT + SCOPE_IDENTITY always
            // returns exactly one row with the new ID
            return connection.QuerySingle<int>(sql, product);
        }

        // ── UPDATE EXISTING PRODUCT ───────────────────────────
        // Returns true if at least one row was updated
        // Returns false if the Id was not found
        public bool UpdateProduct(Product product)
        {
            // FIX: simplified using statement
            using var connection = new SqlConnection(_connectionString);

            // FIX: removed the rogue comma before WHERE
            // Original: "SET Name = @Name, Price = @Price , WHERE Id = @Id"
            // The comma before WHERE caused a SQL syntax error
            var sql = @"UPDATE Products 
                        SET Name  = @Name, 
                            Price = @Price,
                            Stock = @Stock 
                        WHERE Id = @Id";

            // Execute returns the number of rows affected
            // > 0 means the update succeeded
            var rowsAffected = connection.Execute(sql, product);
            return rowsAffected > 0;
        }

        // ── DELETE PRODUCT BY ID ──────────────────────────────
        // FIX: changed parameter from Product product to int id
        // to match the interface - you only need the ID to delete
        // Returns true if a row was deleted
        // Returns false if no product with that Id existed
        public bool DeleteProduct(int id)
        {
            // FIX: simplified using statement
            using var connection = new SqlConnection(_connectionString);

            var sql = "DELETE FROM Products WHERE Id = @id";

            // Pass id as anonymous object so Dapper maps @id correctly
            var rowsAffected = connection.Execute(sql, new { id });
            return rowsAffected > 0;
        }
    }
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
}