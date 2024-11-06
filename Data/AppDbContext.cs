using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Webpro.Models;

namespace Webpro.Data;
public partial class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("E2425Connection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    public virtual DbSet<TblDispatch> TblDispatches { get; set; }
    public virtual DbSet<Openingbalance> Openingbalances { get; set; }

    public virtual DbSet<TblSite> TblSites { get; set; }
    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BillNgstMonth> BillNgstMonths { get; set; }

    public virtual DbSet<DcJune> DcJunes { get; set; }

    public virtual DbSet<Gsb> Gsbs { get; set; }

    public virtual DbSet<GstDatum> GstData { get; set; }

    public virtual DbSet<Nanaavtade> Nanaavtades { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<NotesQ> NotesQs { get; set; }

    public virtual DbSet<Paidamount> Paidamounts { get; set; }

    public virtual DbSet<Partysummry> Partysummries { get; set; }

    public virtual DbSet<PartywiseGroupingMaterial> PartywiseGroupingMaterials { get; set; }

    public virtual DbSet<QCreditPartylistNongst> QCreditPartylistNongsts { get; set; }

    public virtual DbSet<QMaterialSahyadriFind> QMaterialSahyadriFinds { get; set; }

    public virtual DbSet<QSiteCombo> QSiteCombos { get; set; }

    public virtual DbSet<QVehicalCombo> QVehicalCombos { get; set; }

    public virtual DbSet<Select> Selects { get; set; }

    public virtual DbSet<SelectMaterialPartyAndDateRange> SelectMaterialPartyAndDateRanges { get; set; }

    public virtual DbSet<SiteMirajRailwayDatemmdd> SiteMirajRailwayDatemmdds { get; set; }



    public virtual DbSet<TblRateChartPartywise> TblRateChartPartywises { get; set; }

    public virtual DbSet<TblVehicleNumber> TblVehicleNumbers { get; set; }

    public virtual DbSet<Tblpartynamelist> Tblpartynamelists { get; set; }

    public virtual DbSet<TblpartynamelistQuery> TblpartynamelistQueries { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<WhHorizontal> WhHorizontals { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BillNgstMonth>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BILL_NGST_month");

            entity.Property(e => e.Monthnamex)
                .HasMaxLength(25)
                .HasColumnName("monthnamex");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.SumBill).HasColumnName("sum_bill");
        });

        modelBuilder.Entity<DcJune>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("dc-june");

            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Qty).HasColumnName("qty");
        });

        modelBuilder.Entity<Gsb>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("gsb");

            entity.Property(e => e.Amt).HasColumnName("amt");
            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Qtynew).HasColumnName("qtynew");
            entity.Property(e => e.Ton).HasColumnName("ton");
        });

        modelBuilder.Entity<GstDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("gst data");

            entity.Property(e => e.Amount1).HasColumnName("amount1");
            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Drivername)
                .HasMaxLength(255)
                .HasColumnName("drivername");
            entity.Property(e => e.GstAmount).HasColumnName("GST_amount");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Monthnamex)
                .HasMaxLength(25)
                .HasColumnName("monthnamex");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Payablebillwithdiscount).HasColumnName("payablebillwithdiscount");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.RateApplied).HasColumnName("rate_applied");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(255)
                .HasColumnName("vehicleno");
            entity.Property(e => e.Yearnamex)
                .HasMaxLength(255)
                .HasColumnName("yearnamex");
        });

        modelBuilder.Entity<Nanaavtade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("nanaavtade");

            entity.Property(e => e.Amount1).HasColumnName("amount1");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Monthnamex)
                .HasMaxLength(25)
                .HasColumnName("monthnamex");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("NOTES$PrimaryKey");

            entity.ToTable("NOTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("DATEX");
            entity.Property(e => e.Note1)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
        });

        modelBuilder.Entity<NotesQ>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("NOTES_Q");

            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("DATEX");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("NOTE");
        });

        modelBuilder.Entity<Paidamount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PAIDAMOUNT$PrimaryKey");

            entity.ToTable("PAIDAMOUNT");

            entity.HasIndex(e => e.Id, "PAIDAMOUNT$ID");

            entity.HasIndex(e => e.Paid, "PAIDAMOUNT$PAID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("DATEX");
            entity.Property(e => e.Otherdetail)
                .HasMaxLength(255)
                .HasColumnName("OTHERDETAIL");
            entity.Property(e => e.Paid)
                .HasDefaultValue(0.0)
                .HasColumnName("PAID");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("PARTYNAME");
        });

        modelBuilder.Entity<Partysummry>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("partysummry");

            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Payablebillwithdiscount).HasColumnName("payablebillwithdiscount");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.RateApplied).HasColumnName("rate_applied");
            entity.Property(e => e.RateFromchart).HasColumnName("rate_fromchart");
            entity.Property(e => e.TransportCharge).HasColumnName("transport_charge");
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(255)
                .HasColumnName("vehicleno");
        });

        modelBuilder.Entity<PartywiseGroupingMaterial>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("partywise grouping_material");

            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Monthnamex)
                .HasMaxLength(25)
                .HasColumnName("monthnamex");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
            entity.Property(e => e._5).HasColumnName("$5");
            entity.Property(e => e._6).HasColumnName("$6");
        });

        modelBuilder.Entity<QCreditPartylistNongst>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Q_credit_partylist_nongst");

            entity.Property(e => e.GstCustomer)
                .HasMaxLength(255)
                .HasColumnName("gst_customer");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
        });

        modelBuilder.Entity<QMaterialSahyadriFind>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("q_material_sahyadri_find");

            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Monthnamex)
                .HasMaxLength(25)
                .HasColumnName("monthnamex");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.RateFromchart).HasColumnName("rate_fromchart");
            entity.Property(e => e.Yearnamex)
                .HasMaxLength(255)
                .HasColumnName("yearnamex");
            entity.Property(e => e._6).HasColumnName("$6");
        });

        modelBuilder.Entity<QSiteCombo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Q_site_combo");

            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
        });

        modelBuilder.Entity<QVehicalCombo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Q_vehical_combo");

            entity.Property(e => e.Vehicleno)
                .HasMaxLength(255)
                .HasColumnName("vehicleno");
        });

        modelBuilder.Entity<Select>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("select");

            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Discountpercent).HasColumnName("discountpercent");
            entity.Property(e => e.Payablebillwithdiscount).HasColumnName("payablebillwithdiscount");
        });

        modelBuilder.Entity<SelectMaterialPartyAndDateRange>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("select material party and date range");

            entity.Property(e => e.Bill).HasColumnName("bill");
            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.RateApplied).HasColumnName("rate_applied");
        });

        modelBuilder.Entity<SiteMirajRailwayDatemmdd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SITE MIRAJ RAILWAY DATEMMDD");

            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasColumnName("chalanno");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("DATEX");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasColumnName("material");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
        });

        modelBuilder.Entity<TblDispatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tblDispatch$PrimaryKey");

            entity.ToTable("tblDispatch");

            entity.HasIndex(e => e.Partyname, "tblDispatch$Dispatchentrypartyname");

            entity.HasIndex(e => e.TotalAmountBill, "tblDispatch$amount_paid");

            entity.HasIndex(e => e.Id, "tblDispatch$id");

            entity.HasIndex(e => e.Monthnumber, "tblDispatch$monthnum");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount1)
                .HasComment("amount1 =qty *rate_applied")
                .HasColumnName("amount1");
            entity.Property(e => e.CashPaymentRs)
                .HasDefaultValue(0.0)
                .HasComment("rokh wale")
                .HasColumnName("cash_paymentRS");
            entity.Property(e => e.Chalanno)
                .HasMaxLength(255)
                .HasComment("nvchar 10 null")
                .HasColumnName("chalanno");
            entity.Property(e => e.DataEntryDatetime)
                .HasPrecision(0)
                .HasComment("current date and time now")
                .HasColumnName("DATA_ENTRY_DATETIME");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasComment("date")
                .HasColumnName("datex");
            entity.Property(e => e.Discountpercent)
                .HasDefaultValue(0.0)
                .HasComment("10% on purebill qty *ratechart")
                .HasColumnName("discountpercent");
            entity.Property(e => e.Drivername)
                .HasMaxLength(255)
                .HasComment("populate drivername if vehicleno found in tblvehiclenumbers  nv-15")
                .HasColumnName("drivername");
            entity.Property(e => e.GstAmount)
                .HasDefaultValue(0.0)
                .HasComment("5% gst     cgst sgst included")
                .HasColumnName("GST_amount");
            entity.Property(e => e.Gstcustomer)
                .HasMaxLength(255)
                .HasComment("Yes,No combobox")
                .HasColumnName("gstcustomer");
            entity.Property(e => e.JamaAmt)
                .HasDefaultValue(0.0)
                .HasComment("non gst/gst customer jama amount")
                .HasColumnName("jama_amt");
            entity.Property(e => e.Material)
                .HasMaxLength(255)
                .HasComment("  select material combobox nv25")
                .HasColumnName("material");
            entity.Property(e => e.Monthnamex)
                .HasMaxLength(25)
                .HasComment("month name january to december according to datex nvchar 15 null")
                .HasColumnName("monthnamex");
            entity.Property(e => e.Monthnumber)
                .HasDefaultValue((short)0)
                .HasComment("month of  to 1 to 12 according datex")
                .HasColumnName("monthnumber");
            entity.Property(e => e.OnlinePaymentRs)
                .HasDefaultValue(0.0)
                .HasComment("rokh wale")
                .HasColumnName("online_paymentRS");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasComment("dropdown select partyname from tblpartynamelist nvarchar 25")
                .HasColumnName("partyname");
            entity.Property(e => e.Payablebillwithdiscount)
                .HasDefaultValue(0.0)
                .HasComment("bill after discount")
                .HasColumnName("payablebillwithdiscount");
            entity.Property(e => e.Qty)
                .HasDefaultValue(0.0)
                .HasComment("quantity in bras n5-3")
                .HasColumnName("qty");
            entity.Property(e => e.RateApplied)
                .HasDefaultValue(0.0)
                .HasComment("rate applied = transport_charge + rate_from chart")
                .HasColumnName("rate_applied");
            entity.Property(e => e.RateFromchart)
                .HasDefaultValue(0.0)
                .HasComment("auto rate n7-2")
                .HasColumnName("rate_fromchart");
            entity.Property(e => e.RegOrStock)
                .HasMaxLength(255)
                .HasDefaultValue("Regular")
                .HasComment("nvchar 10 null")
                .HasColumnName("reg_or_stock");
            entity.Property(e => e.Royalty)
                .HasDefaultValue(0.0)
                .HasComment("optional")
                .HasColumnName("royalty");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasComment("site name nvarchar 25")
                .HasColumnName("site");
            entity.Property(e => e.Summary)
                .HasMaxLength(255)
                .HasComment("anything remember details")
                .HasColumnName("summary");
            entity.Property(e => e.Supervisorname)
                .HasMaxLength(255)
                .HasComment("optional nv-25")
                .HasColumnName("supervisorname");
            entity.Property(e => e.Timex)
                .HasMaxLength(255)
                .HasComment("nvchar 10 null")
                .HasColumnName("timex");
            entity.Property(e => e.Ton)
                .HasDefaultValue(0.0)
                .HasComment("optional numeric 10,3")
                .HasColumnName("ton");
            entity.Property(e => e.TotalAmountBill)
                .HasComment("recievedamount  or amount paid by customer")
                .HasColumnName("Total_amount_bill");
            entity.Property(e => e.TransportCharge)
                .HasDefaultValue(0.0)
                .HasComment("if vehicleno n7-2 faund in tblvehiclenumbers then show alert add transport charge")
                .HasColumnName("transport_charge");
            entity.Property(e => e.Trip)
                .HasMaxLength(255)
                .HasComment("nv-3")
                .HasColumnName("trip");
            entity.Property(e => e.Txtpartynamesearched)
                .HasMaxLength(255)
                .HasComment("if faund partyname in tblpartynamelist then show in      nvarchar 25   dropdownlist else show as rokh_general")
                .HasColumnName("txtpartynamesearched");
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(255)
                .HasComment("comboxbox nv-10")
                .HasColumnName("vehicleno");
            entity.Property(e => e.Yearnamex)
                .HasMaxLength(255)
                .HasComment("year 2022 to 2050 according to datex nvarchar 4")
                .HasColumnName("yearnamex");
        });

        modelBuilder.Entity<TblRateChartPartywise>(entity =>
        {
            entity.HasKey(e => e.Indexnum).HasName("tblRateChart_partywise$PrimaryKey");

            entity.ToTable("tblRateChart_partywise");

            entity.HasIndex(e => e.Indexnum, "tblRateChart_partywise$indexnum");

            entity.Property(e => e.Indexnum).HasColumnName("indexnum");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasComment("name or company name")
                .HasColumnName("partyname");
            entity.Property(e => e.Rate10mm)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_10MM");
            entity.Property(e => e.Rate20mm)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_20MM");
            entity.Property(e => e.Rate26mm)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_26MM");
            entity.Property(e => e.Rate40mm)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_40MM");
            entity.Property(e => e.Rate60mm)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_60MM");
            entity.Property(e => e.Rate8by6)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_8BY6");
            entity.Property(e => e.RateDust)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_DUST");
            entity.Property(e => e.RateGsb)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_GSB");
            entity.Property(e => e.RateMsand)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_MSAND");
            entity.Property(e => e.RateRoboSand)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_robo_sand");
            entity.Property(e => e.RateSander)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_sander");
            entity.Property(e => e.RateStone)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_STONE");
            entity.Property(e => e.RateWmm)
                .HasDefaultValue(0.0)
                .HasComment("DEFAULT VALUE")
                .HasColumnName("rate_WMM");
            entity.Property(e => e.RateWpsand)
                .HasDefaultValue(0.0)
                .HasComment("WASHABLE PLASTER SAND    OR PSAND")
                .HasColumnName("rate_WPSAND");
            entity.Property(e => e.RateWsand)
                .HasDefaultValue(0.0)
                .HasComment("WASHABLE SAND")
                .HasColumnName("rate_WSAND");
        });

        modelBuilder.Entity<TblVehicleNumber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tblVehicleNumbers$PrimaryKey");

            entity.ToTable("tblVehicleNumbers");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyVehicleNumber)
                .HasMaxLength(255)
                .HasColumnName("companyVehicleNumber");
            entity.Property(e => e.DriverNameOptional)
                .HasMaxLength(255)
                .HasColumnName("driverNameOptional");
            entity.Property(e => e.WeightCapacity)
                .HasMaxLength(255)
                .HasColumnName("weightCapacity");
        });

        modelBuilder.Entity<Tblpartynamelist>(entity =>
        {
            entity.HasKey(e => e.Partyname).HasName("tblpartynamelist$PrimaryKey");

            entity.ToTable("tblpartynamelist");

            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasComment("name or company name")
                .HasColumnName("partyname");
            entity.Property(e => e.Discount).HasColumnName("DISCOUNT");
            entity.Property(e => e.GstCustomer)
                .HasMaxLength(255)
                .HasComment("Yes No")
                .HasColumnName("gst_customer");
            entity.Property(e => e.Transcharge)
                .HasDefaultValue(0.0)
                .HasColumnName("TRANSCHARGE");
        });

        modelBuilder.Entity<TblpartynamelistQuery>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("tblpartynamelist Query");

            entity.Property(e => e._1).HasColumnName("$1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("user$PrimaryKey");

            entity.ToTable("user");

            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.Namesurname)
                .HasMaxLength(255)
                .HasColumnName("namesurname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vehicle");

            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("datex");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("partyname");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
            entity.Property(e => e.Vehicleno)
                .HasMaxLength(255)
                .HasColumnName("vehicleno");
        });

        //

        modelBuilder.Entity<Openingbalance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("OPENINGBALANCE$PrimaryKey");

            entity.ToTable("OPENINGBALANCE");

            entity.HasIndex(e => e.Id, "OPENINGBALANCE$ID");


            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Datex)
                .HasPrecision(0)
                .HasColumnName("DATEX");
            entity.Property(e => e.Openingbal)
                .HasDefaultValue(0.0)
                .HasColumnName("OPENINGBAL");
            entity.Property(e => e.Partyname)
                .HasMaxLength(255)
                .HasColumnName("PARTYNAME");

        });



        modelBuilder.Entity<TblSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tblSite$PrimaryKey");

            entity.ToTable("tblSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Site)
                .HasMaxLength(255)
                .HasColumnName("site");
        });



        //


        modelBuilder.Entity<WhHorizontal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wh-horizontal");

            entity.Property(e => e._1)
                .HasMaxLength(25)
                .HasColumnName("$1");
            entity.Property(e => e._2)
                .HasMaxLength(255)
                .HasColumnName("$2");
            entity.Property(e => e._3)
                .HasMaxLength(255)
                .HasColumnName("$3");
            entity.Property(e => e._4)
                .HasMaxLength(255)
                .HasColumnName("$4");
            entity.Property(e => e._5)
                .HasMaxLength(255)
                .HasColumnName("$5");
            entity.Property(e => e._6).HasColumnName("$6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
