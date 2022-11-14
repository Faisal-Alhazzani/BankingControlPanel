using BankingControlPanel.Core.Models;
using System.Collections;

namespace BankingControlPanel.Core.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> CreateClientAsync(Client client, Address address, Account account);
/*        Task<IEnumerable<Client>> GetClientsAsync(int page,
                                                    int pageSize,
                                                    string name,
                                                    string personalID,
                                                    string email,
                                                    string sortBy,
                                                    string sortDescending);*/
    }
}
