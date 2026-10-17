namespace ActiveLife.Models
{
    public class GymMember
    {
        public int Id { get; set; }
        public string MemberNumber { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string MembershipType { get; set; } = string.Empty; // Gold / Silver
        public ICollection<PersonalTrainingSession> Bookings { get; set; } = new List<PersonalTrainingSession>();
    }
}