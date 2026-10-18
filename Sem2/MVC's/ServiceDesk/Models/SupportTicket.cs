namespace ServiceDesk.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty; // Low, Medium, High, Critical
        public DateTime CreatedAt { get; set; }
        public bool IsResolved { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int ItTechnicianId { get; set; }
        public ItTechnician? ItTechnician { get; set; }
    }
}