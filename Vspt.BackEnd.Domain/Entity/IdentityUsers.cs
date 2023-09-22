using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public class IdentityUsers : IEntity
    {    
        public string Username { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; } 
        
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }     
    }
}
