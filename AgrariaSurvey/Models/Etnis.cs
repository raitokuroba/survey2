using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Etnis
    {
        [Key]
        public int EtnisID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Etnis")]
        public string Value { get; set; }
    }
}
