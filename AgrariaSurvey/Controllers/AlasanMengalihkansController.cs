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
    public class AlasanMengalihkansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanMengalihkansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanMengalihkans
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanMengalihkan.ToListAsync());
        }

        // GET: AlasanMengalihkans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMengalihkan = await _context.AlasanMengalihkan
                .FirstOrDefaultAsync(m => m.AlasanMengalihkanId == id);
            if (alasanMengalihkan == null)
            {
                return NotFound();
            }

            return View(alasanMengalihkan);
        }

        // GET: AlasanMengalihkans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanMengalihkans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanMengalihkanId,Kode,Value")] AlasanMengalihkan alasanMengalihkan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanMengalihkan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanMengalihkan);
        }

        // GET: AlasanMengalihkans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMengalihkan = await _context.AlasanMengalihkan.FindAsync(id);
            if (alasanMengalihkan == null)
            {
                return NotFound();
            }
            return View(alasanMengalihkan);
        }

        // POST: AlasanMengalihkans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanMengalihkanId,Kode,Value")] AlasanMengalihkan alasanMengalihkan)
        {
            if (id != alasanMengalihkan.AlasanMengalihkanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanMengalihkan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanMengalihkanExists(alasanMengalihkan.AlasanMengalihkanId))
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
            return View(alasanMengalihkan);
        }

        // GET: AlasanMengalihkans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMengalihkan = await _context.AlasanMengalihkan
                .FirstOrDefaultAsync(m => m.AlasanMengalihkanId == id);
            if (alasanMengalihkan == null)
            {
                return NotFound();
            }

            return View(alasanMengalihkan);
        }

        // POST: AlasanMengalihkans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanMengalihkan = await _context.AlasanMengalihkan.FindAsync(id);
            _context.AlasanMengalihkan.Remove(alasanMengalihkan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanMengalihkanExists(int id)
        {
            return _context.AlasanMengalihkan.Any(e => e.AlasanMengalihkanId == id);
        }
    }
}
