using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class AccountDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public AccountType AccountType { get; set; }
        public string ImageUri { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string PlaceId { get; set; }
        public bool IsLocked { get; set; }
        public int? ProfileCompletion { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string CompanyId { get; set; }
        public List<string> Keywords { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string City { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public int RDL { get; set; }
        public string LomiId { get; set; }
        public string ProspexId { get; set; }
        public ICollection<SocialMediaAccountDTO> SocialMediaAccounts { get; set; }
        public ICollection<LocationDTO> Locations { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
        public ICollection<IdealClientDTO> IdealClients { get; set; }
    }
}