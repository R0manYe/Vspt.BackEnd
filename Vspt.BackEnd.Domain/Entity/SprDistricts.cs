using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class SprDistrict
    {    
        public string Id { get; init; }        
        public string Name { get; init; }
        public string District_id_txt { get; init; }
        public SprFilials SprFilial { get; init; }
        public string Bu_id { get; init; }

    }
}
