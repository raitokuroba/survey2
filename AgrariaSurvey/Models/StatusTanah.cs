using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class StatusTanah
    {
        [Key]
        public int StatusTanahID { get; set; }
        [StringLength(5)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "StatusTanah")]
        public string Value { get; set; }
        
    }
}
