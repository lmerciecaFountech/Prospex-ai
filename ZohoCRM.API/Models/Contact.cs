using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Contact
    {
        public Owner Owner { get; set; }
        public string Email { get; set; }
        public string CurrencySymobl { get; set; }
        public int VisitorScore { get; set; }
        public string OtherPhone { get; set; }
        public string MailingState { get; set; }
        public string OtherState { get; set; }
        public string OtherCountry { get; set; }
        public string LastActivityTime { get; set; }
        public string Department { get; set; }
        public bool ProcessFlow { get; set; }
        public string Assistant { get; set; }
        public string MailingCountry { get; set; }
        public string Id { get; set; }
        public bool Approved { get; set; }
        public ReportedTo ReportedTo { get; set; }
        public Approval Approval { get; set; }
        public string FirstVisitedUrl { get; set; }
        public int DaysVisited { get; set; }
        public string OtherCity { get; set; }
        public string CreatedTime { get; set; }
        public bool Editable { get; set; }
        public string HomePhone { get; set; }
        public string LastVisitedTime { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string SecondaryEmail { get; set; }
        public string Description { get; set; }
        public string VendorName { get; set; }
        public string MailingZip { get; set; }
        public int NumberOfChats { get; set; }
        public string Twitter { get; set; }
        public string OtherZip { get; set; }
        public string MailingStreet { get; set; }
        public int AverageTimeSpentMinutes { get; set; }
        public string Salution { get; set; }
        public string FirstName { get; set; }
        public string AsstPhone { get; set; }
        public string FullName { get; set; }
        public string RecordImage { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public string SkypeId { get; set; }
        public string Phone { get; set; }
        public AccountName AccountName { get; set; }
        public bool EmailOptOut { get; set; }
        public string ModifiedTime { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MailingCity { get; set; }
        public string Title { get; set; }
        public string OtherStreet { get; set; }
        public string Mobile { get; set; }
        public string FirstVisitedTime { get; set; }
        public string LastName { get; set; }
        public string Referrer { get; set; }
        public string LeadSource { get; set; }
        public string Tag { get; set; }
        public string Fax { get; set; }
    }


    internal class ReportedTo
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    internal class AccountName
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}