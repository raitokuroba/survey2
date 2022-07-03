using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgrariaSurvey.Data;
using AgrariaSurvey.Models;
using Microsoft.AspNetCore.Authorization;


namespace AgrariaSurvey.Controllers
{
    [Authorize]
    public class AnggotaRumahTanggasController : Controller
    {
        private readonly AgrariaSurveyContext _context;
        public AnggotaRumahTanggasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AnggotaRumahTanggas
        public async Task<IActionResult> Index(long? respondenId, string act)
        {
            if (respondenId == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = respondenId;
            ViewBag.Act = act ?? "Create";
            
            var agrariaSurveyContext = _context.AnggotaRumahTangga.Where(x => x.RespondenID == respondenId);
            ////r1
            //return View(await agrariaSurveyContext.ToListAsync());
            //var agrariaSurveyContext = _context.AnggotaRumahTangga.Include(i => i.Responden);
            return View(await agrariaSurveyContext.ToListAsync());
            //return RedirectToAction("Create", "TanahWaris", new { id = respondenId });

        }

        // GET: AnggotaRumahTanggas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggotaRumahTangga = await _context.AnggotaRumahTangga.FirstOrDefaultAsync(m => m.AnggotaRumahTanggaID == id);
            if (anggotaRumahTangga == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = anggotaRumahTangga.RespondenID;

            return View(anggotaRumahTangga);
        }

        // GET: AnggotaRumahTanggas/Create
        public IActionResult Create(long? respondenId)
        {
  
            if (respondenId == null)
            {
                return NotFound();
            }

            var noArt = 1;
            if (_context.AnggotaRumahTangga.Where(x => x.RespondenID == respondenId).Any())
            {
                noArt = _context.AnggotaRumahTangga.Where(x => x.RespondenID == respondenId).Max(x => x.NoART) + 1;
            }

            ViewBag.RespondenID = respondenId;
            ViewBag.NoART = noArt;
            ViewBag.HubunganDenganKepalaKeluarga = new SelectList(_context.HubunganDenganKepalaKeluarga, "Kode", "Value", "1");
            ViewBag.StatusNikah = new SelectList(_context.StatusNikah, "Kode", "Value");
            ViewBag.EtnisSuku = new SelectList(_context.Etnis, "Kode", "Value");
            ViewBag.BahasaSehari = new SelectList(_context.BahasaSehariHari, "Kode", "Value");
            ViewBag.PendidikanTertinggi = new SelectList(_context.PendidikanTertinggi, "Kode", "Value");
            ViewBag.TempatLahir = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", "1");
            ViewBag.PekerjaanUtama = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", "1");
            return View();
        }

        // POST: AnggotaRumahTanggas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnggotaRumahTangga anggotaRumahTangga)
        {
            if (ModelState.IsValid)
            {
                var data = new AnggotaRumahTangga()
                {
                    RespondenID = anggotaRumahTangga.RespondenID,
                    BahasaSehari = anggotaRumahTangga.BahasaSehari,
                    EtnisSuku = anggotaRumahTangga.EtnisSuku,
                    HubunganDenganKepalaKeluarga = anggotaRumahTangga.HubunganDenganKepalaKeluarga,
                    HubunganDenganKepalaKeluargaLainnya = anggotaRumahTangga.HubunganDenganKepalaKeluargaLainnya,
                    JenisKelamin = anggotaRumahTangga.JenisKelamin,
                    LokasiKerjaSamping = anggotaRumahTangga.LokasiKerjaSamping,
                    LokasiKerjaSampingDesa = anggotaRumahTangga.LokasiKerjaSampingDesa,
                    LokasiKerjaSampingKab = anggotaRumahTangga.LokasiKerjaSampingKab,
                    LokasiKerjaSampingKec = anggotaRumahTangga.LokasiKerjaSampingKec,
                    LokasiKerjaSampingNeg = anggotaRumahTangga.LokasiKerjaSampingNeg,
                    LokasiKerjaSampingProv = anggotaRumahTangga.LokasiKerjaSampingProv,
                    LokasiKerjaUtama = anggotaRumahTangga.LokasiKerjaUtama,
                    LokasiKerjaUtamaDesa = anggotaRumahTangga.LokasiKerjaUtamaDesa,
                    LokasiKerjaUtamaKab = anggotaRumahTangga.LokasiKerjaUtamaKab,
                    LokasiKerjaUtamaKec = anggotaRumahTangga.LokasiKerjaUtamaKec,
                    LokasiKerjaUtamaNeg = anggotaRumahTangga.LokasiKerjaUtamaNeg,
                    LokasiKerjaUtamaProv = anggotaRumahTangga.LokasiKerjaUtamaProv,
                    Nama = anggotaRumahTangga.Nama,
                    NoART = anggotaRumahTangga.NoART,
                    PekerjaanSampinganLainnya = anggotaRumahTangga.PekerjaanSampinganLainnya,
                    PekerjaanUSampingan = anggotaRumahTangga.PekerjaanUSampingan,
                    PekerjaanUtama = anggotaRumahTangga.PekerjaanUtama,
                    PekerjaanUtamaLainnya = anggotaRumahTangga.PekerjaanUtamaLainnya,
                    PendidikanTertinggi = anggotaRumahTangga.PendidikanTertinggi,
                    StatusNikah = anggotaRumahTangga.StatusNikah,
                    TempatLahir = anggotaRumahTangga.TempatLahir,
                    TempatLahirDesa = anggotaRumahTangga.TempatLahirDesa,
                    TempatLahirKab = anggotaRumahTangga.TempatLahirKab,
                    TempatLahirKec = anggotaRumahTangga.TempatLahirKec,
                    TempatLahirNeg = anggotaRumahTangga.TempatLahirNeg,
                    TempatLahirProv = anggotaRumahTangga.TempatLahirProv,
                    TempatTinggalLalu = anggotaRumahTangga.TempatTinggalLalu,
                    TempatTinggalLaluDesa = anggotaRumahTangga.TempatTinggalLaluDesa,
                    TempatTinggalLaluKab = anggotaRumahTangga.TempatTinggalLaluKab,
                    TempatTinggalLaluKec = anggotaRumahTangga.TempatTinggalLaluKec,
                    TempatTinggalLaluNeg = anggotaRumahTangga.TempatTinggalLaluNeg,
                    TempatTinggalLaluProv = anggotaRumahTangga.TempatTinggalLaluProv,
                    TanggalLahir = anggotaRumahTangga.TanggalLahir,
                    Umur = anggotaRumahTangga.Umur
                };

                _context.Add(data);
                await _context.SaveChangesAsync();
                //next page E to G
                //return RedirectToAction(nameof(Index), new { respondenId = anggotaRumahTangga.RespondenID });
                return RedirectToAction("Create", "TanahWaris", new { id = anggotaRumahTangga.RespondenID });
            }

            ViewBag.RespondenID = anggotaRumahTangga.RespondenID;
            ViewBag.NoART = anggotaRumahTangga.NoART;
            ViewBag.HubunganDenganKepalaKeluarga = new SelectList(_context.HubunganDenganKepalaKeluarga, "Kode", "Value", anggotaRumahTangga.HubunganDenganKepalaKeluarga);
            ViewBag.StatusNikah = new SelectList(_context.StatusNikah, "Kode", "Value", anggotaRumahTangga.StatusNikah);
            ViewBag.EtnisSuku = new SelectList(_context.Etnis, "Kode", "Value", anggotaRumahTangga.EtnisSuku);
            ViewBag.BahasaSehari = new SelectList(_context.BahasaSehariHari, "Kode", "Value", anggotaRumahTangga.BahasaSehari);
            ViewBag.PendidikanTertinggi = new SelectList(_context.PendidikanTertinggi, "Kode", "Value", anggotaRumahTangga.PendidikanTertinggi);
            ViewBag.TempatLahir = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.TempatLahir);
            ViewBag.TempatTinggalLalu = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.TempatTinggalLalu);
            ViewBag.PekerjaanUtama = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", anggotaRumahTangga.PekerjaanUtama);
            ViewBag.LokasiKerjaUtama = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.LokasiKerjaUtama);
            ViewBag.PekerjaanUSampingan = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", anggotaRumahTangga.PekerjaanUSampingan);
            ViewBag.LokasiKerjaSamping = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.LokasiKerjaSamping);

            return View(anggotaRumahTangga);
        }

        // GET: AnggotaRumahTanggas/Edit/5

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var anggotaRumahTangga = await _context.AnggotaRumahTangga.FindAsync(id);
            if (anggotaRumahTangga == null)
            {
                return NotFound();
            }
            ViewBag.RespondenID = anggotaRumahTangga.RespondenID;
            ViewBag.NoART = anggotaRumahTangga.NoART;
            ViewBag.HubunganDenganKepalaKeluarga = new SelectList(_context.HubunganDenganKepalaKeluarga, "Kode", "Value", anggotaRumahTangga.HubunganDenganKepalaKeluarga);
            ViewBag.StatusNikah = new SelectList(_context.StatusNikah, "Kode", "Value", anggotaRumahTangga.StatusNikah);
            ViewBag.EtnisSuku = new SelectList(_context.Etnis, "Kode", "Value", anggotaRumahTangga.EtnisSuku);
            ViewBag.BahasaSehari = new SelectList(_context.BahasaSehariHari, "Kode", "Value", anggotaRumahTangga.BahasaSehari);
            ViewBag.PendidikanTertinggi = new SelectList(_context.PendidikanTertinggi, "Kode", "Value", anggotaRumahTangga.PendidikanTertinggi);
            ViewBag.TempatLahir = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.TempatLahir);
            ViewBag.TempatTinggalLalu = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.TempatTinggalLalu);
            ViewBag.PekerjaanUtama = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", anggotaRumahTangga.PekerjaanUtama);
            ViewBag.LokasiKerjaUtama = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.LokasiKerjaUtama);
            ViewBag.PekerjaanUSampingan = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", anggotaRumahTangga.PekerjaanUSampingan);
            ViewBag.LokasiKerjaSamping = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.LokasiKerjaSamping);
            return View(anggotaRumahTangga);
            //if (id == null)
            //{
            //    return NotFound();
            //}
            //var anggotaRumahTangga = await _context.AnggotaRumahTangga.FindAsync(id);

            //ViewBag.RespondenID = id;
            //return View(anggotaRumahTangga);
        }

        // POST: AnggotaRumahTanggas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, AnggotaRumahTangga anggotaRumahTangga)
        {
            //return RedirectToAction("Create", "TanahWaris", new { id = anggotaRumahTangga.RespondenID });
            if (id != anggotaRumahTangga.AnggotaRumahTanggaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data = _context.AnggotaRumahTangga.Where(x => x.AnggotaRumahTanggaID == id).FirstOrDefault();
                    if (data == null)
                    {
                        return NotFound();
                    }

                    data.RespondenID = anggotaRumahTangga.RespondenID;
                    data.BahasaSehari = anggotaRumahTangga.BahasaSehari;
                    data.EtnisSuku = anggotaRumahTangga.EtnisSuku;
                    data.HubunganDenganKepalaKeluarga = anggotaRumahTangga.HubunganDenganKepalaKeluarga;
                    data.HubunganDenganKepalaKeluargaLainnya = anggotaRumahTangga.HubunganDenganKepalaKeluargaLainnya;
                    data.JenisKelamin = anggotaRumahTangga.JenisKelamin;
                    data.LokasiKerjaSamping = anggotaRumahTangga.LokasiKerjaSamping;
                    data.LokasiKerjaSampingDesa = anggotaRumahTangga.LokasiKerjaSampingDesa;
                    data.LokasiKerjaSampingKab = anggotaRumahTangga.LokasiKerjaSampingKab;
                    data.LokasiKerjaSampingKec = anggotaRumahTangga.LokasiKerjaSampingKec;
                    data.LokasiKerjaSampingNeg = anggotaRumahTangga.LokasiKerjaSampingNeg;
                    data.LokasiKerjaSampingProv = anggotaRumahTangga.LokasiKerjaSampingProv;
                    data.LokasiKerjaUtama = anggotaRumahTangga.LokasiKerjaUtama;
                    data.LokasiKerjaUtamaDesa = anggotaRumahTangga.LokasiKerjaUtamaDesa;
                    data.LokasiKerjaUtamaKab = anggotaRumahTangga.LokasiKerjaUtamaKab;
                    data.LokasiKerjaUtamaKec = anggotaRumahTangga.LokasiKerjaUtamaKec;
                    data.LokasiKerjaUtamaNeg = anggotaRumahTangga.LokasiKerjaUtamaNeg;
                    data.LokasiKerjaUtamaProv = anggotaRumahTangga.LokasiKerjaUtamaProv;
                    data.Nama = anggotaRumahTangga.Nama;
                    data.NoART = anggotaRumahTangga.NoART;
                    data.PekerjaanSampinganLainnya = anggotaRumahTangga.PekerjaanSampinganLainnya;
                    data.PekerjaanUSampingan = anggotaRumahTangga.PekerjaanUSampingan;
                    data.PekerjaanUtama = anggotaRumahTangga.PekerjaanUtama;
                    data.PekerjaanUtamaLainnya = anggotaRumahTangga.PekerjaanUtamaLainnya;
                    data.PendidikanTertinggi = anggotaRumahTangga.PendidikanTertinggi;
                    data.StatusNikah = anggotaRumahTangga.StatusNikah;
                    data.TempatLahir = anggotaRumahTangga.TempatLahir;
                    data.TempatLahirDesa = anggotaRumahTangga.TempatLahirDesa;
                    data.TempatLahirKab = anggotaRumahTangga.TempatLahirKab;
                    data.TempatLahirKec = anggotaRumahTangga.TempatLahirKec;
                    data.TempatLahirNeg = anggotaRumahTangga.TempatLahirNeg;
                    data.TempatLahirProv = anggotaRumahTangga.TempatLahirProv;
                    data.TempatTinggalLalu = anggotaRumahTangga.TempatTinggalLalu;
                    data.TempatTinggalLaluDesa = anggotaRumahTangga.TempatTinggalLaluDesa;
                    data.TempatTinggalLaluKab = anggotaRumahTangga.TempatTinggalLaluKab;
                    data.TempatTinggalLaluKec = anggotaRumahTangga.TempatTinggalLaluKec;
                    data.TempatTinggalLaluNeg = anggotaRumahTangga.TempatTinggalLaluNeg;
                    data.TempatTinggalLaluProv = anggotaRumahTangga.TempatTinggalLaluProv;
                    data.TanggalLahir = anggotaRumahTangga.TanggalLahir;
                    data.Umur = anggotaRumahTangga.Umur;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnggotaRumahTanggaExists(anggotaRumahTangga.AnggotaRumahTanggaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //r1
                //return RedirectToAction(nameof(Index), new { respondenId = anggotaRumahTangga.RespondenID });
                return RedirectToAction("Edit", "TanahWaris", new { id = anggotaRumahTangga.RespondenID });

            }

            ViewBag.RespondenID = anggotaRumahTangga.RespondenID;
            ViewBag.NoART = anggotaRumahTangga.NoART;
            ViewBag.HubunganDenganKepalaKeluarga = new SelectList(_context.HubunganDenganKepalaKeluarga, "Kode", "Value", anggotaRumahTangga.HubunganDenganKepalaKeluarga);
            ViewBag.StatusNikah = new SelectList(_context.StatusNikah, "Kode", "Value", anggotaRumahTangga.StatusNikah);
            ViewBag.EtnisSuku = new SelectList(_context.Etnis, "Kode", "Value", anggotaRumahTangga.EtnisSuku);
            ViewBag.BahasaSehari = new SelectList(_context.BahasaSehariHari, "Kode", "Value", anggotaRumahTangga.BahasaSehari);
            ViewBag.PendidikanTertinggi = new SelectList(_context.PendidikanTertinggi, "Kode", "Value", anggotaRumahTangga.PendidikanTertinggi);
            ViewBag.TempatLahir = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.TempatLahir);
            ViewBag.TempatTinggalLalu = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.TempatTinggalLalu);
            ViewBag.PekerjaanUtama = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", anggotaRumahTangga.PekerjaanUtama);
            ViewBag.LokasiKerjaUtama = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.LokasiKerjaUtama);
            ViewBag.PekerjaanUSampingan = new SelectList(_context.PekerjaanUtamaDanPekerjaanSampingan, "Kode", "Value", anggotaRumahTangga.PekerjaanUSampingan);
            ViewBag.LokasiKerjaSamping = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value", anggotaRumahTangga.LokasiKerjaSamping);

            return View(anggotaRumahTangga);
        }

        // GET: AnggotaRumahTanggas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggotaRumahTangga = await _context.AnggotaRumahTangga.FirstOrDefaultAsync(m => m.AnggotaRumahTanggaID == id);
            if (anggotaRumahTangga == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = anggotaRumahTangga.RespondenID;

            return View(anggotaRumahTangga);
        }

        // POST: AnggotaRumahTanggas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var anggotaRumahTangga = await _context.AnggotaRumahTangga.FindAsync(id);
            _context.AnggotaRumahTangga.Remove(anggotaRumahTangga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { respondenId = anggotaRumahTangga.RespondenID });
        }

        private bool AnggotaRumahTanggaExists(long id)
        {
            return _context.AnggotaRumahTangga.Any(e => e.AnggotaRumahTanggaID == id);
        }
    }
}
