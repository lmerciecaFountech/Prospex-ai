using Recommendations.Client;
using Recommendations.Client.Entities;
using Recommendations.Trainer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommendations.Trainer.Services
{
    public class RecommendationService
    {
        #region Members

        private RecommendationsAPI _recommendationsAPI;
        private string _endPointUrl;
        private string _apiAdminKey;

        #endregion

        #region Constructor

        public RecommendationService(string endPointUrl, string apiAdminKey)
        {
            _endPointUrl = endPointUrl;
            _apiAdminKey = apiAdminKey;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<RecommendationItem>> GetItemToItemRecommendationsAsync(Guid modelId, string itemId, int? recommendationCount = null)
        {
            var recommendationsAPI = GetRecommendationsAPI(_endPointUrl, _apiAdminKey);
            var recommendationResult = await recommendationsAPI.Models.GetItemRecommendationsAsync(modelId, itemId, recommendationCount);
            return recommendationResult.Select(x => new RecommendationItem { Id = x.RecommendedItemId, Score = x.Score });
        }

        public async Task<IEnumerable<RecommendationItem>> GetPersonalizedRecommendationsAsync(Guid modelId, IList<UsageEvent> usageEvents, string userId, int? recommendationCount = null)
        {
            var recommendationsAPI = GetRecommendationsAPI(_endPointUrl, _apiAdminKey);
            var recommendationResult = await recommendationsAPI.Models.GetPersonalizedRecommendationsAsync(modelId, usageEvents, userId, recommendationCount);
            return recommendationResult.Select(x => new RecommendationItem { Id = x.RecommendedItemId, Score = x.Score });
        }

        #endregion

        #region Helper Methods

        private RecommendationsAPI GetRecommendationsAPI(string endPointUrl, string apiAdminKey)
        {
            if(_recommendationsAPI == null)
            {
                _recommendationsAPI = new RecommendationsAPI(new Uri(endPointUrl));
                _recommendationsAPI.HttpClient.DefaultRequestHeaders.Add("x-api-key", apiAdminKey);
            }
            return _recommendationsAPI;
        }

        #endregion
    }
}