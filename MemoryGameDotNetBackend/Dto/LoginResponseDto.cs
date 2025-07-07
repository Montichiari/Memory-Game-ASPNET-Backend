namespace MemoryGameDotNetBackend.Dto
{
    public class LoginResponseDto
    {
        public LoginResponseDto(string username, string tier)
        {
            Username = username;
            Tier = tier;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Tier { get; set; }


    }
}
