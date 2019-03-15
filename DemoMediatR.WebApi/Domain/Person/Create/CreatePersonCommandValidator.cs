using System.Text.RegularExpressions;
using FluentValidation;

namespace DemoMediatR.WebApi.Domain.Person.Create 
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty();

            RuleFor(e => e.LastName)
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotEmpty()
                .Matches("^[0-9a-z._-]+@{1}[0-9a-z.-]{2,}[.]{1}[a-z]{2,5}$");
        }
    }
}

