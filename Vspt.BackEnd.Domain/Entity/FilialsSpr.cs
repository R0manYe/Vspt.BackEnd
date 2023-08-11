using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vspt.Box.Data.Entities;

namespace Vspt.BackEnd.Domain.Entity
{
    public class FilialsSpr 
    {
        public uint Id { get; set; }
        public string IdTxt { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
