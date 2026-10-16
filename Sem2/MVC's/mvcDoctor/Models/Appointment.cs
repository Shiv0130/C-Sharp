using System.ComponentModel.DataAnnotations;

namespace mvcDoctor.Models
{
    public class Appointment
    {
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        [StringLength(500)]
        public string? DiagnosisNotes { get; set; }
    }
}