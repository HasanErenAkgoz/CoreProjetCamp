using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AccountValidator : AbstractValidator<Admin>

    {
        public AccountValidator()
        {

            RuleFor(account => account.Email).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız"); ;
            RuleFor(account => account.Status).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.Password).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.Password).MinimumLength(2).WithMessage("Şifreniz en az 2 karakterden oluşmalıdır.");
            RuleFor(account => account.Password).MaximumLength(100).WithMessage("Şifreniz en fazla 100 karakterden oluşmalıdır.")
           .Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!");


        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }

    }
}
