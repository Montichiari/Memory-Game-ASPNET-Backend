namespace MemoryGameDotNetBackend.Dto
{
    public class LoginResponseDto
    {
        public LoginResponseDto(string id, string username, string tier)
        {
            Id = id;
            Username = username;
            Tier = tier;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Tier { get; set; }


    }
}
