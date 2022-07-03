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
    public class KomposisiBagiHasilsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public KomposisiBagiHasilsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: KomposisiBagiHasils
        public async Task<IActionResult> Index()
        {
            return View(await _context.KomposisiBagiHasil.ToListAsync());
        }

        // GET: KomposisiBagiHasils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komposisiBagiHasil = await _context.KomposisiBagiHasil
                .FirstOrDefaultAsync(m => m.KomposisiBagiHasilId == id);
            if (komposisiBagiHasil == null)
            {
                return NotFound();
            }

            return View(komposisiBagiHasil);
        }

        // GET: KomposisiBagiHasils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KomposisiBagiHasils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KomposisiBagiHasilId,Kode,Value")] KomposisiBagiHasil komposisiBagiHasil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komposisiBagiHasil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komposisiBagiHasil);
        }

        // GET: KomposisiBagiHasils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komposisiBagiHasil = await _context.KomposisiBagiHasil.FindAsync(id);
            if (komposisiBagiHasil == null)
            {
                return NotFound();
            }
            return View(komposisiBagiHasil);
        }

        // POST: KomposisiBagiHasils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KomposisiBagiHasilId,Kode,Value")] KomposisiBagiHasil komposisiBagiHasil)
        {
            if (id != komposisiBagiHasil.KomposisiBagiHasilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komposisiBagiHasil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomposisiBagiHasilExists(komposisiBagiHasil.KomposisiBagiHasilId))
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
            return View(komposisiBagiHasil);
        }

        // GET: KomposisiBagiHasils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komposisiBagiHasil = await _context.KomposisiBagiHasil
                .FirstOrDefaultAsync(m => m.KomposisiBagiHasilId == id);
            if (komposisiBagiHasil == null)
            {
                return NotFound();
            }

            return View(komposisiBagiHasil);
        }

        // POST: KomposisiBagiHasils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komposisiBagiHasil = await _context.KomposisiBagiHasil.FindAsync(id);
            _context.KomposisiBagiHasil.Remove(komposisiBagiHasil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomposisiBagiHasilExists(int id)
        {
            return _context.KomposisiBagiHasil.Any(e => e.KomposisiBagiHasilId == id);
        }
    }
}
