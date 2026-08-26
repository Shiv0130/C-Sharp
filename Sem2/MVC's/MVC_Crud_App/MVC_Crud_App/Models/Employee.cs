using System.ComponentModel.DataAnnotations;

namespace MVC_Crud_App.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname {  get; set; }

        [Required]
        public int DepartmentId { get; set; }

        //Navigation property, it indicates how two tables are related to each other
        public Department? Department { get; set; }


        //test - given an erd showing relationship, we will get arrtibutes, we will have to create models based on the erd structure.
    }
}
