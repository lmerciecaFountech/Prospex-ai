using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Service.Services;
using Microsoft.Azure.WebJobs;

namespace Lomi.LeadInteraction.Job
{
    public class Functions
    {
        [Singleton]
        public static async Task ProcessQueueMessage([QueueTrigger("%QueueName%")] InteractionDTO message, TextWriter log)
        {
            log.WriteLine(message);

            var onboardingService = new OnboardingService();

            if (message != null)
            {
                await onboardingService.InteractAsync(message.UserId, message.LeadId, message.InteractionType, message.ReferralId);
            }
        }
    }
}
