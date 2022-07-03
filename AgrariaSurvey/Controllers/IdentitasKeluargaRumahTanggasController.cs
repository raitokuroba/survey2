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
    public class IdentitasKeluargaRumahTanggasController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public IdentitasKeluargaRumahTanggasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: IdentitasKeluargaRumahTanggas
        public async Task<IActionResult> Index()
        {
            var agrariaSurveyContext = _context.IdentitasKeluargaRumahTangga.Include(i => i.Responden);
            return View(await agrariaSurveyContext.ToListAsync());
        }

        // GET: IdentitasKeluargaRumahTanggas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identitasKeluargaRumahTangga = await _context.IdentitasKeluargaRumahTangga.Where(x => x.RespondenID == id).FirstOrDefaultAsync();

            ViewBag.RespondenID = id;

            return View(identitasKeluargaRumahTangga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(long? id, IdentitasKeluargaRumahTangga identitasKeluargaRumahTangga)
        {
            if (id != identitasKeluargaRumahTangga.RespondenID)
            {
                return NotFound();
            }

            return RedirectToAction("Details", "RiwayatBermukims", new { id = identitasKeluargaRumahTangga.RespondenID });
        }

        public ActionResult ShowKK(long id)
        {
            var imageData = _context.IdentitasKeluargaRumahTangga.Where(x => x.IdentitasKeluargaRumahTanggaID == id).Select(x => x.FotoKK).FirstOrDefault();

            //return File(imageData, "image/jpg");
            return View();
        }

        // GET: IdentitasKeluargaRumahTanggas/Create
        public IActionResult Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = id;

            return View();
        }

        // POST: IdentitasKeluargaRumahTanggas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BIdentitasKeluargaRumahTangga identitasKeluargaRumahTangga)
        {
            if (ModelState.IsValid)
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

                var data = await _context.IdentitasKeluargaRumahTangga.Where(x => x.RespondenID == identitasKeluargaRumahTangga.RespondenID).FirstOrDefaultAsync();

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

                return RedirectToAction("Create", "RiwayatBermukims", new { id = identitasKeluargaRumahTangga.RespondenID });
            }

            ViewBag.RespondenID = identitasKeluargaRumahTangga.RespondenID;
            return View(identitasKeluargaRumahTangga);
        }

        // GET: IdentitasKeluargaRumahTanggas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identitasKeluargaRumahTangga = await _context.IdentitasKeluargaRumahTangga.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();

            ViewBag.RespondenID = id;
            return View(identitasKeluargaRumahTangga);
        }

        // POST: IdentitasKeluargaRumahTanggas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, BIdentitasKeluargaRumahTangga identitasKeluargaRumahTangga)
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

                    var data = await _context.IdentitasKeluargaRumahTangga.Where(x => x.RespondenID == identitasKeluargaRumahTangga.RespondenID).FirstOrDefaultAsync();

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
                    if (!IdentitasKeluargaRumahTanggaExists(identitasKeluargaRumahTangga.IdentitasKeluargaRumahTanggaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Edit", "RiwayatBermukims", new { id = identitasKeluargaRumahTangga.RespondenID });
            }

            ViewBag.RespondenID = identitasKeluargaRumahTangga.RespondenID;
            return View(identitasKeluargaRumahTangga);
        }

        // GET: IdentitasKeluargaRumahTanggas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identitasKeluargaRumahTangga = await _context.IdentitasKeluargaRumahTangga
                .Include(i => i.Responden)
                .FirstOrDefaultAsync(m => m.IdentitasKeluargaRumahTanggaID == id);
            if (identitasKeluargaRumahTangga == null)
            {
                return NotFound();
            }

            return View(identitasKeluargaRumahTangga);
        }

        // POST: IdentitasKeluargaRumahTanggas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var identitasKeluargaRumahTangga = await _context.IdentitasKeluargaRumahTangga.FindAsync(id);
            _context.IdentitasKeluargaRumahTangga.Remove(identitasKeluargaRumahTangga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentitasKeluargaRumahTanggaExists(long id)
        {
            return _context.IdentitasKeluargaRumahTangga.Any(e => e.IdentitasKeluargaRumahTanggaID == id);
        }
    }
}
