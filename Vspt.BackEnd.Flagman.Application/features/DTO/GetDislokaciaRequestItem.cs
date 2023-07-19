namespace Vspt.BackEnd.Flagman.Application.features.DTO
{
    public record GetDislokaciaRequestItem
    {

        public uint ID { get; set; }

        public string? NOM_VAG { get; set; }

        public DateTime? DATE_NACH { get; set; }

        public decimal? STAN_NACH { get; set; }

        public decimal? STAN_NAZN { get; set; }
        public DateTime? DATE_PRIB { get; set; }
        public decimal? VES_GRZ { get; set; }

        public DateTime? DATE_OP { get; set; }
        public string? INDEX_POEZD { get; set; }

        public string? NOM_POEZD { get; set; }

        public decimal? NPP_VAG { get; set; }


        public string? NAIM_ROD_VAG { get; set; }

        public string? NAIM_STAN_NAZN { get; set; }

        public string? NAIM_GRUZPOL_OKPO { get; set; }

        public string? NAIM_KOD_GRZ { get; set; }

        public string? NAIM_STAN_OP { get; set; }

        public string? NAIM_KOP_VMD { get; set; }

        public string? NAIM_GRUZOTPR_OKPO { get; set; }




    }
    public record GetDislokaciaRequestItemDto
    {
        public required GetDislokaciaRequestItem Item { get; init; }
    }

}
