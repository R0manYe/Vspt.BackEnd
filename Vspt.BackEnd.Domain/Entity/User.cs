using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Domain.Entity
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; } 
        public Filter Filter { get; set; }
    }
}
