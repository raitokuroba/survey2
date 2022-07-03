using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class Kelurahan
    {
        [Key]
        public int KelurahanID { get; set; }
        [StringLength(15)]
        public string Kode { get; set; }
        [StringLength(250)]
        [Display(Name = "Kelurahan")]
        public string Value { get; set; }
        [StringLength(10)]
        public string KodeKecamatan { get; set; }
    }
}
