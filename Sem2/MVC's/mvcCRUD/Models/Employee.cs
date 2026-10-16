// FIX: This was previously "using Microsoft.Build.Framework;" which is WRONG.
// Microsoft.Build.Framework also happens to define a class called RequiredAttribute
// (used to mark MSBuild task parameters as required) - it has nothing to do with
// model validation. VS's auto-import likely offered it because this project also
// references Microsoft.EntityFrameworkCore.Design, which pulls that package in.
// This was the actual root cause of the "Could not load file or assembly
// Microsoft.Build.Framework..." error during Add-Migration: EF's tooling reflects
// over every property attribute on your entities to build the model, and it choked
// trying to resolve this unrelated MSBuild attribute type.
using System.ComponentModel.DataAnnotations;

namespace mvcCRUD.Models
{
    // Represents an employee, linked to a single Department via DepartmentId.
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]

        public string? Surname { get; set; }
        [Required]

        // Foreign key pointing to the owning Department.
        public int DepartmentId { get; set; }

        // Navigation property for related Department
        public Department? Department { get; set; }
    }
}
