using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed  class IdentityClaims : IEntityWithId
    {       
        public Guid Id { get; set; }
        public string ClaimName { get; set; }   
    }
}
