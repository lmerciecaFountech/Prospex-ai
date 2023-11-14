using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Factories
{
    public class ProductFactory
    {
        public Product Create(ProductDTO product)
        {
            var source = Source.Onboarding;
            var id = $"{source.Value}{nameof(Product)}{product.Id.ToString()}";
            var prod = new Product(VertexLabel.Product, source, id, product.Name, product.Description);

            prod.SetId(product.Id.ToString(), source);

            return prod;
        }
    }
}
