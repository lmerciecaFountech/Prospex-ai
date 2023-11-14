using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Models;
using Lomi.Service.Interfaces;
using Microsoft.Azure.WebJobs;
using Recommendations.Client.Entities;
using Recommendations.Trainer.Models;
using Recommendations.Trainer.Services;

namespace Recommendations.Learner.Job
{
    public class Functions
    {
        public static async Task ProcessQueueMessage([QueueTrigger("queue")] RecommendationMessage message, TextWriter log)
        {

            await Task.CompletedTask;

            //var recommendationService = new RecommendationService("", "");

            //if (message != null)
            //{
            //    var userItems = await graphAtributeService.GetCatalogueAttributesByPersonIdAsync(new Lomi.Infrastructure.GraphDB.Models.VertexId(message.PersonId));
            //    var userRecommendations = await recommendationService.GetPersonalizedRecommendationsAsync(new Guid(message.ModelId),
            //        userItems.Select(item => new UsageEvent(item.AttributeVertexId,
            //            new DateTime(item.AttributeCreatedAt),
            //            null,
            //            item?.AttributeAverageWeight)).ToList(),
            //        message.PersonId,
            //        10);

            //    var items = new List<RecommendationItem>();
            //    items.AddRange(userRecommendations);

            //    if (!items.Any())
            //    {
            //        foreach (var userItem in userItems)
            //        {
            //            var popularRecommendations = await recommendationService.GetItemToItemRecommendationsAsync(new Guid(""), userItem.AttributeVertexId);

            //            items.AddRange(popularRecommendations);
            //        }
            //    }

            //    foreach (var id in items.Select(x => x.Id).Distinct())
            //    {
            //        //var edge = new AttributeEdge(EdgeLabel.Mentions, Source.RecommendationEngine);

            //        //edge.Weight = LomiFunctions.GetAttributeWeight(edge.Source);
            //        //edge.Confidence = LomiFunctions.GetAttributeConfidence(edge.Label, Source.Onboarding);

            //        //await graphAtributeService.ConnectAttributeAsync(new VertexId(message.DnaId), new VertexId(id), edge);
            //    }
            //}
            
        }
    }
}
