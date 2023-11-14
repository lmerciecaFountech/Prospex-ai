using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Interfaces
{
    public interface ILeadGeneratorService
    {
        Task<Tuple<string, List<string>>> GenerateAsync(string personVertexId, string personProspexId);
    }
}