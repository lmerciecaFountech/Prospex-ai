using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Deal
    {
        public Owner Owner { get; set; }
        public string Description { get; set; }
        public string CurrencySymbol { get; set; }
        public string CampaignSource { get; set; }
        public int Followers { get; set; }
        public string ClosingDate { get; set; }
        public string LastActivityTime { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public int LeadConversionTime { get; set; }
        public bool ProcessFlow { get; set; }
        public string DealName { get; set; }
        public double ExpectedRevenue { get; set; }
        public int OverallSalesDuration { get; set; }
        public string Stage { get; set; }
        public AccountName AccountName { get; set; }
        public string Id { get; set; }
        public bool Approved { get; set; }
        public Approval Approval { get; set; }
        public string ModifiedTime { get; set; }
        public string CreatedTime { get; set; }
        public double Amount { get; set; }
        public bool Followed { get; set; }
        public int Probability { get; set; }
        public string NextStep { get; set; }
        public bool Editable { get; set; }
        public string PredictionScore { get; set; }
        public ContactName ContactName { get; set; }
        public int SalesCycleDuration { get; set; }
        public string Type { get; set; }
        public string LeadSource { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string Tag { get; set; }
    }

    internal class ContactName
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}