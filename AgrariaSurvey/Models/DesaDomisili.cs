using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class DesaDomisili
    {
        [Key]
        public int DesaDomisiliID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "Desa Domisili")]
        public string Value { get; set; }
    }
}
