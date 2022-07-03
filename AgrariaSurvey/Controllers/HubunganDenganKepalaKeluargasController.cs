using AgrariaSurvey.Data;
using AgrariaSurvey.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Controllers
{
    [Authorize]
    public class HubunganDenganKepalaKeluargasController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public HubunganDenganKepalaKeluargasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: HubunganDenganKepalaKeluargas
        public async Task<IActionResult> Index()
        {
            return View(await _context.HubunganDenganKepalaKeluarga.ToListAsync());
        }

        // GET: HubunganDenganKepalaKeluargas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hubunganDenganKepalaKeluarga = await _context.HubunganDenganKepalaKeluarga
                .FirstOrDefaultAsync(m => m.HubunganDenganKepalaKeluargaID == id);
            if (hubunganDenganKepalaKeluarga == null)
            {
                return NotFound();
            }

            return View(hubunganDenganKepalaKeluarga);
        }

        // GET: HubunganDenganKepalaKeluargas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HubunganDenganKepalaKeluargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HubunganDenganKepalaKeluargaID,Kode,Value")] HubunganDenganKepalaKeluarga hubunganDenganKepalaKeluarga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hubunganDenganKepalaKeluarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hubunganDenganKepalaKeluarga);
        }

        // GET: HubunganDenganKepalaKeluargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hubunganDenganKepalaKeluarga = await _context.HubunganDenganKepalaKeluarga.FindAsync(id);
            if (hubunganDenganKepalaKeluarga == null)
            {
                return NotFound();
            }
            return View(hubunganDenganKepalaKeluarga);
        }

        // POST: HubunganDenganKepalaKeluargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HubunganDenganKepalaKeluargaID,Kode,Value")] HubunganDenganKepalaKeluarga hubunganDenganKepalaKeluarga)
        {
            if (id != hubunganDenganKepalaKeluarga.HubunganDenganKepalaKeluargaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hubunganDenganKepalaKeluarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HubunganDenganKepalaKeluargaExists(hubunganDenganKepalaKeluarga.HubunganDenganKepalaKeluargaID))
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
            return View(hubunganDenganKepalaKeluarga);
        }

        // GET: HubunganDenganKepalaKeluargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hubunganDenganKepalaKeluarga = await _context.HubunganDenganKepalaKeluarga
                .FirstOrDefaultAsync(m => m.HubunganDenganKepalaKeluargaID == id);
            if (hubunganDenganKepalaKeluarga == null)
            {
                return NotFound();
            }

            return View(hubunganDenganKepalaKeluarga);
        }

        // POST: HubunganDenganKepalaKeluargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hubunganDenganKepalaKeluarga = await _context.HubunganDenganKepalaKeluarga.FindAsync(id);
            _context.HubunganDenganKepalaKeluarga.Remove(hubunganDenganKepalaKeluarga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HubunganDenganKepalaKeluargaExists(int id)
        {
            return _context.HubunganDenganKepalaKeluarga.Any(e => e.HubunganDenganKepalaKeluargaID == id);
        }
    }
}
