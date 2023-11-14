using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Person : Entity
    {
        #region Properties

        public Prop<VertexLabel> Label { get; set; }
        public string FullName => string.Join(" ",
            new string[] { FirstName, MiddleName, LastName }.Where(x => !string.IsNullOrWhiteSpace(x)));
        public Prop<string> SourceId { get; set; }
        public Prop<string> ProspexId { get; set; }
        public Prop<string> LomiId { get; set; }
        public Prop<string> FirstName { get; set; }
        public Prop<string> LastName { get; set; }
        public Prop<string> MiddleName { get; set; }
        public Prop<Gender> Gender { get; }
        public Prop<AgeCategory> AgeCategory { get; }
        public EmploymentHistory EmploymentHistory { get; }
        public PersonLocation Location { get; }
        public Prop<string> Email { get; private set; }
        public Prop<string> Email2 { get; set; }
        public Prop<string> Email3 { get; set; }
        public Prop<string> Hobby { get; set; }
        public Prop<string> AddressPoBox { get; set; }
        public Prop<string> City { get; set; }
        public Prop<string> Country { get; set; }
        public Prop<string> Fax { get; set; }
        public Prop<string> PostalCode { get; set; }
        public Prop<string> State { get; set; }
        public Prop<string> Street { get; set; }
        public Prop<string> Street2 { get; set; }
        public Prop<string> Street3 { get; set; }
        public Prop<string> Region { get; set; }
        public Prop<string> Phone { get; set; }
        public Prop<string> Phone2 { get; set; }
        public Prop<string> JobTitle;
        public Occupations Occupations { get; private set; }
        public Skills Skills { get; private set; }
        public EducationInfoHistory EducationList { get; private set; }
        public Prop<string> PictureUrl { get; set; }
        /// <summary>
        /// UTC offset in minutes.
        /// </summary>
        public Prop<int> UtcOffset { get; set; }
        public Prop<bool> IsLocked { get; set; }
        public Prop<int?> ProfileCompletion { get; set; }
        public Prop<string> FacebookUrl { get; set; }
        public Prop<string> TwitterUrl { get; set; }
        public Prop<string> LinkedInUrl { get; set; }
        public Prop<string> CrunchbaseUrl { get; set; }
        public Prop<string> Bio;
        public Prop<long?> Birthdate { get; set; }
        public List<string> Phones { get; set; }
        public Prop<string> Language { get; set; }
        public Prop<string> MobilePhone { get; set; }
        public Prop<string> PrimaryPhone { get; set; }
        public Prop<string> Skype { get; set; }

        public string GeoLocation => !string.IsNullOrEmpty(Location?.GeoLocation) ? Location.GeoLocation : string.Empty;

        public string LocationName => !string.IsNullOrEmpty(Location?.LocationName) ? Location.LocationName : string.Empty;

        public string CurrentCompany
        {
            get
            {
                return EmploymentHistory.EmploymentList
                                        .FirstOrDefault(x => x.Company.HasValue && x.IsPrimary)?.Company.Value.Name ?? string.Empty;
            }
        }

        #endregion

        #region Constructors

        public Person(PersonName name, Maybe<Email> email, Source source) : this
            (source, null, name, email, Enums.Gender.Unknown, Enums.AgeCategory.Unknown,
            EmploymentHistory.None(), PersonLocation.None(), Occupations.None(), Skills.None(), EducationInfoHistory.None(), null, new List<string>())
        {
            Label = VertexLabel.Person;
        }

        public Person(Source source,
                     string dataSourceId,
                     PersonName name,
                     Maybe<Email> email,
                     Gender gender,
                     AgeCategory ageCategory,
                     EmploymentHistory employmentHistory,
                     PersonLocation location,
                     Occupations occupations,
                     Skills skills,
                     EducationInfoHistory educationList,
                     string pictureUrl,
                     List<string> phones)
        {
            Label = VertexLabel.Person;
            //SourceId = dataSourceId;
            Email = email.HasValue ? email.Value.Value.ToLower() : string.Empty;
            FirstName = name?.FirstName.ToLower();
            LastName = name?.LastName.ToLower();
            EmploymentHistory = employmentHistory;
            AgeCategory = ageCategory;
            Location = location;
            Occupations = occupations;
            Gender = gender;
            Skills = skills;
            EducationList = educationList;
            PictureUrl = pictureUrl;
            JobTitle = occupations.Values.FirstOrDefault();
        }

        #endregion

    }
}