using MemoryGameDotNetBackend.Dto;
using MemoryGameDotNetBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            System.Diagnostics.Debug.WriteLine("Savegame called");

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

        [HttpGet("makefakes")]
        public IActionResult MakeFakes()
        {
            // Get the users
            User? user1 = db.Users.FirstOrDefault(u => u.Username == "morganfreeman");
            User? user2 = db.Users.FirstOrDefault(u => u.Username == "johnnycash");
            User? user3 = db.Users.FirstOrDefault(u => u.Username == "faker");
            User? user4 = db.Users.FirstOrDefault(u => u.Username == "ipaidformcafee");

            List<User> users = new List<User> { user1, user2, user3, user4 };

            int time = 100;

            foreach (User user in users)
            {
                if (user == null) continue;
                {
                    db.Add(new Game
                    {
                        User = user,
                        Timing = time,
                    });
                }
                time++;
            }

            db.SaveChanges();
            return Ok(new { Message = "Fakes made." });
        }

        [HttpGet("leaderboard")]
        public IActionResult GetLeaderboard()
        {
            System.Diagnostics.Debug.WriteLine("Leaderboard called");

            List<LeaderboardResponseDto> leaderboard = db.Game
                .Include(g => g.User)
                .OrderBy(g => g.Timing)
                .Take(5)
                .Select(g => new LeaderboardResponseDto(g.User.Username, g.Timing))
                .ToList();

            // For debugging
            foreach (var game in leaderboard)
            {
                Console.WriteLine($"{game.Username}: {game.Timing}");
            }

            return Ok(leaderboard);
        }
    }
}
