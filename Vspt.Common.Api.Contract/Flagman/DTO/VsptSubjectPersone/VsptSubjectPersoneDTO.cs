using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vspt.Common.Api.Contract.Flagman.DTO.VsptSubjectPersone
{
    public record VsptSubjectPersoneDTO
    {
        public string ID { get; set; }

        public string? LAST_NAME { get; set; }

        public string? FIRST_NAME { get; set; }

        public string? SECOND_NAME { get; set; }
        public string? PROF_ID { get; set; }
        public string? PROF { get; set; }
        public string? DIV_ID { get; set; }
        public string? DIV_NAME { get; set; }
        public string? BU { get; set; }
        public string? BU_ID { get; set; }
    }
}
