using ExplorationApi.Classes;
using Microsoft.AspNetCore.Mvc;

namespace ExplorationApi.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Här ska egentligen datan sparas till databasen, exempel:
            // _context.Contacts.Add(contact);
            // await _context.SaveChangesAsync();

            return Ok(new { message = "Form submitted successfully!" });
        }
    }
}
