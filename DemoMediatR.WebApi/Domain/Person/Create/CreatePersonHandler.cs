using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Create 
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson>
    {
        public async Task<Unit> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}