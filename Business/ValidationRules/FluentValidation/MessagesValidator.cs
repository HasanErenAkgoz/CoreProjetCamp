using Business.Constants;
using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class MessagesValidator : AbstractValidator<Message>
    {
        public MessagesValidator()
        {
            RuleFor(messages => messages.Receiver).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(messages => messages.Subject).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(messages => messages.Content).NotEmpty().WithMessage(Messages.NotNull);
            RuleFor(messages => messages.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karekter girişi yapınız");
            RuleFor(messages => messages.Receiver).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girmeyiniz");
        }
    }
}
