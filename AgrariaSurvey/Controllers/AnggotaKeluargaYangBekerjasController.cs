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
    public class AnggotaKeluargaYangBekerjasController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public AnggotaKeluargaYangBekerjasController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: AnggotaKeluargaYangBekerjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnggotaKeluargaYangBekerja.ToListAsync());
        }

        // GET: AnggotaKeluargaYangBekerjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggotaKeluargaYangBekerja = await _context.AnggotaKeluargaYangBekerja
                .FirstOrDefaultAsync(m => m.AnggotaKeluargaYangBekerjaId == id);
            if (anggotaKeluargaYangBekerja == null)
            {
                return NotFound();
            }

            return View(anggotaKeluargaYangBekerja);
        }

        // GET: AnggotaKeluargaYangBekerjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnggotaKeluargaYangBekerjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnggotaKeluargaYangBekerjaId,Kode,Value")] AnggotaKeluargaYangBekerja anggotaKeluargaYangBekerja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anggotaKeluargaYangBekerja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anggotaKeluargaYangBekerja);
        }

        // GET: AnggotaKeluargaYangBekerjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggotaKeluargaYangBekerja = await _context.AnggotaKeluargaYangBekerja.FindAsync(id);
            if (anggotaKeluargaYangBekerja == null)
            {
                return NotFound();
            }
            return View(anggotaKeluargaYangBekerja);
        }

        // POST: AnggotaKeluargaYangBekerjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnggotaKeluargaYangBekerjaId,Kode,Value")] AnggotaKeluargaYangBekerja anggotaKeluargaYangBekerja)
        {
            if (id != anggotaKeluargaYangBekerja.AnggotaKeluargaYangBekerjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anggotaKeluargaYangBekerja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnggotaKeluargaYangBekerjaExists(anggotaKeluargaYangBekerja.AnggotaKeluargaYangBekerjaId))
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
            return View(anggotaKeluargaYangBekerja);
        }

        // GET: AnggotaKeluargaYangBekerjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anggotaKeluargaYangBekerja = await _context.AnggotaKeluargaYangBekerja
                .FirstOrDefaultAsync(m => m.AnggotaKeluargaYangBekerjaId == id);
            if (anggotaKeluargaYangBekerja == null)
            {
                return NotFound();
            }

            return View(anggotaKeluargaYangBekerja);
        }

        // POST: AnggotaKeluargaYangBekerjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anggotaKeluargaYangBekerja = await _context.AnggotaKeluargaYangBekerja.FindAsync(id);
            _context.AnggotaKeluargaYangBekerja.Remove(anggotaKeluargaYangBekerja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnggotaKeluargaYangBekerjaExists(int id)
        {
            return _context.AnggotaKeluargaYangBekerja.Any(e => e.AnggotaKeluargaYangBekerjaId == id);
        }
    }
}
