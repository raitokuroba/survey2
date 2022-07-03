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
    public class KelurahansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public KelurahansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: Kelurahans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kelurahans.ToListAsync());
        }

        // GET: Kelurahans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelurahan = await _context.Kelurahans
                .FirstOrDefaultAsync(m => m.KelurahanID == id);
            if (kelurahan == null)
            {
                return NotFound();
            }

            return View(kelurahan);
        }

        // GET: Kelurahans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kelurahans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KelurahanID,Kode,Value,KodeKecamatan")] Kelurahan kelurahan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kelurahan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kelurahan);
        }

        // GET: Kelurahans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelurahan = await _context.Kelurahans.FindAsync(id);
            if (kelurahan == null)
            {
                return NotFound();
            }
            return View(kelurahan);
        }

        // POST: Kelurahans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KelurahanID,Kode,Value,KodeKecamatan")] Kelurahan kelurahan)
        {
            if (id != kelurahan.KelurahanID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kelurahan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KelurahanExists(kelurahan.KelurahanID))
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
            return View(kelurahan);
        }

        // GET: Kelurahans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kelurahan = await _context.Kelurahans
                .FirstOrDefaultAsync(m => m.KelurahanID == id);
            if (kelurahan == null)
            {
                return NotFound();
            }

            return View(kelurahan);
        }

        // POST: Kelurahans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kelurahan = await _context.Kelurahans.FindAsync(id);
            _context.Kelurahans.Remove(kelurahan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KelurahanExists(int id)
        {
            return _context.Kelurahans.Any(e => e.KelurahanID == id);
        }
    }
}
