namespace MemoryGameDotNetBackend.Models
{
    public class Game
    {
        public Game()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public int Timing { get; set; }


        public virtual User User { get; set; }
    }
}
