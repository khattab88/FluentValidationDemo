using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(u => u.Email)
                .EmailAddress();

            RuleFor(u => u.Address)
                .NotNull()
                .MaximumLength(10)
                .Must(a => a.ToLower().Contains("street")).WithMessage("Address must contain street");

            RuleForEach(u => u.Memberships)
                .ChildRules(m => m.RuleFor(x => x.Name).NotNull().NotEmpty())
                .ChildRules(m => m.RuleFor(x => x.Price).NotNull().GreaterThan(0));
        }
    }
}
