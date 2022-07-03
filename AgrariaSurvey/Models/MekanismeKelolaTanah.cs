using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class MekanismeKelolaTanah
    {
        [Key]
        public int KelolaTanahID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "Kelola Tanah")]
        public string Value { get; set; }
    }
}
