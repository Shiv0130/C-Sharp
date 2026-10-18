namespace ServiceDesk.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string StaffNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public ICollection<SupportTicket> ReportedTickets { get; set; } = new List<SupportTicket>();
    }
}