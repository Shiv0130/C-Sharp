namespace ResearchAdmin.Models
{
    public class GrantAward
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; } = string.Empty;
        public decimal AwardedAmount { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string EthicsClearanceCode { get; set; } = string.Empty;
        public int FundingAgencyId { get; set; }
        public FundingAgency? FundingAgency { get; set; }
        public int LeadResearcherId { get; set; }
        public LeadResearcher? LeadResearcher { get; set; }
    }
}
