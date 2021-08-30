using HotChocolate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RendaSolidaria.Infra.Data.Context;
using RendaSolidaria.Infra.Data.Repository;
using System;

namespace RendaSolidaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public MainContext _context;

        public UserController(IUserRepository userRepository, [ScopedService] MainContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userRepository.GetUsers(_context);
                return StatusCode(200, users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
