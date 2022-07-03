using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrariaSurvey.Models
{
    public class HubunganDenganKepalaKeluarga
    {
        [Key]
        public int HubunganDenganKepalaKeluargaID { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(100)]
        [Display(Name = "Hubungan Dengan Kepala Keluarga")]
        public string Value { get; set; }
    }
}
