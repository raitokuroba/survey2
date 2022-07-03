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
    public class JumlahBuruhsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public JumlahBuruhsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: JumlahBuruhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.JumlahBuruh.ToListAsync());
        }

        // GET: JumlahBuruhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumlahBuruh = await _context.JumlahBuruh
                .FirstOrDefaultAsync(m => m.JumlahBuruhId == id);
            if (jumlahBuruh == null)
            {
                return NotFound();
            }

            return View(jumlahBuruh);
        }

        // GET: JumlahBuruhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JumlahBuruhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JumlahBuruhId,Kode,Value")] JumlahBuruh jumlahBuruh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jumlahBuruh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jumlahBuruh);
        }

        // GET: JumlahBuruhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumlahBuruh = await _context.JumlahBuruh.FindAsync(id);
            if (jumlahBuruh == null)
            {
                return NotFound();
            }
            return View(jumlahBuruh);
        }

        // POST: JumlahBuruhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JumlahBuruhId,Kode,Value")] JumlahBuruh jumlahBuruh)
        {
            if (id != jumlahBuruh.JumlahBuruhId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jumlahBuruh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JumlahBuruhExists(jumlahBuruh.JumlahBuruhId))
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
            return View(jumlahBuruh);
        }

        // GET: JumlahBuruhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jumlahBuruh = await _context.JumlahBuruh
                .FirstOrDefaultAsync(m => m.JumlahBuruhId == id);
            if (jumlahBuruh == null)
            {
                return NotFound();
            }

            return View(jumlahBuruh);
        }

        // POST: JumlahBuruhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jumlahBuruh = await _context.JumlahBuruh.FindAsync(id);
            _context.JumlahBuruh.Remove(jumlahBuruh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JumlahBuruhExists(int id)
        {
            return _context.JumlahBuruh.Any(e => e.JumlahBuruhId == id);
        }
    }
}
