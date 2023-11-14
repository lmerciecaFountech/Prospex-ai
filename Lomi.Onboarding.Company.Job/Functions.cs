using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Service.Services;
using Microsoft.Azure.WebJobs;

namespace Lomi.Onboarding.Company.Job
{
    public class Functions
    {
        public static async Task ProcessQueueMessage([QueueTrigger("%QueueName%")] CompanyDTO message, TextWriter log)
        {
            log.WriteLine(message);

            var onboardingService = new OnboardingService();

            if (message != null)
            {
                await onboardingService.AddCompanyAsync(message, Source.Onboarding);
            }
        }
    }
}
