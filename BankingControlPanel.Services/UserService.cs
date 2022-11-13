using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

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

            // case passwords do not match
            if (registerRequest.Password != registerRequest.ConfirmPassword)
            {
                errors.Add("Passwords do not match");
                response.Errors = errors;
                response.IsSuccess = false;
                return response; 
            }

            var identityUser = new IdentityUser
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };

            var result = await _userManager.CreateAsync(identityUser, registerRequest.Password);

            // case created
            if (result.Succeeded)
            {
                response.IsSuccess = true;
                return response;
            }

            // case fail by user manager
            response.IsSuccess = false;
            response.Errors = result.Errors.Select(err => err.Description);
            return response;
        }
    }
}