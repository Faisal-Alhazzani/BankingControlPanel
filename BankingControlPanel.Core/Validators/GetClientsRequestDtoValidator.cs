using BankingControlPanel.Core.DTOs.RequestDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.Validators
{
    public class GetClientsRequestDtoValidator : AbstractValidator<GetClientsRequestDto>
    {
        public GetClientsRequestDtoValidator()
        {
            RuleFor(r => r.Page)
                .NotEmpty()
                .WithMessage("Page field is required");
            RuleFor(r => r.Page)
                .GreaterThan(0)
                .WithMessage("Invalid page number");
            RuleFor(r => r.PageSize)
                .NotEmpty()
                .WithMessage("Page size field is required");
            RuleFor(r => r.PageSize)
                .LessThan(50)
                .WithMessage("Maximum items per page is 50");
        }
    }
}
