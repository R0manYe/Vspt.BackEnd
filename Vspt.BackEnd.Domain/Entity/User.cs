﻿using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class User : IEntityWithId
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string? Token { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
