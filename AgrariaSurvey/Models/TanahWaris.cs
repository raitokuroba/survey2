using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgrariaSurvey.Models
{
    public partial class TanahWaris
    {
        [Key]
        public long TanahWarisID { get; set; }
        public long RespondenID { get; set; }
        [Required]
        [Display(Name = "Apakah Bapak memiliki atau pernah memiliki lahan warisan")]
        [StringLength(1)]
        public string BapakMemilikiLahanWaris { get; set; }
        [Required]
        [Display(Name = "Jika Ya, bagaimana sistem pewarisannya")]
        [StringLength(1)]
        public string SistemPewarisan { get; set; }
        [Required]
        [Display(Name = "Berapa luas lahan yang dimiliki orangtua anda sebelum diwariskan kepada anda")]
        [StringLength(1)]
        public string LuasTanahSebelum { get; set; }
        [Required]
        [Display(Name = "Berapa luas lahan yang diwariskan kepada anda")]
        public int? LuasTanahDiwariskan { get; set; }
        [Required]
        [Display(Name = "Tahun berapa tanah tersebut diwariskan kepada anda")]
        public int? TahunDiwariskan { get; set; }
        [Required]
        [Display(Name = "Apa bentuk legalitas tanah yang diwariskan")]
        [StringLength(150)]
        public string BentukLegalitas { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi lahan warisan tersebut")]
        [StringLength(150)]
        public string LokasiLahan { get; set; }
        [Required]
        [Display(Name = "Apa bentuk/fungsi lahan sebelum diwariskan kepada anda")]
        [StringLength(1)]
        public string FungsiLahanSebelum { get; set; }
        [Required]
        [Display(Name = "Apa bentuk/fungsi lahan sesudah diwariskan kepada anda")]
        [StringLength(1)]
        public string FungsiLahanSesudah { get; set; }
        [Required]
        [Display(Name = "Jika tanah warisan diusahakan maka hasil usahatani digunakan untuk apa")]
        [StringLength(1)]
        public string HasilUsahaTani { get; set; }
        [Required]
        [Display(Name = "Apakah tanah warisan tersebut subur")]
        [StringLength(1)]
        public string TanahWarisanSubur { get; set; }
        [Required]
        [Display(Name = "Tenaga kerja yang mengelola tanah warisan anda")]
        [StringLength(1)]
        public string TenagaYangMengelola { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, berapa jumlah anggota keluarga yang bekerja")]
        public int? AnggotaKeluargaYangBekerja { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, siapakah mereka dalam struktur ART")]
        [StringLength(150)]
        public string StrukturArt { get; set; }
        [Required]
        [Display(Name = "Jika pekerja adalah buruh tani, berapa jumlah buruh tani yang bekerja")]
        public int? JumlahBuruh { get; set; }
        [Required]
        [Display(Name = "Jika dikelola oleh buruh tani, dari mana asal buruh tani tersebut")]
        [StringLength(150)]
        public string AsalBuruh { get; set; }
        [Required]
        [Display(Name = "Apakah anda pernah mengalihkan penguasaan/pemilikan tanah warisan tersebut kepada orang lain")]
        [StringLength(1)]
        public string MengalihkanTanah { get; set; }
        [Required]
        [Display(Name = "Jika Ya, tahun berapa anda mengalihkan penguasaan/pemilikan tanah warisan tersebut")]
        public int? TahunMengalihkan { get; set; }
        [Required]
        [Display(Name = "Jika Ya, apa bentuk transaksi pengalihan pemilikan lahan warisan yang anda lakukan")]
        [StringLength(1)]
        public string TransaksiPengalihanPemilikan { get; set; }
        [Required]
        [Display(Name = "Kepada siapa anda melakukan pengalihan lahan tersebut")]
        [StringLength(1)]
        public string KepadaSiapaPengalihan { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda mengalihkan lahan warisan tersebut")]
        [StringLength(1)]
        public string AlasanMengalihkan { get; set; }
        [Required]
        [Display(Name = "Apakah Ibu memiliki atau pernah memiliki lahan warisan")]
        [StringLength(1)]
        public string IbuMemilikiLahanWaris { get; set; }
        [Required]
        [Display(Name = "Jika Ya, bagaimana sistem pewarisannya")]
        [StringLength(1)]
        public string IbuSistemPewarisan { get; set; }
        [Required]
        [Display(Name = "Berapa luas lahan yang dimiliki orangtua anda sebelum diwariskan kepada anda")]
        [StringLength(1)]
        public string IbuLuasTanahSebelum { get; set; }
        [Required]
        [Display(Name = "Berapa luas lahan yang diwariskan kepada anda")]
        public int? IbuLuasTanahDiwariskan { get; set; }
        [Required]
        [Display(Name = "Tahun berapa tanah tersebut diwariskan kepada anda")]
        public int? IbuTahunDiwariskan { get; set; }
        [Required]
        [Display(Name = "Apa bentuk legalitas tanah yang diwariskan")]
        [StringLength(150)]
        public string IbuBentukLegalitas { get; set; }
        [Required]
        [Display(Name = "Dimana lokasi lahan warisan tersebut")]
        [StringLength(150)]
        public string IbuLokasiLahan { get; set; }
        [Required]
        [Display(Name = "Apa bentuk/fungsi lahan sebelum diwariskan kepada anda")]
        [StringLength(1)]
        public string IbuFungsiLahanSebelum { get; set; }
        [Required]
        [Display(Name = "Apa bentuk/fungsi lahan sesudah diwariskan kepada anda")]
        [StringLength(1)]
        public string IbuFungsiLahanSesudah { get; set; }
        [Required]
        [Display(Name = "Jika tanah warisan diusahakan maka hasil usahatani digunakan untuk apa")]
        [StringLength(1)]
        public string IbuHasilUsahaTani { get; set; }
        [Required]
        [Display(Name = "Apakah tanah warisan tersebut subur")]
        [StringLength(1)]
        public string IbuTanahWarisanSubur { get; set; }
        [Required]
        [Display(Name = "Tenaga kerja yang mengelola tanah warisan anda")]
        [StringLength(1)]
        public string IbuTenagaYangMengelola { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, berapa jumlah anggota keluarga yang bekerja")]
        public int? IbuAnggotaKeluargaYangBekerja { get; set; }
        [Required]
        [Display(Name = "Jika pekerja berasal dari keluarga, siapakah mereka dalam struktur ART")]
        [StringLength(150)]
        public string IbuStrukturArt { get; set; }

        [Required]
        [Display(Name = "Jika pekerja adalah buruh tani, berapa jumlah buruh tani yang bekerja")]
        public int? IbuJumlahBuruh { get; set; }
        [Required]
        [Display(Name = "Jika dikelola oleh buruh tani, dari mana asal buruh tani tersebut")]
        [StringLength(150)]
        public string IbuAsalBuruh { get; set; }
        [Required]
        [Display(Name = "Apakah anda pernah mengalihkan penguasaan/pemilikan tanah warisan tersebut kepada orang lain")]
        [StringLength(1)]
        public string IbuMengalihkanTanah { get; set; }
        [Required]
        [Display(Name = "Jika Ya, tahun berapa anda mengalihkan penguasaan/pemilikan tanah warisan tersebut")]
        public int? IbuTahunMengalihkan { get; set; }
        [Required]
        [Display(Name = "Jika Ya, apa bentuk transaksi pengalihan pemilikan lahan warisan yang anda lakukan")]
        [StringLength(1)]
        public string IbuTransaksiPengalihanPemilikan { get; set; }
        [Required]
        [Display(Name = "Kepada siapa anda melakukan pengalihan lahan tersebut")]
        [StringLength(1)]
        public string IbuKepadaSiapaPengalihan { get; set; }
        [Required]
        [Display(Name = "Apa alasan anda mengalihkan lahan warisan tersebut")]
        [StringLength(1)]
        public string IbuAlasanMengalihkan { get; set; }



        [ForeignKey(nameof(RespondenID))]
        [InverseProperty("TanahWaris")]
        public Responden Responden { get; set; }
    }
}
