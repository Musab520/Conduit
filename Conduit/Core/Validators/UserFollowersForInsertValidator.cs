using Conduit.Models;
using FluentValidation;

namespace Conduit.Core.Validators
{
    public class UserFollowersForInsertValidator : AbstractValidator<UserFollowers>
    {
        public UserFollowersForInsertValidator()
        {
            RuleFor(userFollower=>userFollower.UserId).NotEqual(userFollower=>userFollower.FollowerId);
        }
    }
}
