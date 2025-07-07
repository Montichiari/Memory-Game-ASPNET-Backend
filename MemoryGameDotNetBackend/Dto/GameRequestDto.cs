namespace MemoryGameDotNetBackend.Dto
{
    public class GameRequestDto
    {
        public GameRequestDto(string UserId, int Timing)
        {
            this.UserId = UserId;
            this.Timing = Timing;
        }
        public string UserId { get; set; }
        public int Timing { get; set; }
    }
}
