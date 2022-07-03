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
    public class TempatLahirDanTempatTinggalsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public TempatLahirDanTempatTinggalsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: TempatLahirDanTempatTinggals
        public async Task<IActionResult> Index()
        {
            return View(await _context.TempatLahirDanTempatTinggal.ToListAsync());
        }

        // GET: TempatLahirDanTempatTinggals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempatLahirDanTempatTinggal = await _context.TempatLahirDanTempatTinggal
                .FirstOrDefaultAsync(m => m.TempatLahirDanTempatTinggalID == id);
            if (tempatLahirDanTempatTinggal == null)
            {
                return NotFound();
            }

            return View(tempatLahirDanTempatTinggal);
        }

        // GET: TempatLahirDanTempatTinggals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TempatLahirDanTempatTinggals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TempatLahirDanTempatTinggalID,Kode,Value")] TempatLahirDanTempatTinggal tempatLahirDanTempatTinggal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempatLahirDanTempatTinggal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tempatLahirDanTempatTinggal);
        }

        // GET: TempatLahirDanTempatTinggals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempatLahirDanTempatTinggal = await _context.TempatLahirDanTempatTinggal.FindAsync(id);
            if (tempatLahirDanTempatTinggal == null)
            {
                return NotFound();
            }
            return View(tempatLahirDanTempatTinggal);
        }

        // POST: TempatLahirDanTempatTinggals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TempatLahirDanTempatTinggalID,Kode,Value")] TempatLahirDanTempatTinggal tempatLahirDanTempatTinggal)
        {
            if (id != tempatLahirDanTempatTinggal.TempatLahirDanTempatTinggalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tempatLahirDanTempatTinggal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempatLahirDanTempatTinggalExists(tempatLahirDanTempatTinggal.TempatLahirDanTempatTinggalID))
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
            return View(tempatLahirDanTempatTinggal);
        }

        // GET: TempatLahirDanTempatTinggals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempatLahirDanTempatTinggal = await _context.TempatLahirDanTempatTinggal
                .FirstOrDefaultAsync(m => m.TempatLahirDanTempatTinggalID == id);
            if (tempatLahirDanTempatTinggal == null)
            {
                return NotFound();
            }

            return View(tempatLahirDanTempatTinggal);
        }

        // POST: TempatLahirDanTempatTinggals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tempatLahirDanTempatTinggal = await _context.TempatLahirDanTempatTinggal.FindAsync(id);
            _context.TempatLahirDanTempatTinggal.Remove(tempatLahirDanTempatTinggal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempatLahirDanTempatTinggalExists(int id)
        {
            return _context.TempatLahirDanTempatTinggal.Any(e => e.TempatLahirDanTempatTinggalID == id);
        }
    }
}
