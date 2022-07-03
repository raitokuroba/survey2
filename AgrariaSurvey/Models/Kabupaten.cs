using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Kabupaten
    {
        [Key]
        public int KabupatenID { get; set; }
        [StringLength(5)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Kabupaten")]
        public string Value { get; set; }
        [StringLength(5)]
        public string KodeProvinsi { get; set; }
    }
}
