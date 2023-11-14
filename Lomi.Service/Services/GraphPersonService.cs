using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Service.Factories;
using Lomi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class GraphPersonService : IGraphPersonService
    {
        private readonly PersonFactory _personFactory;

        public Task<List<PersonFlaggedDnaDTO>> GetFlaggedDnasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonDnaLeadsDTO>> GetMidnightPersonsAsync()
        {
            throw new NotImplementedException();
        }
    }
}