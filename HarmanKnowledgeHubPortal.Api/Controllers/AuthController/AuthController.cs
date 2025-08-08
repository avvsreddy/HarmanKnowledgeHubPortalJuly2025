using HarmanKnowledgeHubPortal.Domain.DTO;
using HarmanKnowledgeHubPortal.Domain.Entities;
using HarmanKnowledgeHubPortal.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using System.Buffers.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HarmanKnowledgeHubPortal.Api.Controllers.AuthController
{
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("register")]
            public IActionResult Register(RegisterDto dto)
            {
                try
                {
                    var result = _authService.Register(dto);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }

            [HttpPost("login")]
            public IActionResult Login(LoginDto dto)
            {
                try
                {
                    var result = _authService.Login(dto);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return Unauthorized(new { message = ex.Message });
                }
            }

            [HttpPost("logout")]
            public IActionResult Logout()
            {
                // Since JWT is stateless, client just deletes the token.
                return Ok(new { message = "Logout successful — please clear token on client." });
            }
        }
    }

