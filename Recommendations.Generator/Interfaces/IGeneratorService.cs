using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Generator.Interfaces
{
    public interface IGeneratorService
    {
        Task StartCatalogProcessAsync();
        Task StartUsageProcessAsync();
    }
}