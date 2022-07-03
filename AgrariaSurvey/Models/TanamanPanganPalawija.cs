using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class TanamanPanganPalawija
    {
        [Key]
        public int TanamanPanganPalawijaID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "Tanaman Pangan & Palawija")]
        public string Value { get; set; }
    }
}
