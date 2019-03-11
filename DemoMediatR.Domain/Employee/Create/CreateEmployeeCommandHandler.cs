using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoMediatR.Domain
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
    {
        public Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}