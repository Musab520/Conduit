using Conduit.Models;
using FluentValidation;

namespace Conduit.Core.Validators
{
    public class CommentForInsertValidator : AbstractValidator<Comment>
    {
        public CommentForInsertValidator()
        {
            RuleFor(comment => comment.BodyText).NotEmpty().NotNull().WithMessage("Text Body is Empty");
        }
    }
}
