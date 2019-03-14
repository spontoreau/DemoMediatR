using System.Collections.Generic;
using System.Threading.Tasks;
using DemoMediatR.WebApi.Domain.Person.Create;
using DemoMediatR.WebApi.Domain.Person.Retreive;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IMediator Mediator { get; }

        public PersonController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonReadModel>> Get()
        {
            return await Mediator.Send(new GetAllPersonQuery());
        }

        [HttpPost]
        public async Task Post(CreatePersonCommand createPerson)
        {
            await Mediator.Send(createPerson);
        }
    }
}
