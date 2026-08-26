////Correction with other part:
//////This is my main program
////using class_act;

////Book book1 = new Book("CSharp","Lunga",0);
//////book1.Return(12);
////Console.WriteLine(book1.Author);
////book1.CanBorrow(12);

////Main program correction

//using class_act;
//Book book1 = new Book("CSharp", "Lunga", 2);

////Exercise 2: at this part:
//book1.BorrowDate = DateTime.Now;


//Console.WriteLine("Borrow Date: " + book1.BorrowDate.ToString("dd MMM yyyy"));
//Console.WriteLine("Due Date: " + book1.GetDueDate().ToString("dd MMM yyyy"));
//Console.WriteLine("Is Overdue: " + book1.IsOverDue());

//Console.WriteLine($"Title: {book1.Title}");
//Console.WriteLine("Author: " + book1.Author);
//Console.WriteLine("Available Copies: " + book1.AvailableCopies);

//bool result1 = book1.Borrow();
//Console.WriteLine($"Borrow attempt 1:{result1}");
//Console.WriteLine($"Available Copies:" + book1.AvailableCopies);
//bool result2 = book1.Borrow();
//Console.WriteLine("Borrow attempt 2: " + result2);
//Console.WriteLine("Available Copies: " + book1.AvailableCopies);

//bool result3 = book1.Borrow();
//Console.WriteLine("Borrow attempt 3: " + result3);
//Console.WriteLine("Available Copies: " + book1.AvailableCopies);

//book1.Return();
//Console.WriteLine("After return - Available Copies: " + book1.AvailableCopies);

//Console.WriteLine("Can borrow: " + book1.CanBorrow());


//Console.WriteLine("Enter book name:");
//string book_name = Console.ReadLine()!;

//Console.WriteLine("Enter Author name:");
//string book_author = Console.ReadLine()!;

//Console.WriteLine("Available copies:");
//int available_copies = int.Parse(Console.ReadLine()!);
//Book book2 = new Book(book_name, book_author, available_copies);

//Console.WriteLine($"Title: {book2.Title}");
//Console.WriteLine("Author: " + book2.Author);
//Console.WriteLine("Available Copies: " + book2.AvailableCopies);

//bool result4 = book2.Borrow();
//Console.WriteLine($"Borrow attempt 1:{result4}");
//Console.WriteLine($"Available Copies:" + book2.AvailableCopies);
//bool result5 = book2.Borrow();
//Console.WriteLine("Borrow attempt 2: " + result5);
//Console.WriteLine("Available Copies: " + book2.AvailableCopies);

//bool result6 = book2.Borrow();
//Console.WriteLine("Borrow attempt 3: " + result6);
//Console.WriteLine("Available Copies: " + book2.AvailableCopies);

//Exercise 3:Student
//using class_act;

//student student1 = new student("Shivaar", new DateTime(2003, 3, 01), 85);

//Console.WriteLine("Name: " + student1.Name);
//Console.WriteLine("Age: " + student1.GetAge());
//Console.WriteLine("Can Write Exam: " + student1.CanWriteExam());
//Console.WriteLine("Letter Grade: " + student1.GetLetterGrade());

//Console.WriteLine("Enter your name:");
//string name = Console.ReadLine();
//Console.WriteLine("Enter your birthdate(yyyy:mm:dd):");
//DateTime birthDate = DateTime.Parse(Console.ReadLine());
////This is part of exercise 4 as well
//Console.WriteLine("Enter average mark:");
//double mark = double.Parse(Console.ReadLine()); 
//student student2 = new student(name,birthDate,mark);

//Console.WriteLine("Name: " + student2.Name);
//Console.WriteLine("Age: " + student2.GetAge());
//Console.WriteLine("Can Write Exam: " + student2.CanWriteExam());

////Exercise 4:
//Console.WriteLine("Letter Grade: " + student2.GetLetterGrade());

//Exercise 5:
//using class_act;

//Product product1 = new Product("Laptop", 15000, "Electronics");

//Console.WriteLine("Product: " + product1.Name);
//Console.WriteLine("Original Price: R" + product1.Price);
//Console.WriteLine("Discounted Price: R" + product1.GetDiscountedPrice());

////Exercise 6:
//Console.WriteLine("Expiry Date: " + product1.ExpiryDate.ToString("dd MMM yyyy"));
//Console.WriteLine("Is Expired: " + product1.IsExpired());
//Console.WriteLine("Days Until Expiry: " + product1.DaysUntilExpiry());

//if (product1.DaysUntilExpiry() <= 7)
//{
//    Console.WriteLine("WARNING: Product expires within 7 days!");
//}

//Exerice 7:
//using class_act;

//Car car1 = new Car("Toyota Corolla", 7.5, 50);

//Console.Write("Enter trip distance (km): ");
//double distance = double.Parse(Console.ReadLine());

//Console.WriteLine("Max Distance on Full Tank: " + car1.CalculateMaxDistance() + " km");
//Console.WriteLine("Fuel Needed: " + car1.FuelNeeded(distance) + " litres");

//if (distance <= car1.CalculateMaxDistance())
//{
//    Console.WriteLine("The car can make it without refueling.");
//}
//else
//{
//    Console.WriteLine("The car cannot make it without refueling.");
//}

////Exercise 8:
//Console.Write("Enter trip date (yyyy-mm-dd): ");
//DateTime tripDate = DateTime.Parse(Console.ReadLine());

//if (car1.IsWeekendTrip(tripDate))
//{
//    Console.WriteLine(tripDate.ToString("dd MMM yyyy") + " is a weekend trip.");
//}
//else
//{
//    Console.WriteLine(tripDate.ToString("dd MMM yyyy") + " is not a weekend trip.");
//}

// Exercise 9:
using class_act;

List<Workout> workouts = new List<Workout>();
string input = "";

do
{
    Console.Write("Enter workout type (or 'done' to finish): ");
    input = Console.ReadLine();

    if (input != "done")
    {
        Console.Write("Enter duration (minutes): ");
        int duration = int.Parse(Console.ReadLine());

        Workout workout = new Workout(DateTime.Now, input, duration);
        workouts.Add(workout);
    }

} while (input != "done");

if (workouts.Count > 0)
{
    int totalDuration = 0;
    Workout longest = workouts[0];

    foreach (Workout w in workouts)
    {
        totalDuration += w.Duration;

        if (w.Duration > longest.Duration)
        {
            longest = w;
        }

        if (w.Date.DayOfWeek == DayOfWeek.Saturday || w.Date.DayOfWeek == DayOfWeek.Sunday)
        {
            Console.WriteLine(w.Type + " was done on a weekend!");
        }
    }

    Console.WriteLine("Total Duration: " + totalDuration + " minutes");
    Console.WriteLine("Average Duration: " + (totalDuration / workouts.Count) + " minutes");
    Console.WriteLine("Longest Workout: " + longest.Type + " (" + longest.Duration + " mins) - " + longest.GetWorkoutIntensity());
}