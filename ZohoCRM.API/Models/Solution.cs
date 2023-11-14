using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoCRM.API.Models
{
    internal class Solution
    {
        public string Status { get; set; }
        public Approval Approval { get; set; }
        public Owner Owner { get; set; }
        public string ModifiedTime { get; set; }
        public string CurrencySymbol { get; set; }
        public string CreatedTime { get; set; }
        public string Comments1 { get; set; }
        public int NoOfComments { get; set; }
        public ProductName ProductName { get; set; }
        public bool Editable { get; set; }
        public string AddComment { get; set; }
        public string SolutionNumber { get; set; }
        public string Anwser { get; set; }
        public ModifiedBy ModifiedBy { get; set; }
        public bool ProcessFlow { get; set; }
        public string SolutionTitle { get; set; }
        public string Question { get; set; }
        public string Id { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string Tag { get; set; }
        public bool Approved { get; set; }
    }
}
