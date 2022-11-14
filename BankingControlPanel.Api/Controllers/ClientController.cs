using BankingControlPanel.Core.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BankingControlPanel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public ClientController()
        {

        }

        [SwaggerOperation(
        Summary = "Register User",
        Description = "Register user by email and password.",
        OperationId = "RegisterUser"
        )]
        [HttpPost("register")]
        public async Task<ActionResult<CreateClientRequestDto>> RegisterAsync([FromBody] CreateClientRequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
