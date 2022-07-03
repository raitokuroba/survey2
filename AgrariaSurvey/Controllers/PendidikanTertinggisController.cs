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
    public class PendidikanTertinggisController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public PendidikanTertinggisController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: PendidikanTertinggis
        public async Task<IActionResult> Index()
        {
            return View(await _context.PendidikanTertinggi.ToListAsync());
        }

        // GET: PendidikanTertinggis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendidikanTertinggi = await _context.PendidikanTertinggi
                .FirstOrDefaultAsync(m => m.PendidikanTertinggiID == id);
            if (pendidikanTertinggi == null)
            {
                return NotFound();
            }

            return View(pendidikanTertinggi);
        }

        // GET: PendidikanTertinggis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PendidikanTertinggis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PendidikanTertinggiID,Kode,Value")] PendidikanTertinggi pendidikanTertinggi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pendidikanTertinggi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pendidikanTertinggi);
        }

        // GET: PendidikanTertinggis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendidikanTertinggi = await _context.PendidikanTertinggi.FindAsync(id);
            if (pendidikanTertinggi == null)
            {
                return NotFound();
            }
            return View(pendidikanTertinggi);
        }

        // POST: PendidikanTertinggis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PendidikanTertinggiID,Kode,Value")] PendidikanTertinggi pendidikanTertinggi)
        {
            if (id != pendidikanTertinggi.PendidikanTertinggiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pendidikanTertinggi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PendidikanTertinggiExists(pendidikanTertinggi.PendidikanTertinggiID))
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
            return View(pendidikanTertinggi);
        }

        // GET: PendidikanTertinggis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pendidikanTertinggi = await _context.PendidikanTertinggi
                .FirstOrDefaultAsync(m => m.PendidikanTertinggiID == id);
            if (pendidikanTertinggi == null)
            {
                return NotFound();
            }

            return View(pendidikanTertinggi);
        }

        // POST: PendidikanTertinggis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pendidikanTertinggi = await _context.PendidikanTertinggi.FindAsync(id);
            _context.PendidikanTertinggi.Remove(pendidikanTertinggi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PendidikanTertinggiExists(int id)
        {
            return _context.PendidikanTertinggi.Any(e => e.PendidikanTertinggiID == id);
        }
    }
}
