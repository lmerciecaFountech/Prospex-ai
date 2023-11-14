using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Enums;
using Lomi.Service.Services;
using Microsoft.Azure.WebJobs;

namespace Lomi.LeadGenerator.Job
{
    public class Functions
    {
        public static async Task ProcessQueueMessage([QueueTrigger("%QueueName%")] LeadGeneratorDTO message, TextWriter log)
        {
            log.WriteLine(message);

            var leadGeneratorService = new LeadGeneratorService();

            var leads = await leadGeneratorService.GenerateAsync(message.PersonVertexId, message.PersonProspexId);

            log.WriteLine(leads.Item1);

            if (leads.Item2.Any())
            {
                foreach (var lomiId in leads.Item2)
                {
                    log.WriteLine(lomiId);

                    var selectQuery = @"SELECT Id
                            FROM dbo.Lead
                            WHERE LomiId = @lomiId";

                    var insertQuery = @"INSERT INTO [dbo].[LeadAssigned]
           ([AccountId]
           ,[LeadId]
           ,[LomiId]
           ,[AssignedOn]
           ,[LeadValidityEndsOn]
           ,[LeadStatus]
           ,[Order]
           ,[SkipCount]
           ,[IsTempLead]
           ,[IsQueuedForDecline]) 
VALUES
           (@accountId,@leadId,@lomiId,@assignedOn,@leadValidityEndsOn,@leadStatus,@order,@skipCount,@isTempLead,@isQueuedForDecline)";

                    int leadId = 0;

                    log.WriteLine(ConfigurationManager.ConnectionStrings["ProspexContext"].ConnectionString);

                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProspexContext"].ConnectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand(selectQuery, connection))
                        {
                            command.Parameters.Add("@lomiId", SqlDbType.NVarChar).Value = lomiId;
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    leadId = reader["Id"] != null ? Convert.ToInt32(reader["Id"]) : 0;
                                }
                            }
                        }
                    }

                    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProspexContext"].ConnectionString))
                    {
                        connection.Open();
                        using (var command2 = new SqlCommand(insertQuery, connection))
                        {
                            command2.CommandTimeout = 100;
                            command2.Parameters.AddWithValue("@accountId", leads.Item1);
                            command2.Parameters.AddWithValue("@leadId", leadId);
                            command2.Parameters.AddWithValue("@lomiId", lomiId);
                            command2.Parameters.AddWithValue("@assignedOn", DateTime.Now);
                            command2.Parameters.AddWithValue("@leadValidityEndsOn", DateTime.Now.AddDays(3));
                            command2.Parameters.AddWithValue("@leadStatus", (int)InteractionType.Assigned);
                            command2.Parameters.AddWithValue("@order", 0);
                            command2.Parameters.AddWithValue("@skipCount", 0);
                            command2.Parameters.AddWithValue("@isTempLead", 0);
                            command2.Parameters.AddWithValue("@isQueuedForDecline", 0);

                            command2.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }

}