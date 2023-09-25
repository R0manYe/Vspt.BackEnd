﻿using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity
{
    public partial class Spr_org
    {
        [Key]
        public string ID { get; set; }
        public string? NAME { get; set; }
        public string? FULL_NAME { get; set; }
        public string? INN { get; set; }
        public string? ADDRESS { get; set; }

    }
}
