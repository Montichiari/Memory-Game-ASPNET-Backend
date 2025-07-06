using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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


    }
}
