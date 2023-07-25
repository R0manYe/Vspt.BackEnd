using Vspt.BackEnd.Flagman.

namespace Vspt.BackEnd.Flagman.PublishModels.Dislokacia;

public sealed record GetDislokaciaDto
{
    public required string NOM_VAG { get; init; }
    public Spr_etran_railways Spr_Etran_Railways { get; init; }
    public string NAIM_ROD_VAG { get; init; }
    public int STAN_NAZN { get; init; }
    public string NAIM_STAN_NAZN { get; init; }
    public string GRUZPOL_OKPO { get; init; }
    public string NAIM_GRUZPOL_OKPO { get; init; }
    public string NAIM_GRUZOTPR_OKPO { get; init; }
    public string NAIM_KOD_GRZ { get; init; }
    public int VES_GRZ { get; init; }
    public DateTime DATE_OP { get; init; }
    public string NAIM_STAN_OP { get; init; }
    public string RASST_STAN_NAZN { get; init; }
    public DateTime DATE_DOSTAV { get; init; }
    public string NAIM_KOP_VMD { get; init; }
    public string NOM_POEZD { get; init; }
    public string INDEX_POEZD { get; init; }
    public string NPP_VAG { get; init; }
}
