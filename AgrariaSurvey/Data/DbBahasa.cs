using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Data
{
    public static class DbBahasa
    {
        public static void InsertBahasa(AgrariaSurveyContext context)
        {
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "1", Value = "Indonesia" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "2", Value = "Jawa" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "3", Value = "Sunda" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "4", Value = "Melayu" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "5", Value = "Madura" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "6", Value = "Baduy" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "7", Value = "Batak" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "8", Value = "Sasak" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "9", Value = "Sumbawa" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "10", Value = "Bima" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "11", Value = "Bugis" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "12", Value = "Makassar" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "13", Value = "Toraja" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "14", Value = "Gorontalo" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "15", Value = "Minahasa" });
            context.SaveChanges();
            context.BahasaSehariHari.Add(new Models.BahasaSehariHari { Kode = "999", Value = "Lainnya" });
            context.SaveChanges();
        }
    }
}
