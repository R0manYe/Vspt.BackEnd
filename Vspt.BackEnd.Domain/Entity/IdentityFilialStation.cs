using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class IdentityFilialStation
    {        
        public uint FilialId { get; set; }
        public FilialsSpr Filials { get; set; }
        public string StationId { get; set; }
    }
}
