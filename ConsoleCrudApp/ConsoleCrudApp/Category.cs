using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCrudApp
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Book>? Books { get; set; }
        //This uses the ICollection for book what is the difference between ICollection and IEnumerable? Why is it ICollection and not IEnumerable? 
        //ICollection is used here instead of IEnumerable because ICollection provides more functionality than IEnumerable. While IEnumerable only allows iteration over a collection, ICollection provides additional methods for adding, removing, and checking the existence of items in the collection.
        //This is useful in scenarios where you need to modify the collection, such as adding or removing books from a category.
    }
}
