using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity
{
    public partial class SPR_ETRAN_RAILWAYS
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }      

    }
}
