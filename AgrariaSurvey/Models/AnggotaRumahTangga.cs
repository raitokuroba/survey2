using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrariaSurvey.Models
{
    public class AnggotaRumahTangga
    {
        [Key]
        public long AnggotaRumahTanggaID { get; set; }
        public long RespondenID { get; set; }
        [Display(Name = "No ART")]
        public int NoART { get; set; }
        [StringLength(150)]
        public string Nama { get; set; }
        [StringLength(3)]
        [Display(Name = "Hubungan Dengan Kepala Keluarga")]
        public string HubunganDenganKepalaKeluarga { get; set; }
        [StringLength(50)]
        [Display(Name = "Lainnya")]
        public string HubunganDenganKepalaKeluargaLainnya { get; set; }
        [StringLength(1)]
        [Display(Name = "Jenis Kelamin")]
        public string JenisKelamin { get; set; }
        public int Umur { get; set; }
        [Required]
        public DateTime? TanggalLahir { get; set; }
        [StringLength(1)]
        [Display(Name = "StatusNikah")]
        public string StatusNikah { get; set; }
        [StringLength(3)]
        [Display(Name = "Etnis / Suku")]
        public string EtnisSuku { get; set; }
        [StringLength(3)]
        [Display(Name = "Bahasa Sehari - hari")]
        public string BahasaSehari { get; set; }
        [StringLength(3)]
        [Display(Name = "Pendidikan Tertinggi Yang Ditamatkan")]
        public string PendidikanTertinggi { get; set; }
        [StringLength(3)]
        [Display(Name = "Tempat Lahir")]
        public string TempatLahir { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Desa")]
        public string TempatLahirDesa { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kecamatan")]
        public string TempatLahirKec { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kabupaten")]
        public string TempatLahirKab { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Provinsi")]
        public string TempatLahirProv { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Negara")]
        public string TempatLahirNeg { get; set; }
        [StringLength(3)]
        [Display(Name = "Tempat Tinggal 5 Tahun Lalu")]
        public string TempatTinggalLalu { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Desa")]
        public string TempatTinggalLaluDesa { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kecamatan")]
        public string TempatTinggalLaluKec { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kabupaten")]
        public string TempatTinggalLaluKab { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Provinsi")]
        public string TempatTinggalLaluProv { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Negara")]
        public string TempatTinggalLaluNeg { get; set; }
        [StringLength(3)]
        [Display(Name = "Pekerjaan Utama (PU)")]
        public string PekerjaanUtama { get; set; }
        [StringLength(50)]
        [Display(Name = "Lainnya")]
        public string PekerjaanUtamaLainnya { get; set; }
        [StringLength(3)]
        [Display(Name = "Lokasi Kerja PU")]
        public string LokasiKerjaUtama { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Desa")]
        public string LokasiKerjaUtamaDesa { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kecamatan")]
        public string LokasiKerjaUtamaKec { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kabupaten")]
        public string LokasiKerjaUtamaKab { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Provinsi")]
        public string LokasiKerjaUtamaProv { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Negara")]
        public string LokasiKerjaUtamaNeg { get; set; }
        [StringLength(3)]
        [Display(Name = "Pekerjaan Sampingan (PS)")]
        public string PekerjaanUSampingan { get; set; }
        [StringLength(50)]
        [Display(Name = "Lainnya")]
        public string PekerjaanSampinganLainnya { get; set; }
        [StringLength(3)]
        [Display(Name = "Lokasi Kerja PS")]
        public string LokasiKerjaSamping { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Desa")]
        public string LokasiKerjaSampingDesa { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kecamatan")]
        public string LokasiKerjaSampingKec { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Kabupaten")]
        public string LokasiKerjaSampingKab { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Provinsi")]
        public string LokasiKerjaSampingProv { get; set; }
        [StringLength(50)]
        [Display(Name = "Nama Negara")]
        public string LokasiKerjaSampingNeg { get; set; }

        [ForeignKey(nameof(RespondenID))]
        [InverseProperty("AnggotaRumahTangga")]
        public Responden Responden { get; set; }
    }
}
