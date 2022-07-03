using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgrariaSurvey.Models
{
    public partial class BagiHasil
    {
        [Key]
        public long BagiHasilId { get; set; }
        public long RespondenId { get; set; }
        [Required]
        [Display(Name = "BAGI HASIL MILIK.Apakah anda sedang melakukan sistem bagi hasil")]
        [StringLength(5)]
        public string BagiHasilMilik { get; set; }
        [Required]
        [Display(Name = "Kepada siapa anda mempercayakan pengelolaan tanah Bagi hasil MIlik tersebut untuk dikelola secara bagi hasil")]
        [StringLength(5)]
        public string KepadaSiapaPengelolaan { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda melakukan bagi hasil tersebut")]
        [StringLength(5)]
        public string AlasanBagiHasil { get; set; }
        [Required]
        [Display(Name = "Berapa luas tanah dengan sistem bagi hasil tersebut")]
        [StringLength(5)]
        public string LuasBagiHasil { get; set; }
        [Required]
        [Display(Name = "Berapa komposisi bagi hasil tersebut")]
        [StringLength(5)]
        public string KomposisiBagiHasil { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi lahan yang Bagi Hasil Milik tersebut")]
        [StringLength(5)]
        public string LokasiBagiHasil { get; set; }
        [Required]
        [Display(Name = "Sejak kapan (tahun) anda melakukan Bagi Hasil Milik")]
        public int? TahunBagiHasil { get; set; }
        [Required]
        [Display(Name = "Sampai kapan kontrak perjanjian Bagi Hasil Milik tersebut")]
        public int? TahunKontrakBagiHasil { get; set; }
        [Required]
        [Display(Name = "Apa bentuk legalitas tanah Bagi Hasil Milik")]
        [StringLength(5)]
        public string BentukLegalitasBagiHasil { get; set; }
        [Required]
        [Display(Name = "Diusahakan untuk apa tanah Bagi Hasil Milik tersebut")]
        [StringLength(5)]
        public string UsahaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Apakah tanah yang anda sewa tersebut subur")]
        [StringLength(5)]
        public string TanahBagiHasilSubur { get; set; }
        [Required]
        [Display(Name = "Jika tanah Bagi Hasil Milik diusahakan. Hasil usahatani dari tanah Bagi Hasil Milik tersebut digunakan untuk apa")]
        [StringLength(5)]
        public string HasilUsahaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Siapa yang mengelola tanah Bagi Hasil Milik tersebut")]
        [StringLength(5)]
        public string TenagaMengelolaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, berapa jumlah anggota keluarga yang bekerja")]
        [StringLength(5)]
        public string JumlahAnggotaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Jika pekerja adalah buruh tani, berapa jumlah buruh tani yang bekerja")]
        [StringLength(5)]
        public string JumlahBuruhTaniBagiHasil { get; set; }
        [Required]
        [Display(Name = "Jika dikelola oleh buruh tani, dari mana asal buruh tani tersebut")]
        [StringLength(5)]
        public string AsalBuruhTaniBagiHasil { get; set; }
        [Required]
        [Display(Name = "Apakah anda sedang menggarap tanah dengan sistem Bagi Hasil Kelola (tanah yang anda garap milik orang lain)")]
        [StringLength(5)]
        public string BagiHasilKelola { get; set; }
        [Required]
        [Display(Name = "Jika ya, kepada siapa anda melakukan Bagi Hasil Kelola tersebut")]
        [StringLength(5)]
        public string KepadaSiapaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Berapa luas tanah Bagi Hasil Kelola")]
        [StringLength(5)]
        public string LuasTanahBagiHasil { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi tanah Bagi Hasil Kelola tersebut")]
        [StringLength(5)]
        public string LokasiTanahBagiHasil { get; set; }
        [Required]
        [Display(Name = "Apa bentuk legalitas tanah tersebut")]
        [StringLength(5)]
        public string LegalitasBagiHasil { get; set; }
        [Required]
        [Display(Name = "Apa alasan menggarap tanah dengan sistem Bagi Hasil Kelola")]
        [StringLength(5)]
        public string AlasanMenggarapBagiHasil { get; set; }
        [Required]
        [Display(Name = "Diusahakan untuk apa tanah tersebut ")]
        [StringLength(5)]
        public string UsahakanBagiHasil { get; set; }
        [Required]
        [Display(Name = "Berapa komposisi bagi hasil tersebut")]
        [StringLength(5)]
        public string KomposisiBagi { get; set; }
        [Required]
        [Display(Name = "Berapa lama jangka waktu Bagi Hasil Kelola")]
        public int? JangkaWaktuBagiHasil { get; set; }
        [Required]
        [Display(Name = "Apakah tanah Bagi Hasil Kelola tersebut subur")]
        [StringLength(5)]
        public string TanahBagiSubur { get; set; }
        [Required]
        [Display(Name = "Jika tanah Bagi Hasil Kelola diusahakan. Hasil usahatani dari tanah Bagi Hasil Kelola tersebut digunakan untuk apa")]
        [StringLength(5)]
        public string UsahaTanahBagiHasil { get; set; }
        [Required]
        [Display(Name = "Tenaga Kerja yang mengelola tanah Bagi Hasil Kelola tersebut")]
        [StringLength(5)]
        public string TenagaKerjaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, berapa jumlah anggota keluarga yang bekerja")]
        [StringLength(5)]
        public string AnggotaKeluargaBagiHasil { get; set; }
        [Required]
        [Display(Name = "Jika pekerja adalah buruh tani, berapa jumlah buruh tani yang bekerja")]
        [StringLength(5)]
        public string BuruhTaniBagiHasil { get; set; }
        [Required]
        [Display(Name = "Jika dikelola oleh buruh tani, dari mana asal buruh tani tersebut")]
        [StringLength(5)]
        public string BuruhTaniAsal { get; set; }
    }
}
