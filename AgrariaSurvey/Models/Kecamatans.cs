using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Kecamatans
    {
        [Key]
        public int KecamatanID { get; set; }
        [StringLength(8)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Kecamatan")]
        public string Value { get; set; }
        [StringLength(5)]
        public string KodeKota { get; set; }
    }
}
