using System;
using System.Collections.Generic;
using System.Text;

// Encapsulating the data container under a custom namespace matching the project folder scheme
namespace QueuesStacks
{
    /// <summary>
    /// Represents a basic blueprint for managing a customer profile data entity.
    /// </summary>
    public class Customer
    {
        // Auto-implemented public property for retrieving or updating the Customer's Name text string
        public string Name { get; set; }

        // Auto-implemented public property for retrieving or updating the Customer's Age integer value
        public int Age { get; set; }

        // Parameterized Constructor to enforce assignment of Name and Age constraints during instantiation initialization
        public Customer(string name, int age)
        {
            Name = name; // Mapping local parameter 'name' into class property 'Name'
            Age = age;   // Mapping local parameter 'age' into class property 'Age'
        }
    }
}