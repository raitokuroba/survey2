using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgrariaSurvey.Models
{
    public partial class SewaTanah
    {
        [Key]
        public long SewaTanahId { get; set; }
       public long RespondenId { get; set; }
        [Required]
        [Display(Name = "NYEWA. Apakah anda sedang menyewa tanah dari orang lain")]
        [StringLength(5)]
        public string SedangMenyewaTanah { get; set; }
        [Required]
        [Display(Name = "Dari siapa anda menyewa tanah tersebut")]
        [StringLength(5)]
        public string DariSiapaMenyewa { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda menyewa tanah tersebut")]
        [StringLength(5)]
        public string AlasanMenyewa { get; set; }
        [Required]
        [Display(Name = "Berapa luas tanah yang di sewa")]
        [StringLength(5)]
        public string LuasTanahDisewa { get; set; }
        [Required]
        [Display(Name = "Berapa biaya sewa tanah tersebut")]
        public int? BiayaSewaTanah { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi lahan yang di sewa tersebut")]
        [StringLength(5)]
        public string LokasiLahanSewa { get; set; }
        [Required]
        [Display(Name = "Sejak kapan (tahun) anda menyewa tanah")]
        public int? TahunMenyewaTanah { get; set; }
        [Required]
        [Display(Name = "Sampai kapan kontrak perjanjian sewa tanah tersebut")]
        public int? TahunSampaiKontrak { get; set; }
        [Required]
        [Display(Name = "Apa bentuk legalitas tanah yang di sewa")]
        [StringLength(5)]
        public string BentukLegalitasTanah { get; set; }
        [Required]
        [Display(Name = "Diusahakan untuk apa tanah yang anda sewa tersebut")]
        [StringLength(5)]
        public string UsahaTanahSewa { get; set; }
        [Required]
        [Display(Name = "Apakah tanah yang anda sewa tersebut subur")]
        [StringLength(5)]
        public string TanahSewaSubur { get; set; }
        [Required]
        [Display(Name = "Jika tanah pembelian diusahakan. Hasil usahatani dari tanah yang anda sewa tersebut digunakan untuk apa")]
        [StringLength(5)]
        public string HasilUsahaTani { get; set; }
        [Required]
        [Display(Name = "Tenaga Kerja yang mengelola tanah sewaan tersebut")]
        [StringLength(5)]
        public string TenagaMengelolaTanah { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, berapa jumlah anggota keluarga yang bekerja")]
        [StringLength(5)]
        public string JumlahAnggotaKeluarga { get; set; }
        [Required]
        [Display(Name = "Jika pekerja adalah buruh tani, berapa jumlah buruh tani yang bekerja")]
        [StringLength(5)]
        public string JumlahBuruhTani { get; set; }
        [Required]
        [Display(Name = "Jika dikelola oleh buruh tani, dari mana asal buruh tani tersebut")]
        [StringLength(5)]
        public string AsalBuruhTani { get; set; }
        [Required]
        [Display(Name = "SEWAKAN. Apakah anda sedang menyewakan tanah kepada orang lain")]
        [StringLength(5)]
        public string MenyewakanTanah { get; set; }
        [Required]
        [Display(Name = "Jika ya, kepada siapa anda menyewakan tanah tersebut")]
        [StringLength(5)]
        public string KepadaSiapaMenyewakan { get; set; }
        [Required]
        [Display(Name = "Berapa luas tanah yang di sewakan")]
        [StringLength(5)]
        public string LuasTanahSewakan { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi tanah yang anda sewakan kepada pihak lain tersebut")]
        [StringLength(5)]
        public string LokasiTanahDisewakan { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda menyewakan tanah tersebut kepada pihak lain")]
        [StringLength(5)]
        public string AlasanMenyewakan { get; set; }
        [Required]
        [Display(Name = "Berapa uang yang anda peroleh dari menyewakan tanah tersebut")]
        public int? UangSewaTanah { get; set; }
        [Required]
        [Display(Name = "Sejak kapan (tahun) anda menyewakan tanah")]
        public int? TahunMenyewakan { get; set; }
        [Required]
        [Display(Name = "Sampai kapan kontrak perjanjian sewakan tanah tersebut")]
        public int? KontrakSewa { get; set; }
    }
}
