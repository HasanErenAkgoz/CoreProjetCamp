using Business.Constants;
using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(category => category.Name).NotNull().WithMessage(Messages.NotNull);
            RuleFor(category => category.Surname).NotNull().WithMessage(Messages.NotNull);
            RuleFor(category => category.Mail).NotNull().WithMessage(Messages.NotNull);
            RuleFor(category => category.About).NotNull().WithMessage(Messages.NotNull);
            RuleFor(category => category.About).Must(x => x != null && x.ToUpper().Contains("A"))
            .WithMessage("Hakkında kısmında en az bir a harfi içermelidir");
        }
    }
}
