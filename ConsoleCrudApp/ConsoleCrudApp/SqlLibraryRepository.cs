using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace ConsoleCrudApp
{
    public class SqlLibraryRepository:ILibraryRepository
    {
        private readonly string _connectionString;

        public SqlLibraryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ---- Categories ----
        public IEnumerable<Category> GetAllCategories()
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.Query<Category>("SELECT * FROM Categories ORDER BY Name");
        }

        public Category? GetCategoryById(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.QueryFirstOrDefault<Category>("SELECT * FROM Categories WHERE CategoryId = @id", new { id });
        }

        public int CreateCategory(Category category)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = @"
                INSERT INTO Categories (Name, Description)
                VALUES (@Name, @Description);
                SELECT CAST(SCOPE_IDENTITY() AS INT)";
            return conn.QuerySingle<int>(sql, category);
        }

        public bool UpdateCategory(Category category)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = "UPDATE Categories SET Name = @Name, Description = @Description WHERE CategoryId = @CategoryId";
            return conn.Execute(sql, category) > 0;
        }

        public bool DeleteCategory(int id)
        {
            using var conn = new SqlConnection(_connectionString);
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
            using var conn = new SqlConnection(_connectionString);
            var book = conn.Query<Book, Category, Book>(
                @"SELECT b.*, c.* FROM Books b
                  INNER JOIN Categories c ON b.CategoryId = c.CategoryId
                  WHERE b.BookId = @id",
                (b, c) => { b.Category = c; return b; },
                new { id },
                splitOn: "CategoryId").FirstOrDefault();
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
        }

        public bool UpdateBook(Book book)
        {
            using var conn = new SqlConnection(_connectionString);
            const string sql = @"
                UPDATE Books
                SET Title = @Title, ISBN = @ISBN, PublishedYear = @PublishedYear, CategoryId = @CategoryId
                WHERE BookId = @BookId";
            return conn.Execute(sql, book) > 0;
        }

        public bool DeleteBook(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            return conn.Execute("DELETE FROM Books WHERE BookId = @id", new { id }) > 0;
        }
    }
}
