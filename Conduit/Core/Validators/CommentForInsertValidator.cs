using Conduit.Core.DTOModels;
using Conduit.Models;
using FluentValidation;

namespace Conduit.Core.Validators
{
    public class CommentForInsertValidator : AbstractValidator<CommentForInsertDTO>
    {
        public CommentForInsertValidator()
        {
            RuleFor(comment => comment.BodyText).NotEmpty().NotNull().WithMessage("Text Body is Empty");
        }
    }
}
