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
    public class AlasanMenyewakansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanMenyewakansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanMenyewakans
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanMenyewakan.ToListAsync());
        }

        // GET: AlasanMenyewakans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenyewakan = await _context.AlasanMenyewakan
                .FirstOrDefaultAsync(m => m.AlasanMenyewakanId == id);
            if (alasanMenyewakan == null)
            {
                return NotFound();
            }

            return View(alasanMenyewakan);
        }

        // GET: AlasanMenyewakans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanMenyewakans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanMenyewakanId,Kode,Value")] AlasanMenyewakan alasanMenyewakan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanMenyewakan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanMenyewakan);
        }

        // GET: AlasanMenyewakans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenyewakan = await _context.AlasanMenyewakan.FindAsync(id);
            if (alasanMenyewakan == null)
            {
                return NotFound();
            }
            return View(alasanMenyewakan);
        }

        // POST: AlasanMenyewakans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanMenyewakanId,Kode,Value")] AlasanMenyewakan alasanMenyewakan)
        {
            if (id != alasanMenyewakan.AlasanMenyewakanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanMenyewakan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanMenyewakanExists(alasanMenyewakan.AlasanMenyewakanId))
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
            return View(alasanMenyewakan);
        }

        // GET: AlasanMenyewakans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanMenyewakan = await _context.AlasanMenyewakan
                .FirstOrDefaultAsync(m => m.AlasanMenyewakanId == id);
            if (alasanMenyewakan == null)
            {
                return NotFound();
            }

            return View(alasanMenyewakan);
        }

        // POST: AlasanMenyewakans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanMenyewakan = await _context.AlasanMenyewakan.FindAsync(id);
            _context.AlasanMenyewakan.Remove(alasanMenyewakan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanMenyewakanExists(int id)
        {
            return _context.AlasanMenyewakan.Any(e => e.AlasanMenyewakanId == id);
        }
    }
}
