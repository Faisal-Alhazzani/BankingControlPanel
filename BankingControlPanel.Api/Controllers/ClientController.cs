using BankingControlPanel.Core.DTOs.RequestDTOs;
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
        Description = "Create client",
        OperationId = "CreateClient"
        )]
        [HttpPost("create-client")]
        public async Task<ActionResult<CreateClientResponeDto>> CreateClientAsync([FromBody] CreateClientResponeDto requestDto)
        {
            var reult = await _clientService.CreateClientAsync(requestDto);
            return Ok(reult);
        }
    }
}
