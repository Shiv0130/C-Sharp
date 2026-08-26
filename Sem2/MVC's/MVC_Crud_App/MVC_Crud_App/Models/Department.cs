using System.ComponentModel.DataAnnotations;

namespace MVC_Crud_App.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        //Navigation Property, department has a one to many realtionship with many employees
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
