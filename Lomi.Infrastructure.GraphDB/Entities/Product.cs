using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.GraphDB.Entities
{
    public class Product : Entity
    {

        public Product(VertexLabel label,
                       Source source,
                       string dataSourceId,
                       string name,
                       string description)
        {
            Label = label;
            //SourceId = dataSourceId;
            Name = name;
            Description = description;
        }

        public Product(Source source,
                       string dataSourceId,
                       string name,
                       string description,
                       string category,
                       string price,
                       List<Company> companyCustomers,
                       List<Person> personCustomers)
        {
            //SourceId = dataSourceId;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            CompanyCustomers = companyCustomers;
            PersonCustomers = personCustomers;
        }

        public Prop<VertexLabel> Label { get; set; }
        public Prop<string> ProspexId { get; set; }
        public Prop<string> SourceId { get; set; }
        public Prop<string> Name { get; set; }
        public Prop<string> Description { get; set; }
        public Prop<string> Category { get; set; }
        public Prop<string> Price { get; set; }
        public List<Company> CompanyCustomers { get; set; }
        public List<Person> PersonCustomers { get; set; }
        
    }

    public class ProductId
    {
        public ProductId(string value)
        {
            InternalId = value;
        }

        public string InternalId { get; }
    }
}