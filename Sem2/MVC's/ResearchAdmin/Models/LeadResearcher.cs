namespace ResearchAdmin.Models
{
    public class LeadResearcher
    {
        public int Id { get; set; }
        public string AcademicTitle { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        public ICollection<GrantAward> Awards { get; set; } = new List<GrantAward>();
    }
}
