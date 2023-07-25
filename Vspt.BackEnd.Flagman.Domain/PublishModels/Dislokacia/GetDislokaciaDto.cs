using Vspt.BackEnd.Flagman.Domain.Entity;

namespace Vspt.BackEnd.Flagman.Domain.PublishModels.Dislokacia;

public sealed record GetDislokaciaDto
{
    public required string NOM_VAG { get; init; }
    //   public required string NAIM_RAILWAYS {get; init; }


    public required string? NAIM_ROD_VAG { get; init; }
    public required int STAN_NAZN { get; init; }
    public required string NAIM_STAN_NAZN { get; init; }
    public required string? GRUZPOL_OKPO { get; init; }
    //public required string? NAIM_GRUZPOL_OKPO { get; init; }
    //public required string? NAIM_GRUZOTPR_OKPO { get; init; }
    public required string? NAIM_KOD_GRZ { get; init; }
    public required int? VES_GRZ { get; init; }
    public required DateTime? DATE_OP { get; init; }
    public required string NAIM_STAN_OP { get; init; }
    public required string RASST_STAN_NAZN { get; init; }
    public required DateTime? DATE_DOSTAV { get; init; }
    public required string? NAIM_KOP_VMD { get; init; }
    public required string? NOM_POEZD { get; init; }
    public required string? INDEX_POEZD { get; init; }
    public required string NPP_VAG { get; init; }
}