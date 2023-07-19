using System.ComponentModel.DataAnnotations;

namespace Vspt.BackEnd.Flagman.Domain.Entity;

public partial class Dislokacia
{
    [Key]
    public uint ID { get; set; }

    public string? NOM_VAG { get; set; }

  //  public sbyte? ROD_VAG_UCH { get; set; }

    // public decimal? KOD_SOB { get; set; }

    public DateTime? DATE_NACH { get; set; }

    public decimal? STAN_NACH { get; set; }

    //public decimal? DorNach { get; set; }

    //public decimal? StrNach { get; set; }

    //public DateTime? DateKon { get; set; }

    public decimal? STAN_NAZN { get; set; }

    //public decimal? DorNazn { get; set; }

    //public string? StrNazn { get; set; }

    //public decimal? Gruzpol { get; set; }

    //public decimal? NomPark { get; set; }

    //public decimal? NomPut { get; set; }

    //public decimal? KolZpu { get; set; }

    //public decimal? KolGrjKont { get; set; }

    //public decimal? KolPorKont { get; set; }

    //public string? NomKon1 { get; set; }

    //public string? NomKon2 { get; set; }

    //public string? NomKon3 { get; set; }

    //public string? NomKon4 { get; set; }

    //public string? NomKon5 { get; set; }

    //public string? NomKon6 { get; set; }

    //public string? NomKon7 { get; set; }

    //public string? NomKon8 { get; set; }

    //public string? NomKon9 { get; set; }

    //public string? NomKon10 { get; set; }

    //public string? NomKon11 { get; set; }

    //public string? NomKon12 { get; set; }

    //public string? NomKon13 { get; set; }

    //public string? IdOtprk { get; set; }

    //public string? NomNak { get; set; }

    //public string? Uno { get; set; }

    //public string? NomOtprk1 { get; set; }

    //public string? NomOtprk2 { get; set; }

    //public string? NomOtprk3 { get; set; }

    //public string? NomOtprk4 { get; set; }

    //public string? NomOtprk5 { get; set; }

    //public string? NomOtprk6 { get; set; }

    //public string? NomOtprk7 { get; set; }

    //public string? NomOtprk8 { get; set; }

    //public string? NomOtprk9 { get; set; }

    //public string? NomOtprk10 { get; set; }

    //public string? NomOtprk11 { get; set; }

    //public string? NomOtprk12 { get; set; }

    //public string? NomOtprk13 { get; set; }

    //public string? IdOtprkDosyl { get; set; }

    //public string? UnoDosyl { get; set; }

    //public DateTime? DateDostav { get; set; }

    //public string? RasstOb { get; set; }

    //public string? RasstStanOp { get; set; }

    //public string? RasstStanNazn { get; set; }

    //public decimal? ProstDn { get; set; }

    //public decimal? ProstСн { get; set; }

    //public decimal? ProstMin { get; set; }

    //public decimal? NormaKm { get; set; }

    //public decimal? Ostatok { get; set; }

    //public decimal? KodGrzVygr { get; set; }

    //public string? PrOstGrz { get; set; }

    //public DateTime? DateOtpr { get; set; }

    public DateTime? DATE_PRIB { get; set; }

    //public string? KodPlOtpr { get; set; }

    //public string? Tarif { get; set; }

    //public string? OtmGodVag { get; set; }

    //public string? PorogProb { get; set; }

    //public string? PrOtm { get; set; }

    //public string? PrStr { get; set; }

    //public DateTime? DateZap { get; set; }

    //public string? KodGrzUch { get; set; }

    //public string? KdsT { get; set; }

    //public DateTime? DvsT { get; set; }

    //public string? IdGruzpol { get; set; }

    //public string? IdGruzotpr { get; set; }

    //public string? GruzpolOkpo { get; set; }

    //public string? Gruzotpr { get; set; }

    //public string? GruzotprOkpo { get; set; }

    //public decimal? KodGrzGng { get; set; }

    //public decimal? ProbGrj { get; set; }

    //public decimal? ProbPor { get; set; }

    //public string? OsOtm1 { get; set; }

    //public string? OsOtm2 { get; set; }

    //public string? OsOtm3 { get; set; }

    public decimal? VES_GRZ { get; set; }

    public DateTime? DATE_OP { get; set; }

    //public string? DorRasch { get; set; }

    //public decimal? StanOp { get; set; }

    //public string? KopVmd { get; set; }

    //public string? KopPmd { get; set; }

    //public string? PpvMest { get; set; }

    //public string? PpvTranz { get; set; }

    //public string? PpvPor { get; set; }

    //public string? PpvGruj { get; set; }

    //public string? PpvNrp { get; set; }

    //public string? PpvRp { get; set; }

    //public string? VnrpNeisp { get; set; }

    //public string? VnrpSpecTex { get; set; }

    //public decimal? DorSdachGos { get; set; }

    //public decimal? DorPriemGos { get; set; }

    public string? INDEX_POEZD { get; set; }

    public string? NOM_POEZD { get; set; }

    public decimal? NPP_VAG { get; set; }

    //public DateTime? DateIns { get; set; }

    public string? NAIM_ROD_VAG { get; set; }

    public string? NAIM_STAN_NAZN { get; set; }

    public string? NAIM_GRUZPOL_OKPO { get; set; }

    public string? NAIM_KOD_GRZ { get; set; }

    public string? NAIM_STAN_OP { get; set; }

    public string? NAIM_KOP_VMD { get; set; }

    public string? NAIM_GRUZOTPR_OKPO { get; set; }
}
