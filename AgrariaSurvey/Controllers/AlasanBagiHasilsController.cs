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
    public class AlasanBagiHasilsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanBagiHasilsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanBagiHasils
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanBagiHasil.ToListAsync());
        }

        // GET: AlasanBagiHasils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanBagiHasil = await _context.AlasanBagiHasil
                .FirstOrDefaultAsync(m => m.AlasanBagiHasilId == id);
            if (alasanBagiHasil == null)
            {
                return NotFound();
            }

            return View(alasanBagiHasil);
        }

        // GET: AlasanBagiHasils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanBagiHasils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanBagiHasilId,Kode,Value")] AlasanBagiHasil alasanBagiHasil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanBagiHasil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanBagiHasil);
        }

        // GET: AlasanBagiHasils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanBagiHasil = await _context.AlasanBagiHasil.FindAsync(id);
            if (alasanBagiHasil == null)
            {
                return NotFound();
            }
            return View(alasanBagiHasil);
        }

        // POST: AlasanBagiHasils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanBagiHasilId,Kode,Value")] AlasanBagiHasil alasanBagiHasil)
        {
            if (id != alasanBagiHasil.AlasanBagiHasilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanBagiHasil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanBagiHasilExists(alasanBagiHasil.AlasanBagiHasilId))
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
            return View(alasanBagiHasil);
        }

        // GET: AlasanBagiHasils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanBagiHasil = await _context.AlasanBagiHasil
                .FirstOrDefaultAsync(m => m.AlasanBagiHasilId == id);
            if (alasanBagiHasil == null)
            {
                return NotFound();
            }

            return View(alasanBagiHasil);
        }

        // POST: AlasanBagiHasils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanBagiHasil = await _context.AlasanBagiHasil.FindAsync(id);
            _context.AlasanBagiHasil.Remove(alasanBagiHasil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanBagiHasilExists(int id)
        {
            return _context.AlasanBagiHasil.Any(e => e.AlasanBagiHasilId == id);
        }
    }
}
