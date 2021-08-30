using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RendaSolidaria.API.Models;
using System.Threading.Tasks;

namespace RendaSolidaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login ([FromBody] Login userInfo)
        {
            return StatusCode(200, new UserToken(userInfo, _configuration));
        }
    }
}
