//My work
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace class_act
//{
//    public class Book
//    {
//        public string? Title { get; set; }
//        public string? Author { get; set; }

//        public int AvailableCopies { get; set; }
//        public Book(string title,string author,int availablecopies)
//        {
//            Title = title;
//            Author = author;
//            AvailableCopies = availablecopies;

//        }

//        public string Borrow(int availablecopies) 
//        {
//            if (availablecopies > 0)
//            {
//                availablecopies--;
//                return "success";
//            }
//            else 
//            {
//                return "no copies";
//            }

//        }

//        public void Return(int availablecopies) 
//        {
//            availablecopies++;
//            Console.WriteLine(availablecopies);
//        }

//        public bool CanBorrow(int availablecopies) 
//        {
//                return availablecopies>0;
//        }


//    }
//}

//Exercise 1 Book system correction
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace class_act
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int AvailableCopies { get; set; }

        public Book(string title, string author, int availablecopies)
        {
            Title = title;
            Author = author;
            AvailableCopies = availablecopies;
        }


        public bool Borrow()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Return()
        {
            AvailableCopies++;
        }

        public bool CanBorrow()
        {
            return AvailableCopies > 0;
        }

        // Exercise 2 
        public DateTime BorrowDate { get; set; }

        public DateTime GetDueDate() 
        {
            return BorrowDate.AddDays(14);
        }

        public bool IsOverDue() 
        {
            return DateTime.Now > GetDueDate();
        }

    }
}
//Hello
