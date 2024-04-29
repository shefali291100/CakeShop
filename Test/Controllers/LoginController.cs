using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.BLL.DTOs.Request;
using Test.BLL.Services;

namespace Test.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            private readonly ILoginService LoginService;
            public LoginController(ILoginService LoginService)
            {
                this.LoginService = LoginService;
            }

            [HttpPost("login")]
            [AllowAnonymous]
            public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
            {
                var result = await LoginService.IsValidUser(loginRequestDTO);
                if (result is not null)
                {
                    return Ok(result);
                }
                return Unauthorized(new { message = "Invalid Login!" });
            }
        }
    
}

