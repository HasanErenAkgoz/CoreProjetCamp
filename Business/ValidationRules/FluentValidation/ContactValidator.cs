using Business.Constants;
using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
  public  class ContactValidator:AbstractValidator<Contact>
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
