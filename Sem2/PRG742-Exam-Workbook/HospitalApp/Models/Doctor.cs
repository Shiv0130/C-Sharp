// GIVEN FILE: the paper never shows Doctor, but Patient needs it. You do not edit this one.
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models;

public class Doctor
{
    [Key]
    public int DoctorId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public string Specialty { get; set; }

    // one doctor -> many patients (the "many" side is Patient.DoctorId)
    public List<Patient> Patients { get; set; }
}
