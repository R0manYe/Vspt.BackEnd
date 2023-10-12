using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity
{
    public partial class Spr_cargo
    {
        [Key]
        public string ID { get; set; }
        public string? NAME { get; set; }
        public string? FULLNAME { get; set; }
        public string? GRP { get; set; } 
      
    }
}
