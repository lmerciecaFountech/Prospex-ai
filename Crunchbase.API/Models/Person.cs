using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crunchbase.API.Models
{
    /// <summary>
    /// Documentation Url: https://data.crunchbase.com/docs/person
    /// </summary>
    internal sealed class Person : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl1 { get; set; }
        public bool RoleInvestor { get; set; }
        public DateTime BornOn { get; set; }
        public DateTime DiedOn { get; set; }
        public string Gender { get; set; }
        public int Rank { get; set; }
    }
}