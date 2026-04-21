using SchoolSystem;

Person student = new Student();
Console.WriteLine("Enter student name:");
student.Name = Console.ReadLine();
Console.WriteLine($"Student name: {student.Name}");
Console.WriteLine($"Role:{student.GetRole()}");

Person lecturer = new Lecturer();
Console.WriteLine("Enter lecturer name:");
lecturer.Name = Console.ReadLine();
Console.WriteLine($"Lecturer name: {lecturer.Name}");
Console.WriteLine($"Role:{lecturer.GetRole()}");