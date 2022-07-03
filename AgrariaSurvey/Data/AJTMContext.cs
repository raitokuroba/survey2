using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AgrariaSurvey.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgrariaSurvey.Data
{
    public partial class AJTMContext : DbContext
    {
        public AJTMContext()
        {
        }

        public AJTMContext(DbContextOptions<AJTMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlasanBagiHasil> AlasanBagiHasil { get; set; }
        public virtual DbSet<AlasanMembeliLahan> AlasanMembeliLahan { get; set; }
        public virtual DbSet<AlasanMengalihkan> AlasanMengalihkan { get; set; }
        public virtual DbSet<AlasanMenggarapBagiHasil> AlasanMenggarapBagiHasil { get; set; }
        public virtual DbSet<AlasanMenyewa> AlasanMenyewa { get; set; }
        public virtual DbSet<AlasanMenyewakan> AlasanMenyewakan { get; set; }
        public virtual DbSet<AlasanPenjualMenjual> AlasanPenjualMenjual { get; set; }
        public virtual DbSet<AnggotaKeluargaYangBekerja> AnggotaKeluargaYangBekerja { get; set; }
        public virtual DbSet<BagiHasil> BagiHasil { get; set; }
        public virtual DbSet<BeliTanah> BeliTanah { get; set; }
        public virtual DbSet<BentukLegalitas> BentukLegalitas { get; set; }
        public virtual DbSet<FungsiLahanSebelum> FungsiLahanSebelum { get; set; }
        public virtual DbSet<HasilUsahaTani> HasilUsahaTani { get; set; }
        public virtual DbSet<JumlahBuruh> JumlahBuruh { get; set; }
        public virtual DbSet<KepadaSiapaPengalihan> KepadaSiapaPengalihan { get; set; }
        public virtual DbSet<KomposisiBagiHasil> KomposisiBagiHasil { get; set; }
        public virtual DbSet<LokasiLahan> LokasiLahan { get; set; }
        public virtual DbSet<LuasTanahDiwariskan> LuasTanahDiwariskan { get; set; }
        public virtual DbSet<LuasTanahSebelum> LuasTanahSebelum { get; set; }
        public virtual DbSet<SewaTanah> SewaTanah { get; set; }
        public virtual DbSet<SistemPewarisan> SistemPewarisan { get; set; }
        public virtual DbSet<TanahWarisanSubur> TanahWarisanSubur { get; set; }
        public virtual DbSet<TenagaYangMengelola> TenagaYangMengelola { get; set; }
        public virtual DbSet<TransaksiPengalihanPemilikan> TransaksiPengalihanPemilikan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DANANG\\SQLEXPRESS;Initial Catalog=AJTM;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagiHasil>(entity =>
            {
                entity.Property(e => e.BagiHasilId).ValueGeneratedNever();

                entity.Property(e => e.RespondenId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<BeliTanah>(entity =>
            {
                entity.Property(e => e.BeliTanahID).ValueGeneratedNever();

                entity.Property(e => e.RespondenID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SewaTanah>(entity =>
            {
                entity.Property(e => e.SewaTanahId).ValueGeneratedNever();

                entity.Property(e => e.RespondenId).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
