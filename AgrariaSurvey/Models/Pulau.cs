using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Pulau
    {
        [Key]
        public int PulauID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Pulau")]
        public string Value { get; set; }
    }
}
