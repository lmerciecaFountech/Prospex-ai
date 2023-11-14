using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Case
    {
        public Owner Owner { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string CurrencySymbol { get; set; }
        public string InternalComments { get; set; }
        public int NoOfComments { get; set; }
        public string ReportedBy { get; set; }
        public string CaseNumber { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public bool ProcessFlow { get; set; }
        public DealName DealName { get; set; }
        public string Phone { get; set; }
        public AccountName AccountName { get; set; }
        public string Id { get; set; }
        public bool Approved { get; set; }
        public string Solution { get; set; }
        public string Status { get; set; }
        public Approval Approval { get; set; }
        public string ModifiedTime { get; set; }
        public string Priority { get; set; }
        public string CreatedTime { get; set; }
        public string Comments { get; set; }
        public ProductName ProductName { get; set; }
        public bool Editable { get; set; }
        public string AddComment { get; set; }
        public string CaseOrigin { get; set; }
        public string CaseReason { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
        public string Tag { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public RelatedTo RelatedTo { get; set; }
    }

    internal class DealName
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    internal class ProductName
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    internal class RelatedTo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

}