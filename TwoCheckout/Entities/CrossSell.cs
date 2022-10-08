namespace TwoCheckout.Entities
{
    public class CrossSell
    {
        public string CampaignCode { get; set; }
        public string ParentCode { get; set; }

        public CrossSell(string campaignCode, string parentCode)
        {
            this.CampaignCode = campaignCode;
            this.ParentCode = parentCode;

        }
    }
}
