using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models.Binding
{
    public class BIdentitasKeluargaRumahTangga
    {
        public long IdentitasKeluargaRumahTanggaID { get; set; }
        public long RespondenID { get; set; }
        [Required]
        [Display(Name = "No KK (Kartu Keluarga)")]
        [StringLength(20)]
        public string NoKK { get; set; }
        public IFormFile FotoKK { get; set; }
        [Required]
        [Display(Name = "Nama Kepala Keluarga")]
        [StringLength(150)]
        public string NamaKepalaKeluarga { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Jenis Kelamin Kepala Keluarga")]
        public string JenisKelaminKepalaKeluarga { get; set; }
        [Required]
        [Display(Name = "Jumlah Anggota Rumah Tangga")]
        public int JumlahAnggotaRumahTangga { get; set; }
        [Required]
        [Display(Name = "Jumlah Keluarga Dalam Rumah Tangga")]
        public int JumlahKeluargaDalamRumahTangga { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Nama Tulang Punggung Rumah Tangga")]
        public string NamaTulangPunggungRumahTangga { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Jenis Kelamin Tulang Punggung Rumah Tangga")]
        public string JenisKelaminTulangPunggungRumahTangga { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Status Tulang Punggung Rumah Tangga Dalam Keluarga")]
        public string StatusTulangPunggungRumahTanggaDalamKeluarga { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Apakah Tulang Punggung Keluarga Tinggal Menetap Di Rumah Responden")]
        public string ApakahTulangPunggungKeluargaTinggalMenetapDiRumahResponden { get; set; }
    }
}
