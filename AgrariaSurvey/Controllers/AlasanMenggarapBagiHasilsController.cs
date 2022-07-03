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
    public class AlasanMenggarapBagiHasilsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanMenggarapBagiHasilsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanMenggarapBagiHasils
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanMenggarapBagiHasil.ToListAsync());
        }

        // GET: AlasanMenggarapBagiHasils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenggarapBagiHasil = await _context.AlasanMenggarapBagiHasil
                .FirstOrDefaultAsync(m => m.AlasanMenggarapBagiHasilId == id);
            if (alasanMenggarapBagiHasil == null)
            {
                return NotFound();
            }

            return View(alasanMenggarapBagiHasil);
        }

        // GET: AlasanMenggarapBagiHasils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanMenggarapBagiHasils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanMenggarapBagiHasilId,Kode,Value")] AlasanMenggarapBagiHasil alasanMenggarapBagiHasil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanMenggarapBagiHasil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanMenggarapBagiHasil);
        }

        // GET: AlasanMenggarapBagiHasils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenggarapBagiHasil = await _context.AlasanMenggarapBagiHasil.FindAsync(id);
            if (alasanMenggarapBagiHasil == null)
            {
                return NotFound();
            }
            return View(alasanMenggarapBagiHasil);
        }

        // POST: AlasanMenggarapBagiHasils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanMenggarapBagiHasilId,Kode,Value")] AlasanMenggarapBagiHasil alasanMenggarapBagiHasil)
        {
            if (id != alasanMenggarapBagiHasil.AlasanMenggarapBagiHasilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanMenggarapBagiHasil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanMenggarapBagiHasilExists(alasanMenggarapBagiHasil.AlasanMenggarapBagiHasilId))
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
            return View(alasanMenggarapBagiHasil);
        }

        // GET: AlasanMenggarapBagiHasils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenggarapBagiHasil = await _context.AlasanMenggarapBagiHasil
                .FirstOrDefaultAsync(m => m.AlasanMenggarapBagiHasilId == id);
            if (alasanMenggarapBagiHasil == null)
            {
                return NotFound();
            }

            return View(alasanMenggarapBagiHasil);
        }

        // POST: AlasanMenggarapBagiHasils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanMenggarapBagiHasil = await _context.AlasanMenggarapBagiHasil.FindAsync(id);
            _context.AlasanMenggarapBagiHasil.Remove(alasanMenggarapBagiHasil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanMenggarapBagiHasilExists(int id)
        {
            return _context.AlasanMenggarapBagiHasil.Any(e => e.AlasanMenggarapBagiHasilId == id);
        }
    }
}
