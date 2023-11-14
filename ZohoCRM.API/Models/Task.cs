using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Task
    {
        public string Status { get; set; }
        public Approval Approval { get; set; }
        public Owner Owner { get; set; }
        public string ModifiedTime { get; set; }
        public string Description { get; set; }
        public string CurrencySymbol { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string CreatedTime { get; set; }
        public string ClosedTime { get; set; }
        public bool Editable { get; set; }
        public string Subject { get; set; }
        public bool SendNotificationEmail { get; set; }
        public string SeModule { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public bool RecurringActivity { get; set; }
        public bool ProcessFlow { get; set; }
        public WhatId WhatId { get; set; }
        public string Id { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string Tag { get; set; }
        public bool Approved { get; set; }
        public string RemindAt { get; set; }
        public WhoId WhoId { get; set; }
    }

    internal class WhatId
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    internal class WhoId
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}