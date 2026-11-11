// GIVEN FILE: the joining table named in Q2.2 (many-to-many). You do not edit this one.
// Notice it has NO [Key]. You will give it a composite key in ApplicationDbContext (Q2.2).
namespace HospitalApp.Models;

public class DoctorPatient
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }

    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
}
