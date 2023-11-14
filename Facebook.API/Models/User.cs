using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.API.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string About { get; set; }
        public Location Address { get; set; }
        public AgeRange AgeRange { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Name { get; set; }
        public string NameFormat { get; set; }
        public string ProfilePic { get; set; }
        public string Gender { get; set; }
        public bool IsGuestUser { get; set; }
        public VideoUploadLimits VideoUploadLimits { get; set; }
    }
}