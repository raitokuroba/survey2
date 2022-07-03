using System.ComponentModel.DataAnnotations;

namespace AgrariaSurvey.Models
{
    public class PemilikanTanah
    {
        [Key]
        public long PemilikanTanahID { get; set; }

        public long RespondenID { get; set; }

        public long NoTanah { get; set; }

        public double LuasTanah { get; set; }

        [StringLength(150)]
        public string KoordinatTanah { get; set; }

        [StringLength(150)]
        public string LokasiTanah { get; set; }

        [StringLength(3)]
        public string StatusTanah { get; set; }

        [StringLength(3)]
        public string BentukLegalitas { get; set; }

        [StringLength(3)]
        public string CaraPerolehanTanah { get; set; }

        [Display(Name = "Jagung")]
        public bool PalawijaJagung { get; set; }

        [Display(Name = "Ubi Kayu")]
        public bool PalawijaUbiKayu { get; set; }

        [Display(Name = "Kacang Tanah")]
        public bool PalawijaKacangTanah { get; set; }

        [Display(Name = "Ubi Jalar")]
        public bool PalawijaUbiJalar { get; set; }

        [Display(Name = "Lainnya")]
        public bool PalawijaLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string PalawijaLainnyaDetail { get; set; }

        [Display(Name = "Padi")]
        public bool PanganPadi { get; set; }

        [Display(Name = "Jagung")]
        public bool PanganJagung { get; set; }

        [Display(Name = "Lainnya")]
        public bool PanganLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string PanganLainnyaDetail { get; set; }

        [Display(Name = "Tebu")]
        public bool PerkebunanTebu { get; set; }

        [Display(Name = "Coklat")]
        public bool PerkebunanCoklat { get; set; }

        [Display(Name = "Karet")]
        public bool PerkebunanKaret { get; set; }

        [Display(Name = "Cengkih")]
        public bool PerkebunanCengkih { get; set; }

        [Display(Name = "Kopi")]
        public bool PerkebunanKopi { get; set; }

        [Display(Name = "Sawit")]
        public bool PerkebunanSawit { get; set; }

        [Display(Name = "Lainnya")]
        public bool PerkebunanLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string PerkebunanLainnyaDetail { get; set; }

        [Display(Name = "Jeruk")]
        public bool HortikulturJeruk { get; set; }

        [Display(Name = "Pisang")]
        public bool HortikulturPisang { get; set; }

        [Display(Name = "Alpukat")]
        public bool HortikulturAlpukat { get; set; }

        [Display(Name = "Rambutan")]
        public bool HortikulturRambutan { get; set; }

        [Display(Name = "Jambu Kristal")]
        public bool HortikulturJambuKristal { get; set; }

        [Display(Name = "Nanas")]
        public bool HortikulturNanas { get; set; }

        [Display(Name = "Duren")]
        public bool HortikulturDuren { get; set; }

        [Display(Name = "Kelengkeng")]
        public bool HortikulturKelengkeng { get; set; }

        [Display(Name = "Buah Naga")]
        public bool HortikulturBuahNaga { get; set; }

        [Display(Name = "Semangka")]
        public bool HortikulturSemangka { get; set; }

        [Display(Name = "Lainnya")]
        public bool HortikulturLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string HortikulturLainnyaDetail { get; set; }

        [Display(Name = "Cabai")]
        public bool HortikulturSayurCabai { get; set; }

        [Display(Name = "Tomat")]
        public bool HortikulturSayurTomat { get; set; }

        [Display(Name = "Terong")]
        public bool HortikulturSayurTerong { get; set; }

        [Display(Name = "Mentimun")]
        public bool HortikulturSayurMentimun { get; set; }

        [Display(Name = "Bawang Merah")]
        public bool HortikulturSayurBawangMerah { get; set; }

        [Display(Name = "Bawang Putih")]
        public bool HortikulturSayurBawangPutih { get; set; }

        [Display(Name = "Kacang Panjang")]
        public bool HortikulturSayurKacangPanjang { get; set; }

        [Display(Name = "Lainnya")]
        public bool HortikulturSayurLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string HortikulturSayurLainnyaDetail { get; set; }

        [Display(Name = "Sengon")]
        public bool TegakanKayuSengon { get; set; }

        [Display(Name = "Kaliandra")]
        public bool TegakanKayuKaliandra { get; set; }

        [Display(Name = "Meranti")]
        public bool TegakanKayuMeranti { get; set; }

        [Display(Name = "Jabon")]
        public bool TegakanKayuJabon { get; set; }

        [Display(Name = "Jati")]
        public bool TegakanKayuJati { get; set; }

        [Display(Name = "Lainnya")]
        public bool TegakanKayuLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string TegakanKayuLainnyaDetail { get; set; }

        [Display(Name = "Kunyit")]
        public bool ObatKunyit { get; set; }

        [Display(Name = "Temulawak")]
        public bool ObatTemulawak { get; set; }

        [Display(Name = "Kencur")]
        public bool ObatKencur { get; set; }

        [Display(Name = "Jahe")]
        public bool ObatJahe { get; set; }

        [Display(Name = "Sereh")]
        public bool ObatSereh { get; set; }

        [Display(Name = "Lainnya")]
        public bool ObatLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string ObatLainnyaDetail { get; set; }

        [Display(Name = "Rumput Gajah")]
        public bool PakanTernakRumputGajah { get; set; }

        [Display(Name = "Rumput Lapang")]
        public bool PakanTernakRumputLapang { get; set; }

        [Display(Name = "Kacang Tanah")]
        public bool PakanTernakKacangTanah { get; set; }

        [Display(Name = "Legume")]
        public bool PakanTernakLegume { get; set; }

        [Display(Name = "Lainnya")]
        public bool PakanTernakLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string PakanTernakLainnyaDetail { get; set; }

        [Display(Name = "Sapi")]
        public bool PeternakanSapi { get; set; }

        [Display(Name = "Domba")]
        public bool PeternakanDomba { get; set; }

        [Display(Name = "Bebek")]
        public bool PeternakanBebek { get; set; }

        [Display(Name = "Kambing")]
        public bool PeternakanKambing { get; set; }

        [Display(Name = "Ayam")]
        public bool PeternakanAyam { get; set; }

        [Display(Name = "Lainnya")]
        public bool PeternakanLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string PeternakanLainnyaDetail { get; set; }

        [Display(Name = "Lele")]
        public bool PerikananLele { get; set; }

        [Display(Name = "Bandeng")]
        public bool PerikananBandeng { get; set; }

        [Display(Name = "Nila")]
        public bool PerikananNila { get; set; }

        [Display(Name = "Lainnya")]
        public bool PerikananLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string PerikananLainnyaDetail { get; set; }

        [Display(Name = "Rumah saja")]
        public bool RumahRumahSaja { get; set; }

        [Display(Name = "Rumah dan toko")]
        public bool RumahRumahDanToko { get; set; }

        [Display(Name = "Rumah, toko, dan bengkel")]
        public bool RumahRumahTokoDanBengkel { get; set; }

        [Display(Name = "Rumah, pekarangan, dan bengkel")]
        public bool RumahRumahPekaranganDanBengkel { get; set; }

        [Display(Name = "Rumah dan pekarangan")]
        public bool RumahRumahDanPekarangan { get; set; }

        [Display(Name = "Rumah dan bengkel")]
        public bool RumahRumahDanBengkel { get; set; }

        [Display(Name = "Rumah, pekarangan, dan toko")]
        public bool RumahRumahPekaranganDanToko { get; set; }

        [Display(Name = "Rumah, pekarangan, bengkel, dan toko")]
        public bool RumahRumahPekaranganBengkelDanToko { get; set; }

        [Display(Name = "Lainnya")]
        public bool RumahLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string RumahLainnyaDetail { get; set; }

        [Display(Name = "Tambang pasir")]
        public bool TambangTambangPasir { get; set; }

        [Display(Name = "Galian batu C")]
        public bool TambangGalianBatuC { get; set; }

        [Display(Name = "Timah")]
        public bool TambangTimah { get; set; }

        [Display(Name = "Batubara")]
        public bool TambangBatubara { get; set; }

        [Display(Name = "Lainnya")]
        public bool TambangLainnya { get; set; }

        [Display(Name = "Sebutkan")]
        [StringLength(150)]
        public string TambangLainnyaDetail { get; set; }

        [StringLength(3)]
        [Display(Name = "Pola Tanam")]
        public string PolaTanam { get; set; }

        [StringLength(3)]
        [Display(Name = "Sebutkan")]
        public string PolaTanamDetail { get; set; }

        [StringLength(3)]
        [Display(Name = "Mekanisme Pengelolaan Tanah")]
        public string MekanismePengelolaanTanah { get; set; }

        [Display(Name = "Jarak Lahan/Tanah dari Rumah")]
        public double JarakLahanTanahDariRumah { get; set; }

        [StringLength(150)]
        [Display(Name = "Siapa Pemilik Tanah")]
        public string PemilikTanah { get; set; }

        [StringLength(150)]
        [Display(Name = "Siapa Pengelola Tanah")]
        public string PengelolaTanah { get; set; }
    }
}
