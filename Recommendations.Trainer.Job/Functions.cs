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

namespace Recommendations.Trainer.Job
{
    public class Functions
    {

        private static readonly string _storageAccountConnectionString = ConfigurationManager.ConnectionStrings["AzureWebJobsStorage"].ConnectionString;
        private static CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
        private static string _reStorageAccountConnectionString = ConfigurationManager.ConnectionStrings["ReWebJobsStorage"].ConnectionString;
        private static string _reLearnerQueue = ConfigurationManager.AppSettings["ReLearnerQueue"];

        [NoAutomaticTrigger()]
        public static async Task RunJob(TextWriter log)
        {

            await Task.CompletedTask;

            //var now = DateTime.UtcNow.Date;
            //var flaggedDnas = await graphPersonService.GetFlaggedDnasAsync();

            //foreach (var dna in flaggedDnas.OrderBy(x => x.NumberOfLeads / x.DnaRDL)
            //                               .ThenBy(x => x.DnaReLastUpdatedAt))
            //{
            //    if (now.AddMinutes(dna.PersonUtcOffset).Hour >= 0)
            //    {
            //        //await graphPersonService.UpdateVertexProperty(VertexLabel.DNA,
            //        //    new VertexId(dna.DnaVertexId),
            //        //    nameof(Dna.LastRecommendationUpdateAt),
            //        //    now.Ticks.ToString());

            //        //await AddToQueue(_reLearnerQueue, new RecommendationMessage
            //        //{
            //        //    PersonId = personDna.PersonVertexId,
            //        //    DnaId = personDna.DnaVertexId,
            //        //    ModelId = recomEngineSettings.ModelId,
            //        //    FromDate = DateTime.UtcNow.AddMonths(-3),
            //        //    RecommendationCount = 50
            //        //});
            //    }
            //}
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
