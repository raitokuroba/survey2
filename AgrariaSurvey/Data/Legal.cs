using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Data
{
    public static class Legal
    {
        public static void InsertLegalitas(AgrariaSurveyContext context)
        {
            context.legalitas.Add(new Models.Legalitas { Kode = "1", Value = "SHM (Sertifikat Hak Milik)" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "2", Value = "Letter C" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "3", Value = "Segel" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "4", Value = "Girik" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "5", Value = "Kuitansi/Akta jual beli bermaterai" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "6", Value = "Surat Keterangan" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "7", Value = "Tidak memiliki legalitas" });
            context.SaveChanges();
            context.legalitas.Add(new Models.Legalitas { Kode = "8", Value = "Lainnya:" });
            context.SaveChanges();
        }
    }
}
