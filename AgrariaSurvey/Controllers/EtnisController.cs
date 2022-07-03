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
    public class EtnisController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public EtnisController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: Etnis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etnis.ToListAsync());
        }

        // GET: Etnis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etnis = await _context.Etnis
                .FirstOrDefaultAsync(m => m.EtnisID == id);
            if (etnis == null)
            {
                return NotFound();
            }

            return View(etnis);
        }

        // GET: Etnis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etnis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EtnisID,Kode,Value")] Etnis etnis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etnis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etnis);
        }

        // GET: Etnis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etnis = await _context.Etnis.FindAsync(id);
            if (etnis == null)
            {
                return NotFound();
            }
            return View(etnis);
        }

        // POST: Etnis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EtnisID,Kode,Value")] Etnis etnis)
        {
            if (id != etnis.EtnisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etnis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtnisExists(etnis.EtnisID))
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
            return View(etnis);
        }

        // GET: Etnis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etnis = await _context.Etnis
                .FirstOrDefaultAsync(m => m.EtnisID == id);
            if (etnis == null)
            {
                return NotFound();
            }

            return View(etnis);
        }

        // POST: Etnis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var etnis = await _context.Etnis.FindAsync(id);
            _context.Etnis.Remove(etnis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtnisExists(int id)
        {
            return _context.Etnis.Any(e => e.EtnisID == id);
        }
    }
}
