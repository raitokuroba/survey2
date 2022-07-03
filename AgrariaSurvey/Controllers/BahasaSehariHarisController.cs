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
    public class BahasaSehariHarisController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public BahasaSehariHarisController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: BahasaSehariHaris
        public async Task<IActionResult> Index()
        {
            return View(await _context.BahasaSehariHari.ToListAsync());
        }

        // GET: BahasaSehariHaris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bahasaSehariHari = await _context.BahasaSehariHari
                .FirstOrDefaultAsync(m => m.BahasaSehariHariID == id);
            if (bahasaSehariHari == null)
            {
                return NotFound();
            }

            return View(bahasaSehariHari);
        }

        // GET: BahasaSehariHaris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BahasaSehariHaris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BahasaSehariHariID,Kode,Value")] BahasaSehariHari bahasaSehariHari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bahasaSehariHari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bahasaSehariHari);
        }

        // GET: BahasaSehariHaris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bahasaSehariHari = await _context.BahasaSehariHari.FindAsync(id);
            if (bahasaSehariHari == null)
            {
                return NotFound();
            }
            return View(bahasaSehariHari);
        }

        // POST: BahasaSehariHaris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BahasaSehariHariID,Kode,Value")] BahasaSehariHari bahasaSehariHari)
        {
            if (id != bahasaSehariHari.BahasaSehariHariID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bahasaSehariHari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BahasaSehariHariExists(bahasaSehariHari.BahasaSehariHariID))
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
            return View(bahasaSehariHari);
        }

        // GET: BahasaSehariHaris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bahasaSehariHari = await _context.BahasaSehariHari
                .FirstOrDefaultAsync(m => m.BahasaSehariHariID == id);
            if (bahasaSehariHari == null)
            {
                return NotFound();
            }

            return View(bahasaSehariHari);
        }

        // POST: BahasaSehariHaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bahasaSehariHari = await _context.BahasaSehariHari.FindAsync(id);
            _context.BahasaSehariHari.Remove(bahasaSehariHari);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BahasaSehariHariExists(int id)
        {
            return _context.BahasaSehariHari.Any(e => e.BahasaSehariHariID == id);
        }
    }
}
