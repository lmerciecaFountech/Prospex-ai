using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Account
    {
        public Owner Owner { get; set; }
        public string Ownership { get; set; }
        public string Description { get; set; }
        public string CurrencySymbol { get; set; }
        public string AccountType { get; set; }
        public string Rating { get; set; }
        public string SICCode { get; set; }
        public string ShipppingState { get; set; }
        public string Website { get; set; }
        public int Employees { get; set; }
        public string LastActivityTime { get; set; }
        public string Industry { get; set; }
        public string RecordImage { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public string AccountSite { get; set; }
        public bool ProcessFlow { get; set; }
        public string Phone { get; set; }
        public string BillingCountry { get; set; }
        public string AccountName { get; set; }
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public bool Approved { get; set; }
        public string TickerSymbol { get; set; }
        public Approval Approval { get; set; }
        public string ModifiedTime { get; set; }
        public string BillingStreet { get; set; }
        public string CreatedTime { get; set; }
        public bool Editable { get; set; }
        public string BillingCode { get; set; }
        public ParentAccount ParentAccount { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCode { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string Tag { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string Fax { get; set; }
        public double AnnualRevenue { get; set; }
        public string ShippingStreet { get; set; }
    }

    internal class ParentAccount
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}