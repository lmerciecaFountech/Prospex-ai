using Lomi.Infrastructure.GraphDB.DTOs;
using Lomi.Infrastructure.GraphDB.Entities;
using Lomi.Infrastructure.GraphDB.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Interfaces
{
    public interface IOnboardingService
    {
        Task AddPersonAsync(AccountDTO account, Source source);
        Task AddCompanyAsync(CompanyDTO prospexCompany, Source source);
        Task InteractAsync(string userId, string leadId, InteractionType interactionType, string referralId = null);
    }
}