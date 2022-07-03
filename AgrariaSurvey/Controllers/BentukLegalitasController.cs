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
    public class BentukLegalitasController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public BentukLegalitasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: BentukLegalitas
        public async Task<IActionResult> Index()
        {
            return View(await _context.BentukLegalitas.ToListAsync());
        }

        // GET: BentukLegalitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bentukLegalitas = await _context.BentukLegalitas
                .FirstOrDefaultAsync(m => m.BentukLegalitasId == id);
            if (bentukLegalitas == null)
            {
                return NotFound();
            }

            return View(bentukLegalitas);
        }

        // GET: BentukLegalitas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BentukLegalitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BentukLegalitasId,Kode,Value")] BentukLegalitas bentukLegalitas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bentukLegalitas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bentukLegalitas);
        }

        // GET: BentukLegalitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bentukLegalitas = await _context.BentukLegalitas.FindAsync(id);
            if (bentukLegalitas == null)
            {
                return NotFound();
            }
            return View(bentukLegalitas);
        }

        // POST: BentukLegalitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BentukLegalitasId,Kode,Value")] BentukLegalitas bentukLegalitas)
        {
            if (id != bentukLegalitas.BentukLegalitasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bentukLegalitas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BentukLegalitasExists(bentukLegalitas.BentukLegalitasId))
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
            return View(bentukLegalitas);
        }

        // GET: BentukLegalitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bentukLegalitas = await _context.BentukLegalitas
                .FirstOrDefaultAsync(m => m.BentukLegalitasId == id);
            if (bentukLegalitas == null)
            {
                return NotFound();
            }

            return View(bentukLegalitas);
        }

        // POST: BentukLegalitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bentukLegalitas = await _context.BentukLegalitas.FindAsync(id);
            _context.BentukLegalitas.Remove(bentukLegalitas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BentukLegalitasExists(int id)
        {
            return _context.BentukLegalitas.Any(e => e.BentukLegalitasId == id);
        }
    }
}
