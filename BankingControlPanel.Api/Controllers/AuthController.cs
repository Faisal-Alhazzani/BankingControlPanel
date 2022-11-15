using BankingControlPanel.Core.DTOs.RequestDTOs;
using BankingControlPanel.Core.DTOs.ResponseDTOs;
using BankingControlPanel.Core.Interfaces.Services;
using BankingControlPanel.Core.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace BankingControlPanel.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [SwaggerTag("Authentication Endpoints")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [SwaggerOperation(
        Summary = "Register User",
        Description = "Register user by email and password.",
        OperationId = "RegisterUser"
        )]
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseDto>> RegisterAsync([FromBody] RegisterRequestDto requestDto)
        {
            var result = await _userService.RegisterUserAsync(requestDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [SwaggerOperation(
        Summary = "Register Admin User",
        Description = "This endpoint is just for demo purposes to register an admin user.",
        OperationId = "RegisterAdminUser"
        )]
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponseDto>> RegisterAdminAsync([FromBody] RegisterRequestDto requestDto)
        {
            var result = await _userService.RegisterAdminAsync(requestDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [SwaggerOperation(
        Summary = "Login User",
        Description = "Login user by email and password.",
        OperationId = "LoginUser"
        )]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> LoginAsync([FromBody] LoginRequestDto requestDto)
        {
            var result = await _userService.LoginUserAsync(requestDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
