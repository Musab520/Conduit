using Conduit.Core.DTOModels;
using FluentValidation;

namespace Conduit.Core.Validators
{
    public class ArticleForUpdateValidator : AbstractValidator<ArticleForUpdateDTO>
    {
        public ArticleForUpdateValidator()
        {
            RuleFor(article=>article.ArticleTitle).NotEmpty().NotNull().WithMessage("Title cannot be empty");
        }
    }
}
