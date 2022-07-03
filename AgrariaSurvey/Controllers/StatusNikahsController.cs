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
    public class StatusNikahsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public StatusNikahsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: StatusNikahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusNikah.ToListAsync());
        }

        // GET: StatusNikahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusNikah = await _context.StatusNikah
                .FirstOrDefaultAsync(m => m.StatusNikahID == id);
            if (statusNikah == null)
            {
                return NotFound();
            }

            return View(statusNikah);
        }

        // GET: StatusNikahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusNikahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusNikahID,Kode,Value")] StatusNikah statusNikah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusNikah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusNikah);
        }

        // GET: StatusNikahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusNikah = await _context.StatusNikah.FindAsync(id);
            if (statusNikah == null)
            {
                return NotFound();
            }
            return View(statusNikah);
        }

        // POST: StatusNikahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusNikahID,Kode,Value")] StatusNikah statusNikah)
        {
            if (id != statusNikah.StatusNikahID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusNikah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusNikahExists(statusNikah.StatusNikahID))
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
            return View(statusNikah);
        }

        // GET: StatusNikahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusNikah = await _context.StatusNikah
                .FirstOrDefaultAsync(m => m.StatusNikahID == id);
            if (statusNikah == null)
            {
                return NotFound();
            }

            return View(statusNikah);
        }

        // POST: StatusNikahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusNikah = await _context.StatusNikah.FindAsync(id);
            _context.StatusNikah.Remove(statusNikah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusNikahExists(int id)
        {
            return _context.StatusNikah.Any(e => e.StatusNikahID == id);
        }
    }
}
