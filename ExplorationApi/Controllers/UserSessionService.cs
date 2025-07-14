using Microsoft.AspNetCore.Mvc;

namespace ExplorationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserSessionService : ControllerBase
    {
        [HttpGet("IsLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            var user = HttpContext.User;
            if (user?.Identity != null && user.Identity.IsAuthenticated)
            {
                return Ok(new { IsLoggedIn = true, Username = user.Identity.Name });
            }
            else
            {
                return Ok(new { IsLoggedIn = false });
            }
        }
    }
}
