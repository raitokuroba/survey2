using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Data
{
    public static class DbJenisPenggunaanTanah
    {
        public static void InsertJenisPenggunaanTanah(AgrariaSurveyContext context)
        {
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "1", Value = "Tanaman Pangan & Palawija" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "2", Value = "Tanaman Perkebunan" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "3", Value = "Tanaman Hortikultur buah" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "4", Value = "Tanaman Hortikultur Sayur" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "5", Value = "Tanaman Tegakan Kayu" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "6", Value = "Tanaman Obat(empon - empon)" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "7", Value = "Tanaman Pakan Ternak" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "8", Value = "Peternakan" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "9", Value = "Perikanan" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "10", Value = "Rumah" });
            context.SaveChanges();
            context.PerolehanTanah.Add(new Models.PerolehanTanah { Kode = "11", Value = "Tambang" });
            context.SaveChanges();

        }

        public static void InsertJenisPenggunaanTanahDetail(AgrariaSurveyContext context)
        {

        }
    }
}
