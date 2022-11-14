using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Repositories;
using BankingControlPanel.Core.Interfaces.Services;
using BankingControlPanel.Core.Models;

namespace BankingControlPanel.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<CreateClientResponseDto> CreateClientAsync(CreateClientResponeDto clientRequestDto)
        {
            // create client model with associated entities 
            var ClientModel = new Client()
            {
                PersonalId = clientRequestDto.PersonalId,
                FirstName = clientRequestDto.FirstName,
                LastName = clientRequestDto.LastName,
                Email = clientRequestDto.Email,
                MobileNo = clientRequestDto.MobileNo,
                ProfilePhoto = clientRequestDto.ProfilePhoto,
                Sex = clientRequestDto.Sex
            };
            var Address = new Address()
            {
                City = clientRequestDto.City,
                Country = clientRequestDto.Country, 
                ZipCode = clientRequestDto.ZipCode,
                Street = clientRequestDto.Street,
            };
            var Account = new Account();

            // insert using client repo
            var client = await _clientRepository.CreateClientAsync(ClientModel, Address, Account);

            // prepare response
            var response = new CreateClientResponseDto();
            if (client is null)
            {
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;
            response.ClientObjectkey = client.ObjectKey;
            return response;
        }
    }
}
