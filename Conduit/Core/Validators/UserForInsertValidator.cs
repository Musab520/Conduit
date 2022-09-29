using Conduit.Models;
using FluentValidation;

namespace Conduit.Core.Validators
{
    public class UserForInsertValidator : AbstractValidator<User>
    {
        public UserForInsertValidator()
        {
            RuleFor(user=>user.Username).NotEmpty().NotNull().WithMessage("Username is required!").Must(UniqueUsername).WithMessage("Username is taken");
            RuleFor(user => user.Password).NotEmpty().NotNull().WithMessage("Password is Required").Must(ValidPassword).WithMessage("Password must be grater than or equal to 6 characters and contain letters and numbers");
        }
        private bool UniqueUsername(string name)
        {
            using (var conduitDbContext = new ConduitDBContext())
            {
                User? user = conduitDbContext.UserTbls.FirstOrDefault(user => user.Username.ToLower() == name.ToLower());
                if (user == null)
                    return true;
                else
                    return false;
            }
        }
        private bool ValidPassword(string password)
        {
            if (password.Length >= 6 && password.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }

    }
}
