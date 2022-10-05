﻿using Conduit.Core.DTOModels;
using Conduit.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Conduit.Core.Validators
{
    public class UserForInsertValidator : AbstractValidator<UserForInsertDTO>
    {
     
        public UserForInsertValidator()
        {
            RuleFor(user => user.Password).NotEmpty().NotNull().WithMessage("Password is Required").Must(ValidPassword).WithMessage("Password must be grater than or equal to 6 characters and contain letters and numbers");
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
