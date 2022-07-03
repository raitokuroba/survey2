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
    public class LuasTanahSebelumsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public LuasTanahSebelumsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: LuasTanahSebelums
        public async Task<IActionResult> Index()
        {
            return View(await _context.LuasTanahSebelum.ToListAsync());
        }

        // GET: LuasTanahSebelums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luasTanahSebelum = await _context.LuasTanahSebelum
                .FirstOrDefaultAsync(m => m.LuasTanahSebelumId == id);
            if (luasTanahSebelum == null)
            {
                return NotFound();
            }

            return View(luasTanahSebelum);
        }

        // GET: LuasTanahSebelums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuasTanahSebelums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LuasTanahSebelumId,Kode,Value")] LuasTanahSebelum luasTanahSebelum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(luasTanahSebelum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luasTanahSebelum);
        }

        // GET: LuasTanahSebelums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luasTanahSebelum = await _context.LuasTanahSebelum.FindAsync(id);
            if (luasTanahSebelum == null)
            {
                return NotFound();
            }
            return View(luasTanahSebelum);
        }

        // POST: LuasTanahSebelums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LuasTanahSebelumId,Kode,Value")] LuasTanahSebelum luasTanahSebelum)
        {
            if (id != luasTanahSebelum.LuasTanahSebelumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luasTanahSebelum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuasTanahSebelumExists(luasTanahSebelum.LuasTanahSebelumId))
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
            return View(luasTanahSebelum);
        }

        // GET: LuasTanahSebelums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luasTanahSebelum = await _context.LuasTanahSebelum
                .FirstOrDefaultAsync(m => m.LuasTanahSebelumId == id);
            if (luasTanahSebelum == null)
            {
                return NotFound();
            }

            return View(luasTanahSebelum);
        }

        // POST: LuasTanahSebelums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var luasTanahSebelum = await _context.LuasTanahSebelum.FindAsync(id);
            _context.LuasTanahSebelum.Remove(luasTanahSebelum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuasTanahSebelumExists(int id)
        {
            return _context.LuasTanahSebelum.Any(e => e.LuasTanahSebelumId == id);
        }
    }
}
