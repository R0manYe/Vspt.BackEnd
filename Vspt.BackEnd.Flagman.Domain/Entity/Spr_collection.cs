using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vspt.BackEnd.Flagman.Domain.Entity
{
    public partial class Spr_collection
    {
        [Key]
        public int ID { get; set; }
        public string?  ID_SPR { get; set; }
        public string? NAIM { get; set; }
        public int SV { get; set; }
        public string? ID_SP { get; set; }

    }
}
