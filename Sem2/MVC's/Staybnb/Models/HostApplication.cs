namespace Staybnb.Models
{
    public class HostApplication
    {
        public int Id { get; set; }
        public string ApplicantUserId { get; set; } = string.Empty;
        public ApplicationUser? Applicant { get; set; }
        public int? PropertyId { get; set; }
        public HostProperty? Property { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    }
}
