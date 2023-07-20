using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vspt.Box.Data.EfCore.Entities.Infrastructure;
using Vspt.Service.Common.Infrastructure.Conventions;
using Vspt.Service.Common.MassTransit.Extensions;
using Vspt.Box.EfCore.Infrastructure;

namespace Vspt.BackEnd.Flagman.Infrastructure.Database;

public class FlagmanContext : DbContext
{
    internal const string SchemaName = "VSPTSVOD";
    internal const string HistoryTableName = "__EFMigrationsHistory";

    public FlagmanContext(DbContextOptions<FlagmanContext> options) : base(options)
    {

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.UpdateEntitiesWithAuditData();

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        this.UpdateEntitiesWithAuditData();

        return base.SaveChanges();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SchemaName);

        //  modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.AddTransactionalOutbox();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FlagmanContext).Assembly);

        modelBuilder.ApplyEntityInterfaceConfiguration(new EntityWithAuditDataConfiguration());
    }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new CommentFromSummaryConvention());
    }
}


    ////modelBuilder.HasDefaultSchema("VSPTSVOD");

    ////modelBuilder.Entity<Dislokacia>(entity =>
    ////{

    ////    entity.HasKey(e => e.ID)

    ////    .HasName("DISLOKACIA_PK");

    ////    entity.ToTable("DISLOKACIA");

    ////    entity.HasIndex(e => e.NOM_VAG, "DISLOKACIA_INDEX1").IsUnique();
    ////});


    //entity.HasIndex(e => e.GruzpolOkpo, "DISLOKACIA_INDEX2");

    //entity.HasIndex(e => e.Gruzpol, "DISLOKACIA_INDEX_GRUZOPOL");

    //entity.HasIndex(e => e.RodVagUch, "DISLOKACIA_INDEX_ROD_VAGONA");

    //entity.HasIndex(e => e.StanNach, "DISLOKACIA_INDEX_STAN_NAZN");

    //entity.Property(e => e.ID)

    //    .HasColumnType("UINT")
    //    .HasColumnName("ID")
    //    .HasConversion<uint>();

    //entity.Property(e => e.DateDostav)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_DOSTAV");
    //entity.Property(e => e.DateIns)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_INS");
    //entity.Property(e => e.DateKon)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_KON");
    //entity.Property(e => e.DateNach)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_NACH");
    //entity.Property(e => e.DateOp)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_OP");
    //entity.Property(e => e.DateOtpr)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_OTPR");
    //entity.Property(e => e.DatePrib)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_PRIB");
    //entity.Property(e => e.DateZap)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DATE_ZAP");
    //entity.Property(e => e.DorNach)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("DOR_NACH");
    //entity.Property(e => e.DorNazn)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("DOR_NAZN");
    //entity.Property(e => e.DorPriemGos)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("DOR_PRIEM_GOS");
    //entity.Property(e => e.DorRasch)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("DOR_RASCH");
    //entity.Property(e => e.DorSdachGos)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("DOR_SDACH_GOS");
    //entity.Property(e => e.DvsT)
    //    .HasColumnType("DATE")
    //    .HasColumnName("DVS_T");
    //entity.Property(e => e.Gruzotpr)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("GRUZOTPR");
    //entity.Property(e => e.GruzotprOkpo)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("GRUZOTPR_OKPO");
    //entity.Property(e => e.Gruzpol)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("GRUZPOL");
    //entity.Property(e => e.GruzpolOkpo)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("GRUZPOL_OKPO");
    //entity.Property(e => e.IdGruzotpr)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("ID_GRUZOTPR");
    //entity.Property(e => e.IdGruzpol)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("ID_GRUZPOL");
    //entity.Property(e => e.IdOtprk)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("ID_OTPRK");
    //entity.Property(e => e.IdOtprkDosyl)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("ID_OTPRK_DOSYL");
    //entity.Property(e => e.IndexPoezd)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("INDEX_POEZD");
    //entity.Property(e => e.KdsT)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("KDS_T");
    //entity.Property(e => e.KodGrzGng)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("KOD_GRZ_GNG");
    //entity.Property(e => e.KodGrzUch)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("KOD_GRZ_UCH");
    //entity.Property(e => e.KodGrzVygr)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("KOD_GRZ_VYGR");
    //entity.Property(e => e.KodPlOtpr)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("KOD_PL_OTPR");
    //entity.Property(e => e.KodSob)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("KOD_SOB");
    //entity.Property(e => e.KolGrjKont)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("KOL_GRJ_KONT");
    //entity.Property(e => e.KolPorKont)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("KOL_POR_KONT");
    //entity.Property(e => e.KolZpu)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("KOL_ZPU");
    //entity.Property(e => e.KopPmd)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("KOP_PMD");
    //entity.Property(e => e.KopVmd)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("KOP_VMD");
    //entity.Property(e => e.NaimGruzotprOkpo)
    //    .HasMaxLength(500)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_GRUZOTPR_OKPO");
    //entity.Property(e => e.NaimGruzpolOkpo)
    //    .HasMaxLength(500)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_GRUZPOL_OKPO");
    //entity.Property(e => e.NaimKodGrz)
    //    .HasMaxLength(300)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_KOD_GRZ");
    //entity.Property(e => e.NaimKopVmd)
    //    .HasMaxLength(100)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_KOP_VMD");
    //entity.Property(e => e.NaimRodVag)
    //    .HasMaxLength(48)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_ROD_VAG");
    //entity.Property(e => e.NaimStanNazn)
    //    .HasMaxLength(48)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_STAN_NAZN");
    //entity.Property(e => e.NaimStanOp)
    //    .HasMaxLength(100)
    //    .IsUnicode(false)
    //    .HasColumnName("NAIM_STAN_OP");
    //entity.Property(e => e.NomKon1)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON1");
    //entity.Property(e => e.NomKon10)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON10");
    //entity.Property(e => e.NomKon11)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON11");
    //entity.Property(e => e.NomKon12)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON12");
    //entity.Property(e => e.NomKon13)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON13");
    //entity.Property(e => e.NomKon2)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON2");
    //entity.Property(e => e.NomKon3)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON3");
    //entity.Property(e => e.NomKon4)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON4");
    //entity.Property(e => e.NomKon5)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON5");
    //entity.Property(e => e.NomKon6)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON6");
    //entity.Property(e => e.NomKon7)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON7");
    //entity.Property(e => e.NomKon8)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON8");
    //entity.Property(e => e.NomKon9)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_KON9");
    //entity.Property(e => e.NomNak)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_NAK");
    //entity.Property(e => e.NomOtprk1)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_1");
    //entity.Property(e => e.NomOtprk10)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_10");
    //entity.Property(e => e.NomOtprk11)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_11");
    //entity.Property(e => e.NomOtprk12)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_12");
    //entity.Property(e => e.NomOtprk13)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_13");
    //entity.Property(e => e.NomOtprk2)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_2");
    //entity.Property(e => e.NomOtprk3)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_3");
    //entity.Property(e => e.NomOtprk4)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_4");
    //entity.Property(e => e.NomOtprk5)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_5");
    //entity.Property(e => e.NomOtprk6)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_6");
    //entity.Property(e => e.NomOtprk7)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_7");
    //entity.Property(e => e.NomOtprk8)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_8");
    //entity.Property(e => e.NomOtprk9)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_OTPRK_9");
    //entity.Property(e => e.NomPark)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("NOM_PARK");
    //entity.Property(e => e.NomPoezd)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("NOM_POEZD");
    //entity.Property(e => e.NomPut)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("NOM_PUT");
    ////entity.Property(e => e.NOM_VAG)
    ////    .HasMaxLength(8)
    ////    .IsUnicode(false)
    ////    .HasColumnName("NOM_VAG");
    //entity.Property(e => e.NormaKm)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("NORMA_KM");
    //entity.Property(e => e.NppVag)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("NPP_VAG");
    //entity.Property(e => e.OsOtm1)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("OS_OTM1");
    //entity.Property(e => e.OsOtm2)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("OS_OTM2");
    //entity.Property(e => e.OsOtm3)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("OS_OTM3");
    //entity.Property(e => e.Ostatok)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("OSTATOK");
    //entity.Property(e => e.OtmGodVag)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("OTM_GOD_VAG");
    //entity.Property(e => e.PorogProb)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("POROG_PROB");
    //entity.Property(e => e.PpvGruj)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PPV_GRUJ");
    //entity.Property(e => e.PpvMest)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PPV_MEST");
    //entity.Property(e => e.PpvNrp)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PPV_NRP");
    //entity.Property(e => e.PpvPor)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PPV_POR");
    //entity.Property(e => e.PpvRp)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PPV_RP");
    //entity.Property(e => e.PpvTranz)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PPV_TRANZ");
    //entity.Property(e => e.PrOstGrz)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PR_OST_GRZ");
    //entity.Property(e => e.PrOtm)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PR_OTM");
    //entity.Property(e => e.PrStr)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("PR_STR");
    //entity.Property(e => e.ProbGrj)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("PROB_GRJ");
    //entity.Property(e => e.ProbPor)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("PROB_POR");
    //entity.Property(e => e.ProstDn)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("PROST_DN");
    //entity.Property(e => e.ProstMin)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("PROST_MIN");
    //entity.Property(e => e.ProstСн)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("PROST_СН");
    //entity.Property(e => e.RasstOb)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("RASST_OB");
    //entity.Property(e => e.RasstStanNazn)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("RASST_STAN_NAZN");
    //entity.Property(e => e.RasstStanOp)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("RASST_STAN_OP");
    //entity.Property(e => e.RodVagUch)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("ROD_VAG_UCH");
    //entity.Property(e => e.StanNach)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("STAN_NACH");
    //entity.Property(e => e.StanNazn)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("STAN_NAZN");
    //entity.Property(e => e.StanOp)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("STAN_OP");
    //entity.Property(e => e.StrNach)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("STR_NACH");
    //entity.Property(e => e.StrNazn)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("STR_NAZN");
    //entity.Property(e => e.Tarif)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("TARIF");
    //entity.Property(e => e.Uno)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("UNO");
    //entity.Property(e => e.UnoDosyl)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("UNO_DOSYL");
    //entity.Property(e => e.VesGrz)
    //    .HasColumnType("NUMBER")
    //    .HasColumnName("VES_GRZ");
    //entity.Property(e => e.VnrpNeisp)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("VNRP_NEISP");
    //entity.Property(e => e.VnrpSpecTex)
    //    .HasMaxLength(20)
    //    .IsUnicode(false)
    //    .HasColumnName("VNRP_SPEC_TEX");
    ////});
    ////modelBuilder.HasSequence("ASU_PROXY_LOG_SEQ");
    ////modelBuilder.HasSequence("DISLOKACIA_SEQ");
    ////modelBuilder.HasSequence("DISLOKACIA_SEQ1");
    ////modelBuilder.HasSequence("DISLOKACIA_SEQ2");
    ////modelBuilder.HasSequence("ETRAN_GU2G_DOC_SEQ");
    ////modelBuilder.HasSequence("ETRAN_GU2G_ITEM_SEQ");
    ////modelBuilder.HasSequence("ETRAN_GU2V_DOC_SEQ");
    ////modelBuilder.HasSequence("ETRAN_GU2V_ITEM_SEQ");
    ////modelBuilder.HasSequence("ETRAN_GU2V_ITEM_SEQ1");
    ////modelBuilder.HasSequence("ETRAN_GU2V_ITEM_SEQ2");
    ////modelBuilder.HasSequence("ROWVERSION_POOL");
    ////modelBuilder.HasSequence("SPR_EL_SOST_SEQ");
    ////modelBuilder.HasSequence("SPR_OTRAS_SEQ");
    ////modelBuilder.HasSequence("SPR_PHONE_DOP");
    ////modelBuilder.HasSequence("SPR_PRICH_SEQ");
    ////modelBuilder.HasSequence("SPR_SERIA_SEQ");
    ////modelBuilder.HasSequence("SPR_SOSTAV_SEQ");
    ////modelBuilder.HasSequence("SPR_VID_SEQ");
    ////modelBuilder.HasSequence("SQ_AN");
    ////modelBuilder.HasSequence("SQ_DIS");
    ////modelBuilder.HasSequence("SQ_DIS_HIS");
    ////modelBuilder.HasSequence("SQ_EO");
    ////modelBuilder.HasSequence("SQ_GU2V");
    ////modelBuilder.HasSequence("SQ_HISTORY");
    ////modelBuilder.HasSequence("SQ_IVC");
    ////modelBuilder.HasSequence("SQ_KO");
    ////modelBuilder.HasSequence("SQ_KOD_OSM");
    ////modelBuilder.HasSequence("SQ_OT");
    ////modelBuilder.HasSequence("SQ_OT_AKT");
    ////modelBuilder.HasSequence("SQ_OT_AKT2");
    ////modelBuilder.HasSequence("SQ_OT2");
    ////modelBuilder.HasSequence("SQ_PF");
    ////modelBuilder.HasSequence("SQ_PHONE_SPR");
    ////modelBuilder.HasSequence("SQ_PHONE_SPR_DOP");
    ////modelBuilder.HasSequence("SQ_PR");
    ////modelBuilder.HasSequence("SQ_PS");
    ////modelBuilder.HasSequence("SQ_RD");
    ////modelBuilder.HasSequence("SQ_REM");
    ////modelBuilder.HasSequence("SQ_SERIA");
    ////modelBuilder.HasSequence("SQ_SL");
    ////modelBuilder.HasSequence("SQ_SOST");
    ////modelBuilder.HasSequence("SQ_SPR");
    ////modelBuilder.HasSequence("SQ_SV");
    ////modelBuilder.HasSequence("SQ_TIP").IncrementsBy(45);
    ////modelBuilder.HasSequence("TEMP_DISLOKACIA_SEQ");

    //OnModelCreatingPartial(modelBuilder);
