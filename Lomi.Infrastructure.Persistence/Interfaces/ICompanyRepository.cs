using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Vertex> AddAsync(Company company, Source source);        
    }
}