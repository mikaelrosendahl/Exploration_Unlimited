
using ExplorationApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class SeriesController : ControllerBase
{
    private readonly DiaryDbContext _context;

    public SeriesController(DiaryDbContext context)
    {
        _context = context;
    }

    // GET: api/series
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Series>>> GetSeries()
    {
        return await _context.Series.ToListAsync();
    }

    // GET: api/series/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Series>> GetSeries(int id)
    {
        var series = await _context.Series.FindAsync(id);

        if (series == null)
        {
            return NotFound();
        }

        return series;
    }

    // POST: api/series
    [HttpPost]
    public async Task<ActionResult<Series>> PostSeries(Series series)
    {
        _context.Series.Add(series);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetSeries", new { id = series.Id }, series);
    }

    // DELETE: api/series/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeries(int id)
    {
        var series = await _context.Series.FindAsync(id);
        if (series == null)
        {
            return NotFound();
        }

        _context.Series.Remove(series);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
