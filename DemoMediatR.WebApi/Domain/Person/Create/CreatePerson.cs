using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Create 
{
    public class CreatePerson : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}