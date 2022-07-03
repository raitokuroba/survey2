using System.Linq;

namespace AgrariaSurvey.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AgrariaSurveyContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.HubunganDenganKepalaKeluarga.Any())
            {
                return;
            }

            #region A1 Pulaus
            context.Pulaus.Add(new Models.Pulau { Kode = "1", Value = "Sumatra" });
            context.Pulaus.Add(new Models.Pulau { Kode = "2", Value = "Jawa" });
            context.Pulaus.Add(new Models.Pulau { Kode = "3", Value = "Bali" });
            context.Pulaus.Add(new Models.Pulau { Kode = "4", Value = "Nusa Tenggara" });
            context.Pulaus.Add(new Models.Pulau { Kode = "5", Value = "Kalimantan" });
            context.Pulaus.Add(new Models.Pulau { Kode = "6", Value = "Sulawesi" });
            context.Pulaus.Add(new Models.Pulau { Kode = "7", Value = "Maluku" });
            context.Pulaus.Add(new Models.Pulau { Kode = "8", Value = "Papua" });
            context.SaveChanges();
            #endregion

            #region A2 Provinsi
            context.Provinsi.Add(new Models.Provinsi { Kode = "11", Value = "NANGGROE ACEH DARUSSALAM" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "12", Value = "SUMATERA UTARA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "13", Value = "SUMATERA BARAT" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "14", Value = "RIAU" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "15", Value = "JAMBI" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "16", Value = "SUMATERA SELATAN" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "17", Value = "BENGKULU" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "18", Value = "LAMPUNG" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "19", Value = "KEP. BANGKA BELITUNG" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "21", Value = "KEPULAUAN RIAU" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "31", Value = "DKI JAKARTA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "32", Value = "JAWA BARAT" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "33", Value = "JAWA TENGAH" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "34", Value = "DAISTA YOGYAKARTA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "35", Value = "JAWA TIMUR" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "36", Value = "BANTEN" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "51", Value = "BALI" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "52", Value = "NUSA TENGGARA BARAT" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "53", Value = "NUSA TENGGARA TIMUR" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "61", Value = "KALIMANTAN BARAT" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "62", Value = "KALIMANTAN TENGAH" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "63", Value = "KALIMANTAN SELATAN" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "64", Value = "KALIMANTAN TIMUR" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "65", Value = "KALIMANTAN UTARA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "71", Value = "SULAWESI UTARA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "72", Value = "SULAWESI TENGAH" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "73", Value = "SULAWESI SELATAN" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "74", Value = "SULAWESI TENGGARA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "75", Value = "GORONTALO" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "76", Value = "SULAWESI BARAT" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "81", Value = "MALUKU" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "82", Value = "MALUKU UTARA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "91", Value = "PAPUA" });
            context.Provinsi.Add(new Models.Provinsi { Kode = "92", Value = "PAPUA BARAT" });
            context.SaveChanges();
            #endregion

            #region A3 Kota
            Kota.InsertKota(context);
            #endregion

            #region A4 Kecamatan
            DbKecamatan.InsertKecamatan(context);
            #endregion

            #region A5 Kelurahan
            DbKelurahan.InsertKelurahan(context);
            DbKelurahan2.InsertKelurahan(context);
            DbKelurahan3.InsertKelurahan(context);
            DbKelurahan4.InsertKelurahan(context);
            DbKelurahan5.InsertKelurahan(context);
            DbKelurahan6.InsertKelurahan(context);
            DbKelurahan7.InsertKelurahan(context);
            DbKelurahan8.InsertKelurahan(context);
            DbKelurahan9.InsertKelurahan(context);
            DbKelurahan91.InsertKelurahan(context);
            #endregion

            #region D3 DesaDomisilis
            context.DesaDomisilis.Add(new Models.DesaDomisili { Kode = "1", Value = "Tahun kedatangan Ayah dari suami ke Desa ini:" });
            context.DesaDomisilis.Add(new Models.DesaDomisili { Kode = "2", Value = "Alasan Ayah dari suami datang ke Desa Ini:" });
            context.SaveChanges();
            #endregion

            #region E3 HubunganDenganKepalaKeluarga
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "1", Value = "Kepala Keluarga" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "2", Value = "Suami" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "3", Value = "Istri" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "4", Value = "Anak kandung" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "5", Value = "Menantu" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "6", Value = "Cucu" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "7", Value = "Keponakan" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "8", Value = "Orangtua" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "9", Value = "Mertua" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "10", Value = "Ipar" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "11", Value = "Kakek/Nenek" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "12", Value = "Saudara (Adik/Kakak)" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "13", Value = "Pembantu rumah tangga" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "14", Value = "Bukan kerabat" });
            context.HubunganDenganKepalaKeluarga.Add(new Models.HubunganDenganKepalaKeluarga { Kode = "15", Value = "Lainnya" });
            context.SaveChanges();
            #endregion

            #region  E6 StatusNikah
            context.StatusNikah.Add(new Models.StatusNikah { Kode = "1", Value = "Menikah dengan satu orang" });
            context.StatusNikah.Add(new Models.StatusNikah { Kode = "2", Value = "Menikah dengan lebih dari satu orang" });
            context.StatusNikah.Add(new Models.StatusNikah { Kode = "3", Value = "Hidup terpisah" });
            context.StatusNikah.Add(new Models.StatusNikah { Kode = "4", Value = "Cerai" });
            context.StatusNikah.Add(new Models.StatusNikah { Kode = "5", Value = "Janda/Duda" });
            context.StatusNikah.Add(new Models.StatusNikah { Kode = "6", Value = "Belum menikah" });
            context.SaveChanges();
            #endregion

            #region E7 Etnis
            DbEtnis.InsertEtnis(context);
            #endregion

            #region E8
            //Formulir E8
            DbBahasa.InsertBahasa(context);
            context.SaveChanges();
            #endregion

            #region E9 PendidikanTertinggi
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "1", Value = "TIDAK/BELUM SEKOLAH" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "2", Value = "Tidak Lulus SD / Sederajat" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "3", Value = "SD / Sederajat" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "4", Value = "Tidak Lulus SMP / Sederajat" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "5", Value = "SMP / Sederajat" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "6", Value = "Tidak lulus SMA / Sederajat" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "7", Value = "SMA / Sederajat" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "8", Value = "Diploma / S1" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "9", Value = "S2/S3" });
            context.PendidikanTertinggi.Add(new Models.PendidikanTertinggi { Kode = "10", Value = "Tidak Tahu" });
            context.SaveChanges();
            #endregion

            #region E10 TempatLahirDanTempatTinggal
            context.TempatLahirDanTempatTinggal.Add(new Models.TempatLahirDanTempatTinggal { Kode = "1", Value = "Desa yang sama dengan tempat tinggal sekarang" });
            context.TempatLahirDanTempatTinggal.Add(new Models.TempatLahirDanTempatTinggal { Kode = "2", Value = "Desa beda, kecamatan sama  dengan tempat tinggal sekarang. Nama Desa:" });
            context.TempatLahirDanTempatTinggal.Add(new Models.TempatLahirDanTempatTinggal { Kode = "3", Value = "Kecamatan beda dengan tempat tinggal sekarang. Nama kecamatan:" });
            context.TempatLahirDanTempatTinggal.Add(new Models.TempatLahirDanTempatTinggal { Kode = "4", Value = "Kabupaten beda dengan tempat tinggal sekarang. Nama kabupaten:" });
            context.TempatLahirDanTempatTinggal.Add(new Models.TempatLahirDanTempatTinggal { Kode = "5", Value = "Provinsi beda dengan tempat tinggal sekarang. Nama provinsi:" });
            context.TempatLahirDanTempatTinggal.Add(new Models.TempatLahirDanTempatTinggal { Kode = "6", Value = "Negara beda dengan tempat tinggal sekarang. Nama negara:" });
            context.SaveChanges();
            #endregion

            #region E12 PekerjaanUtamaDanPekerjaanSampingan
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "1", Value = "Petani" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "2", Value = "Buruh tani" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "3", Value = "Wiraswasta (bengkel, UKM, dsb)" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "4", Value = "PNS / ASN" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "5", Value = "Pegawai / Buruh Pabrik" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "6", Value = "Peternak" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "7", Value = "Pedagang" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "8", Value = "Buruh Bangunan (tukang)" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "9", Value = "Jasa ojek, sopir, dll" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "10", Value = "Makelar" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "11", Value = "Broker" });
            context.PekerjaanUtamaDanPekerjaanSampingan.Add(new Models.PekerjaanUtamaDanPekerjaanSampingan { Kode = "12", Value = "Lainnya. Sebutkan :" });
            context.SaveChanges();
            #endregion
            //Formulir F5
            DbStatusTanah.InsertStatusTanah(context);

            //Formulis F5


            #region F6
            Legal.InsertLegalitas(context);
            #endregion

            #region F7
            DbPerolehanTanah.InsertPerolehanTanah(context);
            #endregion

            #region F10
            KelolaTanah.InsertKelolaTanah(context);
            #endregion


            DbStatusTanah.InsertStatusTanah(context);

            //Formulis F5
            DbStatusTanah.InsertStatusTanah(context);




        }
    }
}
