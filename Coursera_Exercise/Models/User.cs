using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Models
{
    [Index(nameof(Username), IsUnique=true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string Email { get; set; } = null!;
    }
}
