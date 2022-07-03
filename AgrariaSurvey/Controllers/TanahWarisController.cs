using AgrariaSurvey.Data;
using AgrariaSurvey.Models;
using AgrariaSurvey.Models.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Controllers
{
    [Authorize]

    public class TanahWarisController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public TanahWarisController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: IdentitasKeluargaRumahTanggas
        public async Task<IActionResult> Index()
        {
            var agrariaSurveyContext = _context.TanahWaris.Include(i => i.Responden);
            return View(await agrariaSurveyContext.ToListAsync());
        }

        // GET: IdentitasKeluargaRumahTanggas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TanahWaris = await _context.TanahWaris.Where(x => x.RespondenID == id).FirstOrDefaultAsync();

            ViewBag.RespondenID = id;

            return View(TanahWaris);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(long? id, TanahWaris TanahWaris)
        {
            if (id != TanahWaris.RespondenID)
            {
                return NotFound();
            }

            return RedirectToAction("Details", "RiwayatBermukims", new { id = TanahWaris.RespondenID });
        }



        // GET: IdentitasKeluargaRumahTanggas/Create
        public IActionResult Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = id;
            ViewBag.SistemPewarisan = new SelectList(_context.SistemPewarisan, "Kode", "Value");
            ViewBag.LuasTanahSebelum= new SelectList(_context.LuasTanahSebelum, "Kode", "Value");
            ViewBag.FungsiLahanSebelum= new SelectList(_context.FungsiLahanSebelum, "Kode", "Value");
            ViewBag.HasilUsahaTani= new SelectList(_context.HasilUsahaTani, "Kode", "Value");
            ViewBag.TanahWarisanSubur= new SelectList(_context.TanahWarisanSubur, "Kode", "Value");
            ViewBag.TenagaYangMengelola= new SelectList(_context.TenagaYangMengelola, "Kode", "Value");
            ViewBag.TransaksiPengalihanPemilikan= new SelectList(_context.TransaksiPengalihanPemilikan, "Kode", "Value");

            ViewBag.AlasanMengalihkan= new SelectList(_context.AlasanMengalihkan, "Kode", "Value");
            ViewBag.KepadaSiapaPengalihan = new SelectList(_context.KepadaSiapaPengalihan, "Kode", "Value");
            ViewBag.LuasTanahDiwariskan= new SelectList(_context.LuasTanahDiwariskan, "Kode", "Value");
            ViewBag.LokasiLahan= new SelectList(_context.LokasiLahan, "Kode", "Value");
            ViewBag.BentukLegalitas= new SelectList(_context.BentukLegalitas, "Kode", "Value");
            ViewBag.AnggotaKeluargaYangBekerja= new SelectList(_context.AnggotaKeluargaYangBekerja, "Kode", "Value");
            ViewBag.JumlahBuruh= new SelectList(_context.JumlahBuruh, "Kode", "Value");
             ViewBag.TempatLahirDanTempatTinggal = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value");
            ViewBag.legalitas = new SelectList(_context.legalitas, "Kode", "Value");
             ViewBag.HubunganDenganKepalaKeluarga = new SelectList(_context.HubunganDenganKepalaKeluarga, "Kode", "Value");
            return View();
        }

        // POST: IdentitasKeluargaRumahTanggas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TanahWaris TanahWaris)
        {
            if (ModelState.IsValid)
            {
               
                var data = await _context.TanahWaris.Where(x => x.RespondenID == TanahWaris.RespondenID).FirstOrDefaultAsync();

                if (data != null)
                {
                    //r1
                    //ViewBag.GFungsiLahanSebelum = new SelectList(_context.BahasaSehariHari, "Kode", "Value");
                    //ViewBag.GFungsiLahanSebelum = new SelectList(_context.BahasaSehariHari, "Kode", "Value");
                    //ViewBag.GFungsiLahanSebelum = new SelectList(_context.BahasaSehariHari, "Kode", "Value");
                    data.BapakMemilikiLahanWaris = TanahWaris.BapakMemilikiLahanWaris;
                    data.SistemPewarisan = TanahWaris.SistemPewarisan;
                    data.LuasTanahSebelum = TanahWaris.LuasTanahSebelum;
                    data.LuasTanahDiwariskan = TanahWaris.LuasTanahDiwariskan;
                    data.TahunDiwariskan = TanahWaris.TahunDiwariskan;
                    data.BentukLegalitas = TanahWaris.BentukLegalitas;
                    data.LokasiLahan = TanahWaris.LokasiLahan;
                    data.FungsiLahanSebelum = TanahWaris.FungsiLahanSebelum;
                    data.FungsiLahanSesudah = TanahWaris.FungsiLahanSesudah;
                    data.HasilUsahaTani = TanahWaris.HasilUsahaTani;
                    data.TanahWarisanSubur = TanahWaris.TanahWarisanSubur;
                    data.TenagaYangMengelola = TanahWaris.TenagaYangMengelola;
                    data.AnggotaKeluargaYangBekerja = TanahWaris.AnggotaKeluargaYangBekerja;
                    data.StrukturArt = TanahWaris.StrukturArt;
                    data.JumlahBuruh = TanahWaris.JumlahBuruh;
                    data.AsalBuruh = TanahWaris.AsalBuruh;
                    data.MengalihkanTanah = TanahWaris.MengalihkanTanah;
                    data.TahunMengalihkan = TanahWaris.TahunMengalihkan;
                    data.TransaksiPengalihanPemilikan = TanahWaris.TransaksiPengalihanPemilikan;
                    data.KepadaSiapaPengalihan = TanahWaris.KepadaSiapaPengalihan;
                    data.AlasanMengalihkan = TanahWaris.AlasanMengalihkan;
                    data.IbuMemilikiLahanWaris = TanahWaris.IbuMemilikiLahanWaris;
                    data.IbuSistemPewarisan = TanahWaris.IbuSistemPewarisan;
                    data.IbuLuasTanahSebelum = TanahWaris.IbuLuasTanahSebelum;
                    data.IbuLuasTanahDiwariskan = TanahWaris.IbuLuasTanahDiwariskan;
                    data.IbuTahunDiwariskan = TanahWaris.IbuTahunDiwariskan;
                    data.IbuBentukLegalitas = TanahWaris.IbuBentukLegalitas;
                    data.IbuLokasiLahan = TanahWaris.IbuLokasiLahan;
                    data.IbuFungsiLahanSebelum = TanahWaris.IbuFungsiLahanSebelum;
                    data.IbuFungsiLahanSesudah = TanahWaris.IbuFungsiLahanSesudah;
                    data.IbuHasilUsahaTani = TanahWaris.IbuHasilUsahaTani;
                    data.IbuTanahWarisanSubur = TanahWaris.IbuTanahWarisanSubur;
                    data.IbuTenagaYangMengelola = TanahWaris.IbuTenagaYangMengelola;
                    data.IbuAnggotaKeluargaYangBekerja = TanahWaris.IbuAnggotaKeluargaYangBekerja;
                    data.IbuStrukturArt = TanahWaris.IbuStrukturArt;
                    data.IbuJumlahBuruh = TanahWaris.IbuJumlahBuruh;
                    data.IbuAsalBuruh = TanahWaris.IbuAsalBuruh;
                    data.IbuMengalihkanTanah = TanahWaris.IbuMengalihkanTanah;
                    data.IbuTahunMengalihkan = TanahWaris.IbuTahunMengalihkan;
                    data.IbuTransaksiPengalihanPemilikan = TanahWaris.IbuTransaksiPengalihanPemilikan;
                    data.IbuKepadaSiapaPengalihan = TanahWaris.IbuKepadaSiapaPengalihan;
                    data.IbuAlasanMengalihkan = TanahWaris.IbuAlasanMengalihkan;
                }
                else
                {
                    data = new TanahWaris()
                    {
                     RespondenID = TanahWaris.RespondenID,
                     BapakMemilikiLahanWaris = TanahWaris.BapakMemilikiLahanWaris,
                     SistemPewarisan = TanahWaris.SistemPewarisan,
                     LuasTanahSebelum = TanahWaris.LuasTanahSebelum,
                     LuasTanahDiwariskan = TanahWaris.LuasTanahDiwariskan,
                     TahunDiwariskan = TanahWaris.TahunDiwariskan,
                     BentukLegalitas = TanahWaris.BentukLegalitas,
                     LokasiLahan = TanahWaris.LokasiLahan,
                     FungsiLahanSebelum = TanahWaris.FungsiLahanSebelum,
                     FungsiLahanSesudah = TanahWaris.FungsiLahanSesudah,
                     HasilUsahaTani = TanahWaris.HasilUsahaTani,
                     TanahWarisanSubur = TanahWaris.TanahWarisanSubur,
                     TenagaYangMengelola = TanahWaris.TenagaYangMengelola,
                     AnggotaKeluargaYangBekerja = TanahWaris.AnggotaKeluargaYangBekerja,
                     StrukturArt = TanahWaris.StrukturArt,
                     JumlahBuruh = TanahWaris.JumlahBuruh,
                     AsalBuruh = TanahWaris.AsalBuruh,
                     MengalihkanTanah = TanahWaris.MengalihkanTanah,
                     TahunMengalihkan = TanahWaris.TahunMengalihkan,
                     TransaksiPengalihanPemilikan = TanahWaris.TransaksiPengalihanPemilikan,
                     KepadaSiapaPengalihan = TanahWaris.KepadaSiapaPengalihan,
                     AlasanMengalihkan = TanahWaris.AlasanMengalihkan,
                     IbuMemilikiLahanWaris = TanahWaris.IbuMemilikiLahanWaris,
                     IbuSistemPewarisan = TanahWaris.IbuSistemPewarisan,
                     IbuLuasTanahSebelum = TanahWaris.IbuLuasTanahSebelum,
                     IbuLuasTanahDiwariskan = TanahWaris.IbuLuasTanahDiwariskan,
                     IbuTahunDiwariskan = TanahWaris.IbuTahunDiwariskan,
                     IbuBentukLegalitas = TanahWaris.IbuBentukLegalitas,
                     IbuLokasiLahan = TanahWaris.IbuLokasiLahan,
                     IbuFungsiLahanSebelum = TanahWaris.IbuFungsiLahanSebelum,
                     IbuFungsiLahanSesudah = TanahWaris.IbuFungsiLahanSesudah,
                     IbuHasilUsahaTani = TanahWaris.IbuHasilUsahaTani,
                     IbuTanahWarisanSubur = TanahWaris.IbuTanahWarisanSubur,
                     IbuTenagaYangMengelola = TanahWaris.IbuTenagaYangMengelola,
                     IbuAnggotaKeluargaYangBekerja = TanahWaris.IbuAnggotaKeluargaYangBekerja,
                     IbuStrukturArt = TanahWaris.IbuStrukturArt,
                     IbuJumlahBuruh = TanahWaris.IbuJumlahBuruh,
                     IbuAsalBuruh = TanahWaris.IbuAsalBuruh,
                     IbuMengalihkanTanah = TanahWaris.IbuMengalihkanTanah,
                     IbuTahunMengalihkan = TanahWaris.IbuTahunMengalihkan,
                     IbuTransaksiPengalihanPemilikan = TanahWaris.IbuTransaksiPengalihanPemilikan,
                     IbuKepadaSiapaPengalihan = TanahWaris.IbuKepadaSiapaPengalihan,
                     IbuAlasanMengalihkan = TanahWaris.IbuAlasanMengalihkan,
                };
                    await _context.AddAsync(data);
                }

                await _context.SaveChangesAsync();

                //return RedirectToAction("Create", "RiwayatBermukims", new { id = TanahWaris.RespondenID });
                return RedirectToAction("Create", "BeliTanahs", new { id = TanahWaris.RespondenID });
            }

            ViewBag.RespondenID = TanahWaris.RespondenID;
            return View(TanahWaris);
        }

        // GET: IdentitasKeluargaRumahTanggas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TanahWaris = await _context.TanahWaris.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();

            ViewBag.RespondenID = id;
            return View(TanahWaris);
        }

        // POST: IdentitasKeluargaRumahTanggas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, TanahWaris TanahWaris)
        {
            if (id != TanahWaris.RespondenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _context.TanahWaris.Where(x => x.RespondenID == TanahWaris.RespondenID).FirstOrDefaultAsync();

                    if (data != null)
                    {
                        data.BapakMemilikiLahanWaris = TanahWaris.BapakMemilikiLahanWaris;
                        data.SistemPewarisan = TanahWaris.SistemPewarisan;
                        data.LuasTanahSebelum = TanahWaris.LuasTanahSebelum;
                        data.LuasTanahDiwariskan = TanahWaris.LuasTanahDiwariskan;
                        data.TahunDiwariskan = TanahWaris.TahunDiwariskan;
                        data.BentukLegalitas = TanahWaris.BentukLegalitas;
                        data.LokasiLahan = TanahWaris.LokasiLahan;
                        data.FungsiLahanSebelum = TanahWaris.FungsiLahanSebelum;
                        data.FungsiLahanSesudah = TanahWaris.FungsiLahanSesudah;
                        data.HasilUsahaTani = TanahWaris.HasilUsahaTani;
                        data.TanahWarisanSubur = TanahWaris.TanahWarisanSubur;
                        data.TenagaYangMengelola = TanahWaris.TenagaYangMengelola;
                        data.AnggotaKeluargaYangBekerja = TanahWaris.AnggotaKeluargaYangBekerja;
                        data.StrukturArt = TanahWaris.StrukturArt;
                        data.JumlahBuruh = TanahWaris.JumlahBuruh;
                        data.AsalBuruh = TanahWaris.AsalBuruh;
                        data.MengalihkanTanah = TanahWaris.MengalihkanTanah;
                        data.TahunMengalihkan = TanahWaris.TahunMengalihkan;
                        data.TransaksiPengalihanPemilikan = TanahWaris.TransaksiPengalihanPemilikan;
                        data.KepadaSiapaPengalihan = TanahWaris.KepadaSiapaPengalihan;
                        data.AlasanMengalihkan = TanahWaris.AlasanMengalihkan;
                        data.IbuMemilikiLahanWaris = TanahWaris.IbuMemilikiLahanWaris;
                        data.IbuSistemPewarisan = TanahWaris.IbuSistemPewarisan;
                        data.IbuLuasTanahSebelum = TanahWaris.IbuLuasTanahSebelum;
                        data.IbuLuasTanahDiwariskan = TanahWaris.IbuLuasTanahDiwariskan;
                        data.IbuTahunDiwariskan = TanahWaris.IbuTahunDiwariskan;
                        data.IbuBentukLegalitas = TanahWaris.IbuBentukLegalitas;
                        data.IbuLokasiLahan = TanahWaris.IbuLokasiLahan;
                        data.IbuFungsiLahanSebelum = TanahWaris.IbuFungsiLahanSebelum;
                        data.IbuFungsiLahanSesudah = TanahWaris.IbuFungsiLahanSesudah;
                        data.IbuHasilUsahaTani = TanahWaris.IbuHasilUsahaTani;
                        data.IbuTanahWarisanSubur = TanahWaris.IbuTanahWarisanSubur;
                        data.IbuTenagaYangMengelola = TanahWaris.IbuTenagaYangMengelola;
                        data.IbuAnggotaKeluargaYangBekerja = TanahWaris.IbuAnggotaKeluargaYangBekerja;
                        data.IbuStrukturArt = TanahWaris.IbuStrukturArt;
                        data.IbuJumlahBuruh = TanahWaris.IbuJumlahBuruh;
                        data.IbuAsalBuruh = TanahWaris.IbuAsalBuruh;
                        data.IbuMengalihkanTanah = TanahWaris.IbuMengalihkanTanah;
                        data.IbuTahunMengalihkan = TanahWaris.IbuTahunMengalihkan;
                        data.IbuTransaksiPengalihanPemilikan = TanahWaris.IbuTransaksiPengalihanPemilikan;
                        data.IbuKepadaSiapaPengalihan = TanahWaris.IbuKepadaSiapaPengalihan;
                        data.IbuAlasanMengalihkan = TanahWaris.IbuAlasanMengalihkan;
                    }
                    else
                    {
                        data = new TanahWaris()
                        {
                            RespondenID = TanahWaris.RespondenID,
                            BapakMemilikiLahanWaris = TanahWaris.BapakMemilikiLahanWaris,
                            SistemPewarisan = TanahWaris.SistemPewarisan,
                            LuasTanahSebelum = TanahWaris.LuasTanahSebelum,
                            LuasTanahDiwariskan = TanahWaris.LuasTanahDiwariskan,
                            TahunDiwariskan = TanahWaris.TahunDiwariskan,
                            BentukLegalitas = TanahWaris.BentukLegalitas,
                            LokasiLahan = TanahWaris.LokasiLahan,
                            FungsiLahanSebelum = TanahWaris.FungsiLahanSebelum,
                            FungsiLahanSesudah = TanahWaris.FungsiLahanSesudah,
                            HasilUsahaTani = TanahWaris.HasilUsahaTani,
                            TanahWarisanSubur = TanahWaris.TanahWarisanSubur,
                            TenagaYangMengelola = TanahWaris.TenagaYangMengelola,
                            AnggotaKeluargaYangBekerja = TanahWaris.AnggotaKeluargaYangBekerja,
                            StrukturArt = TanahWaris.StrukturArt,
                            JumlahBuruh = TanahWaris.JumlahBuruh,
                            AsalBuruh = TanahWaris.AsalBuruh,
                            MengalihkanTanah = TanahWaris.MengalihkanTanah,
                            TahunMengalihkan = TanahWaris.TahunMengalihkan,
                            TransaksiPengalihanPemilikan = TanahWaris.TransaksiPengalihanPemilikan,
                            KepadaSiapaPengalihan = TanahWaris.KepadaSiapaPengalihan,
                            AlasanMengalihkan = TanahWaris.AlasanMengalihkan,
                            IbuMemilikiLahanWaris = TanahWaris.IbuMemilikiLahanWaris,
                            IbuSistemPewarisan = TanahWaris.IbuSistemPewarisan,
                            IbuLuasTanahSebelum = TanahWaris.IbuLuasTanahSebelum,
                            IbuLuasTanahDiwariskan = TanahWaris.IbuLuasTanahDiwariskan,
                            IbuTahunDiwariskan = TanahWaris.IbuTahunDiwariskan,
                            IbuBentukLegalitas = TanahWaris.IbuBentukLegalitas,
                            IbuLokasiLahan = TanahWaris.IbuLokasiLahan,
                            IbuFungsiLahanSebelum = TanahWaris.IbuFungsiLahanSebelum,
                            IbuFungsiLahanSesudah = TanahWaris.IbuFungsiLahanSesudah,
                            IbuHasilUsahaTani = TanahWaris.IbuHasilUsahaTani,
                            IbuTanahWarisanSubur = TanahWaris.IbuTanahWarisanSubur,
                            IbuTenagaYangMengelola = TanahWaris.IbuTenagaYangMengelola,
                            IbuAnggotaKeluargaYangBekerja = TanahWaris.IbuAnggotaKeluargaYangBekerja,
                            IbuStrukturArt = TanahWaris.IbuStrukturArt,
                            IbuJumlahBuruh = TanahWaris.IbuJumlahBuruh,
                            IbuAsalBuruh = TanahWaris.IbuAsalBuruh,
                            IbuMengalihkanTanah = TanahWaris.IbuMengalihkanTanah,
                            IbuTahunMengalihkan = TanahWaris.IbuTahunMengalihkan,
                            IbuTransaksiPengalihanPemilikan = TanahWaris.IbuTransaksiPengalihanPemilikan,
                            IbuKepadaSiapaPengalihan = TanahWaris.IbuKepadaSiapaPengalihan,
                            IbuAlasanMengalihkan = TanahWaris.IbuAlasanMengalihkan,
                        };
                        await _context.AddAsync(data);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TanahWarisExists(TanahWaris.TanahWarisID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "RiwayatBermukims", new { id = TanahWaris.RespondenID });
            }

            ViewBag.RespondenID = TanahWaris.RespondenID;
            return View(TanahWaris);
        }

     // GET: TanahWaris/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanahWaris = await _context.TanahWaris
                .FirstOrDefaultAsync(m => m.TanahWarisID == id);
            if (tanahWaris == null)
            {
                return NotFound();
            }

            return View(tanahWaris);
        }

        // POST: IdentitasKeluargaRumahTanggas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var TanahWaris = await _context.TanahWaris.FindAsync(id);
            _context.TanahWaris.Remove(TanahWaris);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TanahWarisExists(long id)
        {
            return _context.TanahWaris.Any(e => e.TanahWarisID == id);
        }
    }
}
