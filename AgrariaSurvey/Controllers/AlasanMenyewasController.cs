using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgrariaSurvey.Data;
using AgrariaSurvey.Models;

namespace AgrariaSurvey.Controllers
{
    public class AlasanMenyewasController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanMenyewasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanMenyewas
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanMenyewa.ToListAsync());
        }

        // GET: AlasanMenyewas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenyewa = await _context.AlasanMenyewa
                .FirstOrDefaultAsync(m => m.AlasanMenyewaId == id);
            if (alasanMenyewa == null)
            {
                return NotFound();
            }

            return View(alasanMenyewa);
        }

        // GET: AlasanMenyewas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanMenyewas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanMenyewaId,Kode,Value")] AlasanMenyewa alasanMenyewa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanMenyewa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanMenyewa);
        }

        // GET: AlasanMenyewas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenyewa = await _context.AlasanMenyewa.FindAsync(id);
            if (alasanMenyewa == null)
            {
                return NotFound();
            }
            return View(alasanMenyewa);
        }

        // POST: AlasanMenyewas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanMenyewaId,Kode,Value")] AlasanMenyewa alasanMenyewa)
        {
            if (id != alasanMenyewa.AlasanMenyewaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanMenyewa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanMenyewaExists(alasanMenyewa.AlasanMenyewaId))
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
            return View(alasanMenyewa);
        }

        // GET: AlasanMenyewas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenyewa = await _context.AlasanMenyewa
                .FirstOrDefaultAsync(m => m.AlasanMenyewaId == id);
            if (alasanMenyewa == null)
            {
                return NotFound();
            }

            return View(alasanMenyewa);
        }

        // POST: AlasanMenyewas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanMenyewa = await _context.AlasanMenyewa.FindAsync(id);
            _context.AlasanMenyewa.Remove(alasanMenyewa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanMenyewaExists(int id)
        {
            return _context.AlasanMenyewa.Any(e => e.AlasanMenyewaId == id);
        }
    }
}
