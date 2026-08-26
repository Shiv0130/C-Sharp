using System;
using System.Linq;
using ConsoleCrudApp;


namespace LibrarySystem
{
    class Program
    {
        static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";
        static SqlLibraryRepository repo = new SqlLibraryRepository(connectionString);

        static void Main()
        {
            bool exitApplication = false;

            while (exitApplication == false)
            {
                Console.Clear();
                Console.WriteLine("=== Library System ===");
                Console.WriteLine("1. Manage Categories");
                Console.WriteLine("2. Manage Books");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        ManageCategories();
                        break;
                    case "2":
                        ManageBooks();
                        break;
                    case "3":
                        exitApplication = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageCategories()
        {
            bool goBackToMainMenu = false;

            while (goBackToMainMenu == false)
            {
                Console.Clear();
                Console.WriteLine("=== Categories ===");

                IEnumerable<Category> categories = repo.GetAllCategories();
                bool hasCategories = categories.Any();

                if (hasCategories == true)
                {
                    foreach (Category cat in categories)
                    {
                        Console.WriteLine($"{cat.CategoryId}. {cat.Name} - {cat.Description}");
                    }
                }
                else
                {
                    Console.WriteLine("No categories found.");
                }

                Console.WriteLine("\n1. Add new category");
                Console.WriteLine("2. Update existing category");
                Console.WriteLine("3. Delete category");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Add category
                        Category newCategory = new Category();
                        Console.Write("Category Name: ");
                        newCategory.Name = Console.ReadLine();
                        Console.Write("Category Description (optional): ");
                        newCategory.Description = Console.ReadLine();

                        int newId = repo.CreateCategory(newCategory);
                        if (newId > 0)
                        {
                            Console.WriteLine("Category added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add category.");
                        }
                        Console.ReadKey();
                        break;

                    case "2":
                        // Update category – only if there are categories
                        if (hasCategories == false)
                        {
                            Console.WriteLine("No categories to update. Press any key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Enter Category ID to update: ");
                        string inputId = Console.ReadLine();
                        bool isValidId = int.TryParse(inputId, out int categoryId);

                        if (isValidId == false)
                        {
                            Console.WriteLine("Invalid ID. Press any key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        Category existingCategory = repo.GetCategoryById(categoryId);
                        if (existingCategory == null)
                        {
                            Console.WriteLine("Category not found. Press any key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write($"Current Name ({existingCategory.Name}) – New Name (leave blank to keep): ");
                        string newName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newName) == false)
                        {
                            existingCategory.Name = newName;
                        }

                        Console.Write($"Current Description ({existingCategory.Description}) – New Description (leave blank to keep): ");
                        string newDescription = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(newDescription) == false)
                        {
                            existingCategory.Description = newDescription;
                        }

                        bool updateSuccess = repo.UpdateCategory(existingCategory);
                        if (updateSuccess == true)
                        {
                            Console.WriteLine("Category updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Update failed.");
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        // Delete category
                        if (hasCategories == false)
                        {
                            Console.WriteLine("No categories to delete. Press any key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write("Enter Category ID to delete: ");
                        inputId = Console.ReadLine();
                        isValidId = int.TryParse(inputId, out categoryId);

                        if (isValidId == false)
                        {
                            Console.WriteLine("Invalid ID. Press any key to continue.");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Write($"Are you sure you want to delete category ID {categoryId}? (y/n): ");
                        string confirmation = Console.ReadLine();
                        if (confirmation == "y" || confirmation == "Y")
                        {
                            bool deleteSuccess = repo.DeleteCategory(categoryId);
                            if (deleteSuccess == true)
                            {
                                Console.WriteLine("Category deleted.");
                            }
                            else
                            {
                                Console.WriteLine("Deletion failed. The category may have books linked to it.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Deletion cancelled.");
                        }
                        Console.ReadKey();
                        break;

                    case "4":
                        goBackToMainMenu = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ManageBooks()
        {
            bool goBackToMainMenu = false;

            while (goBackToMainMenu == false)
            {
                Console.Clear();
                Console.WriteLine("=== Books ===");

                IEnumerable<Book> books = repo.GetAllBooks();
                bool hasBooks = books.Any();

                if (hasBooks == true)
                {
                    foreach (Book book in books)
                    {
                        string categoryName = (book.Category != null) ? book.Category.Name : "No Category";
                        Console.WriteLine($"{book.BookId}. {book.Title} (ISBN: {book.ISBN}) – Category: {categoryName} – Year: {book.PublishedYear}");
                    }
                }
                else
                {
                    Console.WriteLine("No books found.");
                }

                Console.WriteLine("\n1. Add new book");
                Console.WriteLine("2. Update existing book");
                Console.WriteLine("3. Delete book");
                Console.WriteLine("4. Back to main menu");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        UpdateBook();
                        break;
                    case "3":
                        DeleteBook();
                        break;
                    case "4":
                        goBackToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.Clear();

            List<Category> categories = repo.GetAllCategories().ToList();
            bool hasCategories = categories.Any();

            if (hasCategories == false)
            {
                Console.WriteLine("No categories exist. Please add a category first.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Available categories:");
            foreach (Category cat in categories)
            {
                Console.WriteLine($"{cat.CategoryId}. {cat.Name}");
            }

            Console.Write("Enter Category ID for the new book: ");
            string categoryInput = Console.ReadLine();
            bool isValidCategory = int.TryParse(categoryInput, out int categoryId);

            if (isValidCategory == false)
            {
                Console.WriteLine("Invalid Category ID. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Category selectedCategory = repo.GetCategoryById(categoryId);
            if (selectedCategory == null)
            {
                Console.WriteLine("Category does not exist. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Book newBook = new Book();
            Console.Write("Book Title: ");
            newBook.Title = Console.ReadLine();
            Console.Write("ISBN: ");
            newBook.ISBN = Console.ReadLine();
            Console.Write("Published Year (optional): ");
            string yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out int year))
            {
                newBook.PublishedYear = year;
            }
            newBook.CategoryId = categoryId;

            int newId = repo.CreateBook(newBook);
            if (newId > 0)
            {
                Console.WriteLine("Book added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add book. Check if the ISBN is unique.");
            }
            Console.ReadKey();
        }

        static void UpdateBook()
        {
            Console.Clear();

            List<Book> books = repo.GetAllBooks().ToList();
            bool hasBooks = books.Any();

            if (hasBooks == false)
            {
                Console.WriteLine("No books to update. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Existing books:");
            foreach (Book b in books)
            {
                Console.WriteLine($"{b.BookId}. {b.Title}");
            }

            Console.Write("Enter Book ID to update: ");
            string idInput = Console.ReadLine();
            bool isValidId = int.TryParse(idInput, out int bookId);

            if (isValidId == false)
            {
                Console.WriteLine("Invalid ID. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Book existingBook = repo.GetBookById(bookId);
            if (existingBook == null)
            {
                Console.WriteLine("Book not found. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Current Title ({existingBook.Title}) – New Title (leave blank to keep): ");
            string newTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newTitle) == false)
            {
                existingBook.Title = newTitle;
            }

            Console.Write($"Current ISBN ({existingBook.ISBN}) – New ISBN (leave blank to keep): ");
            string newIsbn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newIsbn) == false)
            {
                existingBook.ISBN = newIsbn;
            }

            Console.Write($"Current Published Year ({existingBook.PublishedYear}) – New Year (leave blank to keep): ");
            string yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out int newYear))
            {
                existingBook.PublishedYear = newYear;
            }

            List<Category> categories = repo.GetAllCategories().ToList();
            if (categories.Any() == false)
            {
                Console.WriteLine("No categories available. Cannot change category.");
            }
            else
            {
                Console.WriteLine("Available categories:");
                foreach (Category cat in categories)
                {
                    Console.WriteLine($"{cat.CategoryId}. {cat.Name}");
                }
                Console.Write($"Current Category ID ({existingBook.CategoryId}) – New Category ID (leave blank to keep): ");
                string catInput = Console.ReadLine();
                if (int.TryParse(catInput, out int newCatId))
                {
                    Category newCategory = repo.GetCategoryById(newCatId);
                    if (newCategory != null)
                    {
                        existingBook.CategoryId = newCatId;
                    }
                    else
                    {
                        Console.WriteLine("Category ID not found – keeping original category.");
                    }
                }
            }

            bool updateSuccess = repo.UpdateBook(existingBook);
            if (updateSuccess == true)
            {
                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Update failed (maybe duplicate ISBN?).");
            }
            Console.ReadKey();
        }

        static void DeleteBook()
        {
            Console.Clear();

            List<Book> books = repo.GetAllBooks().ToList();
            bool hasBooks = books.Any();

            if (hasBooks == false)
            {
                Console.WriteLine("No books to delete. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Existing books:");
            foreach (Book b in books)
            {
                Console.WriteLine($"{b.BookId}. {b.Title}");
            }

            Console.Write("Enter Book ID to delete: ");
            string idInput = Console.ReadLine();
            bool isValidId = int.TryParse(idInput, out int bookId);

            if (isValidId == false)
            {
                Console.WriteLine("Invalid ID. Press any key to continue.");
                Console.ReadKey();
                return;
            }

            Console.Write($"Are you sure you want to delete book ID {bookId}? (y/n): ");
            string confirmation = Console.ReadLine();
            if (confirmation == "y" || confirmation == "Y")
            {
                bool deleteSuccess = repo.DeleteBook(bookId);
                if (deleteSuccess == true)
                {
                    Console.WriteLine("Book deleted.");
                }
                else
                {
                    Console.WriteLine("Deletion failed.");
                }
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
            Console.ReadKey();
        }
    }
}