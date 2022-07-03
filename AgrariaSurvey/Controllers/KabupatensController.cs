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
    public class KabupatensController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public KabupatensController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: Kabupatens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kabupaten.ToListAsync());
        }

        // GET: Kabupatens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kabupaten = await _context.Kabupaten
                .FirstOrDefaultAsync(m => m.KabupatenID == id);
            if (kabupaten == null)
            {
                return NotFound();
            }

            return View(kabupaten);
        }

        // GET: Kabupatens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kabupatens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KabupatenID,Kode,Value,KodeParent")] Kabupaten kabupaten)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kabupaten);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kabupaten);
        }

        // GET: Kabupatens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kabupaten = await _context.Kabupaten.FindAsync(id);
            if (kabupaten == null)
            {
                return NotFound();
            }
            return View(kabupaten);
        }

        // POST: Kabupatens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KabupatenID,Kode,Value,KodeParent")] Kabupaten kabupaten)
        {
            if (id != kabupaten.KabupatenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kabupaten);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KabupatenExists(kabupaten.KabupatenID))
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
            return View(kabupaten);
        }

        // GET: Kabupatens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kabupaten = await _context.Kabupaten
                .FirstOrDefaultAsync(m => m.KabupatenID == id);
            if (kabupaten == null)
            {
                return NotFound();
            }

            return View(kabupaten);
        }

        // POST: Kabupatens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kabupaten = await _context.Kabupaten.FindAsync(id);
            _context.Kabupaten.Remove(kabupaten);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KabupatenExists(int id)
        {
            return _context.Kabupaten.Any(e => e.KabupatenID == id);
        }
    }
}
