using Microsoft.AspNetCore.Mvc;
using ExplorationApi.Data;
using ExplorationApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExplorationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryController : ControllerBase
    {
        private readonly DiaryDbContext _dbContext;

        public DiaryController(DiaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/diary
        [HttpGet]
        public async Task<IActionResult> GetEntries()
        {
            var entries = await _dbContext.DiaryEntries.ToListAsync();
            return Ok(entries);
        }

        // GET: api/diary/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntryById(int id)
        {
            var entry = await _dbContext.DiaryEntries.FindAsync(id);
            if (entry == null)
            {
                return NotFound(new { message = $"Inlägg med ID {id} hittades inte." });
            }

            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiaryEntry([FromBody] DiaryEntry newEntry)
        {
            if (newEntry == null)
            {
                return BadRequest(new { message = "Inlägget saknas." });
            }

            if (string.IsNullOrWhiteSpace(newEntry.Title))
            {
                return BadRequest(new { message = "Titel får inte vara tom." });
            }

            if (string.IsNullOrWhiteSpace(newEntry.Content))
            {
                return BadRequest(new { message = "Innehåll får inte vara tomt." });
            }

            try
            {
                // Sätt datum till UTC nu
                newEntry.Date = DateTime.UtcNow;

                // Alla nya inlägg publiceras direkt
                newEntry.IsPublished = 1;

                _dbContext.DiaryEntries.Add(newEntry);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEntryById), new { id = newEntry.Id }, newEntry);
            }
            catch (Exception ex)
            {
                // Logga felet
                Console.Error.WriteLine($"Fel vid skapande av inlägg: {ex.Message}");
                return StatusCode(500, new { message = "Serverfel vid skapande av inlägg." });
            }
        }

        // GET: api/diary/deploytest
        [HttpGet("deploytest")]
        public IActionResult DeployTest()
        {
            return Ok(new { message = "Deploy fungerar version 2" });
        }
    }
}
