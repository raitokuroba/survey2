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
    public class LuasTanahDiwariskansController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public LuasTanahDiwariskansController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: LuasTanahDiwariskans
        public async Task<IActionResult> Index()
        {
            return View(await _context.LuasTanahDiwariskan.ToListAsync());
        }

        // GET: LuasTanahDiwariskans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luasTanahDiwariskan = await _context.LuasTanahDiwariskan
                .FirstOrDefaultAsync(m => m.LuasTanahDiwariskanId == id);
            if (luasTanahDiwariskan == null)
            {
                return NotFound();
            }

            return View(luasTanahDiwariskan);
        }

        // GET: LuasTanahDiwariskans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LuasTanahDiwariskans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LuasTanahDiwariskanId,Kode,Value")] LuasTanahDiwariskan luasTanahDiwariskan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(luasTanahDiwariskan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luasTanahDiwariskan);
        }

        // GET: LuasTanahDiwariskans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luasTanahDiwariskan = await _context.LuasTanahDiwariskan.FindAsync(id);
            if (luasTanahDiwariskan == null)
            {
                return NotFound();
            }
            return View(luasTanahDiwariskan);
        }

        // POST: LuasTanahDiwariskans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LuasTanahDiwariskanId,Kode,Value")] LuasTanahDiwariskan luasTanahDiwariskan)
        {
            if (id != luasTanahDiwariskan.LuasTanahDiwariskanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luasTanahDiwariskan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuasTanahDiwariskanExists(luasTanahDiwariskan.LuasTanahDiwariskanId))
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
            return View(luasTanahDiwariskan);
        }

        // GET: LuasTanahDiwariskans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var luasTanahDiwariskan = await _context.LuasTanahDiwariskan
                .FirstOrDefaultAsync(m => m.LuasTanahDiwariskanId == id);
            if (luasTanahDiwariskan == null)
            {
                return NotFound();
            }

            return View(luasTanahDiwariskan);
        }

        // POST: LuasTanahDiwariskans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var luasTanahDiwariskan = await _context.LuasTanahDiwariskan.FindAsync(id);
            _context.LuasTanahDiwariskan.Remove(luasTanahDiwariskan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuasTanahDiwariskanExists(int id)
        {
            return _context.LuasTanahDiwariskan.Any(e => e.LuasTanahDiwariskanId == id);
        }
    }
}
