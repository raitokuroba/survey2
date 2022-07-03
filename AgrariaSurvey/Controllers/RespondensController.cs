using AgrariaSurvey.Data;
using AgrariaSurvey.Models;
using AgrariaSurvey.Models.Binding;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Controllers
{
    [Authorize]
    public class RespondensController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public RespondensController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: Respondens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Responden.Include(x => x.IdentitasResponden).ToListAsync());
        }

        // GET: Respondens/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responden = await _context.Responden
                .FirstOrDefaultAsync(m => m.RespondenID == id);
            if (responden == null)
            {
                return NotFound();
            }

            return View(responden);
        }

        // GET: Respondens/AlamatResponden
        public IActionResult AlamatResponden()
        {
            ViewBag.Pulau = new SelectList(GetPulau(), "Kode", "Value");
            ViewBag.Provinsi = new SelectList(GetProvinsi(), "Kode", "Value");
            return View();
        }

        // GET: Respondens/AlamatRespondenEdit/id
        public async Task<IActionResult> AlamatRespondenEdit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responden = await _context.Responden.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();
            if (responden == null)
            {
                return NotFound();
            }

            ViewBag.Pulau = new SelectList(GetPulau(), "Kode", "Value", responden.Pulau);
            ViewBag.Provinsi = new SelectList(GetProvinsi(), "Kode", "Value", responden.Provinsi);
            ViewBag.Kota = new SelectList(BindKabupaten(responden.Provinsi).ToList(), "Kode", "Value", responden.KabupatenKota);
            ViewBag.Kec = new SelectList(BindKecamatan(responden.KabupatenKota).ToList(), "Kode", "Value", responden.Kecamatan);
            ViewBag.Desa = new SelectList(BindKelurahan(responden.Kecamatan).ToList(), "Kode", "Value", responden.DesaKelurahan);

            return View(responden);
        }

        // GET: Respondens/AlamatRespondenDetail/id
        public async Task<IActionResult> AlamatRespondenDetail(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responden = await _context.Responden.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();
            if (responden == null)
            {
                return NotFound();
            }

            ViewBag.Pulau = _context.Pulaus.Where(x => x.Kode == responden.Pulau).Select(x => x.Value).FirstOrDefault();
            ViewBag.Provinsi = _context.Provinsi.Where(x => x.Kode == responden.Provinsi).Select(x => x.Value).FirstOrDefault();
            ViewBag.Kota = _context.Kabupaten.Where(x => x.Kode == responden.KabupatenKota).Select(x => x.Value).FirstOrDefault();
            ViewBag.Kec = _context.Kecamatans.Where(x => x.Kode == responden.Kecamatan).Select(x => x.Value).FirstOrDefault();
            ViewBag.Desa = _context.Kelurahans.Where(x => x.Kode == responden.DesaKelurahan).Select(x => x.Value).FirstOrDefault();

            return View(responden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AlamatRespondenDetail(long id, Responden responden)
        {
            if (id != responden.RespondenID)
            {
                return NotFound();
            }
            
            return RedirectToAction("Details", "IdentitasRespondens", new { id = responden.RespondenID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlamatRespondenEdit(long id, Responden responden)
        {
            if (id != responden.RespondenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _context.Responden.Where(x => x.RespondenID == id).FirstOrDefaultAsync();

                    if (data == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        data.Pulau = responden.Pulau;
                        data.Provinsi = responden.Provinsi;
                        data.KabupatenKota = responden.KabupatenKota;
                        data.Kecamatan = responden.Kecamatan;
                        data.DesaKelurahan = responden.DesaKelurahan;
                        data.Dusun = responden.Dusun;
                        data.RT = responden.RT;
                        data.RW = responden.RW;
                        data.NamaJalan = responden.NamaJalan;
                        data.NomorRumah = responden.NomorRumah;
                        data.KoordinatAlamatRumah = responden.KoordinatAlamatRumah;

                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespondenExists(responden.RespondenID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "IdentitasRespondens", new { id = responden.RespondenID });
            }

            ViewBag.Pulau = new SelectList(GetPulau(), "Kode", "Value", responden.Pulau);
            ViewBag.Provinsi = new SelectList(GetProvinsi(), "Kode", "Value", responden.Provinsi);
            ViewBag.Kota = new SelectList(BindKabupaten(responden.Provinsi).ToList(), "Kode", "Value", responden.KabupatenKota);
            ViewBag.Kec = new SelectList(BindKecamatan(responden.KabupatenKota).ToList(), "Kode", "Value", responden.Kecamatan);
            ViewBag.Desa = new SelectList(BindKelurahan(responden.Kecamatan).ToList(), "Kode", "Value", responden.DesaKelurahan);

            return View(responden);
        }

        // POST: Respondens/AlamatResponden
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlamatResponden(Responden responden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responden);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "IdentitasRespondens", new { id = responden.RespondenID });
            }

            ViewBag.Pulau = new SelectList(GetPulau(), "Kode", "Value");
            ViewBag.Provinsi = new SelectList(GetProvinsi(), "Kode", "Value");
            return View(responden);
        }

        // GET: Respondens/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responden = await _context.Responden.FindAsync(id);
            if (responden == null)
            {
                return NotFound();
            }
            return View(responden);
        }

        // POST: Respondens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("RespondenID,NomorResponden,NamaResponden,JenisKelaminResponden,NoHoResponden,Provinsi,KabupatenKota,Kecamatan,DesaKelurahan,Dusun,RT,RW,NamaJalanDanNomor")] Responden responden)
        {
            if (id != responden.RespondenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespondenExists(responden.RespondenID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(responden);
        }

        // GET: Respondens/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responden = await _context.Responden.Include(x => x.IdentitasResponden)
                .FirstOrDefaultAsync(m => m.RespondenID == id);
            if (responden == null)
            {
                return NotFound();
            }

            return View(responden);
        }

        // POST: Respondens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var responden = await _context.Responden.FindAsync(id);
            _context.Responden.Remove(responden);
            await _context.SaveChangesAsync();
            var getDataRiwayatBermukimById = await _context.RiwayatBermukim.Where(x => x.RespondenID == id).FirstOrDefaultAsync();
            //r1
            //if (getDataRiwayatBermukimById != null)
            //{
            //    _context.RiwayatBermukim.Remove(getDataRiwayatBermukimById);
            //    await _context.SaveChangesAsync();
            //}

          

            return RedirectToAction(nameof(Index));
        }

        private bool RespondenExists(long id)
        {
            return _context.Responden.Any(e => e.RespondenID == id);
        }

        public async Task<IActionResult> Cancel(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responden = await _context.Responden.FindAsync(id);
            if (responden == null)
            {
                return NotFound();
            }

            _context.Responden.Remove(responden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult IdentitasResponden(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var desa = _context.Responden.Where(x => x.RespondenID == id).Select(x => x.DesaKelurahan).FirstOrDefault();

            long noResponden = 1;
            if (desa != null && _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Any())
            {
                noResponden = _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Max(x => x.NomorResponden) + 1;
            }

            ViewBag.NomorResponden = noResponden;
            ViewBag.RespondenID = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdentitasResponden(long id, IdentitasResponden identitasResponden)
        {
            if (id != identitasResponden.RespondenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _context.IdentitasResponden.FindAsync(identitasResponden.RespondenID);

                    if (data != null)
                    {
                        data.NomorResponden = identitasResponden.NomorResponden;
                        data.NamaResponden = identitasResponden.NamaResponden;
                        data.JenisKelaminResponden = identitasResponden.JenisKelaminResponden;
                        data.NoHpResponden = identitasResponden.NoHpResponden;
                    }
                    else
                    {
                        data = new IdentitasResponden()
                        {
                            RespondenID = identitasResponden.RespondenID,
                            NomorResponden = identitasResponden.NomorResponden,
                            NamaResponden = identitasResponden.NamaResponden,
                            JenisKelaminResponden = identitasResponden.JenisKelaminResponden,
                            NoHpResponden = identitasResponden.NoHpResponden
                        };

                        await _context.IdentitasResponden.AddAsync(data);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespondenExists(identitasResponden.RespondenID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IdentitasKeluargaRumahTangga), new { id });
            }
            return View(identitasResponden);
        }

        public IActionResult IdentitasKeluargaRumahTangga(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IdentitasKeluargaRumahTangga(long id, BIdentitasKeluargaRumahTangga identitasKeluargaRumahTangga)
        {
            if (id != identitasKeluargaRumahTangga.RespondenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    byte[] fotoKK = null;
                    if (identitasKeluargaRumahTangga.FotoKK != null)
                    {
                        if (identitasKeluargaRumahTangga.FotoKK.Length > 0)
                        {
                            //Convert Image to byte and save to database
                            byte[] p1 = null;
                            using (var fs1 = identitasKeluargaRumahTangga.FotoKK.OpenReadStream())
                            using (var ms1 = new MemoryStream())
                            {
                                fs1.CopyTo(ms1);
                                p1 = ms1.ToArray();
                            }
                            fotoKK = p1;
                        }
                    }

                    var data = await _context.IdentitasKeluargaRumahTangga.FindAsync(identitasKeluargaRumahTangga.RespondenID);

                    if (data != null)
                    {
                        data.NoKK = identitasKeluargaRumahTangga.NoKK;
                        data.FotoKK = fotoKK;
                        data.NamaKepalaKeluarga = identitasKeluargaRumahTangga.NamaKepalaKeluarga;
                        data.JenisKelaminKepalaKeluarga = identitasKeluargaRumahTangga.JenisKelaminKepalaKeluarga;
                        data.JumlahAnggotaRumahTangga = identitasKeluargaRumahTangga.JumlahAnggotaRumahTangga;
                        data.JumlahKeluargaDalamRumahTangga = identitasKeluargaRumahTangga.JumlahKeluargaDalamRumahTangga;
                        data.NamaTulangPunggungRumahTangga = identitasKeluargaRumahTangga.NamaTulangPunggungRumahTangga;
                        data.JenisKelaminTulangPunggungRumahTangga = identitasKeluargaRumahTangga.JenisKelaminTulangPunggungRumahTangga;
                        data.StatusTulangPunggungRumahTanggaDalamKeluarga = identitasKeluargaRumahTangga.StatusTulangPunggungRumahTanggaDalamKeluarga;
                        data.ApakahTulangPunggungKeluargaTinggalMenetapDiRumahResponden = identitasKeluargaRumahTangga.ApakahTulangPunggungKeluargaTinggalMenetapDiRumahResponden;
                    }
                    else
                    {
                        data = new IdentitasKeluargaRumahTangga()
                        {
                            RespondenID = identitasKeluargaRumahTangga.RespondenID,
                            NoKK = identitasKeluargaRumahTangga.NoKK,
                            FotoKK = fotoKK,
                            NamaKepalaKeluarga = identitasKeluargaRumahTangga.NamaKepalaKeluarga,
                            JenisKelaminKepalaKeluarga = identitasKeluargaRumahTangga.JenisKelaminKepalaKeluarga,
                            JumlahAnggotaRumahTangga = identitasKeluargaRumahTangga.JumlahAnggotaRumahTangga,
                            JumlahKeluargaDalamRumahTangga = identitasKeluargaRumahTangga.JumlahKeluargaDalamRumahTangga,
                            NamaTulangPunggungRumahTangga = identitasKeluargaRumahTangga.NamaTulangPunggungRumahTangga,
                            JenisKelaminTulangPunggungRumahTangga = identitasKeluargaRumahTangga.JenisKelaminTulangPunggungRumahTangga,
                            StatusTulangPunggungRumahTanggaDalamKeluarga = identitasKeluargaRumahTangga.StatusTulangPunggungRumahTanggaDalamKeluarga,
                            ApakahTulangPunggungKeluargaTinggalMenetapDiRumahResponden = identitasKeluargaRumahTangga.ApakahTulangPunggungKeluargaTinggalMenetapDiRumahResponden
                        };
                        await _context.AddAsync(data);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespondenExists(identitasKeluargaRumahTangga.RespondenID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(RiwayatBermukim), new { id });
            }
            return View(identitasKeluargaRumahTangga);
        }

        public IActionResult RiwayatBermukim(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RiwayatBermukim(long id, Responden responden)
        {
            if (id != responden.RespondenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _context.Responden.FindAsync(responden.RespondenID);

                    if (data != null)
                    {
                        
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespondenExists(responden.RespondenID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "AnggotaRumahTanggas", new { respondenId = id });
            }
            return View(responden);
        }

        #region Get Data
        private List<Pulau> GetPulau()
        {
            return _context.Pulaus.ToList();
        }

        private List<Provinsi> GetProvinsi()
        {
            return _context.Provinsi.ToList();
        }

        private IQueryable<Kabupaten> BindKabupaten(string prov)
        {
            return _context.Kabupaten.Where(x => x.KodeProvinsi == prov);
        }

        public JsonResult GetKota(string prov)
        {
            var data = BindKabupaten(prov).ToList();

            return new JsonResult(new SelectList(data, "Kode", "Value"));
        }

        private IQueryable<Kecamatans> BindKecamatan(string kota)
        {
            return _context.Kecamatans.Where(x => x.KodeKota == kota);
        }

        public JsonResult GetKecamatan(string kota)
        {
            var data = BindKecamatan(kota).ToList();

            return new JsonResult(new SelectList(data, "Kode", "Value"));
        }

        private IQueryable<Kelurahan> BindKelurahan(string kec)
        {
            return _context.Kelurahans.Where(x => x.KodeKecamatan == kec);
        }

        public JsonResult GetDesa(string kec)
        {
            var data = BindKelurahan(kec).ToList();

            return new JsonResult(new SelectList(data, "Kode", "Value"));
        }
        #endregion
    }

    #region DataDummy
    //public class Pulau
    //{
    //    public string Kode { get; set; }
    //    public string Value { get; set; }
    //}
    //public class Provinsi
    //{
    //    public string Kode { get; set; }
    //    public string Value { get; set; }
    //}
    public class Kota
    {
        public string Kode { get; set; }
        public string KodeProvinsi { get; set; }
        public string Value { get; set; }
    }
    //public class Kecamatan
    //{
    //    public string Kode { get; set; }
    //    public string KodeKota { get; set; }
    //    public string Value { get; set; }
    //}
    public class Desa
    {
        public string Kode { get; set; }
        public string KodeKecamatan { get; set; }
        public string Value { get; set; }
    }
    #endregion
}
