using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Infrastructure.Persistence.Interfaces;
using Lomi.Infrastructure.Persistence.Repositories;
using Lomi.Service.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class GraphCompanyService
    {
        private readonly CompanyFactory _companyFactory;
        private readonly ProductFactory _productFactory;
        private readonly ICompanyRepository _companyRepository;
        private readonly IProductRepository _productRepository;

        public GraphCompanyService()
        {
            _companyFactory = new CompanyFactory();
            _productFactory = new ProductFactory();
            _companyRepository = new CompanyRepository();
            _productRepository = new ProductRepository();
        }

        public async Task SaveCompanyAsync(CompanyDTO prospexCompany)
        {
            var company = await _companyFactory.Create(prospexCompany);
            var companyVertex = await _companyRepository.AddAsync(company, Source.Onboarding);

            if(prospexCompany.Products != null)
            {
                foreach (var productDTO in prospexCompany.Products)
                {
                    var product = _productFactory.Create(productDTO);
                    var productVertex = await _productRepository.AddOrUpdateAsync(product, Source.Onboarding);

                    if (companyVertex == null)
                        continue;

                    var standardEdge = new StandardEdge(EdgeLabel.Sells, Source.Onboarding);
                    //await _productRepository.AddProductAsync();
                }
            }
        }
    }
}