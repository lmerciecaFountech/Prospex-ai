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
    public class TrainingService
    {
        #region Members

        private readonly string BLOB_CONTAINER_NAME = "recommendation-engine";
        private readonly string CATALOG_FILE_NAME = "catalog.csv";
        private readonly string USAGE_FILE_NAME = "usage.csv";
        private readonly string BLOB_EVALUTATION_USAGE_NAME = "evaluation-usage";
        private string _endPointUrl;
        private string _apiAdminKey;

        #endregion

        #region Costructor

        public TrainingService(string endPointUrl, string apiAdminKey)
        {
            _endPointUrl = endPointUrl;
            _apiAdminKey = apiAdminKey;
        }

        #endregion

        #region Methods

        public async Task<RecommendationModel> StartTrainingAsync()
        {
            var recommendationsClient = new RecommendationsAPI(new Uri(_endPointUrl));

            recommendationsClient.HttpClient
                                 .DefaultRequestHeaders
                                 .Add("x-api-key", _apiAdminKey);

            var modelParameters = new ModelParameters
            (
                description: $"LOMi product recommendation created at {DateTime.UtcNow.ToString()} UTC.",
                blobContainerName: BLOB_CONTAINER_NAME,
                catalogFileRelativePath: CATALOG_FILE_NAME,
                usageRelativePath: USAGE_FILE_NAME,
                //evaluationUsageRelativePath: BLOB_EVALUATION_USAGE_NAME,
                supportThreshold: 3,
                cooccurrenceUnit: CooccurrenceUnit.User,
                similarityFunction: SimilarityFunction.Jaccard,
                enableColdItemPlacement: true,
                enableColdToColdRecommendations: false,
                enableUserAffinity: true,
                allowSeedItemsInRecommendations: false,
                enableBackfilling: true,
                decayPeriodInDays: 30,
                enableUserToItemRecommendations: true
            );

            var recommendationModel = await TrainModelAsync(recommendationsClient, modelParameters);

            return recommendationModel;
        }

        private async Task<RecommendationModel> TrainModelAsync(RecommendationsAPI recommendationsAPI, ModelParameters modelParameters)
        {
            var model = recommendationsAPI.Models.TrainNewModel(modelParameters);
            Guid modelId = model.Id.Value;
            do
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                model = recommendationsAPI.Models.GetModel(modelId);

            } while (model.ModelStatus != ModelStatus.Completed &&
                     model.ModelStatus != ModelStatus.Failed);

            return new RecommendationModel
            {
                Id = model.Id,
                IsSucceeded = model.ModelStatus == ModelStatus.Completed
            };
        }

        #endregion
    }
}