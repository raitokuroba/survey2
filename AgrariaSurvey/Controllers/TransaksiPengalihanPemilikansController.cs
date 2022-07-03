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
    public class TransaksiPengalihanPemilikansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public TransaksiPengalihanPemilikansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: TransaksiPengalihanPemilikans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransaksiPengalihanPemilikan.ToListAsync());
        }

        // GET: TransaksiPengalihanPemilikans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksiPengalihanPemilikan = await _context.TransaksiPengalihanPemilikan
                .FirstOrDefaultAsync(m => m.TransaksiPengalihanPemilikanId == id);
            if (transaksiPengalihanPemilikan == null)
            {
                return NotFound();
            }

            return View(transaksiPengalihanPemilikan);
        }

        // GET: TransaksiPengalihanPemilikans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransaksiPengalihanPemilikans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransaksiPengalihanPemilikanId,Kode,Value")] TransaksiPengalihanPemilikan transaksiPengalihanPemilikan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksiPengalihanPemilikan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaksiPengalihanPemilikan);
        }

        // GET: TransaksiPengalihanPemilikans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksiPengalihanPemilikan = await _context.TransaksiPengalihanPemilikan.FindAsync(id);
            if (transaksiPengalihanPemilikan == null)
            {
                return NotFound();
            }
            return View(transaksiPengalihanPemilikan);
        }

        // POST: TransaksiPengalihanPemilikans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransaksiPengalihanPemilikanId,Kode,Value")] TransaksiPengalihanPemilikan transaksiPengalihanPemilikan)
        {
            if (id != transaksiPengalihanPemilikan.TransaksiPengalihanPemilikanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksiPengalihanPemilikan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiPengalihanPemilikanExists(transaksiPengalihanPemilikan.TransaksiPengalihanPemilikanId))
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
            return View(transaksiPengalihanPemilikan);
        }

        // GET: TransaksiPengalihanPemilikans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksiPengalihanPemilikan = await _context.TransaksiPengalihanPemilikan
                .FirstOrDefaultAsync(m => m.TransaksiPengalihanPemilikanId == id);
            if (transaksiPengalihanPemilikan == null)
            {
                return NotFound();
            }

            return View(transaksiPengalihanPemilikan);
        }

        // POST: TransaksiPengalihanPemilikans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksiPengalihanPemilikan = await _context.TransaksiPengalihanPemilikan.FindAsync(id);
            _context.TransaksiPengalihanPemilikan.Remove(transaksiPengalihanPemilikan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiPengalihanPemilikanExists(int id)
        {
            return _context.TransaksiPengalihanPemilikan.Any(e => e.TransaksiPengalihanPemilikanId == id);
        }
    }
}
