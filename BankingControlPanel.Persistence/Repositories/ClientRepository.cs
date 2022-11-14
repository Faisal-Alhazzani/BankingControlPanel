using BankingControlPanel.Core.Interfaces.Repositories;
using BankingControlPanel.Core.Models;
using BankingControlPanel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankingControlPanelContext _controlPanelContext;

        public ClientRepository(BankingControlPanelContext controlPanelContext)
        {
            _controlPanelContext = controlPanelContext;
        }

        public async Task<Client> CreateClientAsync(Client client, Address address, Account account)
        {
            using var transaction = _controlPanelContext.Database.BeginTransaction();

            try
            {
                await _controlPanelContext.Clients.AddAsync(client);
                await _controlPanelContext.SaveChangesAsync();

                address.ClientId = client.Id;
                await _controlPanelContext.Addresses.AddAsync(address);
                await _controlPanelContext.SaveChangesAsync();

                account.ClientId = client.Id;
                await _controlPanelContext.Accounts.AddAsync(account);
                await _controlPanelContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception)
            {
                return new Client();
            }
            return client;
        }
    }
}
