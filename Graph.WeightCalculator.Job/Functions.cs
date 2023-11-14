using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.Persistence.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Newtonsoft.Json;

namespace Graph.WeightCalculator.Job
{
    public class Functions
    {
        private static readonly string _storageAccountConnectionString = ConfigurationManager.AppSettings["AzureWebJobsStorage"];
        private static CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
        private static string _leadGeneratorQueue = ConfigurationManager.AppSettings["LeadGeneratorQueueName"];

        public static async Task ProcessQueueMessage([QueueTrigger("%QueueName%")] WeightCalculatorDTO message, TextWriter log)
        {
            log.WriteLine(message);

            var attributeRepository = new AttributeRepository();

            if (message != null)
            {
                var averageEdges = await attributeRepository.GetAllAverageAttributesEdgesAsync(message.PersonVertexId);

                foreach (var edge in averageEdges)
                {
                    await attributeRepository.SetAttributeAverageAsync(edge);
                }

                await AddToQueue(_leadGeneratorQueue, new LeadGeneratorDTO
                {
                    PersonVertexId = message.PersonVertexId,
                    PersonProspexId = message.ProspexId
                });
            }
        }

        private static async Task AddToQueue<T>(string queue, T model)
        {
            var cloudQueueClient = _storageAccount.CreateCloudQueueClient();
            cloudQueueClient.DefaultRequestOptions.RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(2), 7);
            var cloudQueue = cloudQueueClient.GetQueueReference(queue);
            var cloudQueueMessage = model == null ? null : new CloudQueueMessage(JsonConvert.SerializeObject(model));
            await cloudQueue.AddMessageAsync(cloudQueueMessage);
        }
    }
}
