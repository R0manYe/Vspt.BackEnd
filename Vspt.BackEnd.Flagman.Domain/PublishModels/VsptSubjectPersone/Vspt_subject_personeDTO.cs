using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity
{
    public partial class Vspt_subject_personeFIODTO
    {
        [Key]
        public string ID { get; set; }
       
        public string? FIO { get; set; }
    }
}