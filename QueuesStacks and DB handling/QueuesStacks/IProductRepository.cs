using System;
using System.Collections.Generic;
using System.Text;

namespace QueuesStacks
{
    public interface IProductRepository
    {
        // Categories
        IEnumerable<Category> GetAllCategories();
        Category? GetCategoryById(int id);

        int CreateCategory(Category category);
        bool UpdateCategory(Category category);

        bool DeleteCategory(int id);

        //Products
        //Each product must include it's category object
        IEnumerable<Product> GetAllProducts();

        //includes Category
        Product? GetProductBY(int id);
        int CreateProduct(Product product);

        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);

    }
}
