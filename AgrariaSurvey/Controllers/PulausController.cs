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
    public class PulausController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public PulausController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: Pulaus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pulaus.ToListAsync());
        }

        // GET: Pulaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pulau = await _context.Pulaus
                .FirstOrDefaultAsync(m => m.PulauID == id);
            if (pulau == null)
            {
                return NotFound();
            }

            return View(pulau);
        }

        // GET: Pulaus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pulaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PulauID,Kode,Value")] Pulau pulau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pulau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pulau);
        }

        // GET: Pulaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pulau = await _context.Pulaus.FindAsync(id);
            if (pulau == null)
            {
                return NotFound();
            }
            return View(pulau);
        }

        // POST: Pulaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PulauID,Kode,Value")] Pulau pulau)
        {
            if (id != pulau.PulauID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pulau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PulauExists(pulau.PulauID))
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
            return View(pulau);
        }

        // GET: Pulaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pulau = await _context.Pulaus
                .FirstOrDefaultAsync(m => m.PulauID == id);
            if (pulau == null)
            {
                return NotFound();
            }

            return View(pulau);
        }

        // POST: Pulaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pulau = await _context.Pulaus.FindAsync(id);
            _context.Pulaus.Remove(pulau);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PulauExists(int id)
        {
            return _context.Pulaus.Any(e => e.PulauID == id);
        }
    }
}
