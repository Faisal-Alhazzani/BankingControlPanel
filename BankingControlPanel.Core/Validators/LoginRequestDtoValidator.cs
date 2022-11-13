using BankingControlPanel.Core.DTOs.RequestDTOs;
using FluentValidation;

namespace BankingControlPanel.Core.Validators
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(RegisterRequest => RegisterRequest.Email)
                .NotEmpty()
                .WithMessage("Email field is required.");
            RuleFor(RegisterRequest => RegisterRequest.Email)
                .EmailAddress()
                .WithMessage("Please provide correct email.");
            RuleFor(RegisterRequest => RegisterRequest.Password)
                .NotEmpty()
                .WithMessage("Password field is required.");
        }
    }
}