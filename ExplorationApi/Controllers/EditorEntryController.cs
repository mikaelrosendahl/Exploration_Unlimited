using Microsoft.AspNetCore.Mvc;
using ExplorationApi.Data;
using ExplorationApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ExplorationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishedEntryController : ControllerBase
    {
        private readonly DiaryDbContext _dbContext;

        public PublishedEntryController(DiaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/publishedentry
        [HttpGet]
        public async Task<IActionResult> GetAllEntries()
        {
            var entries = await _dbContext.DiaryEntries.ToListAsync();
            return Ok(entries);
        }

        // GET: api/publishedentry/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntryById(int id)
        {
            var entry = await _dbContext.DiaryEntries.FindAsync(id);
            if (entry == null)
                return NotFound(new { message = $"Inlägg med ID {id} hittades inte." });

            return Ok(entry);
        }

        // GET: api/publishedentry/published
        [HttpGet("published")]
        public async Task<IActionResult> GetPublishedEntries()
        {
            var publishedEntries = await _dbContext.DiaryEntries
                .Where(entry => entry.IsPublished == 1)
                .ToListAsync();
            return Ok(publishedEntries);
        }

        // POST: api/publishedentry
        [HttpPost]
        public async Task<IActionResult> CreateEntry([FromBody] DiaryEntry newEntry)
        {
            if (newEntry == null)
                return BadRequest(new { message = "Inlägget saknas." });

            newEntry.Date = System.DateTime.UtcNow;

            _dbContext.DiaryEntries.Add(newEntry);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEntryById), new { id = newEntry.Id }, newEntry);
        }

        // PUT: api/publishedentry/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntry(int id, [FromBody] DiaryEntry updatedEntry)
        {
            if (id != updatedEntry.Id)
                return BadRequest(new { message = "ID:t matchar inte." });

            var existingEntry = await _dbContext.DiaryEntries.FindAsync(id);
            if (existingEntry == null)
                return NotFound(new { message = $"Inlägg med ID {id} hittades inte." });

            existingEntry.Title = updatedEntry.Title;
            existingEntry.Content = updatedEntry.Content;
            existingEntry.Date = System.DateTime.UtcNow;
            existingEntry.IsPublished = updatedEntry.IsPublished;

            await _dbContext.SaveChangesAsync();
            return Ok(existingEntry);
        }

        // PUT: api/publishedentry/{id}/publish
        [HttpPut("{id}/publish")]
        public async Task<IActionResult> PublishEntry(int id)
        {
            var entry = await _dbContext.DiaryEntries.FindAsync(id);
            if (entry == null)
                return NotFound(new { message = $"Inlägg med ID {id} hittades inte." });

            entry.IsPublished = 1;
            await _dbContext.SaveChangesAsync();

            return Ok(entry);
        }

        // DELETE: api/publishedentry/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            var entry = await _dbContext.DiaryEntries.FindAsync(id);
            if (entry == null)
                return NotFound(new { message = $"Inlägg med ID {id} hittades inte." });

            _dbContext.DiaryEntries.Remove(entry);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
