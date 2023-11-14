using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Interfaces
{
    public interface IGraphAttributeService
    {
        Task<List<SixAttributeDTO>> GetSixAttributesAsync(string personVertexId);
        Task<List<string>> GetAttributesIdsAsync(string userId);
        Task<List<Vertex>> GetAllAttributesAsync();
        Task<List<BaseEdge>> GetAllAttributesAsync(VertexId vertexId);
        Task<double> GetGlobalAttributeAverageAsync(string id);
        Task SetAttributeAverageAsync(string id, double averageWeight);
        Task SetAttributeAverageAsync(AttributeEdgeDTO averageEdge);
        Task<List<AttributeEdgeDTO>> GetAllAverageAttributesEdgesAsync(string personVertexId);
        Task SetInCatalogueFlagForTopAttributesAsync(int count);
        Task<List<PersonAttributeCatalogDTO>> GetCatalogueAttributesAsync(int count);
        Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesWithPersonAsync(int count);
        Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesByPersonIdAsync(VertexId vertexId);
        Task ConnectAttributeAsync(VertexId vertexId, VertexId attributeId, StandardEdge edge);
        Task ConnectAttributeAsync(VertexId vertexId, VertexId attributeId, AttributeEdge edge);
        Task RemoveAllInCatalogueFlagsAsync();
        Task<Vertex> AddAttributeAsync(AttributeEntity attributeEntity);
        Task AddAttributeToAsync();
        Task<Vertex> AddAttributeGroupAsync(Vertex attrVertex, AttributeGroup attributeGroup, Source source);
        Task SaveWords(string email, HashSet<Word> words, Source source);
    }
}