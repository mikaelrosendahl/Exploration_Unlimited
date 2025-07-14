using ExplorationApi.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExplorationApi.Controllers
{
    [Route("api/db")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private readonly ExplorationDbContext _db;

        public DbController(ExplorationDbContext db)
        {
            _db = db;
        }

        // Lägg till endpoints här vid behov
    }
}
