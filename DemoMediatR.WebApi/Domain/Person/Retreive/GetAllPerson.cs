using System.Collections.Generic;
using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Retreive 
{
    public class GetAllPerson : IRequest<IEnumerable<PersonReadModel>>
    {

    }
}