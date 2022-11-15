using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Repositories;
using BankingControlPanel.Core.Interfaces.Services;
using BankingControlPanel.Core.Models;
using BankingControlPanel.Core.Helpers;

namespace BankingControlPanel.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<CreateClientResponseDto> CreateClientAsync(CreateClientRequestDto clientRequestDto)
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

            var errors = new List<string>();

            if (client is null)
            {
                response.IsSuccess = false;
                errors.Add("Error adding the client.");
                response.Errors = errors;
                return response;
            }

            response.IsSuccess = true;

            response.Objectkey = client.ObjectKey;

            return response;
        }

        async Task<PagedList<ClientResponseDto>> IClientService.GetClientsAsync(GetClientsRequestDto request)
        {
            // sanitize input parameters

            request.PageSize = request.PageSize
                .Within(min: 1, max: 20, @default: 10);

            request.Page = request.Page
                .AtLeast(1);

             request.SearchByName = request.SearchByName?.ToLower().Trim() ?? string.Empty;

             request.SearchByEmail = request.SearchByEmail?.ToLower().Trim() ?? string.Empty;

             request.SearchByPersonalID = request.SearchByPersonalID?.ToLower().Trim() ?? string.Empty;

            // get clients using client repo
            var result = await _clientRepository.GetClientsAsync(request);

            // prepare response
            var response = new PagedList<ClientResponseDto>();

            if (!result.IsSuccess)
            {
                response.IsSuccess = false;
                return response;
            }

            response.IsSuccess = true;

            response.TotalCount = result.TotalCount;

            response.TotalPages = result.TotalPages;

            response.PageNumber = result.PageNumber;

            response.PageSize = result.PageNumber;

            // map model to response dto
            response.Data = result.Data.Select(c => new ClientResponseDto() {
                ObjectKey = c.ObjectKey,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PersonalId = c.PersonalId,
                Email = c.Email,
                MobileNo = c.MobileNo,
                ProfilePhoto = c.ProfilePhoto,
                Accounts = c.Accounts.Select(a => a.ObjectKey),
                Address = new AddressResponseDto()
                {
                    Country = c.Address.Country ?? string.Empty,
                    City = c.Address.City ?? string.Empty,
                    Street = c.Address.Street ?? string.Empty,
                    ZipCode = c.Address.ZipCode ?? string.Empty
                }
            });

            return response;
        }
    }
}
