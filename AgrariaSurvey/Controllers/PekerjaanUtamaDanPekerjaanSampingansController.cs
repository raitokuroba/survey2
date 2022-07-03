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
    public class PekerjaanUtamaDanPekerjaanSampingansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public PekerjaanUtamaDanPekerjaanSampingansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: PekerjaanUtamaDanPekerjaanSampingans
        public async Task<IActionResult> Index()
        {
            return View(await _context.PekerjaanUtamaDanPekerjaanSampingan.ToListAsync());
        }

        // GET: PekerjaanUtamaDanPekerjaanSampingans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pekerjaanUtamaDanPekerjaanSampingan = await _context.PekerjaanUtamaDanPekerjaanSampingan
                .FirstOrDefaultAsync(m => m.PekerjaanUtamaDanPekerjaanSampinganID == id);
            if (pekerjaanUtamaDanPekerjaanSampingan == null)
            {
                return NotFound();
            }

            return View(pekerjaanUtamaDanPekerjaanSampingan);
        }

        // GET: PekerjaanUtamaDanPekerjaanSampingans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PekerjaanUtamaDanPekerjaanSampingans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PekerjaanUtamaDanPekerjaanSampinganID,Kode,Value")] PekerjaanUtamaDanPekerjaanSampingan pekerjaanUtamaDanPekerjaanSampingan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pekerjaanUtamaDanPekerjaanSampingan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pekerjaanUtamaDanPekerjaanSampingan);
        }

        // GET: PekerjaanUtamaDanPekerjaanSampingans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pekerjaanUtamaDanPekerjaanSampingan = await _context.PekerjaanUtamaDanPekerjaanSampingan.FindAsync(id);
            if (pekerjaanUtamaDanPekerjaanSampingan == null)
            {
                return NotFound();
            }
            return View(pekerjaanUtamaDanPekerjaanSampingan);
        }

        // POST: PekerjaanUtamaDanPekerjaanSampingans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PekerjaanUtamaDanPekerjaanSampinganID,Kode,Value")] PekerjaanUtamaDanPekerjaanSampingan pekerjaanUtamaDanPekerjaanSampingan)
        {
            if (id != pekerjaanUtamaDanPekerjaanSampingan.PekerjaanUtamaDanPekerjaanSampinganID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pekerjaanUtamaDanPekerjaanSampingan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PekerjaanUtamaDanPekerjaanSampinganExists(pekerjaanUtamaDanPekerjaanSampingan.PekerjaanUtamaDanPekerjaanSampinganID))
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
            return View(pekerjaanUtamaDanPekerjaanSampingan);
        }

        // GET: PekerjaanUtamaDanPekerjaanSampingans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pekerjaanUtamaDanPekerjaanSampingan = await _context.PekerjaanUtamaDanPekerjaanSampingan
                .FirstOrDefaultAsync(m => m.PekerjaanUtamaDanPekerjaanSampinganID == id);
            if (pekerjaanUtamaDanPekerjaanSampingan == null)
            {
                return NotFound();
            }

            return View(pekerjaanUtamaDanPekerjaanSampingan);
        }

        // POST: PekerjaanUtamaDanPekerjaanSampingans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pekerjaanUtamaDanPekerjaanSampingan = await _context.PekerjaanUtamaDanPekerjaanSampingan.FindAsync(id);
            _context.PekerjaanUtamaDanPekerjaanSampingan.Remove(pekerjaanUtamaDanPekerjaanSampingan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PekerjaanUtamaDanPekerjaanSampinganExists(int id)
        {
            return _context.PekerjaanUtamaDanPekerjaanSampingan.Any(e => e.PekerjaanUtamaDanPekerjaanSampinganID == id);
        }
    }
}
