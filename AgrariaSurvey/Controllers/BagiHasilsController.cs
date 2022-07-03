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
    public class BagiHasilsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public BagiHasilsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: BagiHasils
        public async Task<IActionResult> Index()
        {
            return View(await _context.BagiHasil.ToListAsync());
        }

        // GET: BagiHasils/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagiHasil = await _context.BagiHasil
                .FirstOrDefaultAsync(m => m.BagiHasilId == id);
            if (bagiHasil == null)
            {
                return NotFound();
            }

            return View(bagiHasil);
        }

        // GET: BagiHasils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BagiHasils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BagiHasilId,RespondenId,BagiHasilMilik,KepadaSiapaPengelolaan,AlasanBagiHasil,LuasBagiHasil,KomposisiBagiHasil,LokasiBagiHasil,TahunBagiHasil,TahunKontrakBagiHasil,BentukLegalitasBagiHasil,UsahaBagiHasil,TanahBagiHasilSubur,HasilUsahaBagiHasil,TenagaMengelolaBagiHasil,JumlahAnggotaBagiHasil,JumlahBuruhTaniBagiHasil,AsalBuruhTaniBagiHasil,BagiHasilKelola,KepadaSiapaBagiHasil,LuasTanahBagiHasil,LokasiTanahBagiHasil,LegalitasBagiHasil,AlasanMenggarapBagiHasil,UsahakanBagiHasil,KomposisiBagi,JangkaWaktuBagiHasil,TanahBagiSubur,UsahaTanahBagiHasil,TenagaKerjaBagiHasil,AnggotaKeluargaBagiHasil,BuruhTaniBagiHasil,BuruhTaniAsal")] BagiHasil bagiHasil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bagiHasil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bagiHasil);
        }

        // GET: BagiHasils/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagiHasil = await _context.BagiHasil.FindAsync(id);
            if (bagiHasil == null)
            {
                return NotFound();
            }
            return View(bagiHasil);
        }

        // POST: BagiHasils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BagiHasilId,RespondenId,BagiHasilMilik,KepadaSiapaPengelolaan,AlasanBagiHasil,LuasBagiHasil,KomposisiBagiHasil,LokasiBagiHasil,TahunBagiHasil,TahunKontrakBagiHasil,BentukLegalitasBagiHasil,UsahaBagiHasil,TanahBagiHasilSubur,HasilUsahaBagiHasil,TenagaMengelolaBagiHasil,JumlahAnggotaBagiHasil,JumlahBuruhTaniBagiHasil,AsalBuruhTaniBagiHasil,BagiHasilKelola,KepadaSiapaBagiHasil,LuasTanahBagiHasil,LokasiTanahBagiHasil,LegalitasBagiHasil,AlasanMenggarapBagiHasil,UsahakanBagiHasil,KomposisiBagi,JangkaWaktuBagiHasil,TanahBagiSubur,UsahaTanahBagiHasil,TenagaKerjaBagiHasil,AnggotaKeluargaBagiHasil,BuruhTaniBagiHasil,BuruhTaniAsal")] BagiHasil bagiHasil)
        {
            if (id != bagiHasil.BagiHasilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bagiHasil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BagiHasilExists(bagiHasil.BagiHasilId))
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
            return View(bagiHasil);
        }

        // GET: BagiHasils/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bagiHasil = await _context.BagiHasil
                .FirstOrDefaultAsync(m => m.BagiHasilId == id);
            if (bagiHasil == null)
            {
                return NotFound();
            }

            return View(bagiHasil);
        }

        // POST: BagiHasils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bagiHasil = await _context.BagiHasil.FindAsync(id);
            _context.BagiHasil.Remove(bagiHasil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BagiHasilExists(long id)
        {
            return _context.BagiHasil.Any(e => e.BagiHasilId == id);
        }
    }
}
