using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Data
{
    public static class KelolaTanah
    {
        public static void InsertKelolaTanah(AgrariaSurveyContext context)
        {
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "1", Value = "Warisan Orangtua" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "2", Value = "Beli" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "3", Value = "Menyewa tanah dari pihak lain" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "4", Value = "Bagi Hasil dari tanah milik pihak lain" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "5", Value = "Tanah yang digadaikan oleh pihak lain" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "6", Value = "Hibah" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "7", Value = "Penduduk Lahan" });
            context.SaveChanges();
        }
    }
}
