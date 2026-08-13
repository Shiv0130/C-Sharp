using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ConsoleCrudApp
{
    
    // This line defines a class named SqlLibraryRepository that implements the ILibraryRepository interface.
    public class SqlLibraryRepository:ILibraryRepository
    {
        
        // This line declares a private readonly field named _connectionString of type string.
        private readonly string _connectionString;
        // This is a constructor for the SqlLibraryRepository class that takes a string parameter named connectionString and assigns it to the _connectionString field.
        public SqlLibraryRepository(string connectionString)
        {
            // This line assigns the value of the connectionString parameter to the _connectionString field.
            _connectionString = connectionString;
        }

        // ---- Categories ----

        /// This method retrieves all categories from the database, ordered by name, and returns them as an IEnumerable of Category objects.
        /// IEnumerable means that the method returns a collection of Category objects that can be enumerated (iterated) using a foreach loop or other LINQ methods. The IEnumerable interface allows for deferred execution, meaning that the data is not actually retrieved from the database until it is needed during enumeration.
        public IEnumerable<Category> GetAllCategories()
        {
            // This line creates a new SqlConnection object using the connection string stored in the _connectionString field. The using statement ensures that the connection is properly disposed of after use.
            using var conn = new SqlConnection(_connectionString);
            // This line executes a SQL query to select all categories from the Categories table, ordered by the Name column. The Query method from Dapper is used to execute the query and map the results to a collection of Category objects, which is then returned.
            return conn.Query<Category>("SELECT * FROM Categories ORDER BY Name");
        }

        /// This method retrieves a single category from the database based on the provided id. It returns a Category object if found, or null if no matching category is found.
        public Category? GetCategoryById(int id)
        {
            // This line creates a new SqlConnection object using the connection string stored in the _connectionString field. The using statement ensures that the connection is properly disposed of after use.
            using var conn = new SqlConnection(_connectionString);
            // This line executes a SQL query to select a category from the Categories table where the CategoryId matches the provided id. The QueryFirstOrDefault method from Dapper is used to execute the query and map the result to a Category object. If no matching category is found, null is returned.
            return conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE CategoryId = @id", new { id });
        }

        public int CreateCategory(Category category)
        {
            // This line creates a new SqlConnection object using the connection string stored in the _connectionString field. The using statement ensures that the connection is properly disposed of after use.
            using var conn = new SqlConnection(_connectionString);
            // The @ symbol in the SQL query is used to denote parameters. In this case, @Name and @Description are placeholders for the values that will be provided from the category object when the query is executed. Dapper will automatically replace these placeholders with the corresponding properties from the category object, allowing for parameterized queries that help prevent SQL injection attacks.
            const string sql = @"
                INSERT INTO Categories (Name, Description)
                VALUES (@Name, @Description);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";
            // This line executes the SQL query defined in the sql variable, passing the category object as a parameter. The QuerySingle method from Dapper is used to execute the query and retrieve the newly generated CategoryId (the primary key) of the inserted category. The SCOPE_IDENTITY() function is used to get the last identity value generated in the current scope, which is then cast to an integer and returned.
            return conn.QuerySingle<int>(sql, category);
        }

        // This method updates an existing category in the database based on the provided Category object. It returns true if the update was successful (i.e., at least one row was affected), or false if no rows were updated (e.g., if the category with the specified CategoryId does not exist).
        public bool UpdateCategory(Category category)
        {
            // This line creates a new SqlConnection object using the connection string stored in the _connectionString field. The using statement ensures that the connection is properly disposed of after use.
            using var conn = new SqlConnection(_connectionString);
            // The @ symbol in the SQL query is used to denote parameters. In this case, @Name, @Description, and @CategoryId are placeholders for the values that will be provided from the category object when the query is executed. Dapper will automatically replace these placeholders with the corresponding properties from the category object, allowing for parameterized queries that help prevent SQL injection attacks.
            const string sql = "UPDATE Categories SET Name = @Name, Description = @Description WHERE CategoryId = @CategoryId";
            return conn.Execute(sql, category) > 0;
        }

        public bool DeleteCategory(int id)
        {
            // This line creates a new SqlConnection object using the connection string stored in the _connectionString field. The using statement ensures that the connection is properly disposed of after use.
            using var conn = new SqlConnection(_connectionString);
            // This line executes a SQL query to delete a category from the Categories table where the CategoryId matches the provided id. The Execute method from Dapper is used to execute the query, and it returns the number of rows affected. If the number of rows affected is greater than 0, it means the deletion was successful, and true is returned; otherwise, false is returned.
            return conn.Execute("DELETE FROM Categories WHERE CategoryId = @id", new { id }) > 0;
        }

        // ---- Books ----
        public IEnumerable<Book> GetAllBooks()
        {
            using var conn = new SqlConnection(_connectionString);
            var books = conn.Query<Book, Category, Book>(
                @"SELECT b.*, c.* FROM Books b
                  INNER JOIN Categories c ON b.CategoryId = c.CategoryId",
                (book, category) => { book.Category = category; return book; },
                splitOn: "CategoryId");
            return books;
        }

        public Book? GetBookById(int id)
        {
            //WHY ARE WE JOINING HERE? Because we want to retrieve the book along with its associated category information in a single query. By using an INNER JOIN between the Books and Categories tables, we can fetch all the relevant data for a book, including its category details, without needing to make multiple database calls. This approach improves performance and simplifies the code by allowing us to map the results directly to our Book and Category objects using Dapper's multi-mapping feature.
            using var conn = new SqlConnection(_connectionString);
            var book = conn.Query<Book, Category, Book>(
                @"SELECT b.*, c.* FROM Books b
                  INNER JOIN Categories c ON b.CategoryId = c.CategoryId
                  WHERE b.BookId = @id",
                (b, c) => { b.Category = c; return b; },
                new { id },
                splitOn: "CategoryId").FirstOrDefault();
            // FIRSTORDEFAULT is used to return the first book that matches the specified id. If no book is found with the given id, it will return null instead of throwing an exception. This allows for safer handling of cases where a book may not exist in the database.
            return book;
        }

        public int CreateBook(Book book)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = @"
                INSERT INTO Books (Title, ISBN, PublishedYear, CategoryId)
                VALUES (@Title, @ISBN, @PublishedYear, @CategoryId);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";
            return conn.QuerySingle<int>(sql, book);
            //QuerySingle is used here to execute the SQL query that inserts a new book into the Books table and retrieves the newly generated BookId (the primary key) of the inserted book. The SCOPE_IDENTITY() function is used to get the last identity value generated in the current scope, which is then cast to an integer and returned. This allows us to easily obtain the unique identifier of the newly created book for further use in the application.
        }

        public bool UpdateBook(Book book)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = @"
                UPDATE Books
                SET Title = @Title, ISBN = @ISBN, PublishedYear = @PublishedYear, CategoryId = @CategoryId
                WHERE BookId = @BookId";
            return conn.Execute(sql, book) > 0;
            // EXECUTE is used here to execute the SQL query that updates an existing book in the Books table based on the provided Book object. The method returns true if the update was successful (i.e., at least one row was affected), or false if no rows were updated (e.g., if the book with the specified BookId does not exist). This allows us to easily determine whether the update operation was successful or not.
        }

        //WHAT IS THE DIFFERENCE BETWEEN EXECUTE AND QUERYSINGLE? The main difference between Execute and QuerySingle in Dapper is that Execute is used for executing commands that do not return a result set (such as INSERT, UPDATE, DELETE), while QuerySingle is used for executing queries that return a single result. Execute returns the number of rows affected by the command, whereas QuerySingle returns the single result mapped to a specified type. If QuerySingle does not find any results or finds more than one result, it will throw an exception, while Execute simply returns the count of affected rows without throwing exceptions based on the number of results.

        public bool DeleteBook(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.Execute("DELETE FROM Books WHERE BookId = @id", new { id }) > 0;
        }
    }
}
