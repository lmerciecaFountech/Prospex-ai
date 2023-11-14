using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class SocialMediaAccountDTO
    {
        public SocialMedia Provider { get; set; }
        public string ProviderUserId { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string AccessToken { get; set; }
    }
}