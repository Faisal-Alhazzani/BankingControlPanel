using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;

namespace BankingControlPanel.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<RegisterResponseDto> RegisterUserAsync(RegisterRequestDto registerRequest);
        Task<LoginResponseDto> LoginUserAsync(LoginRequestDto loginRequest);
    }
}
