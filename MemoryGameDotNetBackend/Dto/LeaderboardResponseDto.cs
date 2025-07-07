using System.Security;

namespace MemoryGameDotNetBackend.Dto
{
    public class LeaderboardResponseDto
    {
        public LeaderboardResponseDto(string username, int timing)
        {
            this.Username = username;
            this.Timing = timing;
        }

        public string Username { get; set; }
        public int Timing { get; set; }
    }
}
