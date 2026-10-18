namespace ServiceDesk.Models
{
    public class ItTechnician
    {
        public int Id { get; set; }
        public string TechnicianName { get; set; } = string.Empty;
        public string TierLevel { get; set; } = string.Empty; // Tier 1, Tier 2, SysAdmin
        public ICollection<SupportTicket> AssignedTickets { get; set; } = new List<SupportTicket>();
    }
}