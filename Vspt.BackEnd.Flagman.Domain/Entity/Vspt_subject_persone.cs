using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity
{
    public partial class Vspt_subject_persone
    {
        [Key]
        public string ID { get; set; }

        public string? LAST_NAME { get; set; }

        public string? FIRST_NAME { get; set; }

        public string? SECOND_NAME { get; set; }
        public string? PROF_ID { get; set; }
        public string? PROF { get; set; }
        public string? DIV_ID { get; set; }
        public string? DIV_NAME  { get; set; }
        public string? BU  { get; set; }
        public string? BU_ID  { get; set; }


    }
}