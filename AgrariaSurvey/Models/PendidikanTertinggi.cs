using System.ComponentModel.DataAnnotations;


namespace AgrariaSurvey.Models
{
    public class PendidikanTertinggi
    {
        [Key]
        public int PendidikanTertinggiID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Pendidikan Tertinggi")]
        public string Value { get; set; }
    }
}
