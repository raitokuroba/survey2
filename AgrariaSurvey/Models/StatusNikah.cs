using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class StatusNikah
    {
        [Key]
        public int StatusNikahID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Status Nikah")]
        public string Value { get; set; }
    }
}
