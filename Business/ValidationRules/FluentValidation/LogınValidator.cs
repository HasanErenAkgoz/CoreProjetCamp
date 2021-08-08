using Business.Constants;
using Entity.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class LogınValidator:AbstractValidator<LoginViewModel>
    {
        public LogınValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Messages.NotNull);
        }
    }
}
