using HappyPathApi.Models;
using MediatR;

namespace HappyPathApi.Requests
{
    public class HentPersonRequest : IRequest<Person>
    {
        public HentPersonRequest(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
