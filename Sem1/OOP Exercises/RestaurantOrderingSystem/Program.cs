using RestaurantOrderingSystem;

List<FoodItem> foodItems = new List<FoodItem>();

FoodItem pizza = new Pizza(100);
FoodItem burger = new Burger(80);

foodItems.Add(pizza);
foodItems.Add(burger);

for (int i = 0; i < foodItems.Count; i++) 
{
    Console.WriteLine($"Food Item {i + 1}: {foodItems[i].Prepare()} at price {foodItems[i].price}");
}