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
    public class KepadaSiapaPengalihansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public KepadaSiapaPengalihansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: KepadaSiapaPengalihans
        public async Task<IActionResult> Index()
        {
            return View(await _context.KepadaSiapaPengalihan.ToListAsync());
        }

        // GET: KepadaSiapaPengalihans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kepadaSiapaPengalihan = await _context.KepadaSiapaPengalihan
                .FirstOrDefaultAsync(m => m.KepadaSiapaPengalihanId == id);
            if (kepadaSiapaPengalihan == null)
            {
                return NotFound();
            }

            return View(kepadaSiapaPengalihan);
        }

        // GET: KepadaSiapaPengalihans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KepadaSiapaPengalihans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KepadaSiapaPengalihanId,Kode,Value")] KepadaSiapaPengalihan kepadaSiapaPengalihan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kepadaSiapaPengalihan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kepadaSiapaPengalihan);
        }

        // GET: KepadaSiapaPengalihans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kepadaSiapaPengalihan = await _context.KepadaSiapaPengalihan.FindAsync(id);
            if (kepadaSiapaPengalihan == null)
            {
                return NotFound();
            }
            return View(kepadaSiapaPengalihan);
        }

        // POST: KepadaSiapaPengalihans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KepadaSiapaPengalihanId,Kode,Value")] KepadaSiapaPengalihan kepadaSiapaPengalihan)
        {
            if (id != kepadaSiapaPengalihan.KepadaSiapaPengalihanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kepadaSiapaPengalihan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KepadaSiapaPengalihanExists(kepadaSiapaPengalihan.KepadaSiapaPengalihanId))
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
            return View(kepadaSiapaPengalihan);
        }

        // GET: KepadaSiapaPengalihans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kepadaSiapaPengalihan = await _context.KepadaSiapaPengalihan
                .FirstOrDefaultAsync(m => m.KepadaSiapaPengalihanId == id);
            if (kepadaSiapaPengalihan == null)
            {
                return NotFound();
            }

            return View(kepadaSiapaPengalihan);
        }

        // POST: KepadaSiapaPengalihans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kepadaSiapaPengalihan = await _context.KepadaSiapaPengalihan.FindAsync(id);
            _context.KepadaSiapaPengalihan.Remove(kepadaSiapaPengalihan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KepadaSiapaPengalihanExists(int id)
        {
            return _context.KepadaSiapaPengalihan.Any(e => e.KepadaSiapaPengalihanId == id);
        }
    }
}
