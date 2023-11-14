using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Lead
    {
        public Owner Owner { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string CurrencySymobl { get; set; }
        public int VisitorScore { get; set; }
        public string LastActivityTime { get; set; }
        public string Industry { get; set; }
        public bool Converted { get; set; }
        public bool ProcessFlow { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Id { get; set; }
        public bool Approved { get; set; }
        public Approval Approval { get; set; }
        public string FirstVisitedUrl { get; set; }
        public int DaysVisited { get; set; }
        public string CreatedTime { get; set; }
        public bool Editable { get; set; }
        public string City { get; set; }
        public int NoOfEmployees { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string LastVisitedTime { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public double AnnualRevenue { get; set; }
        public string SecondaryEmail { get; set; }
        public string Description { get; set; }
        public int NumberOfChats { get; set; }
        public string Rating { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }
        public int AverageTimeSpentMinutes { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LeadStatus { get; set; }
        public string FullName { get; set; }
        public string RecordImage { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public string Mobile { get; set; }
        public string PredictionScore { get; set; }
        public string FirstVisitedTime { get; set; }
        public string LastName { get; set; }
        public string Referrer { get; set; }
        public string LeadSource { get; set; }
        public string Fax { get; set; }
        public string Tag { get; set; }
    }

    internal class Owner
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    internal class Approval
    {
        public bool Delegate { get; set; }
        public bool Approve { get; set; }
        public bool Reject { get; set; }
        public bool Resubmit { get; set; }
    }

    internal class CreatedBy
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    internal class ModifiedBy
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}