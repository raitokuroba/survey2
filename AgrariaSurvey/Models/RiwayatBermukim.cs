using AgrariaSurvey.Models.CustomAttribute;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
namespace AgrariaSurvey.Models
{
    public class RiwayatBermukim
    {
        [Key]
        public long RiwayatBermukimID { get; set; }
        public long RespondenID { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Tempat Lahir Ayah Dari Suami")]
        public string TempatLahirAyahDariSuami { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariSuami), "2")]
        [StringLength(5)]
        [Display(Name = "Provinsi")]
        public string TempatLahirAyahDariSuamiProv { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariSuami), "2")]
        [StringLength(5)]
        [Display(Name = "Kota / Kabupaten")]
        public string TempatLahirAyahDariSuamiKota { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariSuami), "2")]
        [StringLength(8)]
        [Display(Name = "Kecamatan")]
        public string TempatLahirAyahDariSuamiKec { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariSuami), "2")]
        [StringLength(15)]
        [Display(Name = "Desa")]
        public string TempatLahirAyahDariSuamiDesa { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Etnis Ayah Dari Suami")]
        public string EtnisAyahDariSuami { get; set; }

        [Display(Name = "Tahun Kedatangan Ayah Dari Suami Ke Desa")]
        public int? TahunKedatanganAyahDariSuamiKeDesa { get; set; }

        [RequiredIfNot(nameof(TahunKedatanganAyahDariSuamiKeDesa), null)]
        [StringLength(1)]
        [Display(Name = "Alasan Ayah Dari Suami Datang Ke Desa Ini")]
        public string AlasanAyahDariSuamiDatangKeDesaIni { get; set; }

        [RequiredIf(nameof(AlasanAyahDariSuamiDatangKeDesaIni), "4")]
        [Display(Name = "Lainnya :")]
        [StringLength(512)]
        public string AlasanAyahDariSuamiDatangKeDesaIniLainnya { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Tempat Lahir Ibu Dari Suami")]
        public string TempatLahirIbuDariSuami { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariSuami), "2")]
        [StringLength(5)]
        [Display(Name = "Provinsi")]
        public string TempatLahirIbuDariSuamiProv { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariSuami), "2")]
        [StringLength(5)]
        [Display(Name = "Kota / Kabupaten")]
        public string TempatLahirIbuDariSuamiKota { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariSuami), "2")]
        [StringLength(8)]
        [Display(Name = "Kecamatan")]
        public string TempatLahirIbuDariSuamiKec { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariSuami), "2")]
        [StringLength(15)]
        [Display(Name = "Desa")]
        public string TempatLahirIbuDariSuamiDesa { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Etnis Ibu Dari Suami")]
        public string EtnisIbuDariSuami { get; set; }

        [Display(Name = "Tahun Kedatangan Ibu Dari Suami Ke Desa")]
        public int? TahunKedatanganIbuDariSuamiKeDesa { get; set; }

        [RequiredIfNot(nameof(TahunKedatanganIbuDariSuamiKeDesa), null)]
        [StringLength(1)]
        [Display(Name = "Alasan Ibu Dari Suami Datang Ke Desa Ini")]
        public string AlasanIbuDariSuamiDatangKeDesaIni { get; set; }

        [RequiredIf(nameof(AlasanIbuDariSuamiDatangKeDesaIni), "4")]
        [Display(Name = "Lainnya :")]
        [StringLength(512)]
        public string AlasanIbuDariSuamiDatangKeDesaIniLainnya { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Tempat Lahir Ayah Dari Istri")]
        public string TempatLahirAyahDariIstri { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariIstri), "2")]
        [StringLength(5)]
        [Display(Name = "Provinsi")]
        public string TempatLahirAyahDariIstriProv { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariIstri), "2")]
        [StringLength(5)]
        [Display(Name = "Kota / Kabupaten")]
        public string TempatLahirAyahDariIstriKota { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariIstri), "2")]
        [StringLength(8)]
        [Display(Name = "Kecamatan")]
        public string TempatLahirAyahDariIstriKec { get; set; }

        [RequiredIf(nameof(TempatLahirAyahDariIstri), "2")]
        [StringLength(15)]
        [Display(Name = "Desa")]
        public string TempatLahirAyahDariIstriDesa { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Etnis Ayah Dari Istri")]
        public string EtnisAyahDariIstri { get; set; }

        [Display(Name = "Tahun Kedatangan Ayah Dari Istri Ke Desa")]
        public int? TahunKedatanganAyahDariIstriKeDesa { get; set; }

        [RequiredIfNot(nameof(TahunKedatanganAyahDariIstriKeDesa), null)]
        [StringLength(1)]
        [Display(Name = "Alasan Ayah Dari Istri Datang Ke Desa Ini")]
        public string AlasanAyahDariIstriDatangKeDesaIni { get; set; }

        [RequiredIf(nameof(AlasanAyahDariIstriDatangKeDesaIni), "4")]
        [Display(Name = "Lainnya :")]
        [StringLength(512)]
        public string AlasanAyahDariIstriDatangKeDesaIniLainnya { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Tempat Lahir Ibu Dari Istri")]
        public string TempatLahirIbuDariIstri { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariIstri), "2")]
        [StringLength(5)]
        [Display(Name = "Provinsi")]
        public string TempatLahirIbuDariIstriProv { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariIstri), "2")]
        [StringLength(5)]
        [Display(Name = "Kota / Kabupaten")]
        public string TempatLahirIbuDariIstriKota { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariIstri), "2")]
        [StringLength(8)]
        [Display(Name = "Kecamatan")]
        public string TempatLahirIbuDariIstriKec { get; set; }

        [RequiredIf(nameof(TempatLahirIbuDariIstri), "2")]
        [StringLength(15)]
        [Display(Name = "Desa")]
        public string TempatLahirIbuDariIstriDesa { get; set; }

        [Required]
        [StringLength(3)]
        [Display(Name = "Etnis Ibu Dari Istri")]
        public string EtnisIbuDariIstri { get; set; }

        [Display(Name = "Tahun Kedatangan Ibu Dari Istri Ke Desa")]
        public int? TahunKedatanganIbuDariIstriKeDesa { get; set; }

        [RequiredIfNot(nameof(TahunKedatanganIbuDariIstriKeDesa), null)]
        [StringLength(1)]
        [Display(Name = "Alasan Ibu Dari Istri Datang Ke Desa Ini")]
        public string AlasanIbuDariIstriDatangKeDesaIni { get; set; }

        [RequiredIf(nameof(AlasanIbuDariIstriDatangKeDesaIni), "4")]
        [Display(Name = "Lainnya :")]
        [StringLength(512)]
        public string AlasanIbuDariIstriDatangKeDesaIniLainnya { get; set; }


        [ForeignKey(nameof(RespondenID))]
        [InverseProperty("RiwayatBermukim")]
        public Responden Responden { get; set; }
    }
}
