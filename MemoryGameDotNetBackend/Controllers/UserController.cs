using MemoryGameDotNetBackend.Dto;
using MemoryGameDotNetBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryGameDotNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private MemoryGameContext db;

        public UserController(MemoryGameContext context)
        {
            this.db = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto request)
        {
            System.Diagnostics.Debug.WriteLine("Login called");

            var user = db.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            // Assuming the User model has a Tier property
            var response = new LoginResponseDto(user.Id, user.Username, user.Tier);
            return Ok(response);
       

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestDto request)
        {
            if (db.Users.Any(u => u.Username == request.Username))
            {
                return BadRequest("Username already exists.");
            }
            var user = new User
            {
                Username = request.Username,
                Password = request.Password,
                Tier = request.Tier
            };
            db.Users.Add(user);
            db.SaveChanges();
            return Ok("User registered successfully.");
        }

    }
}
