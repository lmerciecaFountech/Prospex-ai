using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class CompanyDTO : BaseDTO
    {
        public string SubdomainAddress { get; set; }
        public bool? Active { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string ContactFirstname { get; set; }
        public string ContactSurname { get; set; }
        public string ContactJobTitle { get; set; }
        public string ContactEmail { get; set; }
        public string ContactTelephoneNumber { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string LogoUrl { get; set; }
        public CompanyTypeDTO CompanyType { get; set; }
        public ICollection<LocationDTO> Locations { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
}