<<<<<<< HEAD
﻿using EmployeePayrollSystem;

//Employee fulltimeepmloyee = new FullTimeEmployee("Shivaar");
//Employee contractor = new Contractor("James");
//fulltimeepmloyee.monthlySalary = 5000;
//contractor.hourlyRate = 50;
//((Contractor)contractor).hoursWorked = 160;
//Console.WriteLine($" Full time employee salary:{fulltimeepmloyee.CalculateSalary()}");
//Console.WriteLine($"Contractor salary:{contractor.CalculateSalary()}");

Employee employee1 = new FullTimeEmployee("John", 20000);
Employee employee2 = new Contractor("Mike", 100, 160);

Console.WriteLine(employee1.CalculateSalary());
Console.WriteLine(employee2.CalculateSalary());
=======
﻿using EmployeePayrollSystem;

Employee fulltimeepmloyee = new FullTimeEmployee("Shivaar");
Employee contractor = new Contractor("James");

Console.WriteLine(fulltimeepmloyee.CalculateSalary());
Console.WriteLine(contractor.CalculateSalary());
>>>>>>> dc12548130aeb50905ddce44b8ba16c469423f90
