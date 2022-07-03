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
    public class TenagaYangMengelolasController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public TenagaYangMengelolasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: TenagaYangMengelolas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TenagaYangMengelola.ToListAsync());
        }

        // GET: TenagaYangMengelolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenagaYangMengelola = await _context.TenagaYangMengelola
                .FirstOrDefaultAsync(m => m.TenagaYangMengelolaId == id);
            if (tenagaYangMengelola == null)
            {
                return NotFound();
            }

            return View(tenagaYangMengelola);
        }

        // GET: TenagaYangMengelolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TenagaYangMengelolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenagaYangMengelolaId,Kode,Value")] TenagaYangMengelola tenagaYangMengelola)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenagaYangMengelola);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tenagaYangMengelola);
        }

        // GET: TenagaYangMengelolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenagaYangMengelola = await _context.TenagaYangMengelola.FindAsync(id);
            if (tenagaYangMengelola == null)
            {
                return NotFound();
            }
            return View(tenagaYangMengelola);
        }

        // POST: TenagaYangMengelolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TenagaYangMengelolaId,Kode,Value")] TenagaYangMengelola tenagaYangMengelola)
        {
            if (id != tenagaYangMengelola.TenagaYangMengelolaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenagaYangMengelola);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenagaYangMengelolaExists(tenagaYangMengelola.TenagaYangMengelolaId))
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
            return View(tenagaYangMengelola);
        }

        // GET: TenagaYangMengelolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenagaYangMengelola = await _context.TenagaYangMengelola
                .FirstOrDefaultAsync(m => m.TenagaYangMengelolaId == id);
            if (tenagaYangMengelola == null)
            {
                return NotFound();
            }

            return View(tenagaYangMengelola);
        }

        // POST: TenagaYangMengelolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tenagaYangMengelola = await _context.TenagaYangMengelola.FindAsync(id);
            _context.TenagaYangMengelola.Remove(tenagaYangMengelola);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TenagaYangMengelolaExists(int id)
        {
            return _context.TenagaYangMengelola.Any(e => e.TenagaYangMengelolaId == id);
        }
    }
}
