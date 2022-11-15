using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BankingControlPanel.Api.Controllers
{
    [Authorize]
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
        Description = "Create client, please see schema tap for accepted values and format",
        OperationId = "CreateClient"
        )]
        [HttpPost("create-client")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CreateClientResponseDto>> CreateClientAsync([FromBody] CreateClientRequestDto createClientRequestDto)
        {
            var result = await _clientService.CreateClientAsync(createClientRequestDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [SwaggerOperation(
        Summary = "Get Clients",
        Description = "Get clients with pagination",
        OperationId = "GetClients"
        )]
        [HttpGet("get-clients")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<PagedList<ClientResponseDto>>> GetClientsAsync([FromQuery] GetClientsRequestDto getClientsRequestDto)
        {
            var result = await _clientService.GetClientsAsync(getClientsRequestDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }


    }
}
