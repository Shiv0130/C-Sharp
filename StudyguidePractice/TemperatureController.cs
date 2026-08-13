using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyguidePractice
{
    public class TemperatureController
    {
        private readonly TemperatureModel _model;
        private readonly TemperatureView _view;

        // Dependency Injection via Constructor
        public TemperatureController(TemperatureModel model, TemperatureView view)
        {
            _model = model;
            _view = view;
        }

        public void Run()
        {
            // 1. Get raw string input from the View
            string input = _view.GetTemperatureInput();

            try
            {
                // 2. Try parsing the input string into an integer
                if (!int.TryParse(input, out int parsedTemperature))
                {
                    throw new FormatException("Input string was not a valid whole number.");
                }

                // 3. Pass the integer to the Model for validation rules
                _model.ValidateAndSetTemperature(parsedTemperature);

                // 4. If no exception was thrown, display success
                _view.DisplaySuccess(_model.Temperature);
            }
            catch (FormatException ex)
            {
                // Catches non-numeric inputs (e.g., "abc")
                _view.DisplayError(ex.Message);
            }
            catch (InvalidTemperatureException ex)
            {
                // Catches numbers out of range (e.g., 150) and extracts custom property
                _view.DisplayError($"{ex.Message} (Rejected Entry: {ex.FaultyTemperature})");
            }
        }
    }
}
