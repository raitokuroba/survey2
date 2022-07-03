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
    public class SistemPewarisansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public SistemPewarisansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: SistemPewarisans
        public async Task<IActionResult> Index()
        {
            return View(await _context.SistemPewarisan.ToListAsync());
        }

        // GET: SistemPewarisans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemPewarisan = await _context.SistemPewarisan
                .FirstOrDefaultAsync(m => m.SistemPewarisanId == id);
            if (sistemPewarisan == null)
            {
                return NotFound();
            }

            return View(sistemPewarisan);
        }

        // GET: SistemPewarisans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SistemPewarisans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SistemPewarisanId,Kode,Value")] SistemPewarisan sistemPewarisan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistemPewarisan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistemPewarisan);
        }

        // GET: SistemPewarisans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemPewarisan = await _context.SistemPewarisan.FindAsync(id);
            if (sistemPewarisan == null)
            {
                return NotFound();
            }
            return View(sistemPewarisan);
        }

        // POST: SistemPewarisans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SistemPewarisanId,Kode,Value")] SistemPewarisan sistemPewarisan)
        {
            if (id != sistemPewarisan.SistemPewarisanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistemPewarisan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemPewarisanExists(sistemPewarisan.SistemPewarisanId))
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
            return View(sistemPewarisan);
        }

        // GET: SistemPewarisans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistemPewarisan = await _context.SistemPewarisan
                .FirstOrDefaultAsync(m => m.SistemPewarisanId == id);
            if (sistemPewarisan == null)
            {
                return NotFound();
            }

            return View(sistemPewarisan);
        }

        // POST: SistemPewarisans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sistemPewarisan = await _context.SistemPewarisan.FindAsync(id);
            _context.SistemPewarisan.Remove(sistemPewarisan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemPewarisanExists(int id)
        {
            return _context.SistemPewarisan.Any(e => e.SistemPewarisanId == id);
        }
    }
}
