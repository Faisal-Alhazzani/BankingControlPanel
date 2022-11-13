using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto registerRequest)
        {
            List<string> errors = new();
            RegisterResponseDto response = new();
            if (registerRequest.Password != registerRequest.ConfirmPassword)
            {
                errors.Add("Passwords do not match");
                response.Errors = errors;
                return response; 
            }

            var identityUser = new IdentityUser
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };

            var result = 
        }
    }
}
