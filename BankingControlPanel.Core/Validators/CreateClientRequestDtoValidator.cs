using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using BankingControlPanel.Core.DTOs.RequestDTOs;

namespace BankingControlPanel.Core.Validators
{
    public class CreateClientRequestDtoValidator : AbstractValidator<CreateClientRequestDto>
    {
        public CreateClientRequestDtoValidator()
        {
            RuleFor(c => c.PersonalId)
                .NotEmpty()
                .WithMessage("Personal Id field is required.");
            RuleFor(c => c.PersonalId)
                .Length(11)
                .WithMessage("Personal Id must be 11 characters length");
            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("Email field is required.");
            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Invalid email, please enter a correct email.");
            RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First Name field is required.");
            RuleFor(c => c.FirstName)
                .MaximumLength(60)
                .WithMessage("First Name is too long.");
            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("Last Name field is required.");
            RuleFor(c => c.LastName)
                .MaximumLength(60)
                .WithMessage("Last Name is too long.");
            RuleFor(c => c.MobileNo)
                .Matches(@"^\+[1-9]{1}[0-9]{3,11}$")
                .WithMessage("Invalid mobile format.");
            RuleFor(c => c.Sex)
                .NotEmpty()
                .WithMessage("Sex field is required.");
            RuleFor(c => c.Sex)
                .IsInEnum()
                .WithMessage("Sex value should be 1 for male or 2 for female.");
        }
    }
}
