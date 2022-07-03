using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgrariaSurvey.Models
{
    public class IdentitasResponden
    {
        [Key]
        public long IdentitasRespondenID { get; set; }
        public long RespondenID { get; set; }
        [Required]
        [Display(Name = "Nomor Responden")]
        public long NomorResponden { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Nama Responden")]
        public string NamaResponden { get; set; }
        [Required]
        [StringLength(1)]
        [Display(Name = "Jenis Kelamin Responden")]
        public string JenisKelaminResponden { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "No HP Responden")]
        public string NoHpResponden { get; set; }

        [ForeignKey(nameof(RespondenID))]
        [InverseProperty("IdentitasResponden")]
        public Responden Responden { get; set; }
    }
}
