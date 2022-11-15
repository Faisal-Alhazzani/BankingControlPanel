using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;

namespace BankingControlPanel.Core.Interfaces.Services
{
    public interface IClientService
    {
       Task<CreateClientResponseDto> CreateClientAsync(CreateClientRequestDto clientRequestDto);
       Task<PagedList<ClientResponseDto>> GetClientsAsync(GetClientsRequestDto getClientsRequest);
    }
}
