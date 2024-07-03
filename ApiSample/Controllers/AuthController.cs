using ApiSample.Models;
using ApiSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserService userService, TokenManager tokenManager) : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLogin form)
        {
            User currentUser = userService.Login(form.Email, form.Password);
            string token = tokenManager.GenerateToken(currentUser);
            return Ok(token);
        }
    }
}
