using ConsoleNotes;

Student student1 = new Student("S123", "Yashin", "Naidoo", "BSc Information Systems");

student1.DisplayStudentDetails(student1);

Console.WriteLine("--------------------------------------");

Console.WriteLine("Enter Student Details");

Console.Write("Enter Student Number:");
string studetNumber = Console.ReadLine();


Console.Write("Enter Student Name:");
string name = Console.ReadLine();


Console.Write("Enter Student Surname:");
string surname = Console.ReadLine();


Console.Write("Enter Student Qaulification:");
string qualification = Console.ReadLine();


Student student2 = new Student(studetNumber, name, surname, qualification);

student2.DisplayStudentDetails(student2);
