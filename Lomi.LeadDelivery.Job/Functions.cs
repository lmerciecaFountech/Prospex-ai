using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Service.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using Newtonsoft.Json;

namespace Lomi.LeadDelivery.Job
{
    public class Functions
    {
        private static CloudStorageAccount _cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ProspexWebJobsStorage"].ConnectionString);
        private static string _leadQueueName = ConfigurationManager.AppSettings["LeadQueueName"];

        [NoAutomaticTrigger()]
        public static async Task RunJob(TextWriter log)
        {
            //var people = await leadDeliveryService.GetPersonsWithMarkedForDeliveryLeadsAsync();

            //foreach (var person in people)
            //{
            //    var leads = await leadDeliveryService.GetMarkedForDeliveryLeadsAsync(person.PersonVertexId, person.PersonProspexId);

            //    foreach (var lead in leads)
            //    {
            //        await QueueRequest(_leadQueueName, lead);
            //    }
            //}

            await Task.CompletedTask;
        }

        private static async Task QueueRequest(string queueName, object dataObject)
        {
            var queueClient = _cloudStorageAccount.CreateCloudQueueClient();
            queueClient.DefaultRequestOptions.RetryPolicy = new LinearRetry(TimeSpan.FromSeconds(5), 3);
            var requestQueue = queueClient.GetQueueReference(queueName);
            var queueMessage = new CloudQueueMessage(JsonConvert.SerializeObject(dataObject));
            await requestQueue.AddMessageAsync(queueMessage);
        }
    }
}