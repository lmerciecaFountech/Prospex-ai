using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.Persistence.Repositories;
using Microsoft.Azure.WebJobs;

namespace Graph.GlobalWeightCalculator.Job
{
    public class Functions
    {
        [NoAutomaticTrigger()]
        public static async Task RunJob(TextWriter log)
        {
            var attributeRepository = new AttributeRepository();

            var attributes = await attributeRepository.GetAllAttributesAsync();

            foreach (var attribute in attributes)
            {
                log.WriteLine(attribute.Id);

                await Task.Delay(500);

                var attributeAverageWeight = await attributeRepository.GetGlobalAttributeAverageAsync(attribute.Id);

                if (!double.IsNaN(attributeAverageWeight))
                {
                    await Task.Delay(500);

                    await attributeRepository.SetAttributeAverageAsync(attribute.Id, attributeAverageWeight);
                }
            }
        }
    }
}
