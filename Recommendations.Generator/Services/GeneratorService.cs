using Lomi.Service.Interfaces;
using Recommendations.Generator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Generator.Services
{
    public class GeneratorService : IGeneratorService
    {

        #region Members

        private static readonly string CATALOG_FILE_NAME = "catalog.csv";
        private static readonly string USAGE_FILE_NAME = "usage.csv";
        private readonly IGraphAttributeService _graphAttributeService;

        #endregion

        #region Constructor

        public GeneratorService(IGraphAttributeService graphAttributeService)
        {
            if (graphAttributeService == null)
                throw new ArgumentNullException(nameof(graphAttributeService));

            _graphAttributeService = graphAttributeService;
        }

        #endregion


        /// <summary>
        /// Generate catalog and upload it to Azure Storage.
        /// </summary>
        /// <returns></returns>
        public async Task StartCatalogProcessAsync()
        {
            await _graphAttributeService.SetInCatalogueFlagForTopAttributesAsync(100000);
            var attributes = await _graphAttributeService.GetCatalogueAttributesAsync(100000);

        }

        /// <summary>
        /// Generate usage and upload it to Azure Storage.
        /// </summary>
        /// <returns></returns>
        public async Task StartUsageProcessAsync()
        {
            var attributes = await _graphAttributeService.GetCatalogueAttributesWithPersonAsync(400000);

        }
    }
}