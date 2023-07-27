using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vspt.BackEnd.Domain.Entity
{
    public class IdentityRoles
    {
        [Key]
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public List<IdentityUsersRoles> IdentityUsersRole { get; set; } 
    }
}
