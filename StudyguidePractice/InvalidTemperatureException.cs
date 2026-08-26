//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

////6. for topic 5
//namespace StudyguidePractice
//{
//    public class InvalidTemperatureException
//    {
//        public int temperature { get; set; }

//        public int ReadTemp()
//        {
//            try
//            {
//                temperature = int.Parse(Console.ReadLine());
//                return temperature;
//            }
//            catch (Exception ex)
//            {
//                return "Invalid input";
//            }
//        }
//    }
//}

//6. Correction Topic 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudyguidePractice
{
    // MUST inherit from Exception to be used in try/catch blocks
    public class InvalidTemperatureException : Exception
    {
        // Property to store the invalid value for troubleshooting
        public int FaultyTemperature { get; }

        // Constructor passes the formatted message up to the base Exception class
        public InvalidTemperatureException(int temperature)
            : base($"Invalid temperature value: {temperature}°C. Value must be between -100 and 100.")
        {
            FaultyTemperature = temperature;
        }
    }
}
