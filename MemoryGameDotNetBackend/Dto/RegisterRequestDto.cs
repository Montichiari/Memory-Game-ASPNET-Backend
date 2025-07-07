namespace MemoryGameDotNetBackend.Dto
{
    public class RegisterRequestDto
    {
        public RegisterRequestDto(string username, string password, string tier)
        {
            Username = username;
            Password = password;
            Tier = tier;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tier { get; set; }
    }
}
