namespace ResearchAdmin.Models
{
    public class FundingAgency
    {
        public int Id { get; set; }
        public string AgencyName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public ICollection<GrantAward> Awards { get; set; } = new List<GrantAward>();

    }
}
