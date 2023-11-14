using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.DTOs
{
    public class LeadQueueDTO
    {
        public string LomiId { get; set; }
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        /// <summary>
        /// Lead Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Lead Business Name
        /// </summary>
        public string BusinessName { get; set; }
        /// <summary>
        /// Lead Business logo image url
        /// </summary>
        public string BusinessLogo { get; set; }
        /// <summary>
        /// Lead profile image url
        /// </summary>
        public string ProfileImage { get; set; }
        /// <summary>
        /// Lead location, only city + country or country if city is not available
        /// </summary>
        public string GenericLocation { get; set; }
        /// <summary>
        /// Lead industry, or last word in headline if no industry available
        /// </summary>
        public string GenericJobTitle { get; set; }
        /// <summary>
        /// Lead job title in full detail (aka headline)
        /// </summary>
        public string JobTitle { get; set; }
        /// <summary>
        /// Lead location in full detail
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Top 5 attributes with highest average weight for this lead that have isPrivate false
        /// </summary>
        public string Keywords { get; set; }
        public List<string> KeywordsList
        {
            set
            {
                if (value != null)
                {
                    Keywords = string.Join(", ", value);
                }
            }
        }
        /// <summary>
        /// Currently always blank, will be Hot/Fresh/Popular
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Lead's linkedin url
        /// </summary>
        public string LinkedInUrl { get; set; }
        /// <summary>
        /// Date lead was created in LOMi
        /// </summary>
        public DateTime? GenerationDate { get; set; }
        public long? GenerationDateLong
        {
            set
            {
                if (value.HasValue)
                {
                    GenerationDate = new DateTime(value.Value);
                }
                else
                {
                    GenerationDate = null;
                }
            }
        }
        public string Title { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string BusinessStreet { get; set; }
        public string BusinessStreet2 { get; set; }
        public string BusinessStreet3 { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessState { get; set; }
        public string BusinessPostalCode { get; set; }
        public string BusinessCountryRegion { get; set; }
        public string HomeStreet { get; set; }
        public string HomeStreet2 { get; set; }
        public string HomeStreet3 { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomePostalCode { get; set; }
        public string HomeCountryRegion { get; set; }
        public string OtherStreet { get; set; }
        public string OtherStreet2 { get; set; }
        public string OtherStreet3 { get; set; }
        public string OtherCity { get; set; }
        public string OtherState { get; set; }
        public string OtherPostalCode { get; set; }
        public string OtherCountryRegion { get; set; }
        public string BusinessFax { get; set; }
        public string BusinessPhone { get; set; }
        public string BusinessPhone2 { get; set; }
        public string CompanyMainPhone { get; set; }
        public string HomeFax { get; set; }
        public string HomePhone { get; set; }
        public string HomePhone2 { get; set; }
        public string MobilePhone { get; set; }
        public string OtherFax { get; set; }
        public string OtherPhone { get; set; }
        public string PrimaryPhone { get; set; }
        public string Birthday { get; set; }
        public long? BirthdayLong
        {
            set
            {
                if (value.HasValue)
                {
                    Birthday = new DateTime(value.Value).ToString();
                }
                else
                {
                    Birthday = null;
                }
            }
        }
        public string BusinessAddressPoBox { get; set; }
        public string Categories { get; set; }
        public string EmailAddress { get; set; }
        public string Email2Address { get; set; }
        public string Email3Address { get; set; }
        public string Gender { get; set; }
        public string GovernmentIdNumber { get; set; }
        public string Hobby { get; set; }
        public string HomeAddressPoBox { get; set; }
        public string Initials
        {
            get
            {
                return $"{FirstName.FirstOrDefault().ToString().ToUpperInvariant()}{LastName.FirstOrDefault().ToString().ToUpperInvariant()}";
            }
        }
        public string Language { get; set; }
        public string OrganizationalIdNumber { get; set; }
        public string OtherAddressPoBox { get; set; }
        public string Profession { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string CrunchbaseUrl { get; set; }
        public string Skype { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}