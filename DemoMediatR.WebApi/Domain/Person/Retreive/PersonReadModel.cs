using MediatR;

namespace DemoMediatR.WebApi.Domain.Person.Retreive 
{
    public class PersonReadModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public PersonReadModel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}