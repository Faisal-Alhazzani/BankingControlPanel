using BankingControlPanel.Core.Models;

namespace BankingControlPanel.Core.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> CreateClientAsync(Client client, Address address, Account account);
    }
}
