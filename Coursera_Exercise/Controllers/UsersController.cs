using Coursera_Exercise.Data;
using Coursera_Exercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Coursera_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CourseraExerciseContext _context;
        private DbSet<User> Users { get { return _context.Users; } }
        public UsersController(CourseraExerciseContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }
            User? existingUser = await Users.Where(u => u.Username == u.Username).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return Conflict();
            }
            //Hash the password in real application
            Users.Add(newUser);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User login)
        {
            
            User? user = await Users.Where(u=>u.Username==login.Username)
                .FirstOrDefaultAsync();
            if(user == null)
            {
                return NotFound();
            }
            if(user.Password != login.Password)
            {
                return Unauthorized();
            }
            string token = GenerateJwtToken(login.Username);
            return Ok(new {token});
        }

        private string GenerateJwtToken(string username)
        {
            Claim[] claims = new[]
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
