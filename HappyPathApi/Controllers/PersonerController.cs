using HappyPathApi.Models;
using HappyPathApi.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HappyPathApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonerController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/values
        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> HentPerson([Required]int? personId)
            => await mediator.Send(new HentPersonRequest(personId.Value));
    }
}
