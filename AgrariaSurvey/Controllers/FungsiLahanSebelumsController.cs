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
    public class FungsiLahanSebelumsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public FungsiLahanSebelumsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: FungsiLahanSebelums
        public async Task<IActionResult> Index()
        {
            return View(await _context.FungsiLahanSebelum.ToListAsync());
        }

        // GET: FungsiLahanSebelums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fungsiLahanSebelum = await _context.FungsiLahanSebelum
                .FirstOrDefaultAsync(m => m.FungsiLahanSebelumId == id);
            if (fungsiLahanSebelum == null)
            {
                return NotFound();
            }

            return View(fungsiLahanSebelum);
        }

        // GET: FungsiLahanSebelums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FungsiLahanSebelums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FungsiLahanSebelumId,Kode,Value")] FungsiLahanSebelum fungsiLahanSebelum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fungsiLahanSebelum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fungsiLahanSebelum);
        }

        // GET: FungsiLahanSebelums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fungsiLahanSebelum = await _context.FungsiLahanSebelum.FindAsync(id);
            if (fungsiLahanSebelum == null)
            {
                return NotFound();
            }
            return View(fungsiLahanSebelum);
        }

        // POST: FungsiLahanSebelums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FungsiLahanSebelumId,Kode,Value")] FungsiLahanSebelum fungsiLahanSebelum)
        {
            if (id != fungsiLahanSebelum.FungsiLahanSebelumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fungsiLahanSebelum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FungsiLahanSebelumExists(fungsiLahanSebelum.FungsiLahanSebelumId))
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
            return View(fungsiLahanSebelum);
        }

        // GET: FungsiLahanSebelums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fungsiLahanSebelum = await _context.FungsiLahanSebelum
                .FirstOrDefaultAsync(m => m.FungsiLahanSebelumId == id);
            if (fungsiLahanSebelum == null)
            {
                return NotFound();
            }

            return View(fungsiLahanSebelum);
        }

        // POST: FungsiLahanSebelums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fungsiLahanSebelum = await _context.FungsiLahanSebelum.FindAsync(id);
            _context.FungsiLahanSebelum.Remove(fungsiLahanSebelum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FungsiLahanSebelumExists(int id)
        {
            return _context.FungsiLahanSebelum.Any(e => e.FungsiLahanSebelumId == id);
        }
    }
}
