using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Data
{
    public static class DbEtnis
    {
        public static void InsertEtnis(AgrariaSurveyContext context)
        {
            context.Etnis.Add(new Models.Etnis { Kode = "1", Value = "Jawa" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "2", Value = "Sunda" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "3", Value = "Melayu" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "4", Value = "Madura" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "5", Value = "Baduy" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "6", Value = "Batak" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "7", Value = "Sasak" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "8", Value = "Sumbawa" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "9", Value = "Bima" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "10", Value = "Bugis" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "11", Value = "Makassar" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "12", Value = "Toraja" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "13", Value = "Gorontalo" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "14", Value = "Minahasa" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "15", Value = "Dayak" });
            
            context.Etnis.Add(new Models.Etnis { Kode = "999", Value = "Lainnya" });
            context.SaveChanges();
        }
    }
}
