using EmployeePayrollSystem;

Employee fulltimeepmloyee = new FullTimeEmployee("Shivaar");
Employee contractor = new Contractor("James");

Console.WriteLine(fulltimeepmloyee.CalculateSalary());
Console.WriteLine(contractor.CalculateSalary());
