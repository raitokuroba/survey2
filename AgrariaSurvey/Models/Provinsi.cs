using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Provinsi
    {
        [Key]
        public int ProvinsiID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Provinsi")]
        public string Value { get; set; }
    }
}
