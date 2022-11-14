using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BankingControlPanel.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [SwaggerOperation(
        Summary = "Create Client",
        Description = "Create client",
        OperationId = "CreateClient"
        )]
        [HttpPost("create-client")]
        public async Task<ActionResult<CreateClientResponseDto>> CreateClientAsync([FromBody] CreateClientRequestDto createClientRequestDto)
        {
            var reult = await _clientService.CreateClientAsync(createClientRequestDto);
            return Ok(reult);
        }


        [SwaggerOperation(
        Summary = "Get Clients",
        Description = "Get clients with pagination",
        OperationId = "GetClients"
        )]
        [HttpGet("get-clients")]
        public async Task<ActionResult<GetClientsResponseDto>> CreateClientAsync([FromQuery] GetClientsRequestDto getClientsRequestDto)
        {
            return new GetClientsResponseDto();
/*            var reult = await _clientService.GetClientsAsync(GetClientsRequestDto);
            return Ok(reult);*/
        }


    }
}
