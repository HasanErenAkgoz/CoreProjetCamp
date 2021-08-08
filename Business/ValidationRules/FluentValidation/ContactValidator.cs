using Business.Constants;
using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.Email).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(contact => contact.Subject).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(contact => contact.Name).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(contact => contact.Message).NotEmpty().WithMessage(Messages.NotNull);
        }
    }
}
