using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Services
{
    public class ClientService : IClientService
    {
        public ClientService()
        {

        }
        public Task<CreateClientResponseDto> CreateClientAsync(CreateClientRequestDto clientRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
