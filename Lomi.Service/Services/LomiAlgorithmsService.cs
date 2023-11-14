using Lomi.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lomi.Service.Services
{
    public class LomiAlgorithmsService
    {
        private readonly PersonRepository _personRepository;

        public LomiAlgorithmsService()
        {
            _personRepository = new PersonRepository();
        }

        public async Task DnaRefreshOnboarding(string prospexId)
        {
            var isLocked = await _personRepository.IsLockedAsync(prospexId);

            if (isLocked)
                return;

            await _personRepository.CopyAttributesFromPersonToDnaAsync(prospexId);
        }

        public async Task DnaAttributeUpdateAsync(string prospexId)
        {
            await DnaRefreshOnboarding(prospexId);
        }

        public async Task UnstructuredDataIndexing(IEnumerable<string> keywords)
        {
            return;
        }


    }
}
