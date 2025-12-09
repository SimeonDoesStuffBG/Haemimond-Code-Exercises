using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Technical_Request.Data;
using Technical_Request.Models;

namespace Technical_Request.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TechnicalRequestContext context;
        private DbSet<User> Users
        {
            get { return context.Users; }
        }
        public UsersController(TechnicalRequestContext _context)
        {
            context = _context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }
            User? existingUser = await Users.FirstOrDefaultAsync(u => u.Username == newUser.Username || u.Email == newUser.Email);
            if (existingUser != null)
            {
                return Conflict();
            }

            Users.Add(newUser);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User login)
        {
            User? user = await Users.FirstOrDefaultAsync(u=>u.Username==login.Username);
            if (user == null) 
            {
                return NotFound();
            }
            if (user.Password != login.Password) 
            {
                return Unauthorized();
            }
            string token = GenerateJwtToken(login.Username);
            return Ok(new { token });
        }
        
        private string GenerateJwtToken(string username)
        {
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ScrQlcnDYK5OyE9bzp8QnO60Bdsiugfjqfgascjphsciudgsu"));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer:"localhost:7000",
                audience:"localhost:7000",
                claims:claims,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
