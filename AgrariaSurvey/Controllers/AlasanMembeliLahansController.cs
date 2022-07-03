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
    public class AlasanMembeliLahansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanMembeliLahansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanMembeliLahans
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanMembeliLahan.ToListAsync());
        }

        // GET: AlasanMembeliLahans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMembeliLahan = await _context.AlasanMembeliLahan
                .FirstOrDefaultAsync(m => m.AlasanMembeliLahanId == id);
            if (alasanMembeliLahan == null)
            {
                return NotFound();
            }

            return View(alasanMembeliLahan);
        }

        // GET: AlasanMembeliLahans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanMembeliLahans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanMembeliLahanId,Kode,Value")] AlasanMembeliLahan alasanMembeliLahan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanMembeliLahan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanMembeliLahan);
        }

        // GET: AlasanMembeliLahans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMembeliLahan = await _context.AlasanMembeliLahan.FindAsync(id);
            if (alasanMembeliLahan == null)
            {
                return NotFound();
            }
            return View(alasanMembeliLahan);
        }

        // POST: AlasanMembeliLahans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanMembeliLahanId,Kode,Value")] AlasanMembeliLahan alasanMembeliLahan)
        {
            if (id != alasanMembeliLahan.AlasanMembeliLahanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanMembeliLahan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanMembeliLahanExists(alasanMembeliLahan.AlasanMembeliLahanId))
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
            return View(alasanMembeliLahan);
        }

        // GET: AlasanMembeliLahans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMembeliLahan = await _context.AlasanMembeliLahan
                .FirstOrDefaultAsync(m => m.AlasanMembeliLahanId == id);
            if (alasanMembeliLahan == null)
            {
                return NotFound();
            }

            return View(alasanMembeliLahan);
        }

        // POST: AlasanMembeliLahans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanMembeliLahan = await _context.AlasanMembeliLahan.FindAsync(id);
            _context.AlasanMembeliLahan.Remove(alasanMembeliLahan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanMembeliLahanExists(int id)
        {
            return _context.AlasanMembeliLahan.Any(e => e.AlasanMembeliLahanId == id);
        }
    }
}
