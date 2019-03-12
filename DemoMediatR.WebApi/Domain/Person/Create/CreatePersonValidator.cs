using System.Text.RegularExpressions;
using FluentValidation;

namespace DemoMediatR.WebApi.Domain.Person.Create 
{
    public class CreatePersonValidator : AbstractValidator<CreatePerson>
    {
        public CreatePersonValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.LastName)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .Must(e => {
                    return Regex.IsMatch(e, "^[0-9a-z._-]+@{1}[0-9a-z.-]{2,}[.]{1}[a-z]{2,5}$");
                });
        }
    }
}

