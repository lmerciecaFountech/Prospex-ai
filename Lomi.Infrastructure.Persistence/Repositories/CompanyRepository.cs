using Lomi.Infrastructure.GraphDB;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.GraphDB.Strategies;
using Lomi.Infrastructure.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : RepositoryBase, ICompanyRepository
    {
        private readonly ILocationRepository _locationRepository;

        public CompanyRepository()
        {
            _locationRepository = new LocationRepository();
        }

        public async Task<Vertex> AddAsync(Company company, Source source)
        {
            var strategy = CompanyVertexResolutionStrategy.For(company, source);
            var companyVertex = await strategy.AddOrUpdateAsync(company);

            if (company.Location.HasValue)
            {
                await _locationRepository.AddAsync(company.Location.Value, EdgeLabel.In, companyVertex.Id, source);
            }

            return companyVertex;
        }

    }
}