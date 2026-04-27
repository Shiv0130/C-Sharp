<<<<<<< HEAD
﻿using SchoolSystem;

//Person student = new Student();
//Console.WriteLine("Enter student name:");
//student.Name = Console.ReadLine();
//Console.WriteLine($"Student name: {student.Name}");
//Console.WriteLine($"Role:{student.GetRole()}");

//Person lecturer = new Lecturer();
//Console.WriteLine("Enter lecturer name:");
//lecturer.Name = Console.ReadLine();
//Console.WriteLine($"Lecturer name: {lecturer.Name}");
//Console.WriteLine($"Role:{lecturer.GetRole()}");

//Correction
List<Person> people = new List<Person>();

Person lecturer1 = new Lecturer();
Person student1 = new Student();

Person lectuer2 = new Lecturer();
Student student2 = new Student();

lecturer1.Name = "Lunga";
student1.Name = "Shivaar";

Console.WriteLine("Enter lecturer name:");
lectuer2.Name = Console.ReadLine();

Console.WriteLine("Enter student name:");
student2.Name = Console.ReadLine();

people.Add(lecturer1);
people.Add(lectuer2);
people.Add(student1);
people.Add(student2);

foreach (Person person in people)
{
    Console.WriteLine($"Name: {person.Name}, Role: {person.GetRole()}");
}
=======
﻿using SchoolSystem;

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
>>>>>>> dc12548130aeb50905ddce44b8ba16c469423f90
