using System.Collections.Generic;
using System.Threading.Tasks;
using DemoMediatR.Domain;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task Post(CreatePerson createPerson)
        {
            await Mediator.Send(createPerson);
        }
    }
}
