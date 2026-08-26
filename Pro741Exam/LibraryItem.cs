using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro741Exam
{
    public class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public LibraryItem(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public virtual double CalculateFee(int daysLate) 
        {
            return 0.0; // Base implementation, can be overridden in derived classes
        }


    }
    
}
