using Lomi.Infrastructure.GraphDB.DTOs;
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
    public interface IAttributeRepository
    {
        Task ConnectAttributeAsync(VertexId vertexId, VertexId attributeId, AttributeEdge edge);
        Task<List<BaseVertex>> GetAllAttributesAsync();
        Task<List<BaseEdge>> GetAllAttributesAsync(VertexId vertexId);
        Task<List<BaseVertex>> GetAllAttributesEdgesAsync(string prospexId);
        Task<List<AttributeEdgeDTO>> GetAllAverageAttributesEdgesAsync(string personVertexId);
        Task<Maybe<Vertex>> GetAttributeByIdAsync(string id);
        Task<Maybe<Vertex>> GetAttributeByValueAsync(string value);
        Task<List<string>> GetAttributesIdAsync(string filteredUserId);
        Task<List<PersonAttributeCatalogDTO>> GetCatalogueAttributesAsync(int count);
        Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesByPersonIdAsync(VertexId vertexId);
        Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesWithPersonAsync(int count);
        Task<double> GetGlobalAttributeAverageAsync(string id);
        Task<List<PersonAttributeUsageDTO>> GetPersonsTopAttributesAsync(double minWeight, int count);
        Task<List<PersonAttributeUsageDTO>> GetRandomPersonAttributesAsync(int count);
        Task<List<SixAttributeDTO>> GetSixAttributesAsync(string personVertexId);
        Task RemoveAllInCatalogueFlagsAsync();
        Task SetAttributeAverageAsync(AttributeEdgeDTO averageEdge);
        Task SetAttributeAverageAsync(string id, double averageWeight);
        Task SetInCatalogueFlagForTopAttributesAsync(int count);
        Task AddAttributeIfNotExistsAsync(AttributeDTO attributeDTO);
        Task AddAttributesIfNotExistsAsync(IEnumerable<AttributeDTO> attributeDTOs);
    }
}