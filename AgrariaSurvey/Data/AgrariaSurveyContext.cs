using AgrariaSurvey.Models;
using Microsoft.EntityFrameworkCore;

namespace AgrariaSurvey.Data
{
    public class AgrariaSurveyContext : DbContext
    {
        public AgrariaSurveyContext()
        {
        }
        public AgrariaSurveyContext(DbContextOptions<AgrariaSurveyContext> options)
            : base(options)
        {
        }

        public DbSet<AnggotaRumahTangga> AnggotaRumahTangga { get; set; }
        public DbSet<BahasaSehariHari> BahasaSehariHari { get; set; }
        public DbSet<Etnis> Etnis { get; set; }
        public DbSet<HubunganDenganKepalaKeluarga> HubunganDenganKepalaKeluarga { get; set; }
        public DbSet<IdentitasKeluargaRumahTangga> IdentitasKeluargaRumahTangga { get; set; }
        public DbSet<IdentitasResponden> IdentitasResponden { get; set; }
        public DbSet<PekerjaanUtamaDanPekerjaanSampingan> PekerjaanUtamaDanPekerjaanSampingan { get; set; }
        public DbSet<PendidikanTertinggi> PendidikanTertinggi { get; set; }
        public DbSet<Responden> Responden { get; set; }
        public DbSet<RiwayatBermukim> RiwayatBermukim { get; set; }
        public DbSet<StatusNikah> StatusNikah { get; set; }
        public DbSet<TempatLahirDanTempatTinggal> TempatLahirDanTempatTinggal { get; set; }
        public DbSet<PemilikanTanah> PemilikanTanah { get; set; }
        public DbSet<Provinsi> Provinsi { get; set; }
        public DbSet<Kabupaten> Kabupaten { get; set; }
        public DbSet<Kecamatans> Kecamatans { get; set; }
        public DbSet<Kelurahan> Kelurahans { get; set; }
        public DbSet<Pulau> Pulaus { get; set; }
        public DbSet<StatusTanah> StatusTanah { get; set;  }
        public DbSet<DesaDomisili> DesaDomisilis { get; set; }
        public DbSet<Legalitas> legalitas { get; set; }
        public DbSet<PerolehanTanah> PerolehanTanah { get; set; }
        public DbSet<MekanismeKelolaTanah> KelolaTanah { get; set; }
        public DbSet<TanamanPanganPalawija> JenisPenggunaanTanah { get; set; }
        public DbSet<TanahWaris> TanahWaris { get; set; }
        //public DbSet<BeliTanah> BeliTanah { get; set; }
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


    }
}
