using HappyPathApi.Common;
using HappyPathApi.Models;
using HappyPathApi.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HappyPathApi.RequestHandlers
{
    public class HentPersonRequestHandler : IRequestHandler<HentPersonRequest, Person>
    {
        public HentPersonRequestHandler()
        {
            // Her vil man typisk injecte EF-contexten. Skipper det for eksempelets skyld.
        }
        public Task<Person> Handle(HentPersonRequest request, CancellationToken cancellationToken)
        {
            // Her vil man bruke EFcontexten til å hente personen.
            // Et par eksempelcaser som kan føre til exceptions er hardkodet her,
            // for å demonstrere hva som skjer mtp custom middleware.

            if (request.PersonId == 4)
            {
                // Simulerer at personen med ID 4 ikke finnes i basen.
                throw new EntityNotFoundException(nameof(Person), request.PersonId);
            }
            else if (request.PersonId == 1)
            {
                // Simulerer at databasen er utilgjengelig - dette vil typisk kastes lenger ned i callstacken
                throw new DB2UnavailableException();
            }
            else
            {
                // personen er hentet fra databasen og mappes til domenemodell eller dto
                return Task.FromResult(new Person
                {
                    Id = request.PersonId,
                    Name = "Person " + request.PersonId.ToString()
                });
            }
        }
    }
}
