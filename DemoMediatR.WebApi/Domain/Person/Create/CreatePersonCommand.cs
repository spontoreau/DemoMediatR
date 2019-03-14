using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Create 
{
    [Event(EventType.Create)]
    public class CreatePersonCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}