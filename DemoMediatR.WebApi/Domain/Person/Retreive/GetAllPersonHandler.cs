using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DemoMediatR.WebApi.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DemoMediatR.WebApi.Domain.Person.Retreive 
{
    public class GetAllPersonHandler : IRequestHandler<GetAllPerson, IEnumerable<PersonReadModel>>
    {
        DataContext Context { get; }

        public GetAllPersonHandler(DataContext context)
        {
            Context = context;
        }
        
        public async Task<IEnumerable<PersonReadModel>> Handle(GetAllPerson request, CancellationToken cancellationToken)
        {
            return await Context
                    .Persons
                    .Select(p => new PersonReadModel(p.FirstName, p.LastName, p.Email))
                    .ToArrayAsync();
        }
    }
}