using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class BahasaSehariHari
    {
        [Key]
        public int BahasaSehariHariID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Bahasa Sehari - Hari")]
        public string Value { get; set; }
    }
}
