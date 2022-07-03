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
    public class AlasanPenjualMenjualsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AlasanPenjualMenjualsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AlasanPenjualMenjuals
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlasanPenjualMenjual.ToListAsync());
        }

        // GET: AlasanPenjualMenjuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanPenjualMenjual = await _context.AlasanPenjualMenjual
                .FirstOrDefaultAsync(m => m.AlasanPenjualMenjualId == id);
            if (alasanPenjualMenjual == null)
            {
                return NotFound();
            }

            return View(alasanPenjualMenjual);
        }

        // GET: AlasanPenjualMenjuals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlasanPenjualMenjuals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlasanPenjualMenjualId,Kode,Value")] AlasanPenjualMenjual alasanPenjualMenjual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alasanPenjualMenjual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alasanPenjualMenjual);
        }

        // GET: AlasanPenjualMenjuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanPenjualMenjual = await _context.AlasanPenjualMenjual.FindAsync(id);
            if (alasanPenjualMenjual == null)
            {
                return NotFound();
            }
            return View(alasanPenjualMenjual);
        }

        // POST: AlasanPenjualMenjuals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlasanPenjualMenjualId,Kode,Value")] AlasanPenjualMenjual alasanPenjualMenjual)
        {
            if (id != alasanPenjualMenjual.AlasanPenjualMenjualId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alasanPenjualMenjual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlasanPenjualMenjualExists(alasanPenjualMenjual.AlasanPenjualMenjualId))
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
            return View(alasanPenjualMenjual);
        }

        // GET: AlasanPenjualMenjuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alasanPenjualMenjual = await _context.AlasanPenjualMenjual
                .FirstOrDefaultAsync(m => m.AlasanPenjualMenjualId == id);
            if (alasanPenjualMenjual == null)
            {
                return NotFound();
            }

            return View(alasanPenjualMenjual);
        }

        // POST: AlasanPenjualMenjuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alasanPenjualMenjual = await _context.AlasanPenjualMenjual.FindAsync(id);
            _context.AlasanPenjualMenjual.Remove(alasanPenjualMenjual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlasanPenjualMenjualExists(int id)
        {
            return _context.AlasanPenjualMenjual.Any(e => e.AlasanPenjualMenjualId == id);
        }
    }
}
