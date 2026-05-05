using Api.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using MiSide.Models.Accounts;

namespace MiSide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController(AccountService accountService) : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            accountService.Register(request.UserName, request.FirstName, request.Password);
            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            string token = accountService.Login(loginRequest.UserName, loginRequest.Password);
            HttpContext.Response.Cookies.Append("myToken", token, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(token);
        }
    }
}
