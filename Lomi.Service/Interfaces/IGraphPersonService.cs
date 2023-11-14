using Lomi.Infrastructure.GraphDB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Interfaces
{
    public interface IGraphPersonService
    {
        Task<List<PersonFlaggedDnaDTO>> GetFlaggedDnasAsync();
        Task<IEnumerable<PersonDnaLeadsDTO>> GetMidnightPersonsAsync();
    }
}