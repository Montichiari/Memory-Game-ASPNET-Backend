namespace MemoryGameDotNetBackend.Models
{
    public class User
    {

        public User()
        {
            Id = Guid.NewGuid().ToString();
            Game = new List<Game>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tier { get; set; }

        public virtual ICollection<Game> Game { get; set; }

        }


}
