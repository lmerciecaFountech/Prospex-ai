using Lomi.Infrastructure.DataIndexing;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Service.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //OnboardingCompanies();
            //OnboardingPersons();

            //AddCompanyAndPersonsFromCrunchbase();

            //onboardingService.CalculateWeightAsync("e646c715-0422-5b83-a43e-4ec54e60cff0").Wait();
            //Task.Delay(500);
            //onboardingService.CalculateGlobalWeightAsync("64182e8a-1845-5ccf-942e-0a1a61d3b649").Wait();
            //onboardingService.CalculateGlobalWeightAsync("8b90f978-36d6-5548-a0f6-45866046bbf9").Wait();

            //var xx = new OnboardingService();
            //xx.AcceptLeadAsync("899e2cf2-4d4d-5739-9bbe-287fe9b56e97", "849bbde4-2d5a-51ef-8d8f-b4b0091a2d2e").Wait();
            //xx.ReferLeadAsync("899e2cf2-4d4d-5739-9bbe-287fe9b56e97", "849bbde4-2d5a-51ef-8d8f-b4b0091a2d2e", "3eb3f909-a481-5b8b-9f21-9fce06d1ec57").Wait();

            //var generator = new LeadGeneratorService();
            //generator.GenerateAsync("e646c715-0422-5b83-a43e-4ec54e60cff0", "").Wait();

            AddCrunchbaseCompanies();

            //LoadPersons();

            //CreateLeads();


            Console.WriteLine("Finishing...");
            Console.ReadKey();
        }

        public static void OnboardingCompanies()
        {
            var onboardingService = new OnboardingService();

            var company = new CompanyDTO
            {
                Id = "1",
                Name = "Fountech Solutions",
                Active = true,
                City = "New York",
                Country = "United States",
                AddressLine1 = "New York, United States",
                Region = "CY",
                Website = "https://fountech.solutions",
                SubdomainAddress = "https://fountech.solutions",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "1", PlaceId = "ChIJOwg_06VPwokRYv534QaPC8g"}
                },
                Products = new List<ProductDTO>
                {
                    new ProductDTO { Id = "1", Name = "Artificial Intelligence", Description = "Artificial Intelligence"}
                }
            };

            onboardingService.AddCompanyAsync(company, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} has added", company.Name));

            Task.Delay(500);

            var company2 = new CompanyDTO
            {
                Id = "2",
                Name = "Prospex",
                Active = true,
                City = "London",
                Country = "United Kingdom",
                Region = "UK",
                AddressLine1 = "London, England, United Kingdom",
                SubdomainAddress = "https://prospex.ai",
                Website = "https://prospex.ai",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "2", PlaceId = "EhVDaGVhcHNpZGUsIExvbmRvbiwgVUsiLiosChQKEgkbEHavqgR2SBFhPUSsXP0EJRIUChIJqZHHQhE7WgIReiWIMkOg-MQ" },
                },
                Products = new List<ProductDTO>
                {
                    new ProductDTO { Id = "2", Name = "Software", Description = "Software"},
                    new ProductDTO { Id = "3", Name = "Artificial Intelligence", Description = "Artificial Intelligence"},
                    new ProductDTO { Id = "4", Name = "Analytics", Description = "Analytics"},
                }
            };

            onboardingService.AddCompanyAsync(company2, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} has added", company2.Name));

            Task.Delay(500);

            var company3 = new CompanyDTO
            {
                Id = "3",
                Name = "Dinabite",
                Active = true,
                City = "London",
                Country = "United Kingdom",
                AddressLine1 = "London, England, United Kingdom",
                Region = "UK",
                SubdomainAddress = "https://dinabite.ai",
                Website = "https://dinabite.ai",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "3", PlaceId = "ChIJuX_-UJ0FdkgRTJPFOHK77dM" },
                },
                Products = new List<ProductDTO>
                {
                    new ProductDTO { Id = "5", Name = "Artificial Intelligence", Description = "Artificial Intelligence"},
                    new ProductDTO { Id = "6", Name = "Food and Beverage", Description = "Food and Beverage"},
                    new ProductDTO { Id = "7", Name = "Hospitality", Description = "Hospitality"},
                    new ProductDTO { Id = "8", Name = "Marketing", Description = "Marketing"},
                }
            };

            onboardingService.AddCompanyAsync(company3, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} has added", company3.Name));

            Task.Delay(500);

            var company4 = new CompanyDTO
            {
                Id = "4",
                Name = "Soffos",
                Active = true,
                City = "Washington",
                Country = "United States",
                AddressLine1 = "Washington, United States",
                Region = "CY",
                SubdomainAddress = "https://soffos.ai",
                Website = "https://soffos.ai",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "4", PlaceId = "ChIJW-T2Wt7Gt4kRKl2I1CJFUsI" },
                },
                Products = new List<ProductDTO>
                {
                    new ProductDTO { Id = "9", Name = "Artificial Intelligence", Description = "Artificial Intelligence"},
                    new ProductDTO { Id = "10", Name = "EdTech", Description = "EdTech"},
                    new ProductDTO { Id = "11", Name = "Education", Description = "Education"},
                }
            };

            onboardingService.AddCompanyAsync(company4, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} has added", company4.Name));

            Task.Delay(500);
        }

        public static void OnboardingPersons()
        {
            var onboardingService = new OnboardingService();

            var person = new AccountDTO
            {
                Id = "1",
                ProspexId = "1",
                RDL = 1,
                AccountType = AccountType.AdminUser,
                JobTitle = "CEO",
                CompanyId = "1",
                Email = "n.kairinos@fountech.solutions",
                FirstName = "Nick",
                LastName = "Kairinos",
                ProfileCompletion = 100,
                PlaceId = "ChIJOwg_06VPwokRYv534QaPC8g",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "1", PlaceId = "ChIJOwg_06VPwokRYv534QaPC8g"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "services", "ceo", "founder", "social", "consulting"
                }
            };
            onboardingService.AddPersonAsync(person, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person.LastName, person.FirstName));

            Task.Delay(500);

            var person2 = new AccountDTO
            {
                Id = "2",
                ProspexId = "2",
                RDL = 1,
                AccountType = AccountType.AdminUser,
                JobTitle = "Senior Software Developer",
                CompanyId = "2",
                Email = "savvas.ioannidis@fountech.solutions",
                FirstName = "Savvas",
                LastName = "Ioannidis",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "Software", "technology", "mobile", "analysis", "development"
                }
            };
            onboardingService.AddPersonAsync(person2, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person2.LastName, person2.FirstName));

            Task.Delay(500);

            var person3 = new AccountDTO
            {
                Id = "3",
                ProspexId = "3",
                RDL = 1,
                AccountType = AccountType.AdminUser,
                JobTitle = "QA Manager",
                CompanyId = "3",
                Email = "a.christofi@fountech.solutions",
                FirstName = "Andreas",
                LastName = "Christofi",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "testing", "machine", "applications", "internet", "engineering"
                }
            };
            onboardingService.AddPersonAsync(person3, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person3.LastName, person3.FirstName));

            Task.Delay(500);

            var person4 = new AccountDTO
            {
                Id = "4",
                ProspexId = "4",
                RDL = 1,
                AccountType = AccountType.AdminUser,
                JobTitle = "Software Architect",
                CompanyId = "4",
                Email = "s.kairinos@fountech.solutions",
                FirstName = "Stefan",
                LastName = "Kairinos",
                ProfileCompletion = 100,
                PlaceId = "ChIJW-T2Wt7Gt4kRKl2I1CJFUsI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "4", PlaceId = "ChIJW-T2Wt7Gt4kRKl2I1CJFUsI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "edtech", "education", "mobile", "services", "university"
                }
            };
            onboardingService.AddPersonAsync(person4, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person4.LastName, person4.FirstName));

            Task.Delay(500);

            var person5 = new AccountDTO
            {
                Id = "5",
                ProspexId = "5",
                RDL = 1,
                AccountType = AccountType.AdminUser,
                JobTitle = "Lead AI Architect",
                CompanyId = "2",
                Email = "petros.mina@fountech.solutions",
                FirstName = "Petros",
                LastName = "Mina",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "data science", "data", "know", "collect", "place"
                }
            };
            onboardingService.AddPersonAsync(person5, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person5.LastName, person5.FirstName));

            Task.Delay(500);

            var person6 = new AccountDTO
            {
                Id = "6",
                ProspexId = "6",
                RDL = 1,
                AccountType = AccountType.AdminUser,
                JobTitle = "Secretary",
                CompanyId = "2",
                Email = "a.kyriacou@fountech.solutions",
                FirstName = "Alexia",
                LastName = "Kyriacou",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Female,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "secretary", "payroll", "operational", "economic", "staff"
                }
            };
            onboardingService.AddPersonAsync(person6, Source.Onboarding).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person6.LastName, person6.FirstName));

            Task.Delay(500);
        }

        public static void AddCompanyAndPersonsFromCrunchbase()
        {
            var onboardingService = new OnboardingService();

            var company5 = new CompanyDTO
            {
                Id = "5",
                Name = "Lingoda",
                Active = true,
                City = "London",
                Country = "United Kingdom",
                Region = "UK",
                AddressLine1 = "London, UnitedKingdom",
                Website = "https://lingoda.com",
                SubdomainAddress = "https://lingoda.com",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI" },
                }
            };

            onboardingService.AddCompanyAsync(company5, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} has added", company5.Name));
            Task.Delay(500);


            var person7 = new AccountDTO
            {
                Id = "7",
                AccountType = AccountType.AdminUser,
                JobTitle = "CO-Founder, Managing Director",
                CompanyId = "5",
                Email = "contact@lingoda.com",
                FirstName = "Felix",
                LastName = "Wunderlich",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "education", "offers", "edtech", "felix", "from"
                }
            };
            onboardingService.AddPersonAsync(person7, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person7.LastName, person7.FirstName));
            Task.Delay(500);

            var company6 = new CompanyDTO
            {
                Id = "6",
                Name = "Mimo",
                Active = true,
                City = "London",
                Country = "United Kingdom",
                Region = "UK",
                AddressLine1 = "London, UnitedKingdom",
                Website = "https://mimo.com",
                SubdomainAddress = "https://mimo.com",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI" },
                }
            };

            onboardingService.AddCompanyAsync(company6, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} has added", company6.Name));
            Task.Delay(500);

            var person8 = new AccountDTO
            {
                Id = "8",
                AccountType = AccountType.AdminUser,
                JobTitle = "Co-founder and Chief Operating Officer",
                CompanyId = "6",
                Email = "",
                FirstName = "Henry",
                LastName = "Ameseder",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "education", "mobile", "computer", "industry", "interactive"
                }
            };
            onboardingService.AddPersonAsync(person8, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person8.LastName, person8.FirstName));
            Task.Delay(500);

            var company7 = new CompanyDTO
            {
                Id = "7",
                Name = "Princeton Review",
                Active = true,
                City = "London",
                Country = "United Kingdom",
                Region = "UK",
                AddressLine1 = "London, UnitedKingdom",
                Website = "https://princeton.com",
                SubdomainAddress = "https://princeton.com",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI" },
                }
            };

            onboardingService.AddCompanyAsync(company7, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} has added", company7.Name));
            Task.Delay(500);

            var person9 = new AccountDTO
            {
                Id = "9",
                AccountType = AccountType.AdminUser,
                JobTitle = "Acting Chief Executive Officer",
                CompanyId = "7",
                Email = "",
                FirstName = "Alexis",
                LastName = "Ferraro",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "print", "review", "services", "education", "courses"
                }
            };

            onboardingService.AddPersonAsync(person9, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person9.LastName, person9.FirstName));
            Task.Delay(500);

            var company8 = new CompanyDTO
            {
                Id = "8",
                Name = "LearnerLane",
                Active = true,
                City = "London",
                Country = "United Kingdom",
                Region = "UK",
                AddressLine1 = "London, UnitedKingdom",
                Website = "https://learnerlane.com",
                SubdomainAddress = "https://learnerlane.com",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI" },
                }
            };

            onboardingService.AddCompanyAsync(company8, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} has added", company8.Name));
            Task.Delay(500);

            var person10 = new AccountDTO
            {
                Id = "10",
                AccountType = AccountType.AdminUser,
                JobTitle = "Principal",
                CompanyId = "8",
                Email = "",
                FirstName = "Seun",
                LastName = "Debiyi",
                ProfileCompletion = 100,
                PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI",
                Locations = new List<LocationDTO>
                {
                    new LocationDTO { Id = "5", PlaceId = "ChIJdd4hrwug2EcRmSrV3Vo6llI"}
                },
                Gender = Gender.Male,
                IsLocked = false,
                Keywords = new List<string>
                {
                    "learnerlane", "director", "education", "university", "believe"
                }
            };

            onboardingService.AddPersonAsync(person10, Source.FullContact).Wait();
            Console.WriteLine(string.Format("{0} {1} has added", person10.LastName, person10.FirstName));
            Task.Delay(500);
        }

        public static void AddCrunchbaseCompanies()
        {
            //var textProcessor = TextProcessor.Instance();
            var onboardingService = new OnboardingService();

            var query = @"SELECT *
                FROM [CrunhbaseData].[dbo].[Companies] as c
                WHERE uuid IN (SELECT featured_job_organization_uuid  
                        FROM [CrunhbaseData].[dbo].[Person]
                        WHERE keywords NOT Like '' and city NOT Like '' and country_code NOT LIKE ''
                        AND FC_City NOT LIKE '' and FC_Country NOT LIKE '')
ORDER BY uuid
OFFSET 3711 ROWS FETCH NEXT 10000 ROWS ONLY";

            var updateQuery = @"UPDATE [dbo].[Companies]
                                SET [IsProcessed] = 1
                            WHERE uuid = @uuid";


            var personQuery = @"SELECT *
                FROM [CrunhbaseData].[dbo].[Person] as p
                WHERE keywords NOT Like '' and city NOT Like '' and country_code NOT LIKE ''
                AND FC_City NOT LIKE '' and FC_Country NOT LIKE '' AND featured_job_organization_uuid = @uuid";

            int counter = 0;
            int metritis = 0;
            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = CrunhbaseData; Integrated Security =SSPI;MultipleActiveResultSets=True"))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            counter++;
                            var company = new CompanyDTO
                            {
                                Id = GetReturnValue(reader["uuid"]),
                                Name = GetReturnValue(reader["name"]),
                                Active = true,
                                City = GetReturnValue(reader["city"]),
                                Country = GetReturnValue(reader["country_code"]) == "USA"
                                ? "United States"
                                : GetReturnValue(reader["city"]) == "GBR"
                                    ? "United Kingdom"
                                    : string.Empty,
                                PostCode = GetReturnValue(reader["postal_code"]),
                                Region = GetReturnValue(reader["region"]),
                                AddressLine1 = GetReturnValue(reader["address"]),
                                Website = GetReturnValue(reader["homepage_url"]),
                                SubdomainAddress = GetReturnValue(reader["domain"]),
                                ContactEmail = GetReturnValue(reader["email"]),
                                ContactTelephoneNumber = GetReturnValue(reader["phone"])
                            };

                            onboardingService.AddCompanyAsync(company, Source.FullContact).Wait();
                            Console.WriteLine(string.Format("{0}: {1} has added", counter, company.Name));

                            //using (var command2 = new SqlCommand(updateQuery, connection))
                            //{
                            //var command2 = new SqlCommand(updateQuery, connection);
                            //command2.Parameters.AddWithValue("@uuid", company.Id);
                            //command2.ExecuteNonQuery();
                            //}

                            int counter2 = 0;
                            using (var command3 = new SqlCommand(personQuery, connection))
                            {
                                command3.Parameters.Add("@uuid", SqlDbType.NVarChar).Value = company.Id;
                                SqlDataReader reader2 = command3.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    while (reader2.Read())
                                    {
                                        counter2++;
                                        metritis++;
                                        var bio = GetReturnValue(reader2["FC_Bio"]);
                                        var keywords = GetReturnValue(reader2["keywords"]);
                                        var person = new AccountDTO
                                        {
                                            Id = GetReturnValue(reader2["uuid"]),
                                            CompanyId = GetReturnValue(reader2["featured_job_organization_uuid"]),
                                            FirstName = GetReturnValue(reader2["first_name"]),
                                            LastName = GetReturnValue(reader2["last_name"]),
                                            Gender = GetReturnValue(reader2["gender"]) == "male"
                                                ? Gender.Male
                                                : Gender.Female,
                                            JobTitle = GetReturnValue(reader2["FC_Title"]),
                                            Email = GetReturnValue(reader2["FC_Email"]),
                                            ImageUri = GetReturnValue(reader2["FC_Avatar"]),
                                            IsLocked = false,
                                            City = GetReturnValue(reader2["city"]) == null
                                                ? GetReturnValue(reader2["FC_City"])
                                                : GetReturnValue(reader2["city"]),
                                            Country = GetCountry(reader2["country_code"], reader2["FC_Country"]),
                                            Keywords = keywords.Split(',').Where(k => !string.IsNullOrEmpty(k)).Take(20).ToList(),
                                            Bio = bio
                                        };
                                        onboardingService.AddPersonAsync(person, Source.FullContact).Wait();
                                        Console.WriteLine(string.Format("\t {0}: {1} has added", counter2, person.FullName));
                                        Task.Delay(250);
                                    }
                                }

                            }

                            Task.Delay(250);
                            
                        }
                    }
                }
            }
        }

        public static string GetCountry(object val, object val2)
        {
            if (val != null)
            {
                var value = Convert.ToString(val);

                if (string.IsNullOrWhiteSpace(value))
                    return null;
                else
                {
                    return value == "USA" ? "United States" : "United Kingdom";
                }
            }
            else
            {
                var value = Convert.ToString(val2);

                if (string.IsNullOrWhiteSpace(value))
                    return null;
                else
                {
                    return value;
                }

            }

        }

        public static string GetReturnValue(object val)
        {
            if (val == null)
                return null;

            var value = Convert.ToString(val);

            if (string.IsNullOrWhiteSpace(value))
                return null;
            else
                return value;
        }

        public static void LoadPersons()
        {
            var textProcessor = TextProcessor.Instance();

            var loadQuery = @"SELECT P.*, pd.description
                FROM [CrunhbaseData].[dbo].[Persons] as p
                LEFT JOIN [CrunhbaseData].[dbo].[PeopleDescriptions] as pd
                ON p.uuid = pd.uuid
                WHERE p.uuid NOT IN (SELECT uuid FROM dbo.Person)";


            var insertQuery = @"INSERT INTO [dbo].[Person]
        ([uuid]
          ,[lomiId]
          ,[IsProcessed]
          ,[name]
          ,[permalink]
          ,[cb_url]
          ,[first_name]
          ,[last_name]
          ,[gender]
          ,[country_code]
          ,[state_code]
          ,[region]
          ,[city]
          ,[featured_job_organization_uuid]
          ,[featured_job_organization_name]
          ,[featured_job_title]
          ,[facebook_url]
          ,[linkedin_url]
          ,[twitter_url]
          ,[logo_url]
          ,[description]
          ,[keywords]
          ,[FC_Email]
          ,[FC_Phone]
          ,[FC_FullName]
          ,[FC_GivenName]
          ,[FC_FamilyName]
          ,[FC_Gender]
          ,[FC_AgeRange]
          ,[FC_AgeValue]
          ,[FC_Location]
          ,[FC_City]
          ,[FC_Region]
          ,[FC_RegionCode]
          ,[FC_Country]
          ,[FC_CountryCode]
          ,[FC_FormattedLocation]
          ,[FC_Title]
          ,[FC_Organization]
          ,[FC_LinkedIn]
          ,[FC_Twitter]
          ,[FC_Facebook]
          ,[FC_Bio]
          ,[FC_Avatar]
          ,[FC_Website])
    VALUES
          (@uuid, @lomiId, @isProcessed, @name, @permalink, @cbUrl, @firstName, @lastName,
           @gender, @countryCode, @stateCode, @region, @city, @featuredJobOrganizationUuid, @featuredJobOrganizationName, @featuredJobTitle,
           @facebookUrl, @linkedinUrl, @twitterUrl, @logoUrl, @description, @keywords, @fc_Email, @fc_Phone, @fc_FullName, @fc_FamilyName,
@fc_GivenName, @fc_Gender, @fc_AgeRange, @fc_AgeValue, @fc_Location, @fc_City, @fc_Region, @fc_RegionCode, @fc_Country, @fc_CountryCode,
@fc_FormattedLocation, @fc_Title, @fc_Organization, @fc_LinkedIn, @fc_Twitter, @fc_Facebook, @fc_Bio, @fc_Avatar, @fc_Website)";


            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = CrunhbaseData; Integrated Security =SSPI;MultipleActiveResultSets=True; Connection Timeout=60"))
            {
                connection.Open();
                string uuid = string.Empty;
                string lomiId = string.Empty;
                bool isProcessed = false;
                string name = string.Empty;
                string permalink = string.Empty;
                string cbUrl = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string gender = string.Empty;
                string countryCode = string.Empty;
                string stateCode = string.Empty;
                string region = string.Empty;
                string city = string.Empty;
                string featuredJobOrganizationUuid = string.Empty;
                string featuredJobOrganizationName = string.Empty;
                string featuredJobTitle = string.Empty;
                string facebookUrl = string.Empty;
                string linkedinUrl = string.Empty;
                string twitterUrl = string.Empty;
                string logoUrl = string.Empty;
                string keywords = string.Empty;
                string description = string.Empty;
                string fc_Email = string.Empty;
                string fc_Phone = string.Empty;
                string fc_FullName = string.Empty;
                string fc_GivenName = string.Empty;
                string fc_FamilyName = string.Empty;
                string fc_Gender = string.Empty;
                string fc_AgeRange = string.Empty;
                string fc_AgeValue = string.Empty;
                string fc_Location = string.Empty;
                string fc_City = string.Empty;
                string fc_Region = string.Empty;
                string fc_RegionCode = string.Empty;
                string fc_Country = string.Empty;
                string fc_CountryCode = string.Empty;
                string fc_FormattedLocation = string.Empty;
                string fc_Title = string.Empty;
                string fc_Organization = string.Empty;
                string fc_LinkedIn = string.Empty;
                string fc_Twitter = string.Empty;
                string fc_Facebook = string.Empty;
                string fc_Bio = string.Empty;
                string fc_Avatar = string.Empty;
                string fc_Website = string.Empty;




                int counter = 0;

                using (var command = new SqlCommand(loadQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var desc = reader["description"] != null ? Convert.ToString(reader["description"]) : string.Empty;
                            var b = reader["FC_Bio"] != null ? Convert.ToString(reader["FC_Bio"]) : string.Empty;
                            var bio = string.Format("{0} {1}", b, desc);
                            var phrases = textProcessor.Process(bio).Result;
                            var k = string.Empty;

                            if (phrases.Any())
                                k = string.Join(",", phrases.Select(p => p.Value.Value));


                            keywords = k;
                            uuid = reader["uuid"] != null ? Convert.ToString(reader["uuid"]) : null;
                            lomiId = reader["lomiId"] != null ? Convert.ToString(reader["lomiId"]) : null;
                            isProcessed = reader["isProcessed"] != null ? Convert.ToBoolean(reader["isProcessed"]) : false;
                            name = reader["name"] != null ? Convert.ToString(reader["name"]) : null;
                            permalink = reader["permalink"] != null ? Convert.ToString(reader["permalink"]) : null;
                            cbUrl = reader["cb_url"] != null ? Convert.ToString(reader["cb_url"]) : null;
                            firstName = reader["first_name"] != null ? Convert.ToString(reader["first_name"]) : null;
                            lastName = reader["last_name"] != null ? Convert.ToString(reader["last_name"]) : null;
                            gender = reader["gender"] != null ? Convert.ToString(reader["gender"]) : null;
                            countryCode = reader["country_code"] != null ? Convert.ToString(reader["country_code"]) : null;
                            stateCode = reader["state_code"] != null ? Convert.ToString(reader["state_code"]) : null;
                            region = reader["region"] != null ? Convert.ToString(reader["region"]) : null;
                            city = reader["city"] != null ? Convert.ToString(reader["city"]) : null;
                            featuredJobOrganizationUuid = reader["featured_job_organization_uuid"] != null ? Convert.ToString(reader["featured_job_organization_uuid"]) : null;
                            featuredJobOrganizationName = reader["featured_job_organization_name"] != null ? Convert.ToString(reader["featured_job_organization_name"]) : null;
                            featuredJobTitle = reader["featured_job_title"] != null ? Convert.ToString(reader["featured_job_title"]) : null;
                            facebookUrl = reader["facebook_url"] != null ? Convert.ToString(reader["facebook_url"]) : null;
                            linkedinUrl = reader["linkedin_url"] != null ? Convert.ToString(reader["linkedin_url"]) : null;
                            twitterUrl = reader["twitter_url"] != null ? Convert.ToString(reader["twitter_url"]) : null;
                            logoUrl = reader["logo_url"] != null ? Convert.ToString(reader["logo_url"]) : null;
                            description = reader["description"] != null ? Convert.ToString(reader["description"]) : null;
                            fc_Email = reader["FC_Email"] != null ? Convert.ToString(reader["FC_Email"]) : null;
                            fc_Phone = reader["FC_Phone"] != null ? Convert.ToString(reader["FC_Phone"]) : null;
                            fc_FullName = reader["FC_FullName"] != null ? Convert.ToString(reader["FC_FullName"]) : null;
                            fc_GivenName = reader["FC_GivenName"] != null ? Convert.ToString(reader["FC_GivenName"]) : null;
                            fc_FamilyName = reader["FC_FamilyName"] != null ? Convert.ToString(reader["FC_FamilyName"]) : null;
                            fc_Gender = reader["FC_Gender"] != null ? Convert.ToString(reader["FC_Gender"]) : null;
                            fc_AgeRange = reader["FC_AgeRange"] != null ? Convert.ToString(reader["FC_AgeRange"]) : null;
                            fc_AgeValue = reader["FC_AgeValue"] != null ? Convert.ToString(reader["FC_AgeValue"]) : null;
                            fc_Location = reader["FC_Location"] != null ? Convert.ToString(reader["FC_Location"]) : null;
                            fc_City = reader["FC_City"] != null ? Convert.ToString(reader["FC_City"]) : null;
                            fc_Region = reader["FC_Region"] != null ? Convert.ToString(reader["FC_Region"]) : null;
                            fc_RegionCode = reader["FC_RegionCode"] != null ? Convert.ToString(reader["FC_RegionCode"]) : null;
                            fc_Country = reader["FC_Country"] != null ? Convert.ToString(reader["FC_Country"]) : null;
                            fc_CountryCode = reader["FC_CountryCode"] != null ? Convert.ToString(reader["FC_CountryCode"]) : null;
                            fc_Title = reader["FC_Title"] != null ? Convert.ToString(reader["FC_Title"]) : null;
                            fc_Organization = reader["FC_Organization"] != null ? Convert.ToString(reader["FC_Organization"]) : null;
                            fc_LinkedIn = reader["FC_LinkedIn"] != null ? Convert.ToString(reader["FC_LinkedIn"]) : null;
                            fc_Twitter = reader["FC_Twitter"] != null ? Convert.ToString(reader["FC_Twitter"]) : null;
                            fc_Facebook = reader["FC_Facebook"] != null ? Convert.ToString(reader["FC_Facebook"]) : null;
                            fc_Bio = reader["FC_Bio"] != null ? Convert.ToString(reader["FC_Bio"]) : null;
                            fc_Avatar = reader["FC_Avatar"] != null ? Convert.ToString(reader["FC_Avatar"]) : null;
                            fc_Website = reader["FC_Website"] != null ? Convert.ToString(reader["FC_Website"]) : null;

                            counter++;
                            Console.WriteLine(string.Format("{0}: {1}", counter, name));

                            using (var command2 = new SqlCommand(insertQuery, connection))
                            {
                                command2.CommandTimeout = 100;
                                command2.Parameters.AddWithValue("@uuid", uuid);
                                command2.Parameters.AddWithValue("@lomiId", lomiId);
                                command2.Parameters.AddWithValue("@IsProcessed", isProcessed);
                                command2.Parameters.AddWithValue("@name", name == null ? (object)DBNull.Value : name);
                                command2.Parameters.AddWithValue("@permalink", permalink == null ? (object)DBNull.Value : permalink);
                                command2.Parameters.AddWithValue("@cbUrl", cbUrl == null ? (object)DBNull.Value : cbUrl);
                                command2.Parameters.AddWithValue("@firstName", firstName == null ? (object)DBNull.Value : firstName);
                                command2.Parameters.AddWithValue("@lastName", lastName == null ? (object)DBNull.Value : lastName);
                                command2.Parameters.AddWithValue("@gender", gender == null ? (object)DBNull.Value : gender);
                                command2.Parameters.AddWithValue("@countryCode", countryCode == null ? (object)DBNull.Value : countryCode);
                                command2.Parameters.AddWithValue("@stateCode", stateCode == null ? (object)DBNull.Value : stateCode);
                                command2.Parameters.AddWithValue("@region", region == null ? (object)DBNull.Value : region);
                                command2.Parameters.AddWithValue("@city", city == null ? (object)DBNull.Value : city);
                                command2.Parameters.AddWithValue("@featuredJobOrganizationUuid", featuredJobOrganizationUuid == null ? (object)DBNull.Value : featuredJobOrganizationUuid);
                                command2.Parameters.AddWithValue("@featuredJobOrganizationName", featuredJobOrganizationName == null ? (object)DBNull.Value : featuredJobOrganizationName);
                                command2.Parameters.AddWithValue("@featuredJobTitle", featuredJobTitle == null ? (object)DBNull.Value : featuredJobTitle);
                                command2.Parameters.AddWithValue("@facebookUrl", facebookUrl == null ? (object)DBNull.Value : facebookUrl);
                                command2.Parameters.AddWithValue("@linkedinUrl", linkedinUrl == null ? (object)DBNull.Value : linkedinUrl);
                                command2.Parameters.AddWithValue("@twitterUrl", twitterUrl == null ? (object)DBNull.Value : twitterUrl);
                                command2.Parameters.AddWithValue("@logoUrl", logoUrl == null ? (object)DBNull.Value : logoUrl);
                                command2.Parameters.AddWithValue("@keywords", keywords == null ? (object)DBNull.Value : keywords);
                                command2.Parameters.AddWithValue("@description", description == null ? (object)DBNull.Value : description);
                                command2.Parameters.AddWithValue("@fc_Email", fc_Email == null ? (object)DBNull.Value : fc_Email);
                                command2.Parameters.AddWithValue("@fc_Phone", fc_Phone == null ? (object)DBNull.Value : fc_Phone);
                                command2.Parameters.AddWithValue("@fc_FullName", fc_FullName == null ? (object)DBNull.Value : fc_FullName);
                                command2.Parameters.AddWithValue("@fc_GivenName", fc_GivenName == null ? (object)DBNull.Value : fc_GivenName);
                                command2.Parameters.AddWithValue("@fc_FamilyName", fc_FamilyName == null ? (object)DBNull.Value : fc_FamilyName);
                                command2.Parameters.AddWithValue("@fc_Gender", fc_Gender == null ? (object)DBNull.Value : fc_Gender);
                                command2.Parameters.AddWithValue("@fc_AgeRange", fc_AgeRange == null ? (object)DBNull.Value : fc_AgeRange);
                                command2.Parameters.AddWithValue("@fc_AgeValue", fc_AgeValue == null ? (object)DBNull.Value : fc_AgeValue);
                                command2.Parameters.AddWithValue("@fc_Location", fc_Location == null ? (object)DBNull.Value : fc_Location);
                                command2.Parameters.AddWithValue("@fc_City", fc_City == null ? (object)DBNull.Value : fc_City);
                                command2.Parameters.AddWithValue("@fc_Region", fc_Region == null ? (object)DBNull.Value : fc_Region);
                                command2.Parameters.AddWithValue("@fc_RegionCode", fc_RegionCode == null ? (object)DBNull.Value : fc_RegionCode);
                                command2.Parameters.AddWithValue("@fc_Country", fc_Country == null ? (object)DBNull.Value : fc_Country);
                                command2.Parameters.AddWithValue("@fc_CountryCode", fc_CountryCode == null ? (object)DBNull.Value : fc_CountryCode);
                                command2.Parameters.AddWithValue("@fc_FormattedLocation", fc_FormattedLocation == null ? (object)DBNull.Value : fc_FormattedLocation);
                                command2.Parameters.AddWithValue("@fc_Title", fc_Title == null ? (object)DBNull.Value : fc_Title);
                                command2.Parameters.AddWithValue("@fc_Organization", fc_Organization == null ? (object)DBNull.Value : fc_Organization);
                                command2.Parameters.AddWithValue("@fc_LinkedIn", fc_LinkedIn == null ? (object)DBNull.Value : fc_LinkedIn);
                                command2.Parameters.AddWithValue("@fc_Twitter", fc_Twitter == null ? (object)DBNull.Value : fc_Twitter);
                                command2.Parameters.AddWithValue("@fc_Facebook", fc_Facebook == null ? (object)DBNull.Value : fc_Facebook);
                                command2.Parameters.AddWithValue("@fc_Bio", fc_Bio == null ? (object)DBNull.Value : fc_Bio);
                                command2.Parameters.AddWithValue("@fc_Avatar", fc_Avatar == null ? (object)DBNull.Value : fc_Avatar);
                                command2.Parameters.AddWithValue("@fc_Website", fc_Website == null ? (object)DBNull.Value : fc_Website);


                                command2.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }

        }


        public static void CreateLeads()
        {
            var loadPersons = @"SELECT *
                FROM [CrunhbaseData].[dbo].[Person] as p
                WHERE keywords NOT Like '' and city NOT Like '' and country_code NOT LIKE ''
                AND FC_City NOT LIKE '' and FC_Country NOT LIKE '' AND featured_job_organization_uuid = @uuid";

            var loadCompanies = @"SELECT *
                FROM [CrunhbaseData].[dbo].[Companies] as c
                WHERE uuid IN (SELECT featured_job_organization_uuid  
                        FROM [CrunhbaseData].[dbo].[Person]
                        WHERE keywords NOT Like '' and city NOT Like '' and country_code NOT LIKE ''
                        AND FC_City NOT LIKE '' and FC_Country NOT LIKE '')";

            var insertQuery = @"INSERT INTO [dbo].[Lead]
           ([ExpiryNotifiedOn]
            ,[CreatedOn]
           ,[UpdatedOn]
           ,[GenericLocation]
           ,[GenericJobTitle]
           ,[LomiId]
           ,[FirstName]
           ,[LastName]
           ,[FullName]
           ,[Initials]
           ,[BusinessName]
           ,[BusinessLogo]
           ,[ProfileImage]
           ,[JobTitle]
           ,[Location]
           ,[Keywords]
           ,[LinkedInUrl]
           ,[TwitterUrl]
           ,[FacebookUrl]
           ,[CrunchbaseUrl]
           ,[GenerationDate]
           ,[Title]
           ,[Company]
           ,[CompanyMainPhone]
           ,[BusinessStreet]
           ,[BusinessCity]
           ,[BusinessState]
           ,[BusinessPostalCode]
           ,[BusinessCountryRegion]
           ,[BusinessPhone]
           ,[HomeCity]
           ,[HomeState]
           ,[HomeCountryRegion]
           ,[Gender])
     VALUES
           (@expiryNotifiedOn,@createdOn,@updatedOn,@genericLocation,@genericJobTitle,@lomiId,@firstName,@lastName,@fullName,@initials,@businessName,
@businessLogo,@profileImage,@jobTitle,@location,@keywords,@linkedinUrl,@twitterUrl,@facebookUrl,@crunchbaseUrl,@generationDate,
@title,@company,@companyMainPhone,@businessStreet,@businessCity,@businessState,@businessPostalCode,@businessCountryRegion,@businessPhone,
@homeCity,@homeState,@homeCountryRegion,@gender)";

            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = CrunhbaseData; Integrated Security =SSPI;MultipleActiveResultSets=True; Connection Timeout=60"))
            {
                connection.Open();
                string uuid = string.Empty;
                string lomiId = string.Empty;
                string firstName = string.Empty;
                string lastName = string.Empty;
                string fullName = string.Empty;
                string initials = string.Empty;
                string businessName = string.Empty;
                string businessLogo = string.Empty;
                string profileImage = string.Empty;
                string jobTitle = string.Empty;
                string location = string.Empty;
                string keywords = string.Empty;
                string linkedinUrl = string.Empty;
                string twitterUrl = string.Empty;
                string facebookUrl = string.Empty;
                string crunchbaseUrl = string.Empty;
                string title = string.Empty;
                string company = string.Empty;
                string companyMainPhone = string.Empty;
                string businessStreet = string.Empty;
                string businessCity = string.Empty;
                string businessState = string.Empty;
                string businessPostalCode = string.Empty;
                string businessCountryRegion = string.Empty;
                string businessPhone = string.Empty;
                string homeCity = string.Empty;
                string homeState = string.Empty;
                string homePostalCode = string.Empty;
                string homeCountryRegion = string.Empty;
                string homePhone = string.Empty;
                string gender = string.Empty;
                DateTime createdOn;
                DateTime updatedOn;
                DateTime generationDate;
                int counter = 0;
                using (var command = new SqlCommand(loadCompanies, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            uuid = reader["uuid"] != null ? Convert.ToString(reader["uuid"]) : null;
                            businessName = reader["name"] != null ? Convert.ToString(reader["name"]) : null;
                            businessLogo = reader["logo_url"] != null ? Convert.ToString(reader["logo_url"]) : null;
                            company = businessName;
                            companyMainPhone = reader["phone"] != null ? Convert.ToString(reader["phone"]) : null;
                            businessStreet = reader["address"] != null ? Convert.ToString(reader["address"]) : null;
                            businessCity = reader["city"] != null ? Convert.ToString(reader["city"]) : null;
                            businessState = reader["state_code"] != null ? Convert.ToString(reader["state_code"]) : null;
                            businessPostalCode = reader["postal_code"] != null ? Convert.ToString(reader["postal_code"]) : null;
                            businessCountryRegion = reader["region"] != null ? Convert.ToString(reader["region"]) : null;
                            businessPhone = companyMainPhone;
                            createdOn = DateTime.Now;
                            updatedOn = createdOn;

                            using (var command2 = new SqlCommand(loadPersons, connection))
                            {
                                command2.Parameters.AddWithValue("@uuid", uuid);
                                SqlDataReader reader2 = command2.ExecuteReader();
                                if (reader2.HasRows)
                                {
                                    while (reader2.Read())
                                    {
                                        lomiId = reader2["lomiId"] != null ? Convert.ToString(reader2["lomiId"]) : null;
                                        firstName = reader2["first_name"] != null ? Convert.ToString(reader2["first_name"]) : null;
                                        lastName = reader2["last_name"] != null ? Convert.ToString(reader2["last_name"]) : null;
                                        if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
                                            fullName = firstName + " " + lastName;
                                        else
                                            fullName = reader2["FC_FullName"] != null ? Convert.ToString(reader2["FC_FullName"]) : null;
                                        if (!string.IsNullOrWhiteSpace(firstName))
                                            initials = firstName[0].ToString();
                                        if (!string.IsNullOrWhiteSpace(lastName))
                                            initials = initials + lastName[0].ToString();
                                        profileImage = reader2["FC_Avatar"] != null ? Convert.ToString(reader2["FC_Avatar"]) : null;
                                        jobTitle = reader2["FC_Title"] != null ? Convert.ToString(reader2["FC_Title"]) 
                                            : reader2["featured_job_title"] != null ? Convert.ToString(reader2["featured_job_title"]) : null;
                                        location = reader2["FC_Location"] != null ? Convert.ToString(reader2["FC_Location"]) 
                                            : Convert.ToString(reader2["FC_City"]) + ", " + Convert.ToString(reader2["FC_Region"]) + ", " + Convert.ToString(reader2["FC_Country"]);
                                        keywords = string.Join(",", Convert.ToString(reader2["keywords"]).Split(',').Where(k => !k.Any(c => char.IsDigit(c))).Take(20));
                                        facebookUrl = reader2["FC_Facebook"] != null ? Convert.ToString(reader2["FC_Facebook"]) 
                                            : reader2["facebook_url"] != null ? Convert.ToString(reader2["facebook_url"]) : null;
                                        linkedinUrl = reader2["FC_LinkedIn"] != null ? Convert.ToString(reader2["FC_LinkedIn"])
                                            : reader2["linkedin_url"] != null ? Convert.ToString(reader2["linkedin_url"]) : null;
                                        twitterUrl = reader2["FC_Twitter"] != null ? Convert.ToString(reader2["FC_Twitter"])
                                            : reader2["twitter_url"] != null ? Convert.ToString(reader2["twitter_url"]) : null;
                                        crunchbaseUrl = reader2["cb_url"] != null ? Convert.ToString(reader2["cb_url"]) : null;
                                        generationDate = createdOn;
                                        title = jobTitle;
                                        homeCity = reader2["FC_City"] != null ? Convert.ToString(reader2["FC_City"])
                                            : reader2["city"] != null ? Convert.ToString(reader2["city"]) : null;
                                        homeState = reader2["FC_RegionCode"] != null ? Convert.ToString(reader2["FC_RegionCode"])
                                            : reader2["state_code"] != null ? Convert.ToString(reader2["state_code"]) : null;
                                        homeCountryRegion = reader2["FC_Region"] != null ? Convert.ToString(reader2["FC_Region"])
                                            : reader2["region"] != null ? Convert.ToString(reader2["region"]) : null;

                                        gender = reader2["FC_Gender"] != null ? Convert.ToString(reader2["FC_Gender"])
                                            : reader2["gender"] != null ? Convert.ToString(reader2["gender"]) : null;

                                        using (var command3 = new SqlCommand(insertQuery, connection))
                                        {
                                            command3.CommandTimeout = 100;
                                            command3.Parameters.AddWithValue("@businessName", businessName);
                                            command3.Parameters.AddWithValue("@businessLogo", businessLogo);
                                            command3.Parameters.AddWithValue("@company", company);
                                            command3.Parameters.AddWithValue("@companyMainPhone", companyMainPhone);
                                            command3.Parameters.AddWithValue("@businessStreet", businessStreet);
                                            command3.Parameters.AddWithValue("@businessCity", businessCity);
                                            command3.Parameters.AddWithValue("@businessState", businessState);
                                            command3.Parameters.AddWithValue("@businessPostalCode", businessPostalCode);
                                            command3.Parameters.AddWithValue("@businessCountryRegion", businessCountryRegion);
                                            command3.Parameters.AddWithValue("@businessPhone", businessPhone);
                                            command3.Parameters.AddWithValue("@expiryNotifiedOn", createdOn);
                                            command3.Parameters.AddWithValue("@createdOn", createdOn);
                                            command3.Parameters.AddWithValue("@updatedOn", updatedOn);
                                            command3.Parameters.AddWithValue("@lomiId", lomiId);
                                            command3.Parameters.AddWithValue("@firstName", firstName);
                                            command3.Parameters.AddWithValue("@lastName", lastName);
                                            command3.Parameters.AddWithValue("@fullName", fullName);
                                            command3.Parameters.AddWithValue("@initials", initials);
                                            command3.Parameters.AddWithValue("@profileImage", profileImage);
                                            command3.Parameters.AddWithValue("@jobTitle", jobTitle);
                                            command3.Parameters.AddWithValue("@genericJobTitle", jobTitle);
                                            command3.Parameters.AddWithValue("@genericLocation", location);
                                            command3.Parameters.AddWithValue("@location", location);
                                            command3.Parameters.AddWithValue("@keywords", keywords);
                                            command3.Parameters.AddWithValue("@facebookUrl", facebookUrl);
                                            command3.Parameters.AddWithValue("@linkedinUrl", linkedinUrl);
                                            command3.Parameters.AddWithValue("@twitterUrl", twitterUrl);
                                            command3.Parameters.AddWithValue("@crunchbaseUrl", crunchbaseUrl);
                                            command3.Parameters.AddWithValue("@generationDate", generationDate);
                                            command3.Parameters.AddWithValue("@title", title);
                                            command3.Parameters.AddWithValue("@homeCity", homeCity);
                                            command3.Parameters.AddWithValue("@homeState", homeState);
                                            command3.Parameters.AddWithValue("@homeCountryRegion", homeCountryRegion);
                                            command3.Parameters.AddWithValue("@gender", gender);

                                            command3.ExecuteNonQuery();

                                            counter++;
                                            Console.WriteLine(counter + ":" + firstName + " " + lastName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
