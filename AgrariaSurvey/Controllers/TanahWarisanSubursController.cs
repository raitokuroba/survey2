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
    public class TanahWarisanSubursController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public TanahWarisanSubursController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: TanahWarisanSuburs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TanahWarisanSubur.ToListAsync());
        }

        // GET: TanahWarisanSuburs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanahWarisanSubur = await _context.TanahWarisanSubur
                .FirstOrDefaultAsync(m => m.TanahWarisanSuburId == id);
            if (tanahWarisanSubur == null)
            {
                return NotFound();
            }

            return View(tanahWarisanSubur);
        }

        // GET: TanahWarisanSuburs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TanahWarisanSuburs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TanahWarisanSuburId,Kode,Value")] TanahWarisanSubur tanahWarisanSubur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tanahWarisanSubur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tanahWarisanSubur);
        }

        // GET: TanahWarisanSuburs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanahWarisanSubur = await _context.TanahWarisanSubur.FindAsync(id);
            if (tanahWarisanSubur == null)
            {
                return NotFound();
            }
            return View(tanahWarisanSubur);
        }

        // POST: TanahWarisanSuburs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TanahWarisanSuburId,Kode,Value")] TanahWarisanSubur tanahWarisanSubur)
        {
            if (id != tanahWarisanSubur.TanahWarisanSuburId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tanahWarisanSubur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TanahWarisanSuburExists(tanahWarisanSubur.TanahWarisanSuburId))
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
            return View(tanahWarisanSubur);
        }

        // GET: TanahWarisanSuburs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tanahWarisanSubur = await _context.TanahWarisanSubur
                .FirstOrDefaultAsync(m => m.TanahWarisanSuburId == id);
            if (tanahWarisanSubur == null)
            {
                return NotFound();
            }

            return View(tanahWarisanSubur);
        }

        // POST: TanahWarisanSuburs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tanahWarisanSubur = await _context.TanahWarisanSubur.FindAsync(id);
            _context.TanahWarisanSubur.Remove(tanahWarisanSubur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TanahWarisanSuburExists(int id)
        {
            return _context.TanahWarisanSubur.Any(e => e.TanahWarisanSuburId == id);
        }
    }
}
