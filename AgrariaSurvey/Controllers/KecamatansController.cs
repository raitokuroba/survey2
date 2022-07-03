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
    public class KecamatansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public KecamatansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: Kecamatans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kecamatans.ToListAsync());
        }

        // GET: Kecamatans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kecamatans = await _context.Kecamatans
                .FirstOrDefaultAsync(m => m.KecamatanID == id);
            if (kecamatans == null)
            {
                return NotFound();
            }

            return View(kecamatans);
        }

        // GET: Kecamatans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kecamatans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KecamatanID,Kode,Value,KodeKota")] Kecamatans kecamatans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kecamatans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kecamatans);
        }

        // GET: Kecamatans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kecamatans = await _context.Kecamatans.FindAsync(id);
            if (kecamatans == null)
            {
                return NotFound();
            }
            return View(kecamatans);
        }

        // POST: Kecamatans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KecamatanID,Kode,Value,KodeKota")] Kecamatans kecamatans)
        {
            if (id != kecamatans.KecamatanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kecamatans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KecamatansExists(kecamatans.KecamatanID))
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
            return View(kecamatans);
        }

        // GET: Kecamatans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kecamatans = await _context.Kecamatans
                .FirstOrDefaultAsync(m => m.KecamatanID == id);
            if (kecamatans == null)
            {
                return NotFound();
            }

            return View(kecamatans);
        }

        // POST: Kecamatans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kecamatans = await _context.Kecamatans.FindAsync(id);
            _context.Kecamatans.Remove(kecamatans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KecamatansExists(int id)
        {
            return _context.Kecamatans.Any(e => e.KecamatanID == id);
        }
    }
}
