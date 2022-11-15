using BankingControlPanel.Core.DTOs.RequestDTOs;
using FluentValidation;

namespace BankingControlPanel.Core.Validators
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
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
            RuleFor(RegisterRequest => RegisterRequest.ConfirmPassword)
                .NotEmpty()
                .WithMessage("Confirm password field is required.");
            RuleFor(RegisterRequest => RegisterRequest.ConfirmPassword)
                .Equal(RegisterRequest => RegisterRequest.Password)
                .WithMessage("Passwords do not match.");
        }
    }
}