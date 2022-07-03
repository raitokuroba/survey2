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
    public class SewaTanahsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public SewaTanahsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: SewaTanahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SewaTanah.ToListAsync());
        }

        // GET: SewaTanahs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaTanah = await _context.SewaTanah
                .FirstOrDefaultAsync(m => m.SewaTanahId == id);
            if (sewaTanah == null)
            {
                return NotFound();
            }

            return View(sewaTanah);
        }

        // GET: SewaTanahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SewaTanahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SewaTanahId,RespondenId,SedangMenyewaTanah,DariSiapaMenyewa,AlasanMenyewa,LuasTanahDisewa,BiayaSewaTanah,LokasiLahanSewa,TahunMenyewaTanah,TahunSampaiKontrak,BentukLegalitasTanah,UsahaTanahSewa,TanahSewaSubur,HasilUsahaTani,TenagaMengelolaTanah,JumlahAnggotaKeluarga,JumlahBuruhTani,AsalBuruhTani,MenyewakanTanah,KepadaSiapaMenyewakan,LuasTanahSewakan,LokasiTanahDisewakan,AlasanMenyewakan,UangSewaTanah,TahunMenyewakan,KontrakSewa")] SewaTanah sewaTanah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sewaTanah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sewaTanah);
        }

        // GET: SewaTanahs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaTanah = await _context.SewaTanah.FindAsync(id);
            if (sewaTanah == null)
            {
                return NotFound();
            }
            return View(sewaTanah);
        }

        // POST: SewaTanahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SewaTanahId,RespondenId,SedangMenyewaTanah,DariSiapaMenyewa,AlasanMenyewa,LuasTanahDisewa,BiayaSewaTanah,LokasiLahanSewa,TahunMenyewaTanah,TahunSampaiKontrak,BentukLegalitasTanah,UsahaTanahSewa,TanahSewaSubur,HasilUsahaTani,TenagaMengelolaTanah,JumlahAnggotaKeluarga,JumlahBuruhTani,AsalBuruhTani,MenyewakanTanah,KepadaSiapaMenyewakan,LuasTanahSewakan,LokasiTanahDisewakan,AlasanMenyewakan,UangSewaTanah,TahunMenyewakan,KontrakSewa")] SewaTanah sewaTanah)
        {
            if (id != sewaTanah.SewaTanahId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sewaTanah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SewaTanahExists(sewaTanah.SewaTanahId))
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
            return View(sewaTanah);
        }

        // GET: SewaTanahs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sewaTanah = await _context.SewaTanah
                .FirstOrDefaultAsync(m => m.SewaTanahId == id);
            if (sewaTanah == null)
            {
                return NotFound();
            }

            return View(sewaTanah);
        }

        // POST: SewaTanahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var sewaTanah = await _context.SewaTanah.FindAsync(id);
            _context.SewaTanah.Remove(sewaTanah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SewaTanahExists(long id)
        {
            return _context.SewaTanah.Any(e => e.SewaTanahId == id);
        }
    }
}
