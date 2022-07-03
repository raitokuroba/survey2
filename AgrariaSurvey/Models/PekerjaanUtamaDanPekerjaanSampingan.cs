using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class PekerjaanUtamaDanPekerjaanSampingan
    {
        [Key]
        public int PekerjaanUtamaDanPekerjaanSampinganID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Pekerjaan Utama Dan Pekerjaan Sampingan")]
        public string Value { get; set; }
    }
}
