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
    public class LokasiLahansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public LokasiLahansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: LokasiLahans
        public async Task<IActionResult> Index()
        {
            return View(await _context.LokasiLahan.ToListAsync());
        }

        // GET: LokasiLahans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokasiLahan = await _context.LokasiLahan
                .FirstOrDefaultAsync(m => m.LokasiLahanId == id);
            if (lokasiLahan == null)
            {
                return NotFound();
            }

            return View(lokasiLahan);
        }

        // GET: LokasiLahans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LokasiLahans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LokasiLahanId,Kode,Value")] LokasiLahan lokasiLahan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lokasiLahan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lokasiLahan);
        }

        // GET: LokasiLahans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokasiLahan = await _context.LokasiLahan.FindAsync(id);
            if (lokasiLahan == null)
            {
                return NotFound();
            }
            return View(lokasiLahan);
        }

        // POST: LokasiLahans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LokasiLahanId,Kode,Value")] LokasiLahan lokasiLahan)
        {
            if (id != lokasiLahan.LokasiLahanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lokasiLahan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LokasiLahanExists(lokasiLahan.LokasiLahanId))
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
            return View(lokasiLahan);
        }

        // GET: LokasiLahans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lokasiLahan = await _context.LokasiLahan
                .FirstOrDefaultAsync(m => m.LokasiLahanId == id);
            if (lokasiLahan == null)
            {
                return NotFound();
            }

            return View(lokasiLahan);
        }

        // POST: LokasiLahans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lokasiLahan = await _context.LokasiLahan.FindAsync(id);
            _context.LokasiLahan.Remove(lokasiLahan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LokasiLahanExists(int id)
        {
            return _context.LokasiLahan.Any(e => e.LokasiLahanId == id);
        }
    }
}
