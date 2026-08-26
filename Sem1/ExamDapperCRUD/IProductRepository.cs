<<<<<<< HEAD
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExamDapperCRUD
//{
//    public interface IProductRepository
//    {
//        Product GetProduct(int id);
//        IEnumerable<Product> GetAllProducts();
//        int AddProduct(Product product);
//        bool UpdateProduct(Product product);
//        bool DeleteProduct(int id);
//        IEnumerable<Product> GetProduct();
//    }
//}

//correction:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperCRUD
{
    public interface IProductRepository
    {
        // FIX: renamed GetProduct(int id) → GetProductById(int id)
        // The original had two methods both named GetProduct which
        // caused CS0111 duplicate member error
        // Also matches the exam requirement: "Product GetProductById(int id)"
        Product? GetProductById(int id);

        // Returns all products from the Products table
        IEnumerable<Product> GetAllProducts();

        // Inserts a new product and returns the auto-generated Id
        int AddProduct(Product product);

        // Updates an existing product, returns true if row was found and updated
        bool UpdateProduct(Product product);

        // FIX: changed DeleteProduct(Product product) → DeleteProduct(int id)
        // You only need the ID to delete - no need to pass the whole object
        // Also matches exam requirement: "bool DeleteProduct(int id)"
        bool DeleteProduct(int id);
    }
}
=======
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ExamDapperCRUD
//{
//    public interface IProductRepository
//    {
//        Product GetProduct(int id);
//        IEnumerable<Product> GetAllProducts();
//        int AddProduct(Product product);
//        bool UpdateProduct(Product product);
//        bool DeleteProduct(int id);
//        IEnumerable<Product> GetProduct();
//    }
//}

//correction:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDapperCRUD
{
    public interface IProductRepository
    {
        // FIX: renamed GetProduct(int id) → GetProductById(int id)
        // The original had two methods both named GetProduct which
        // caused CS0111 duplicate member error
        // Also matches the exam requirement: "Product GetProductById(int id)"
        Product? GetProductById(int id);

        // Returns all products from the Products table
        IEnumerable<Product> GetAllProducts();

        // Inserts a new product and returns the auto-generated Id
        int AddProduct(Product product);

        // Updates an existing product, returns true if row was found and updated
        bool UpdateProduct(Product product);

        // FIX: changed DeleteProduct(Product product) → DeleteProduct(int id)
        // You only need the ID to delete - no need to pass the whole object
        // Also matches exam requirement: "bool DeleteProduct(int id)"
        bool DeleteProduct(int id);
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
