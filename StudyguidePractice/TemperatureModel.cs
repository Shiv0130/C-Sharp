using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//6. correction topic 5 - this class is where we will use our custom exception to validate temperature input
namespace StudyguidePractice
{
    public class TemperatureModel
    {
        // Private setter ensures the temperature can't be changed without validation
        public int Temperature { get; private set; }

        public void ValidateAndSetTemperature(int value)
        {
            // Business Rule: Must be within acceptable atmospheric limits
            if (value < -100 || value > 100)
            {
                // Throw our custom exception if the rule is broken
                throw new InvalidTemperatureException(value);
            }

            // If it passes validation, save the value
            Temperature = value;
        }
    }
}
