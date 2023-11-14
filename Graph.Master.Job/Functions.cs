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

namespace Graph.Master.Job
{
    public class Functions
    {
        private static readonly string _storageAccountConnectionString = ConfigurationManager.AppSettings["AzureWebJobsStorage"];
        private static CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
        private static string _weightCalculatorQueue = ConfigurationManager.AppSettings["WeightCalculatorQueue"];

        [NoAutomaticTrigger()]
        public static async Task RunJob(TextWriter logger)
        {
            logger.WriteLine(_weightCalculatorQueue);

            var personRepository = new PersonRepository();

            var midnightPersons = await personRepository.GetMidnightPersonsAsync();

            foreach (var person in midnightPersons)
            {
                logger.WriteLine(person.PersonProspexId + " " + person.PersonVertexId);

                await AddToQueue(_weightCalculatorQueue,
                    new WeightCalculatorDTO
                    {
                        PersonVertexId = person.PersonVertexId,
                        ProspexId = person.PersonProspexId
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
