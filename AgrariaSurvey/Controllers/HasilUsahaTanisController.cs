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
    public class HasilUsahaTanisController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public HasilUsahaTanisController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: HasilUsahaTanis
        public async Task<IActionResult> Index()
        {
            return View(await _context.HasilUsahaTani.ToListAsync());
        }

        // GET: HasilUsahaTanis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasilUsahaTani = await _context.HasilUsahaTani
                .FirstOrDefaultAsync(m => m.HasilUsahaTaniId == id);
            if (hasilUsahaTani == null)
            {
                return NotFound();
            }

            return View(hasilUsahaTani);
        }

        // GET: HasilUsahaTanis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HasilUsahaTanis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HasilUsahaTaniId,Kode,Value")] HasilUsahaTani hasilUsahaTani)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hasilUsahaTani);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasilUsahaTani);
        }

        // GET: HasilUsahaTanis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasilUsahaTani = await _context.HasilUsahaTani.FindAsync(id);
            if (hasilUsahaTani == null)
            {
                return NotFound();
            }
            return View(hasilUsahaTani);
        }

        // POST: HasilUsahaTanis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HasilUsahaTaniId,Kode,Value")] HasilUsahaTani hasilUsahaTani)
        {
            if (id != hasilUsahaTani.HasilUsahaTaniId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasilUsahaTani);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HasilUsahaTaniExists(hasilUsahaTani.HasilUsahaTaniId))
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
            return View(hasilUsahaTani);
        }

        // GET: HasilUsahaTanis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasilUsahaTani = await _context.HasilUsahaTani
                .FirstOrDefaultAsync(m => m.HasilUsahaTaniId == id);
            if (hasilUsahaTani == null)
            {
                return NotFound();
            }

            return View(hasilUsahaTani);
        }

        // POST: HasilUsahaTanis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hasilUsahaTani = await _context.HasilUsahaTani.FindAsync(id);
            _context.HasilUsahaTani.Remove(hasilUsahaTani);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HasilUsahaTaniExists(int id)
        {
            return _context.HasilUsahaTani.Any(e => e.HasilUsahaTaniId == id);
        }
    }
}
