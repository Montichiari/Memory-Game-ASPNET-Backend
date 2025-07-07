using MemoryGameDotNetBackend.Dto;
using MemoryGameDotNetBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MemoryGameDotNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private MemoryGameContext db;

        public GameController(MemoryGameContext context)
        {
            this.db = context;
        }

        [HttpPost("savegame")]
        public IActionResult CreateGame(GameRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserId))
            {
                return BadRequest("Invalid game data.");
            }

            // Check if the user exists
            User? user = db.Users.FirstOrDefault(u => u.Id == request.UserId);

            if (user != null)
            {
                db.Add(new Game
                {
                    User = user,
                    Timing = request.Timing,
                });
            }
            db.SaveChanges();
            return Ok(new { Message = "Game created successfully." });
        }

        [HttpGet("leaderboard")]
        public IActionResult GetLeaderboard()
        {
            List<LeaderboardResponseDto> leaderboard = db.Game
                .OrderBy(g => g.Timing)
                .Take(5)
                .Select(g => new LeaderboardResponseDto(g.User.Username, g.Timing))
                .ToList();

            return Ok(leaderboard);
        }
    }
}
