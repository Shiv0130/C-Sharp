using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCrudApp
{
    public interface ILibraryRepository
    {
        // Categories
        IEnumerable<Category> GetAllCategories();
        Category? GetCategoryById(int id);
        int CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);

        // Books
        IEnumerable<Book> GetAllBooks();      
        Book? GetBookById(int id);
        int CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
