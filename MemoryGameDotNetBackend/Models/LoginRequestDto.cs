namespace MemoryGameDotNetBackend.Models
{
    public class LoginRequestDto
    {
        public LoginRequestDto(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
