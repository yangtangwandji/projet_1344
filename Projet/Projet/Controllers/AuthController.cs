using Microsoft.AspNetCore.Mvc;
using Projet.Models.DTOS;
using Projet.Services.AuthService;

namespace Projet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dtoUser)
        {
            try
            {
                return Ok(await _authService.Register(dtoUser));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dtoUser)
        {
            try
            {

                AuthResponseDto user = await _authService.Login(dtoUser);
                if (user == null)
                    return Unauthorized("User not exist");

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}
