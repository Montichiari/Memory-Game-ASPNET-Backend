namespace MemoryGameDotNetBackend.Models
{
    public class LoginResponseDto
    {
        public LoginResponseDto(string username, string tier)
        {
            Username = username;
            Tier = tier;
        }

        public string Username { get; set; }
        public string Tier { get; set; }


    }
}
