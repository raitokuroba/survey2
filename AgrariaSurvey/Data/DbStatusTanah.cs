using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Data
{
    public static class DbStatusTanah
    {
        public static void InsertStatusTanah(AgrariaSurveyContext context)
        {
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "1", Value = "Milik Sendiri" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "2", Value = "Nyewa" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "3", Value = "Sewakan" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "4", Value = "Bagi Hasil Milik" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "5", Value = "Bagi Hasil Kelola" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "6", Value = "Gadai" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "7", Value = "Ngegadein" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "8", Value = "Kawasan Hutan" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "9", Value = "Tanah Negara" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "10", Value = "Tanah Adat" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "11", Value = "Tanah Milik Desa" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "12", Value = "Tanah Komunal" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "13", Value = "Kemitraan" });
            context.SaveChanges();
            context.StatusTanah.Add(new Models.StatusTanah { Kode = "14", Value = "Lainnya. Sebutkan:" });
            context.SaveChanges();
        }
    }
}
