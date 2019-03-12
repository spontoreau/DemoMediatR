using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoMediatR.Domain
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson>
    {
        public async Task<Unit> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}