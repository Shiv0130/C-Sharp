using OnlineShoppingSystem;

Product[] products = new Product[]
{
    new Electronics(1000),
    new Clothing(500)
};

foreach (Product product in products) 
{
    Console.WriteLine($"Original Price: {product.price}, Discounted Price: {product.CalculateDiscount()}");
    
}