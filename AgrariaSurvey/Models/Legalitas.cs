using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Legalitas
    {
        [Key]
        public int LegalitasID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "Legalitas")]
        public string Value { get; set; }
    }
}
