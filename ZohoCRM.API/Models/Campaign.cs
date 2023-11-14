using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Campaign
    {
        public string Status { get; set; }
        public Approval Approval { get; set; }
        public Owner Owner { get; set; }
        public string ModifiedTime { get; set; }
        public string Description { get; set; }
        public string CurrencySymbol { get; set; }
        public string CampaignName { get; set; }
        public string CreatedTime { get; set; }
        public bool Editable { get; set; }
        public string EndDate { get; set; }
        public string Type { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public int NumSent { get; set; }
        public string ProcessFlow { get; set; }
        public double ExpectedRevenue { get; set; }
        public double ActualCost { get; set; }
        public string Id { get; set; }
        public int ExpectedResponse { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string Tag { get; set; }
        public string StartDate { get; set; }
        public bool Approved { get; set; }
        public double BudgetedCost { get; set; }
    }
}