using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage;

namespace Graph.WeightCalculator.Job
{
    class Program
    {

        private static readonly string _storageAccountConnectionString = ConfigurationManager.AppSettings["AzureWebJobsStorage"];
        private static readonly string _weightCalculatorName = ConfigurationManager.AppSettings["QueueName"];
        private static readonly string _weightCalculatorNamePoison = ConfigurationManager.AppSettings["PoisonQueueName"];


        static void Main()
        {
            var storageAccount = CloudStorageAccount.Parse(_storageAccountConnectionString);
            var queueClient = storageAccount.CreateCloudQueueClient();

            queueClient.GetQueueReference(_weightCalculatorName)
                       .CreateIfNotExists();

            queueClient.GetQueueReference(_weightCalculatorNamePoison)
                       .CreateIfNotExists();


            var config = new JobHostConfiguration();

            if (config.IsDevelopment)
            {
                config.UseDevelopmentSettings();
            }

            var host = new JobHost(config);
            // The following code ensures that the WebJob will be running continuously
            host.RunAndBlock();
        }
    }
}
