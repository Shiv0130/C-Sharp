namespace Classes
{

    internal class Program
    {
        static void Main(string[] args) {
            Person person1 = new Person("Rahul",21);
            person1.Greet();

            Employees emploee1 = new Employees(1,"Rahul","Surname",24000);
            emploee1.DisplayEmployeeInfo();

        }
    }
}
