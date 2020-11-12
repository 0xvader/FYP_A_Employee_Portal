using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeePortal.Models
{
    public partial class bcckContext : DbContext
    {
        public bcckContext()
        {
        }

        public bcckContext(DbContextOptions<bcckContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<Pmast> Pmast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-89DDNJAT;Database=bcck;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => e.Nricno)
                    .HasName("PK_family_1");

                entity.ToTable("family");

                entity.Property(e => e.Nricno)
                    .HasColumnName("NRICNO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Datebirth)
                    .HasColumnName("DATEBIRTH")
                    .HasColumnType("date");

                entity.Property(e => e.Empno)
                    .IsRequired()
                    .HasColumnName("EMPNO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Memname)
                    .IsRequired()
                    .HasColumnName("MEMNAME")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("SEX")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpnoNavigation)
                    .WithMany(p => p.Family)
                    .HasForeignKey(d => d.Empno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_family_pmast");
            });

            modelBuilder.Entity<Pmast>(entity =>
            {
                entity.HasKey(e => e.Empno);

                entity.ToTable("pmast");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Add1)
                    .IsRequired()
                    .HasColumnName("ADD1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Add2)
                    .IsRequired()
                    .HasColumnName("ADD2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Addrtype)
                    .IsRequired()
                    .HasColumnName("ADDRTYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Aladj)
                    .HasColumnName("ALADJ")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Alall)
                    .HasColumnName("ALALL")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Albal)
                    .HasColumnName("ALBAL")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Albf)
                    .HasColumnName("ALBF")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Alcla)
                    .HasColumnName("ALCLA")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Almctbl)
                    .IsRequired()
                    .HasColumnName("ALMCTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.BPutra)
                    .IsRequired()
                    .HasColumnName("B_PUTRA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Badgeno)
                    .IsRequired()
                    .HasColumnName("BADGENO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Bankaccno)
                    .IsRequired()
                    .HasColumnName("BANKACCNO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Bankcat)
                    .IsRequired()
                    .HasColumnName("BANKCAT")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Bankcode)
                    .IsRequired()
                    .HasColumnName("BANKCODE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Bankic)
                    .IsRequired()
                    .HasColumnName("BANKIC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Bankpmode)
                    .IsRequired()
                    .HasColumnName("BANKPMODE")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Bonus)
                    .HasColumnName("BONUS")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Bonusfrny)
                    .HasColumnName("BONUSFRNY")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Bonustoly)
                    .HasColumnName("BONUSTOLY")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Brancode)
                    .IsRequired()
                    .HasColumnName("BRANCODE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Brate)
                    .HasColumnName("BRATE")
                    .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.BrateLm)
                    .HasColumnName("BRATE_LM")
                    .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.Brcode)
                    .IsRequired()
                    .HasColumnName("BRCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Comm)
                    .HasColumnName("COMM")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Confid)
                    .IsRequired()
                    .HasColumnName("CONFID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Contract)
                    .IsRequired()
                    .HasColumnName("CONTRACT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ContractF)
                    .HasColumnName("CONTRACT_F")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContractT)
                    .HasColumnName("CONTRACT_T")
                    .HasColumnType("datetime");

                entity.Property(e => e.Countryc)
                    .IsRequired()
                    .HasColumnName("COUNTRYC")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Cp8dgrp)
                    .IsRequired()
                    .HasColumnName("CP8DGRP")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Cp8dgrpi)
                    .IsRequired()
                    .HasColumnName("CP8DGRPI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CpfCeili).HasColumnName("CPF_CEILI");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cschmcode)
                    .IsRequired()
                    .HasColumnName("CSCHMCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Dateenter)
                    .HasColumnName("DATEENTER")
                    .HasColumnType("datetime");

                entity.Property(e => e.Daypmth)
                    .HasColumnName("DAYPMTH")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Dbaw101)
                    .HasColumnName("DBAW101")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw102)
                    .HasColumnName("DBAW102")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw103)
                    .HasColumnName("DBAW103")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw104)
                    .HasColumnName("DBAW104")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw105)
                    .HasColumnName("DBAW105")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw106)
                    .HasColumnName("DBAW106")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw107)
                    .HasColumnName("DBAW107")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw108)
                    .HasColumnName("DBAW108")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw109)
                    .HasColumnName("DBAW109")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw110)
                    .HasColumnName("DBAW110")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw111)
                    .HasColumnName("DBAW111")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw112)
                    .HasColumnName("DBAW112")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw113)
                    .HasColumnName("DBAW113")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw114)
                    .HasColumnName("DBAW114")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw115)
                    .HasColumnName("DBAW115")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw116)
                    .HasColumnName("DBAW116")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbaw117)
                    .HasColumnName("DBAW117")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Dbded101)
                    .HasColumnName("DBDED101")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded102)
                    .HasColumnName("DBDED102")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded103)
                    .HasColumnName("DBDED103")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded104)
                    .HasColumnName("DBDED104")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded105)
                    .HasColumnName("DBDED105")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded106)
                    .HasColumnName("DBDED106")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded107)
                    .HasColumnName("DBDED107")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded108)
                    .HasColumnName("DBDED108")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded109)
                    .HasColumnName("DBDED109")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded110)
                    .HasColumnName("DBDED110")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded111)
                    .HasColumnName("DBDED111")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded112)
                    .HasColumnName("DBDED112")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded113)
                    .HasColumnName("DBDED113")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded114)
                    .HasColumnName("DBDED114")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbded115)
                    .HasColumnName("DBDED115")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dbirth)
                    .HasColumnName("DBIRTH")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dcomm)
                    .HasColumnName("DCOMM")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dconfirm)
                    .HasColumnName("DCONFIRM")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dedmem111)
                    .IsRequired()
                    .HasColumnName("DEDMEM111")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dedmem112)
                    .IsRequired()
                    .HasColumnName("DEDMEM112")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dedmem113)
                    .IsRequired()
                    .HasColumnName("DEDMEM113")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dedmem114)
                    .IsRequired()
                    .HasColumnName("DEDMEM114")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dedmem115)
                    .IsRequired()
                    .HasColumnName("DEDMEM115")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Deptcode)
                    .IsRequired()
                    .HasColumnName("DEPTCODE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dfundall)
                    .HasColumnName("DFUNDALL")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dirfset)
                    .IsRequired()
                    .HasColumnName("DIRFSET")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dpassport)
                    .HasColumnName("DPASSPORT")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dpromote)
                    .HasColumnName("DPROMOTE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dresign)
                    .HasColumnName("DRESIGN")
                    .HasColumnType("datetime");

                entity.Property(e => e.Du).HasColumnName("DU");

                entity.Property(e => e.EaGrpSn)
                    .IsRequired()
                    .HasColumnName("EA_GRP_SN")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.EaSn)
                    .IsRequired()
                    .HasColumnName("EA_SN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Eadd1)
                    .IsRequired()
                    .HasColumnName("EADD1")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Eadd2)
                    .IsRequired()
                    .HasColumnName("EADD2")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Eadd3)
                    .IsRequired()
                    .HasColumnName("EADD3")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Econtact)
                    .IsRequired()
                    .HasColumnName("ECONTACT")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Edu)
                    .IsRequired()
                    .HasColumnName("EDU")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Emerphone)
                    .IsRequired()
                    .HasColumnName("EMERPHONE")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Emerrship)
                    .IsRequired()
                    .HasColumnName("EMERRSHIP")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasColumnName("EMP_CODE")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.EmpStatus)
                    .IsRequired()
                    .HasColumnName("EMP_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EmpType)
                    .IsRequired()
                    .HasColumnName("EMP_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Emppass)
                    .IsRequired()
                    .HasColumnName("EMPPASS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Epf1hd)
                    .IsRequired()
                    .HasColumnName("EPF1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EpfFyee)
                    .IsRequired()
                    .HasColumnName("EPF_FYEE")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.EpfFyer)
                    .IsRequired()
                    .HasColumnName("EPF_FYER")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Epfbrinsbp)
                    .IsRequired()
                    .HasColumnName("EPFBRINSBP")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epfbyer)
                    .IsRequired()
                    .HasColumnName("EPFBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epfcat)
                    .IsRequired()
                    .HasColumnName("EPFCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epfic)
                    .IsRequired()
                    .HasColumnName("EPFIC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epfnk)
                    .IsRequired()
                    .HasColumnName("EPFNK")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epfno)
                    .IsRequired()
                    .HasColumnName("EPFNO")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Epftbl)
                    .IsRequired()
                    .HasColumnName("EPFTBL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Epg1hd)
                    .IsRequired()
                    .HasColumnName("EPG1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epgbyer)
                    .IsRequired()
                    .HasColumnName("EPGBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epgcat)
                    .IsRequired()
                    .HasColumnName("EPGCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Epgno)
                    .IsRequired()
                    .HasColumnName("EPGNO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Epgtbl)
                    .IsRequired()
                    .HasColumnName("EPGTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Etelno)
                    .IsRequired()
                    .HasColumnName("ETELNO")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Exp)
                    .IsRequired()
                    .HasColumnName("EXP")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Extra)
                    .HasColumnName("EXTRA")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Finno)
                    .IsRequired()
                    .HasColumnName("FINNO")
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Fwlevyadj)
                    .HasColumnName("FWLEVYADJ")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Fwlevymtd)
                    .IsRequired()
                    .HasColumnName("FWLEVYMTD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Fwlevytbl)
                    .IsRequired()
                    .HasColumnName("FWLEVYTBL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.HrpBrate)
                    .HasColumnName("HRP_BRATE")
                    .HasColumnType("numeric(13, 4)");

                entity.Property(e => e.HrpLm)
                    .HasColumnName("HRP_LM")
                    .HasColumnType("numeric(13, 4)");

                entity.Property(e => e.HrpTm)
                    .HasColumnName("HRP_TM")
                    .HasColumnType("numeric(13, 4)");

                entity.Property(e => e.Iccolor)
                    .IsRequired()
                    .HasColumnName("ICCOLOR")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Icinssocno)
                    .IsRequired()
                    .HasColumnName("ICINSSOCNO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Imigrano)
                    .IsRequired()
                    .HasColumnName("IMIGRANO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Iname)
                    .IsRequired()
                    .HasColumnName("INAME")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IncAmt)
                    .HasColumnName("INC_AMT")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.IncDate)
                    .HasColumnName("INC_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iskerja)
                    .IsRequired()
                    .HasColumnName("ISKERJA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Itaxbran)
                    .IsRequired()
                    .HasColumnName("ITAXBRAN")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Itaxcat)
                    .IsRequired()
                    .HasColumnName("ITAXCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Itaxno)
                    .IsRequired()
                    .HasColumnName("ITAXNO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Itaxnoki)
                    .IsRequired()
                    .HasColumnName("ITAXNOKI")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Itaxtbl)
                    .IsRequired()
                    .HasColumnName("ITAXTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Jfunction)
                    .IsRequired()
                    .HasColumnName("JFUNCTION")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Jobcode)
                    .IsRequired()
                    .HasColumnName("JOBCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Jstacode)
                    .IsRequired()
                    .HasColumnName("JSTACODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Jtitle)
                    .IsRequired()
                    .HasColumnName("JTITLE")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Keyuser)
                    .IsRequired()
                    .HasColumnName("KEYUSER")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Lschmcode)
                    .IsRequired()
                    .HasColumnName("LSCHMCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Lvetocash)
                    .HasColumnName("LVETOCASH")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.LyDEpf)
                    .HasColumnName("LY_D_EPF")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.LyDTxamt)
                    .HasColumnName("LY_D_TXAMT")
                    .HasColumnType("numeric(15, 2)");

                entity.Property(e => e.MIncAmt)
                    .HasColumnName("M_INC_AMT")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.MIncDate)
                    .HasColumnName("M_INC_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mcall)
                    .HasColumnName("MCALL")
                    .HasColumnType("numeric(9, 2)");

                entity.Property(e => e.Mcbal)
                    .HasColumnName("MCBAL")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Meditbl)
                    .IsRequired()
                    .HasColumnName("MEDITBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Meps)
                    .IsRequired()
                    .HasColumnName("MEPS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mfundall)
                    .HasColumnName("MFUNDALL")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Mstatus)
                    .IsRequired()
                    .HasColumnName("MSTATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Mstatusod)
                    .IsRequired()
                    .HasColumnName("MSTATUSOD")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MustprSoc)
                    .IsRequired()
                    .HasColumnName("MUSTPR_SOC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.National)
                    .IsRequired()
                    .HasColumnName("NATIONAL")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NmPcb).HasColumnName("NM_PCB");

                entity.Property(e => e.Noadvday)
                    .HasColumnName("NOADVDAY")
                    .HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Nochild).HasColumnName("NOCHILD");

                entity.Property(e => e.Nppm).HasColumnName("NPPM");

                entity.Property(e => e.Nric)
                    .IsRequired()
                    .HasColumnName("NRIC")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nricn)
                    .IsRequired()
                    .HasColumnName("NRICN")
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.Property(e => e.NumChild)
                    .HasColumnName("NUM_CHILD")
                    .HasColumnType("numeric(4, 1)");

                entity.Property(e => e.Numchild1).HasColumnName("NUMCHILD");

                entity.Property(e => e.OrpLm)
                    .HasColumnName("ORP_LM")
                    .HasColumnType("numeric(13, 4)");

                entity.Property(e => e.OrpTm)
                    .HasColumnName("ORP_TM")
                    .HasColumnType("numeric(13, 4)");

                entity.Property(e => e.OtMaxpay)
                    .IsRequired()
                    .HasColumnName("OT_MAXPAY")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Otcode)
                    .IsRequired()
                    .HasColumnName("OTCODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Otraterc)
                    .IsRequired()
                    .HasColumnName("OTRATERC")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Ottbl)
                    .IsRequired()
                    .HasColumnName("OTTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Passport)
                    .IsRequired()
                    .HasColumnName("PASSPORT")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Paymeth)
                    .IsRequired()
                    .HasColumnName("PAYMETH")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Payrtype)
                    .IsRequired()
                    .HasColumnName("PAYRTYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Paystatus)
                    .IsRequired()
                    .HasColumnName("PAYSTATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PbonusMth).HasColumnName("PBONUS_MTH");

                entity.Property(e => e.Pcb1hd)
                    .IsRequired()
                    .HasColumnName("PCB1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Pcbbyer)
                    .IsRequired()
                    .HasColumnName("PCBBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("PHONE")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .IsRequired()
                    .HasColumnName("PHONE2")
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .IsRequired()
                    .HasColumnName("PHOTO")
                    .IsUnicode(false);

                entity.Property(e => e.Photodir)
                    .IsRequired()
                    .HasColumnName("PHOTODIR")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Plineno)
                    .IsRequired()
                    .HasColumnName("PLINENO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("POSTCODE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PrFrom)
                    .HasColumnName("PR_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrNum)
                    .IsRequired()
                    .HasColumnName("PR_NUM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrRate)
                    .IsRequired()
                    .HasColumnName("PR_RATE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PrnEa)
                    .IsRequired()
                    .HasColumnName("PRN_EA")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PrnIr8s)
                    .IsRequired()
                    .HasColumnName("PRN_IR8S")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.RStatu)
                    .IsRequired()
                    .HasColumnName("R_STATU")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasColumnName("RACE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Relcode)
                    .IsRequired()
                    .HasColumnName("RELCODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .IsRequired()
                    .HasColumnName("REMARK")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Restwkday).HasColumnName("RESTWKDAY");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("SEX")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Shifttbl)
                    .IsRequired()
                    .HasColumnName("SHIFTTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sitbranch)
                    .IsRequired()
                    .HasColumnName("SITBRANCH")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .IsRequired()
                    .HasColumnName("SNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Snric)
                    .IsRequired()
                    .HasColumnName("SNRIC")
                    .HasMaxLength(22)
                    .IsUnicode(false);

                entity.Property(e => e.Soaso1hd)
                    .IsRequired()
                    .HasColumnName("SOASO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soasobyer)
                    .IsRequired()
                    .HasColumnName("SOASOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soasocat)
                    .IsRequired()
                    .HasColumnName("SOASOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soasono)
                    .IsRequired()
                    .HasColumnName("SOASONO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Soasotbl)
                    .IsRequired()
                    .HasColumnName("SOASOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sobso1hd)
                    .IsRequired()
                    .HasColumnName("SOBSO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sobsobyer)
                    .IsRequired()
                    .HasColumnName("SOBSOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sobsocat)
                    .IsRequired()
                    .HasColumnName("SOBSOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sobsono)
                    .IsRequired()
                    .HasColumnName("SOBSONO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sobsotbl)
                    .IsRequired()
                    .HasColumnName("SOBSOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Socso1hd)
                    .IsRequired()
                    .HasColumnName("SOCSO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Socsobyer)
                    .IsRequired()
                    .HasColumnName("SOCSOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Socsocat)
                    .IsRequired()
                    .HasColumnName("SOCSOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Socsoic)
                    .IsRequired()
                    .HasColumnName("SOCSOIC")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Socsoinit)
                    .IsRequired()
                    .HasColumnName("SOCSOINIT")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Socsono)
                    .IsRequired()
                    .HasColumnName("SOCSONO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Socsotbl)
                    .IsRequired()
                    .HasColumnName("SOCSOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sodso1hd)
                    .IsRequired()
                    .HasColumnName("SODSO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sodsobyer)
                    .IsRequired()
                    .HasColumnName("SODSOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sodsocat)
                    .IsRequired()
                    .HasColumnName("SODSOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sodsono)
                    .IsRequired()
                    .HasColumnName("SODSONO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sodsotbl)
                    .IsRequired()
                    .HasColumnName("SODSOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soeso1hd)
                    .IsRequired()
                    .HasColumnName("SOESO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soesobyer)
                    .IsRequired()
                    .HasColumnName("SOESOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soesocat)
                    .IsRequired()
                    .HasColumnName("SOESOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Soesono)
                    .IsRequired()
                    .HasColumnName("SOESONO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Soesotbl)
                    .IsRequired()
                    .HasColumnName("SOESOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("SOURCE")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Stat11hd)
                    .IsRequired()
                    .HasColumnName("STAT11HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("STATE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Su).HasColumnName("SU");

                entity.Property(e => e.Tempfig1)
                    .HasColumnName("TEMPFIG1")
                    .HasColumnType("numeric(14, 2)");

                entity.Property(e => e.Tempfig2)
                    .HasColumnName("TEMPFIG2")
                    .HasColumnType("numeric(14, 2)");

                entity.Property(e => e.Tempfig3)
                    .HasColumnName("TEMPFIG3")
                    .HasColumnType("numeric(14, 2)");

                entity.Property(e => e.Tempfig4)
                    .HasColumnName("TEMPFIG4")
                    .HasColumnType("numeric(14, 2)");

                entity.Property(e => e.Tempstr1)
                    .IsRequired()
                    .HasColumnName("TEMPSTR1")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasColumnName("TOWN")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Trancode)
                    .IsRequired()
                    .HasColumnName("TRANCODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TxDedSp)
                    .IsRequired()
                    .HasColumnName("TX_DED_SP")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Unempitbl)
                    .IsRequired()
                    .HasColumnName("UNEMPITBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Union1hd)
                    .IsRequired()
                    .HasColumnName("UNION1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Unionbyer)
                    .IsRequired()
                    .HasColumnName("UNIONBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Unioncat)
                    .IsRequired()
                    .HasColumnName("UNIONCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Unionno)
                    .IsRequired()
                    .HasColumnName("UNIONNO")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Uniontbl)
                    .IsRequired()
                    .HasColumnName("UNIONTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Weekpay)
                    .IsRequired()
                    .HasColumnName("WEEKPAY")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Whtbl)
                    .IsRequired()
                    .HasColumnName("WHTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Withbopcb)
                    .IsRequired()
                    .HasColumnName("WITHBOPCB")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Withcopcb)
                    .IsRequired()
                    .HasColumnName("WITHCOPCB")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Withhrdf)
                    .IsRequired()
                    .HasColumnName("WITHHRDF")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Withpcb)
                    .IsRequired()
                    .HasColumnName("WITHPCB")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Workgrpid)
                    .IsRequired()
                    .HasColumnName("WORKGRPID")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.WpFrom)
                    .HasColumnName("WP_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.WpTo)
                    .HasColumnName("WP_TO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Wpermit)
                    .IsRequired()
                    .HasColumnName("WPERMIT")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
