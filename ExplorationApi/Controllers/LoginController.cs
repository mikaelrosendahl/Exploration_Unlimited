using ExplorationApi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExplorationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));  // Kontrollera att config inte är null
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login loginModel)
        {
            // Kontrollera att nödvändiga JWT-inställningar finns
            var secretKeyConfig = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            if (string.IsNullOrEmpty(secretKeyConfig) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
            {
                return StatusCode(500, "JWT-konfigurationsnycklar saknas i appsettings.json");
            }

            // Kontrollera autentiseringsuppgifterna här
            if (loginModel.Email == "michael.rose@exploration.se" && loginModel.Password == "Prestige2012!")
            {
                // Skapa säkerhetsnyckeln för token
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKeyConfig));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, loginModel.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                // Returnera tokenen till klienten
                return Ok(new { Token = tokenString });
            }

            // Autentiseringen misslyckades
            return Unauthorized(new { success = false });
        }
    }
}
