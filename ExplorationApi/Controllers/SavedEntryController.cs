using Microsoft.AspNetCore.Mvc;
using ExplorationApi.Data;
using ExplorationApi.Models;
using Microsoft.EntityFrameworkCore;
using ExplorationApi.Classes;

namespace ExplorationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedEntryController : ControllerBase
    {
        private readonly DiaryDbContext _dbContext;

        public SavedEntryController(DiaryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/savedentries
        [HttpGet]
        public async Task<IActionResult> GetAllSavedEntries()
        {
            var savedEntries = await _dbContext.SavedEntries.ToListAsync();
            return Ok(savedEntries);
        }

        // GET: api/savedentries/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavedEntryById(int id)
        {
            var savedEntry = await _dbContext.SavedEntries.FindAsync(id);
            if (savedEntry == null)
            {
                return NotFound(new { message = $"Utkast med ID {id} hittades inte." });
            }

            return Ok(savedEntry);
        }

        // POST: api/savedentries
        [HttpPost]
        public async Task<IActionResult> CreateSavedEntry([FromBody] SavedEntry newEntry)
        {
            if (string.IsNullOrWhiteSpace(newEntry.Title))
            {
                return BadRequest(new { message = "Titel är obligatorisk för att spara ett utkast." });
            }

            newEntry.LastSaved = DateTime.Now;

            _dbContext.SavedEntries.Add(newEntry);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSavedEntryById), new { id = newEntry.Id }, newEntry);
        }

        // PUT: api/savedentries/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavedEntry(int id, [FromBody] SavedEntry updatedEntry)
        {
            if (id != updatedEntry.Id)
            {
                return BadRequest(new { message = "ID mismatch." });
            }

            var existingEntry = await _dbContext.SavedEntries.FindAsync(id);
            if (existingEntry == null)
            {
                return NotFound(new { message = $"Utkast med ID {id} hittades inte." });
            }

            existingEntry.Title = updatedEntry.Title;
            existingEntry.Content = updatedEntry.Content;
            existingEntry.LastSaved = DateTime.Now;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/savedentries/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedEntry(int id)
        {
            var savedEntry = await _dbContext.SavedEntries.FindAsync(id);
            if (savedEntry == null)
            {
                return NotFound(new { message = $"Utkast med ID {id} hittades inte." });
            }

            _dbContext.SavedEntries.Remove(savedEntry);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

