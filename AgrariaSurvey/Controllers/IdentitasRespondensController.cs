using AgrariaSurvey.Data;
using AgrariaSurvey.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Controllers
{
    [Authorize]
    public class IdentitasRespondensController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public IdentitasRespondensController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: IdentitasRespondens
        public async Task<IActionResult> Index()
        {
            var agrariaSurveyContext = _context.IdentitasResponden.Include(i => i.Responden);
            return View(await agrariaSurveyContext.ToListAsync());
        }

        // GET: IdentitasRespondens/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var identitasResponden = await _context.IdentitasResponden.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();
            long noResponden = 1;
            if (identitasResponden == null)
            {
                identitasResponden = new IdentitasResponden();
                var desa = _context.Responden.Where(x => x.RespondenID == id).Select(x => x.DesaKelurahan).FirstOrDefault();
                if (desa != null && _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Any())
                {
                    noResponden = _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Max(x => x.NomorResponden) + 1;
                }
            }
            else
            {
                noResponden = identitasResponden.NomorResponden;
            }

            ViewBag.NomorResponden = noResponden;
            ViewBag.RespondenID = id;

            return View(identitasResponden);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(long id, Responden responden)
        {
            if (id != responden.RespondenID)
            {
                return NotFound();
            }

            return RedirectToAction("Details", "IdentitasKeluargaRumahTanggas", new { id = responden.RespondenID });
        }

        // GET: IdentitasRespondens/Create
        public IActionResult Create(long? id)
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

        // POST: IdentitasRespondens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentitasResponden identitasResponden)
        {
            if (ModelState.IsValid)
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
                //r1
                return RedirectToAction("Create", "IdentitasKeluargaRumahTanggas", new { id = identitasResponden.RespondenID });
                //return RedirectToAction("Create", "BeliTanahs", new { id = identitasResponden.RespondenID });
            }

            ViewBag.NomorResponden = identitasResponden.NomorResponden;
            ViewBag.RespondenID = identitasResponden.RespondenID;
            return View(identitasResponden);
        }

        // GET: IdentitasRespondens/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var identitasResponden = await _context.IdentitasResponden.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();
            long noResponden = 1;
            if (identitasResponden == null)
            {
                identitasResponden = new IdentitasResponden();
                var desa = _context.Responden.Where(x => x.RespondenID == id).Select(x => x.DesaKelurahan).FirstOrDefault();
                if (desa != null && _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Any())
                {
                    noResponden = _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Max(x => x.NomorResponden) + 1;
                }
            }
            else
            {
                noResponden = identitasResponden.NomorResponden;
            }

            ViewBag.NomorResponden = noResponden;
            ViewBag.RespondenID = id;
            return View(identitasResponden);
        }

        // POST: IdentitasRespondens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdentitasRespondenID,RespondenID,NomorResponden,NamaResponden,JenisKelaminResponden,NoHpResponden")] IdentitasResponden identitasResponden)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _context.IdentitasResponden.Where(x => x.RespondenID == identitasResponden.RespondenID).FirstOrDefaultAsync();

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
                    if (!IdentitasRespondenExists(identitasResponden.IdentitasRespondenID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Edit", "IdentitasKeluargaRumahTanggas", new { id = identitasResponden.RespondenID });
            }

            ViewBag.NomorResponden = identitasResponden.NomorResponden;
            ViewBag.RespondenID = id;
            return View(identitasResponden);
        }

        // GET: IdentitasRespondens/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identitasResponden = await _context.IdentitasResponden
                .Include(i => i.Responden)
                .FirstOrDefaultAsync(m => m.IdentitasRespondenID == id);
            if (identitasResponden == null)
            {
                return NotFound();
            }

            return View(identitasResponden);
        }

        // POST: IdentitasRespondens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var identitasResponden = await _context.IdentitasResponden.FindAsync(id);
            _context.IdentitasResponden.Remove(identitasResponden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentitasRespondenExists(long id)
        {
            return _context.IdentitasResponden.Any(e => e.IdentitasRespondenID == id);
        }
    }
}
