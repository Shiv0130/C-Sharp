<<<<<<< HEAD
﻿namespace Exercise_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Question 2
            Character warrior1 = new Warrior(900);
            Character mage1 = new Mage(500);

            Console.WriteLine(warrior1.Attack());
            Console.WriteLine(mage1.Attack());

            warrior1.TakeDamage(40);
            mage1.TakeDamage(60);


            //Question 3
            List<Person> people = new List<Person>();

            Person lecturer1 = new Lecturer();
            Person student1 = new Student();
            Person student2 = new Student();

            lecturer1.Name = "Lunga";
            student1.Name = "Rahul";
            student2.Name = "Kirthi";

            people.Add(lecturer1);
            people.Add(student1);
            people.Add(student2);

            foreach (Person p in people) {

                Console.WriteLine("Name: "+p.Name+" | Role: "+ p.GetRole());

            }

            //Question 6
            Employee employee1 = new FullTimeEmployee("John", 20000);
            Employee employee2 = new Contractor("Mike", 100, 160);

            Console.WriteLine(employee1.CalculateSalary());
            Console.WriteLine(employee2.CalculateSalary());

        }
    }
}
=======
﻿namespace Exercise_7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Question 2
            Character warrior1 = new Warrior(900);
            Character mage1 = new Mage(500);

            Console.WriteLine(warrior1.Attack());
            Console.WriteLine(mage1.Attack());

            warrior1.TakeDamage(40);
            mage1.TakeDamage(60);


            //Question 3
            List<Person> people = new List<Person>();

            Person lecturer1 = new Lecturer();
            Person student1 = new Student();
            Person student2 = new Student();

            lecturer1.Name = "Lunga";
            student1.Name = "Rahul";
            student2.Name = "Kirthi";

            people.Add(lecturer1);
            people.Add(student1);
            people.Add(student2);

            foreach (Person p in people) {

                Console.WriteLine("Name: "+p.Name+" | Role: "+ p.GetRole());

            }

            //Question 6
            Employee employee1 = new FullTimeEmployee("John", 20000);
            Employee employee2 = new Contractor("Mike", 100, 160);

            Console.WriteLine(employee1.CalculateSalary());
            Console.WriteLine(employee2.CalculateSalary());

        }
    }
}
>>>>>>> f1fd9259c06725f9a30786509326a6e923171712
