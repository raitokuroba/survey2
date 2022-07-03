using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrariaSurvey.Models
{
    public class Responden
    {
        //r1
        //public Responden()
        //{
        //    AnggotaRumahTangga = new HashSet<AnggotaRumahTangga>();
        //}

        [Key]
        public long RespondenID { get; set; }

        #region A. AlamatResponden
        [Required]
        [StringLength(5, ErrorMessage = "Please Select Pulau")]
        public string Pulau { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Please Select Provinsi")]
        public string Provinsi { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "Please Select Kabupaten / Kota")]
        [Display(Name = "Kabupaten / Kota")]
        public string KabupatenKota { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Please Select Kecamatan")]
        public string Kecamatan { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Please Select Desa / Kelurahan")]
        [Display(Name = "Desa / Kelurahan")]
        public string DesaKelurahan { get; set; }
        [StringLength(50)]
        public string Dusun { get; set; }
        [StringLength(3)]
        public string RT { get; set; }
        [StringLength(3)]
        public string RW { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Nama Jalan")]
        public string NamaJalan { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Nomor Rumah")]
        public string NomorRumah { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Koordinat Alamat Rumah")]
        public string KoordinatAlamatRumah { get; set; }
        #endregion

        [InverseProperty("Responden")]
        public IdentitasResponden IdentitasResponden { get; set; }
        [InverseProperty("Responden")]
        public IdentitasKeluargaRumahTangga IdentitasKeluargaRumahTangga { get; set; }

        [InverseProperty("Responden")]
        public ICollection<AnggotaRumahTangga> AnggotaRumahTangga { get; set; }
        [InverseProperty("Responden")]
        public TanahWaris TanahWaris { get; set; }

        [InverseProperty("Responden")]
        public RiwayatBermukim RiwayatBermukim { get; set; }
        [InverseProperty("Responden")]
        public BeliTanah BeliTanah { get; set; }

    }
}
