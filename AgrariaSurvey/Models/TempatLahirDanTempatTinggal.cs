using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class TempatLahirDanTempatTinggal
    {
        [Key]
        public int TempatLahirDanTempatTinggalID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Tempat Lahir Dan Tempat Tinggal")]
        public string Value { get; set; }
    }
}
