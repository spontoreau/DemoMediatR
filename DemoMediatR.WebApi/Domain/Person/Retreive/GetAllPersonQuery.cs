using System.Collections.Generic;
using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Retreive 
{
    public class GetAllPersonQuery : IRequest<IEnumerable<PersonReadModel>>
    {

    }
}