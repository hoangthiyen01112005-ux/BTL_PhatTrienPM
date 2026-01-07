using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthencationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IConfiguration config) : ControllerBase
    {
        private static ConcurrentDictionary<string, string> Accounts { get; set; } =
            new ConcurrentDictionary<string, string>();
        [AllowAnonymous]
        [HttpPost("login/{email}/{password}")]
        public async Task<IActionResult> Get(string email, string password)
        {
            await Task.Delay(500); // Simulate async operation
            var getEmail = Accounts!.Keys.Where(e => e.Equals(email)).FirstOrDefault();
            if (!string.IsNullOrEmpty(getEmail))
            {
                Accounts.TryGetValue(getEmail, out string? storedPassword);
                if (!Equals(storedPassword, password))
                    return BadRequest("Invalid password");
                string jwtToken = GenerateToken(email);
                return Ok(jwtToken);
            }
            else
            {
                return NotFound("Account not found");
            }
        }

        private string GenerateToken(string email)
        {
            var key = Encoding.UTF8.GetBytes(config["Authentication:Key"]!);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] { new Claim(ClaimTypes.Email, email!) };
            var token = new JwtSecurityToken(
                issuer: config["Authentication:Issuer"],
                audience: config["Authentication:Audience"],
                claims: claims,
                expires: null,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("register/{email}/{password}")]
        public async Task<IActionResult> resgister(string email, string password)
        {
            await Task.Delay(500); // Simulate async operation
            var getEmail = Accounts!.Keys.Where(e => e.Equals(email)).FirstOrDefault();
            if (!string.IsNullOrEmpty(getEmail))
                return BadRequest("Account already exists");
            Accounts[email] = password;
            return Ok("Account registered successfully");


        }


    }
}
