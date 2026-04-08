//Product class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_act
{
    public class Product
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Category { get; set; }

        public Product(string name, double price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public double GetDiscountedPrice()
        {
            double discountPercent = DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Monday => 0.10,
                DayOfWeek.Friday => 0.20,
                DayOfWeek.Saturday or DayOfWeek.Sunday => 0.15,
                _ => 0.05
            };

            if (Category == "Electronics")
            {
                discountPercent += 0.02;
            }

            return Price - (Price * discountPercent);
        }
        public DateTime ExpiryDate { get; set; }

        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }

        public int DaysUntilExpiry()
        {
            return (ExpiryDate - DateTime.Now).Days;
        }

    }
}