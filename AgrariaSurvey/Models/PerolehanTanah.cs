using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class PerolehanTanah
    {
        [Key]
        public int PerolehanTanahID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "Perolehan Tanah")]
        public string Value { get; set; }
    }
}
