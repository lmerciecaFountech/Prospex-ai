using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class GraphAttributeService : IGraphAttributeService
    {
        public Task<Vertex> AddAttributeAsync(AttributeEntity attributeEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Vertex> AddAttributeGroupAsync(Vertex attrVertex, AttributeGroup attributeGroup, Source source)
        {
            throw new NotImplementedException();
        }

        public Task AddAttributeToAsync()
        {
            throw new NotImplementedException();
        }

        public Task ConnectAttributeAsync(VertexId vertexId, VertexId attributeId, StandardEdge edge)
        {
            throw new NotImplementedException();
        }

        public Task ConnectAttributeAsync(VertexId vertexId, VertexId attributeId, AttributeEdge edge)
        {
            throw new NotImplementedException();
        }

        public Task<List<Vertex>> GetAllAttributesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<BaseEdge>> GetAllAttributesAsync(VertexId vertexId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AttributeEdgeDTO>> GetAllAverageAttributesEdgesAsync(string personVertexId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetAttributesIdsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonAttributeCatalogDTO>> GetCatalogueAttributesAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesByPersonIdAsync(VertexId vertexId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonAttributeUsageDTO>> GetCatalogueAttributesWithPersonAsync(int count)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetGlobalAttributeAverageAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SixAttributeDTO>> GetSixAttributesAsync(string personVertexId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllInCatalogueFlagsAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveWords(string email, HashSet<Word> words, Source source)
        {
            throw new NotImplementedException();
        }

        public Task SetAttributeAverageAsync(string id, double averageWeight)
        {
            throw new NotImplementedException();
        }

        public Task SetAttributeAverageAsync(AttributeEdgeDTO averageEdge)
        {
            throw new NotImplementedException();
        }

        public Task SetInCatalogueFlagForTopAttributesAsync(int count)
        {
            throw new NotImplementedException();
        }
    }
}