﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vspt.Box.Data.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vspt.BackEnd.Domain.Entity
{
    public sealed class SprDistrict:IEntity
    {    
        public ulong Id { get; init; }        
        public string Name { get; init; }
        public string District_id_txt { get; init; }
        public SprFilials SprFilial { get; init; }
        public byte Bu_id { get; init; }       
    }
}
