using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgrariaSurvey.Models
{
    public partial class BeliTanah
    {
        [Key]
        public long BeliTanahID { get; set; }
        public long RespondenID { get; set; }

        [Required]
        [Display(Name = "Apakah anda memiliki tanah dari hasil pembelian")]
        [StringLength(5)]
        public string DariHasilPembelian { get; set; }
        [Required]
        [Display(Name = "Tahun pembelian:")]
        public int? TahunPembelian { get; set; }
        [Required]
        [Display(Name = "Dari siapa anda membeli tanah tersebut")]
        [StringLength(5)]
        public string DariSiapaMembeli { get; set; }
        [Required]
        [Display(Name = "Apa alasan PENJUAL menjual tanahnya kepada anda")]
        [StringLength(5)]
        public string AlasanPenjualMenjual { get; set; }
        [StringLength(512)]
        public string CeritakanPenjual { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda membeli lahan")]
        [StringLength(5)]
        public string AlasanMembeliLahan { get; set; }
        [StringLength(512)]
        public string CeritakanMembeli { get; set; }
        [Required]
        [Display(Name = "Berapa luas tanah yang dibeli")]
        [StringLength(100)]
        public string LuasTanahDibeli { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi lahan yang dibeli tersebut tersebut")]
        [StringLength(100)]
        public string LokasiLahanDibeli { get; set; }
        [Required]
        [Display(Name = "Apa bentuk legalitas tanah yang dibeli")]
        [StringLength(5)]
        public string BentukLegalitasDibeli { get; set; }
        [Required]
        [Display(Name = "Diusahakan untuk apa tanah hasil pembelian tersebut")]
        [StringLength(5)]
        public string DiusahakanTanahPembelian { get; set; }
        [Required]
        [Display(Name = "Apakah tanah yang anda beli tersebut subur")]
        [StringLength(5)]
        public string TanahBeliSubur { get; set; }
        [Required]
        [Display(Name = "Jika tanah pembelian diusahakan. Hasil usahatani dari tanah tersebut digunakan untuk apa")]
        [StringLength(5)]
        public string HasilUsahaTaniTanah { get; set; }
        [Required]
        [Display(Name = "Tenaga Kerja yang mengelola tanah hasil pembelian tersebut")]
        [StringLength(100)]
        public string TenagaKerjaTanah { get; set; }
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
        [Display(Name = "Apakah anda pernah menjual tanah")]
        [StringLength(5)]
        public string PernahMenjualTanah { get; set; }
        [Required]
        [Display(Name = "Jika ya, kepada siapa anda menjual tanah tersebut")]
        [StringLength(5)]
        public string KepadaSiapaMenjual { get; set; }
        [Required]
        [Display(Name = "Tahun berapa menjual tanah")]
        public int? TahunMenjualTanah { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi lahan yang anda jual tersebut")]
        [StringLength(5)]
        public string LokasiLahanJual { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda menjual tanah tersebut")]
        [StringLength(5)]
        public string AlasanMenjualTanah { get; set; }
        [StringLength(512)]
        public string CeritakanMenjual { get; set; }


        [ForeignKey(nameof(RespondenID))]
        [InverseProperty("BeliTanah")]
        public Responden Responden { get; set; }
    }
}
