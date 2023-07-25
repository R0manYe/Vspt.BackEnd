using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity;

public partial class GetAllDislokacia
{
    [Key]
    public  int ID { get; set; }

    public string? NOM_VAG { get; set; }

    public string? RAILWAYS {get; set; }

    public string? NAIM_ROD_VAG { get; set; }

    public int? STAN_NAZN { get; set; }

    public string? NAIM_STAN_NAZN { get; set; }

    public string? GRUZPOL_OKPO { get; set; }

    public string? NAIM_GRUZPOL_OKPO { get; set; }

    public string? NAIM_GRUZOTPR_OKPO { get; set; }

    public string? NAIM_KOD_GRZ { get; set; }
    public int? VES_GRZ { get; set; }
    public DateTime? DATE_OP { get; set; }
    public string? NAIM_STAN_OP { get; set; }
    public string? RASST_STAN_NAZN { get; set; }
    public DateTime? DATE_DOSTAV { get; set; }
    public string? NAIM_KOP_VMD { get; set; }
    public string? NOM_POEZD { get; set; }
    public string? INDEX_POEZD { get; set; }
    public string? NPP_VAG { get; set; }
}
