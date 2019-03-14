using System.Threading;
using System.Threading.Tasks;
using DemoMediatR.WebApi.Context;
using MediatR;
using System.Linq;
using System;

namespace DemoMediatR.WebApi.Domain.Person.Create 
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand>
    {
        DataContext Context { get; }

        public CreatePersonHandler(DataContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            bool canCreate = !Context.Persons.Any(p => p.Email == request.Email);

            if(canCreate) 
            {
                await Context.Persons.AddAsync(new Context.Person
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Id = Guid.NewGuid()
                });
                await Context.SaveChangesAsync();
                return Unit.Value;
            }
            else
            {
                throw new DomainException("Email must be unique!");
            }
        }
    }
}