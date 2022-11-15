using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Models;
using System.Collections;

namespace BankingControlPanel.Core.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> CreateClientAsync(Client client, Address address, Account account);
        Task<PagedList<Client>> GetClientsAsync(GetClientsRequestDto getClientsRequest);
    }
}
