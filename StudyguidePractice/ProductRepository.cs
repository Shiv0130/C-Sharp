<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

 
namespace StudyguidePractice
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        //Answer question 8
        public ProductRepository(string connectionString) => _connectionString = connectionString;

        // Use QueryFirstOrDefault for lookups where the ID might not exist
        public Product? GetProductById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QueryFirstOrDefault<Product>(
                "SELECT * FROM Products WHERE Id = @Id",
                new { Id = id });
        }

        // Use QuerySingle for mandatory data (e.g., a specific product that MUST exist)
        public Product GetSingleProduct(string name)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QuerySingle<Product>(
                "SELECT * FROM Products WHERE Name = @Name",
                new { Name = name });
        }

        //Answer 10
        public int AddProduct(Product product)
        {
            using var conn = new SqlConnection(_connectionString);

            const string sql = @"
        INSERT INTO Products (Name, Description, Price, StockQuantity)
        VALUES (@Name, @Description, @Price, @StockQuantity);
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            // QuerySingle works perfectly here because our SQL ends with a SELECT
            return conn.QuerySingle<int>(sql, product);
        }

        //Answer 11
        public bool UpdateProduct(Product product)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = @"
        UPDATE Products
        SET ProductName = @ProductName, UnitPrice = @UnitPrice
        WHERE ProductId = @ProductId";

            int rowsAffected = conn.Execute(sql, product);

            // If rowsAffected > 0, the update worked
            // If rowsAffected == 0, the ProductId was not found
            return rowsAffected > 0;
        }

        //Answer question 12
        public bool UpdateProductPrice(int productId, decimal newPrice)
        {
            using var conn = new SqlConnection(_connectionString);

            const string sql = @"
        UPDATE Products
        SET UnitPrice = @newPrice
        WHERE ProductId = @productId";

            // Execute returns number of rows affected
            // > 0 means at least one row was updated successfully
            return conn.Execute(sql, new { productId, newPrice }) > 0;
        }

        //Answer question 7
        //// The constructor receives the string from Program.cs
        //public ProductRepository(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}


        //public List<Product> GetAllProducts()
        //{
        //    using var conn = new SqlConnection(_connectionString);
        //    return conn.Query<Product>("SELECT * FROM Products").ToList();
        //}
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

 
namespace StudyguidePractice
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        //Answer question 8
        public ProductRepository(string connectionString) => _connectionString = connectionString;

        // Use QueryFirstOrDefault for lookups where the ID might not exist
        public Product? GetProductById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QueryFirstOrDefault<Product>(
                "SELECT * FROM Products WHERE Id = @Id",
                new { Id = id });
        }

        // Use QuerySingle for mandatory data (e.g., a specific product that MUST exist)
        public Product GetSingleProduct(string name)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QuerySingle<Product>(
                "SELECT * FROM Products WHERE Name = @Name",
                new { Name = name });
        }

        //Answer 10
        public int AddProduct(Product product)
        {
            using var conn = new SqlConnection(_connectionString);

            const string sql = @"
        INSERT INTO Products (Name, Description, Price, StockQuantity)
        VALUES (@Name, @Description, @Price, @StockQuantity);
        SELECT CAST(SCOPE_IDENTITY() AS INT);";

            // QuerySingle works perfectly here because our SQL ends with a SELECT
            return conn.QuerySingle<int>(sql, product);
        }

        //Answer 11
        public bool UpdateProduct(Product product)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = @"
        UPDATE Products
        SET ProductName = @ProductName, UnitPrice = @UnitPrice
        WHERE ProductId = @ProductId";

            int rowsAffected = conn.Execute(sql, product);

            // If rowsAffected > 0, the update worked
            // If rowsAffected == 0, the ProductId was not found
            return rowsAffected > 0;
        }

        //Answer question 12
        public bool UpdateProductPrice(int productId, decimal newPrice)
        {
            using var conn = new SqlConnection(_connectionString);

            const string sql = @"
        UPDATE Products
        SET UnitPrice = @newPrice
        WHERE ProductId = @productId";

            // Execute returns number of rows affected
            // > 0 means at least one row was updated successfully
            return conn.Execute(sql, new { productId, newPrice }) > 0;
        }

        //Answer question 7
        //// The constructor receives the string from Program.cs
        //public ProductRepository(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}


        //public List<Product> GetAllProducts()
        //{
        //    using var conn = new SqlConnection(_connectionString);
        //    return conn.Query<Product>("SELECT * FROM Products").ToList();
        //}
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
