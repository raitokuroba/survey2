using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AgrariaSurvey.Models
{
    public partial class SistemPewarisan
    {
        [Key]
        [Column("SistemPewarisanID")]
        public int SistemPewarisanId { get; set; }
        [StringLength(3)]
        public string Kode { get; set; }
        [StringLength(250)]
        public string Value { get; set; }
    }
}
