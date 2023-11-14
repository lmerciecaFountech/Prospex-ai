using Lomi.Infrastructure.DataIndexing;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Infrastructure.GraphDB.Extensions;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.Persistence.Interfaces;
using Lomi.Infrastructure.Persistence.Repositories;
using Lomi.Service.Factories;
using Lomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class OnboardingService : IOnboardingService
    {
        #region Members

        private readonly PersonRepository _personRepository;
        private readonly CompanyRepository _companyRepository;
        private readonly ProductRepository _productRepository;
        private readonly AttributeRepository _attributeRepository;
        private readonly CompanyFactory _companyFactory;
        private readonly ProductFactory _productFactory;
        private readonly PersonFactory _personFactory;
        private readonly LomiAlgorithmsService _lomiAlgorithmsService;
        private TextProcessor _textProcessor;

        #endregion

        #region Constructor

        public OnboardingService()
        {
            _personRepository = new PersonRepository();
            _companyRepository = new CompanyRepository();
            _productRepository = new ProductRepository();
            _attributeRepository = new AttributeRepository();
            _companyFactory = new CompanyFactory();
            _productFactory = new ProductFactory();
            _personFactory = new PersonFactory();
            _lomiAlgorithmsService = new LomiAlgorithmsService();
            _textProcessor = TextProcessor.Instance();
        }

        #endregion

        #region Methods

        public async Task CalculateGlobalWeightAsync(string attributeId)
        {
            var averageWeight = await _attributeRepository.GetGlobalAttributeAverageAsync(attributeId);

            await Task.Delay(200);

            if (!double.IsNaN(averageWeight))
            {
                await _attributeRepository.SetAttributeAverageAsync(attributeId, averageWeight);
            }
        }

        public async Task CalculateWeightAsync(string personVertexId)
        {
            await Task.CompletedTask;

            var averageEdges = await _attributeRepository.GetAllAverageAttributesEdgesAsync(personVertexId);

            await Task.Delay(500);

            foreach (var averageEdge in averageEdges)
            {
                await _attributeRepository.SetAttributeAverageAsync(averageEdge);

                await Task.Delay(500);
            }
        }

        public async Task AddCompanyAsync(CompanyDTO prospexCompany, Source source)
        {
            var company = await _companyFactory.Create(prospexCompany);
            var companyVertex = await _companyRepository.AddAsync(company, source);

            await Task.Delay(500);

            if (prospexCompany.Products == null)
                return;

            foreach (var product in prospexCompany.Products)
            {
                var companyProduct = _productFactory.Create(product);
                var productVertex = await _productRepository.AddOrUpdateAsync(companyProduct, source);

                await Task.Delay(250);

                if (productVertex == null)
                    continue;

                var standardEdge = new StandardEdge(EdgeLabel.Sells, source);
                await _productRepository.AddOrUpdateEdgeAsync(companyVertex.Id, productVertex.Id, standardEdge);

                await Task.Delay(250);
            }
        }

        public async Task AddPersonAsync(AccountDTO account, Source source)
        {
            var person = await _personFactory.Create(account);

            var personVertex = await _personRepository.AddAsync(person, source);

            await Task.Delay(500);

            var ageAttribute = new AttributeDTO
            {
                Attribute = new AttributeEntity(person.AgeCategory.Value.ToFriendlyString()),
                Group = new AttributeGroupEntity("Age"),
                Edge = new AttributeEdge(EdgeLabel.Is, source, personVertex.Id),
                SourceVertexId = personVertex.Id
            };

            await _attributeRepository.AddAttributeIfNotExistsAsync(ageAttribute);

            await Task.Delay(500);

            var genderAttribute = new AttributeDTO
            {
                Attribute = new AttributeEntity(person.Gender.ToString()),
                Group = new AttributeGroupEntity("Gender"),
                Edge = new AttributeEdge(EdgeLabel.Is, source, personVertex.Id),
                SourceVertexId = personVertex.Id
            };

            await _attributeRepository.AddAttributeIfNotExistsAsync(genderAttribute);

            await Task.Delay(500);

            Vertex dnaVertex = null;

            if(source == Source.Onboarding)
                dnaVertex = await _personRepository.AddOrGetDnaAsync(personVertex);

            await Task.Delay(500);

            if (account.Keywords != null && account.Keywords.Any())
            {
                await _attributeRepository.AddAttributesIfNotExistsAsync(account.Keywords.Select(x => new AttributeDTO
                {
                    SourceVertexId = personVertex.Id,
                    Attribute = new AttributeEntity(x),
                    Edge = new AttributeEdge(EdgeLabel.Mentions, source, person.Id)
                    {
                        Confidence = GetAttributeConfidence(EdgeLabel.Mentions, source),
                        Weight = GetAttributeWeight(source)
                    }
                }));

                await Task.Delay(500);
            }

            if (account.IdealClients != null && account.IdealClients.Any())
            {
                var idealClients = new List<Person>();

                foreach (var idealClient in account.IdealClients)
                {
                    var idealClientPerson = await _personFactory.Create(idealClient);

                    idealClients.Add(idealClientPerson);
                }
                await _personRepository.AddIdealClientsAsync(idealClients, source, dnaVertex, personVertex);
            }

            Vertex companyVertex = null;

            if (!string.IsNullOrWhiteSpace(account.CompanyId))
            {
                var company = await _companyFactory.Create(new CompanyDTO { Id = account.CompanyId });
                companyVertex = await _companyRepository.AddAsync(company, source);
                await _personRepository.ConnectToCompanyAsync(personVertex, companyVertex, EdgeLabel.WorksIn, source);

                await Task.Delay(500);
            }

            if (account.Products != null && account.Products.Any())
            {
                foreach (var item in account.Products)
                {
                    var product = _productFactory.Create(item);
                    var productVertex = await _productRepository.AddOrUpdateAsync(product, source);

                    var standardEdge = new StandardEdge(EdgeLabel.Sells, source);
                    await _productRepository.AddOrUpdateEdgeAsync(personVertex.Id, productVertex.Id, standardEdge);

                    if (companyVertex != null)
                    {
                        await _productRepository.AddOrUpdateEdgeAsync(personVertex.Id, companyVertex.Id, standardEdge);
                    }
                }
            }

            if (source == Source.Onboarding)
            {
                await _personRepository.SetRDLAsync(personVertex.Id, account.RDL);
                await Task.Delay(500);
                await _lomiAlgorithmsService.DnaAttributeUpdateAsync(personVertex.Id);
                await Task.Delay(500);
            }
        }

        public async Task InteractAsync(string userId, string leadId, InteractionType interactionType, string referralId = null)
        {
            await _personRepository.InteractAsync(userId, leadId, interactionType, referralId);
        }

        public async Task AcceptLeadAsync(string userId, string leadId)
        {
            await _personRepository.InteractAsync(userId, leadId, InteractionType.Accepted);
        }

        public async Task DeclineLeadAsync(string userId, string leadId)
        {
            await _personRepository.InteractAsync(userId, leadId, InteractionType.Declined);
        }

        public async Task AutoDeclineLeadAsync(string userId, string leadId)
        {
            await _personRepository.InteractAsync(userId, leadId, InteractionType.AutoDeclined);
        }

        public async Task SkipLeadAsync(string userId, string leadId)
        {
            await _personRepository.InteractAsync(userId, leadId, InteractionType.Skipped);
        }

        public async Task ReferLeadAsync(string userId, string leadId, string referralId = null)
        {
            await _personRepository.InteractAsync(userId, leadId, InteractionType.Referred, referralId);
        }

        private static double GetAttributeConfidence(EdgeLabel edgeLabel, Source source, bool active = true, DateTime? lastUpdatedAt = null)
        {
            double confidence = 0;
            double gravityMultiplier = 0.01;
            int age = active ? 0 : 45;

            if (edgeLabel == EdgeLabel.Is)
            {
                confidence = 1;
            }
            else if (edgeLabel == EdgeLabel.Mentions)
            {
                confidence = 0.5;
            }

            // Onboarding data in A05 is twice as strong 
            confidence = source == Source.Onboarding ? confidence : confidence / 2;

            if (lastUpdatedAt.HasValue)
            {
                return confidence - (DateTime.UtcNow.Subtract(lastUpdatedAt.Value).TotalDays + age) * gravityMultiplier;
            }
            else
            {
                return confidence - age * gravityMultiplier;
            }
        }

        private static double GetAttributeWeight(Source source, double? weight = null, DateTime? lastUpdatedAt = null)
        {
            double value = 0;

            if (weight.HasValue)
            {
                value = weight.Value;
                var gravityMultiplier = source == Source.Onboarding ? 0.007 : 0.01;

                if (lastUpdatedAt.HasValue)
                {
                    return value - DateTime.UtcNow.Subtract(lastUpdatedAt.Value).TotalDays * gravityMultiplier;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                if (source == Source.RecommendationEngine)
                {
                    value = 0.5;
                }
                else
                {
                    value = 0.7;
                }

                return value;
            }
        }

        #endregion
    }
}