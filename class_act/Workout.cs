//workout class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_act
{
    public class Workout
    {
        public DateTime Date { get; set; }
        public string? Type { get; set; }
        public int Duration { get; set; }

        public Workout(DateTime date, string type, int duration)
        {
            Date = date;
            Type = type;
            Duration = duration;
        }

        public string GetWorkoutIntensity()
        {
            return Duration switch
            {
                < 30 => "Light",
                <= 60 => "Moderate",
                _ => "Intense"
            };
        }
    }
}