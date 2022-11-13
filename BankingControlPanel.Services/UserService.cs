using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankingControlPanel.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> LoginUserAsync(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            var response = new LoginResponseDto();
            var errors = new List<string>();

            if (user is null)
            {
                errors.Add("Invalid email, no user is registered with the entered email.");
                response.Errors = errors;
                response.IsSuccess = false;
                return response;
            }

            var isValidCredentials = await _userManager.CheckPasswordAsync(user: user,
                                                                           password: loginRequest.Password);
            if (!isValidCredentials)
            {
                errors.Add("Invalid credentials, please check the email and password entered correctly.");
                response.Errors = errors;
                response.IsSuccess = false; 
                return response;
            }

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["AuthSettings:Issuer"],
                audience: _configuration["AuthSettings:Audience"],
                claims: claims, expires: DateTime.Now.AddHours(8),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            response.Token = tokenAsString;
            response.ExpireDate = token.ValidTo; 
            response.IsSuccess = true;
            return response;
        }

        public async Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto registerRequest)
        {
            var identityUser = new IdentityUser
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Email
            };

            var result = await _userManager.CreateAsync(user: identityUser,
                                                        password: registerRequest.Password);

            var response = new RegisterResponseDto();
            // case created
            if (result.Succeeded)
            {
                response.IsSuccess = true;
                return response;
            }

            var errors = new List<string>();
            // case fail by user manager
            response.IsSuccess = false;
            response.Errors = result.Errors.Select(err => err.Description);
            return response;
        }
    }
}