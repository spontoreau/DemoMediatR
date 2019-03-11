using System.Collections.Generic;
using System.Threading.Tasks;
using DemoMediatR.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatR.WebApi.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator Mediator { get; }

        public EmployeeController(IMediator mediator)
        {
            Mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost]
        public async Task<bool> Post()
        {
            return await Mediator.Send<bool>(new CreateEmployeeCommand());
        }
    }
}
