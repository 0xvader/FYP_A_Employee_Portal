using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Employee_Portal_Test.Models
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
                optionsBuilder.UseSqlServer("Server=DESKTOP-6EIM981;Database=bcck;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => new { e.Empno, e.Memname })
                    .HasName("PK_family_1");

                entity.ToTable("family");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Memname)
                    .HasColumnName("MEMNAME")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Datebirth)
                    .HasColumnName("DATEBIRTH")
                    .HasColumnType("date");

                entity.Property(e => e.Nricno)
                    .HasColumnName("NRICNO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sex)
                    .HasColumnName("SEX")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .IsFixedLength();

                entity.Property(e => e.Add1)
                    .HasColumnName("ADD1")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
                  

                entity.Property(e => e.Add2)
                    .HasColumnName("ADD2")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Addrtype)
                    .HasColumnName("ADDRTYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("ALMCTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BPutra)
                    .HasColumnName("B_PUTRA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Badgeno)
                    .HasColumnName("BADGENO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bankaccno)
                    .HasColumnName("BANKACCNO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bankcat)
                    .HasColumnName("BANKCAT")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bankcode)
                    .HasColumnName("BANKCODE")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bankic)
                    .HasColumnName("BANKIC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Bankpmode)
                    .HasColumnName("BANKPMODE")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("BRANCODE")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Brate)
                    .HasColumnName("BRATE")
                    .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.BrateLm)
                    .HasColumnName("BRATE_LM")
                    .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.Brcode)
                    .HasColumnName("BRCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Category)
                    .HasColumnName("CATEGORY")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comm)
                    .HasColumnName("COMM")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Confid)
                    .HasColumnName("CONFID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Contract)
                    .HasColumnName("CONTRACT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ContractF)
                    .HasColumnName("CONTRACT_F")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContractT)
                    .HasColumnName("CONTRACT_T")
                    .HasColumnType("datetime");

                entity.Property(e => e.Countryc)
                    .HasColumnName("COUNTRYC")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cp8dgrp)
                    .HasColumnName("CP8DGRP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cp8dgrpi)
                    .HasColumnName("CP8DGRPI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CpfCeili).HasColumnName("CPF_CEILI");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("CREATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cschmcode)
                    .HasColumnName("CSCHMCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("DEDMEM111")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dedmem112)
                    .HasColumnName("DEDMEM112")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dedmem113)
                    .HasColumnName("DEDMEM113")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dedmem114)
                    .HasColumnName("DEDMEM114")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dedmem115)
                    .HasColumnName("DEDMEM115")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Deptcode)
                    .HasColumnName("DEPTCODE")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dfundall)
                    .HasColumnName("DFUNDALL")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Dirfset)
                    .HasColumnName("DIRFSET")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("EA_GRP_SN")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EaSn)
                    .HasColumnName("EA_SN")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Eadd1)
                    .HasColumnName("EADD1")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Eadd2)
                    .HasColumnName("EADD2")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Eadd3)
                    .HasColumnName("EADD3")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Econtact)
                    .HasColumnName("ECONTACT")
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Edu)
                    .HasColumnName("EDU")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Emerphone)
                    .HasColumnName("EMERPHONE")
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Emerrship)
                    .HasColumnName("EMERRSHIP")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpCode)
                    .HasColumnName("EMP_CODE")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpStatus)
                    .HasColumnName("EMP_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EmpType)
                    .HasColumnName("EMP_TYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Emppass)
                    .HasColumnName("EMPPASS")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epf1hd)
                    .HasColumnName("EPF1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EpfFyee)
                    .HasColumnName("EPF_FYEE")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EpfFyer)
                    .HasColumnName("EPF_FYER")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epfbrinsbp)
                    .HasColumnName("EPFBRINSBP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epfbyer)
                    .HasColumnName("EPFBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epfcat)
                    .HasColumnName("EPFCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epfic)
                    .HasColumnName("EPFIC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epfnk)
                    .HasColumnName("EPFNK")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epfno)
                    .HasColumnName("EPFNO")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epftbl)
                    .HasColumnName("EPFTBL")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epg1hd)
                    .HasColumnName("EPG1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epgbyer)
                    .HasColumnName("EPGBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epgcat)
                    .HasColumnName("EPGCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epgno)
                    .HasColumnName("EPGNO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Epgtbl)
                    .HasColumnName("EPGTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Etelno)
                    .HasColumnName("ETELNO")
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Exp)
                    .HasColumnName("EXP")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Extra)
                    .HasColumnName("EXTRA")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.Finno)
                    .HasColumnName("FINNO")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fwlevyadj)
                    .HasColumnName("FWLEVYADJ")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.Fwlevymtd)
                    .HasColumnName("FWLEVYMTD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fwlevytbl)
                    .HasColumnName("FWLEVYTBL")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("ICCOLOR")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Icinssocno)
                    .HasColumnName("ICINSSOCNO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Imigrano)
                    .HasColumnName("IMIGRANO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Iname)
                    .IsRequired()
                    .HasColumnName("INAME")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IncAmt)
                    .HasColumnName("INC_AMT")
                    .HasColumnType("numeric(12, 2)");

                entity.Property(e => e.IncDate)
                    .HasColumnName("INC_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iskerja)
                    .HasColumnName("ISKERJA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Itaxbran)
                    .HasColumnName("ITAXBRAN")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Itaxcat)
                    .HasColumnName("ITAXCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Itaxno)
                    .HasColumnName("ITAXNO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Itaxnoki)
                    .HasColumnName("ITAXNOKI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Itaxtbl)
                    .HasColumnName("ITAXTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Jfunction)
                    .HasColumnName("JFUNCTION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Jobcode)
                    .HasColumnName("JOBCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Jstacode)
                    .HasColumnName("JSTACODE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Jtitle)
                    .HasColumnName("JTITLE")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Keyuser)
                    .HasColumnName("KEYUSER")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Lschmcode)
                    .HasColumnName("LSCHMCODE")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("MEDITBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Meps)
                    .HasColumnName("MEPS")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mfundall)
                    .HasColumnName("MFUNDALL")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Mstatus)
                    .HasColumnName("MSTATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Mstatusod)
                    .HasColumnName("MSTATUSOD")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MustprSoc)
                    .HasColumnName("MUSTPR_SOC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.National)
                    .HasColumnName("NATIONAL")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NmPcb).HasColumnName("NM_PCB");

                entity.Property(e => e.Noadvday)
                    .HasColumnName("NOADVDAY")
                    .HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Nochild).HasColumnName("NOCHILD");

                entity.Property(e => e.Nppm).HasColumnName("NPPM");

                entity.Property(e => e.Nric)
                    .HasColumnName("NRIC")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nricn)
                    .HasColumnName("NRICN")
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("OT_MAXPAY")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Otcode)
                    .HasColumnName("OTCODE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Otraterc)
                    .HasColumnName("OTRATERC")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Ottbl)
                    .HasColumnName("OTTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Passport)
                    .HasColumnName("PASSPORT")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Paymeth)
                    .HasColumnName("PAYMETH")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Payrtype)
                    .HasColumnName("PAYRTYPE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Paystatus)
                    .HasColumnName("PAYSTATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PbonusMth).HasColumnName("PBONUS_MTH");

                entity.Property(e => e.Pcb1hd)
                    .HasColumnName("PCB1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pcbbyer)
                    .HasColumnName("PCBBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone2)
                    .HasColumnName("PHONE2")
                    .HasMaxLength(24)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Photo)
                    .HasColumnName("PHOTO")
                    .IsUnicode(false);

                entity.Property(e => e.Photodir)
                    .HasColumnName("PHOTODIR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Plineno)
                    .HasColumnName("PLINENO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Postcode)
                    .HasColumnName("POSTCODE")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrFrom)
                    .HasColumnName("PR_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrNum)
                    .HasColumnName("PR_NUM")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrRate)
                    .HasColumnName("PR_RATE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrnEa)
                    .HasColumnName("PRN_EA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PrnIr8s)
                    .HasColumnName("PRN_IR8S")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RStatu)
                    .HasColumnName("R_STATU")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Race)
                    .HasColumnName("RACE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Relcode)
                    .HasColumnName("RELCODE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Remark)
                    .HasColumnName("REMARK")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Restwkday).HasColumnName("RESTWKDAY");

                entity.Property(e => e.Sex)
                    .HasColumnName("SEX")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Shifttbl)
                    .HasColumnName("SHIFTTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sitbranch)
                    .HasColumnName("SITBRANCH")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sname)
                    .HasColumnName("SNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Snric)
                    .HasColumnName("SNRIC")
                    .HasMaxLength(22)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soaso1hd)
                    .HasColumnName("SOASO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soasobyer)
                    .HasColumnName("SOASOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soasocat)
                    .HasColumnName("SOASOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soasono)
                    .HasColumnName("SOASONO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soasotbl)
                    .HasColumnName("SOASOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sobso1hd)
                    .HasColumnName("SOBSO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sobsobyer)
                    .HasColumnName("SOBSOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sobsocat)
                    .HasColumnName("SOBSOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sobsono)
                    .HasColumnName("SOBSONO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sobsotbl)
                    .HasColumnName("SOBSOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socso1hd)
                    .HasColumnName("SOCSO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socsobyer)
                    .HasColumnName("SOCSOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socsocat)
                    .HasColumnName("SOCSOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socsoic)
                    .HasColumnName("SOCSOIC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socsoinit)
                    .HasColumnName("SOCSOINIT")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socsono)
                    .HasColumnName("SOCSONO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Socsotbl)
                    .HasColumnName("SOCSOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sodso1hd)
                    .HasColumnName("SODSO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sodsobyer)
                    .HasColumnName("SODSOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sodsocat)
                    .HasColumnName("SODSOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sodsono)
                    .HasColumnName("SODSONO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sodsotbl)
                    .HasColumnName("SODSOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soeso1hd)
                    .HasColumnName("SOESO1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soesobyer)
                    .HasColumnName("SOESOBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soesocat)
                    .HasColumnName("SOESOCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soesono)
                    .HasColumnName("SOESONO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Soesotbl)
                    .HasColumnName("SOESOTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Source)
                    .HasColumnName("SOURCE")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Stat11hd)
                    .HasColumnName("STAT11HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasColumnName("STATE")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

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
                    .HasColumnName("TEMPSTR1")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Town)
                    .HasColumnName("TOWN")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Trancode)
                    .HasColumnName("TRANCODE")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TxDedSp)
                    .HasColumnName("TX_DED_SP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Unempitbl)
                    .HasColumnName("UNEMPITBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Union1hd)
                    .HasColumnName("UNION1HD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Unionbyer)
                    .HasColumnName("UNIONBYER")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Unioncat)
                    .HasColumnName("UNIONCAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Unionno)
                    .HasColumnName("UNIONNO")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Uniontbl)
                    .HasColumnName("UNIONTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("UPDATED_ON")
                    .HasColumnType("datetime");

                entity.Property(e => e.Weekpay)
                    .HasColumnName("WEEKPAY")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Whtbl)
                    .HasColumnName("WHTBL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Withbopcb)
                    .HasColumnName("WITHBOPCB")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Withcopcb)
                    .HasColumnName("WITHCOPCB")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Withhrdf)
                    .HasColumnName("WITHHRDF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Withpcb)
                    .HasColumnName("WITHPCB")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Workgrpid)
                    .HasColumnName("WORKGRPID")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WpFrom)
                    .HasColumnName("WP_FROM")
                    .HasColumnType("datetime");

                entity.Property(e => e.WpTo)
                    .HasColumnName("WP_TO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Wpermit)
                    .HasColumnName("WPERMIT")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
