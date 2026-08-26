using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class TemperatureView
    {
        public string GetTemperatureInput()
        {
            Console.Write("Enter temperature (-100 to 100): ");
            return Console.ReadLine() ?? string.Empty;
        }

        public void DisplaySuccess(int temperature)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[SUCCESS] Temperature '{temperature}°C' recorded successfully.");
            Console.ResetColor();
        }

        public void DisplayError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] {errorMessage}");
            Console.ResetColor();
        }
    }
}