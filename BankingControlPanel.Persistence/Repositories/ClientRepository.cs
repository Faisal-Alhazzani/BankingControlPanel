using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Enums;
using BankingControlPanel.Core.Interfaces.Repositories;
using BankingControlPanel.Core.Models;
using BankingControlPanel.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
                // add client with related address and account
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

        public async Task<PagedList<Client>> GetClientsAsync(GetClientsRequestDto request)
        {
            try
            {
                // build query 
                var query = _controlPanelContext.Clients

                    .Where(c => string.IsNullOrEmpty(request.SearchByName)
                                || c.FirstName.ToLower().Contains(request.SearchByName)
                                || c.LastName.ToLower().Contains(request.SearchByName))

                    .Where(c => string.IsNullOrEmpty(request.SearchByPersonalID)
                                || c.PersonalId.Contains(request.SearchByPersonalID))

                    .Where(c => string.IsNullOrEmpty(request.SearchByEmail)
                                || c.Email.ToLower().Contains(request.SearchByEmail))

                    .AsNoTracking()

                    .AsQueryable();

                // add sorting to query
                query = (request.SortBy, request.SortDescending) switch
                {
                    (ClientTableSortBy.Name, false) => query.OrderBy(c => c.FirstName).ThenBy(c => c.LastName),

                    (ClientTableSortBy.Name, true) => query.OrderByDescending(c => c.FirstName).ThenByDescending(c => c.LastName),

                    (ClientTableSortBy.Country, false) => query.OrderBy(c => c.Address.Country),

                    (ClientTableSortBy.Country, true) => query.OrderByDescending(c => c.Address.Country),

                    _ => query.OrderBy(c => c.FirstName).ThenBy(c => c.LastName),
                };

                var totalCount = await query.CountAsync();

                var result = await query.Include(c => c.Address).Include(c => c.Accounts).ToListAsync();

                return new PagedList<Client>()
                {
                    IsSuccess = true,
                    Data = result,
                    PageNumber = request.Page.Value,
                    PageSize = request.PageSize.Value,
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling((double)totalCount / request.PageSize.Value)
                };
            }
            catch (Exception)
            {
                return new PagedList<Client>()
                {
                    IsSuccess = false
                };
            }
        }
    }
}
