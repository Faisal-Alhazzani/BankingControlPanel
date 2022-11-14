using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingControlPanel.Core.Interfaces.Services
{
    public interface IClientService
    {
        Task<CreateClientResponseDto> CreateClientAsync(CreateClientRequestDto clientRequestDto);
    }
}
