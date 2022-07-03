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
    public class StatusTanahsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public StatusTanahsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: StatusTanahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusTanah.ToListAsync());
        }

        // GET: StatusTanahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusTanah = await _context.StatusTanah
                .FirstOrDefaultAsync(m => m.StatusTanahID == id);
            if (statusTanah == null)
            {
                return NotFound();
            }

            return View(statusTanah);
        }

        // GET: StatusTanahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusTanahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusTanahID,Kode,Value")] StatusTanah statusTanah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusTanah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusTanah);
        }

        // GET: StatusTanahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusTanah = await _context.StatusTanah.FindAsync(id);
            if (statusTanah == null)
            {
                return NotFound();
            }
            return View(statusTanah);
        }

        // POST: StatusTanahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusTanahID,Kode,Value")] StatusTanah statusTanah)
        {
            if (id != statusTanah.StatusTanahID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusTanah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusTanahExists(statusTanah.StatusTanahID))
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
            return View(statusTanah);
        }

        // GET: StatusTanahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusTanah = await _context.StatusTanah
                .FirstOrDefaultAsync(m => m.StatusTanahID == id);
            if (statusTanah == null)
            {
                return NotFound();
            }

            return View(statusTanah);
        }

        // POST: StatusTanahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusTanah = await _context.StatusTanah.FindAsync(id);
            _context.StatusTanah.Remove(statusTanah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusTanahExists(int id)
        {
            return _context.StatusTanah.Any(e => e.StatusTanahID == id);
        }
    }
}
