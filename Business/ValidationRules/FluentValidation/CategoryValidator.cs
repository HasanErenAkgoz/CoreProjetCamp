using Entity.Concrate;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.Name).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız"); ;
            RuleFor(category => category.Status).NotNull().WithMessage("Lütfen Boş Alan Bırakmayınız");
            RuleFor(category => category.Name).MinimumLength(2).WithMessage("Ketegori Adı En Az 2 Harften Oluşmalıdır.");
        }
    }
}
