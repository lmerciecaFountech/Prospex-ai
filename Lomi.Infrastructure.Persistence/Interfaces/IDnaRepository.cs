using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Helpers;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Infrastructure.Persistence.Interfaces
{
    public interface IDnaRepository
    {
        Task<Maybe<Vertex>> UpdateAsync(Dna dna);
    }
}