using Entity.Concrate;
using Entity.ViewModel;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>

    {
        public RegisterValidator()
        {

            RuleFor(account => account.Email).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.UserName).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.Name).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.SurName).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.PhoneNumber).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(account => account.Password).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız").Must(IsPasswordValid).WithMessage("Parolanız en az sekiz karakter, en az bir harf ve bir sayı içermelidir!"); ;
            RuleFor(account => account.Password).MinimumLength(2).WithMessage("Şifreniz en az 2 karakterden oluşmalıdır.");
            RuleFor(account => account.Password).MaximumLength(100).WithMessage("Şifreniz en fazla 100 karakterden oluşmalıdır.");
        }

        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
            return regex.IsMatch(arg);
        }

    }
}
