using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Dapper;

namespace QueuesStacks
{
    public class sqlProductRepository:IProductRepository
    {
        private readonly string _connectionString;

        public sqlProductRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        //Categories
        //Read
       public IEnumerable<sqlCategoryRepository> GetAllCategories() 
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                var categories = connection.Query<sqlCategoryRepository>("SELECT * FROM Categories");
                return categories;
            }
        }

        //Create
        public void CreateCategory(sqlCategoryRepository category) 
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                var sqlCreate = "INSERT INTO Categories (Name, Description) VALUES (@Name, @Description)";
                connection.Execute(sqlCreate, category);
            }
        }

        //Update
        public bool UpdateCategory(sqlCategoryRepository category) 
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                var sqlUpdate = "UPDATE Categories SET Name = @Name, Description = @Description WHERE Id = @Id";
                var rowsAffected = connection.Execute(sqlUpdate, category);
                return rowsAffected > 0;
            }
        }

        //Delete
        public bool DeleteCategory(int id) 
        {
            using (var connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                var sqlDelete = "DELETE FROM Categories WHERE Id = @Id";
                var rowsAffected = connection.Execute(sqlDelete, new { Id = id });
                return rowsAffected > 0;
            }
        }

        //Products

        //Read
        public IEnumerable<sqlProductRepository> GetAllProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var products = connection.Query<sqlProductRepository>("SELECT * FROM Products");
                return products;
            }
        }

        //Create
        public void CreateProduct(sqlProductRepository product) 
        {
            using (var connection = new SqlProdutRepository(_connectionString)) 
            {
                connection.Open();
                var sqlCreate = "INSERT INTO Products (Name, Description, CategoryId) VALUES (@Name, @Description, @CategoryId)";
                connection.Execute(sqlCreate, product);
            }

        }

        //Update
        public bool UpdateProduct(sqlProductRpository product) 
        {
            using (var connection = new sqlProductRepository(_connectionString)) 
            {
                connection.Open();
                var sqlUpdate = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE Id = @Id";
                var rowsAffected = connection.Execute(sqlUpdate,product);
            }
        }

        //Delete
        public bool DeleteProduct(int id) 
        {
            using (var connection = new sqlProductRepository(_connectionString)) 
            {
                connection.Open();
                var sqlDelete = "DELETE FROM Products WHERE Id = @Id";
                var rowsAffected = connection.Execute(sqlDelete, new { Id = id });
                return rowsAffected > 0;
            }
        }





    }
}
