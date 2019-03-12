using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Retreive 
{
    public class GetAllPersonHandler : IRequestHandler<GetAllPerson, IEnumerable<PersonReadModel>>
    {
        public Task<IEnumerable<PersonReadModel>> Handle(GetAllPerson request, CancellationToken cancellationToken)
        {
            IEnumerable<PersonReadModel> persons = new [] {
                new PersonReadModel("t", "t", "t") 
            };
            return Task.FromResult(persons);
        }
    }
}