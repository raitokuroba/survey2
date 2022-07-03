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
    public class BeliTanahsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public BeliTanahsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: BeliTanahs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeliTanah.ToListAsync());
        }

        // GET: BeliTanahs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beliTanah = await _context.BeliTanah
                .FirstOrDefaultAsync(m => m.BeliTanahID == id);
            if (beliTanah == null)
            {
                return NotFound();
            }

            return View(beliTanah);
        }

        // GET: BeliTanahs/Create
        //public IActionResult Create()
        //{
        //    return View();

        //}
        public IActionResult Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var desa = _context.Responden.Where(x => x.RespondenID == id).Select(x => x.DesaKelurahan).FirstOrDefault();

            //long noResponden = 1;
            //if (desa != null && _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Any())
            //{
            //    noResponden = _context.IdentitasResponden.Include(x => x.Responden).Where(x => x.Responden.DesaKelurahan == desa).Max(x => x.NomorResponden) + 1;
            //}

            //ViewBag.NomorResponden = noResponden;
            ViewBag.RespondenID = id;
            ViewBag.KepadaSiapaPengalihan = new SelectList(_context.KepadaSiapaPengalihan, "Kode", "Value");
            ViewBag.AlasanPenjualMenjual = new SelectList(_context.AlasanPenjualMenjual, "Kode", "Value");
            ViewBag.AlasanMembeliLahan = new SelectList(_context.AlasanMembeliLahan, "Kode", "Value");
            ViewBag.TempatLahirDanTempatTinggal = new SelectList(_context.TempatLahirDanTempatTinggal, "Kode", "Value");
            ViewBag.FungsiLahanSebelum = new SelectList(_context.FungsiLahanSebelum, "Kode", "Value");
            ViewBag.TanahWarisanSubur = new SelectList(_context.TanahWarisanSubur, "Kode", "Value");
            ViewBag.HasilUsahaTani = new SelectList(_context.HasilUsahaTani, "Kode", "Value");
            ViewBag.TenagaYangMengelola = new SelectList(_context.TenagaYangMengelola, "Kode", "Value");
            ViewBag.AnggotaKeluargaYangBekerja = new SelectList(_context.AnggotaKeluargaYangBekerja, "Kode", "Value");
            ViewBag.JumlahBuruh = new SelectList(_context.JumlahBuruh, "Kode", "Value");
            ViewBag.KepadaSiapaPengalihan = new SelectList(_context.KepadaSiapaPengalihan, "Kode", "Value");
            ViewBag.AlasanMengalihkan = new SelectList(_context.AlasanMengalihkan, "Kode", "Value");
            ViewBag.legalitas = new SelectList(_context.legalitas, "Kode", "Value");


            return View();
        }
        // POST: BeliTanahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //public async Task<IActionResult> Create([Bind("BeliTanahID,RespondenID,DariHasilPembelian,TahunPembelian,DariSiapaMembeli,AlasanPenjualMenjual,CeritakanPenjual,AlasanMembeliLahan,CeritakanMembeli,LuasTanahDibeli,LokasiLahanDibeli,BentukLegalitasDibeli,DiusahakanTanahPembelian,TanahBeliSubur,HasilUsahaTaniTanah,TenagaKerjaTanah,JumlahAnggotaKeluarga,JumlahBuruhTani,AsalBuruhTani,PernahMenjualTanah,KepadaSiapaMenjual,TahunMenjualTanah,LokasiLahanJual,AlasanMenjualTanah,CeritakanMenjual")] BeliTanah beliTanah)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(beliTanah);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(beliTanah);
        //}
        public async Task<IActionResult> Create(BeliTanah beliTanah)
        {
            //var errors = ModelState
            //.Where(x => x.Value.Errors.Count > 0)
            //.Select(x => new { x.Key, x.Value.Errors })
            //.ToArray();
            if (ModelState.IsValid)
            {
                var data = await _context.BeliTanah.FindAsync(beliTanah.RespondenID);

                if (data != null)
                {
                    data.BeliTanahID = beliTanah.BeliTanahID;
                    data.RespondenID = beliTanah.RespondenID;
                    data.DariHasilPembelian = beliTanah.DariHasilPembelian;
                    data.TahunPembelian = beliTanah.TahunPembelian;
                    data.DariSiapaMembeli = beliTanah.DariSiapaMembeli;
                    data.AlasanPenjualMenjual = beliTanah.AlasanPenjualMenjual;
                    data.CeritakanPenjual = beliTanah.CeritakanPenjual;
                    data.AlasanMembeliLahan = beliTanah.AlasanMembeliLahan;
                    data.CeritakanMembeli = beliTanah.CeritakanMembeli;
                    data.LuasTanahDibeli = beliTanah.LuasTanahDibeli;
                    data.LokasiLahanDibeli = beliTanah.LokasiLahanDibeli;
                    data.BentukLegalitasDibeli = beliTanah.BentukLegalitasDibeli;
                    data.DiusahakanTanahPembelian = beliTanah.DiusahakanTanahPembelian;
                    data.TanahBeliSubur = beliTanah.TanahBeliSubur;
                    data.HasilUsahaTaniTanah = beliTanah.HasilUsahaTaniTanah;
                    data.TenagaKerjaTanah = beliTanah.TenagaKerjaTanah;
                    data.JumlahAnggotaKeluarga = beliTanah.JumlahAnggotaKeluarga;
                    data.JumlahBuruhTani = beliTanah.JumlahBuruhTani;
                    data.AsalBuruhTani = beliTanah.AsalBuruhTani;
                    data.PernahMenjualTanah = beliTanah.PernahMenjualTanah;
                    data.KepadaSiapaMenjual = beliTanah.KepadaSiapaMenjual;
                    data.TahunMenjualTanah = beliTanah.TahunMenjualTanah;
                    data.LokasiLahanJual = beliTanah.LokasiLahanJual;
                    data.AlasanMenjualTanah = beliTanah.AlasanMenjualTanah;
                    data.CeritakanMenjual = beliTanah.CeritakanMenjual;
                }
                else
                {
                    data = new BeliTanah()
                    {
                        RespondenID = beliTanah.RespondenID,
                        BeliTanahID = beliTanah.BeliTanahID,
                 
                        DariHasilPembelian = beliTanah.DariHasilPembelian,
                        TahunPembelian = beliTanah.TahunPembelian,
                        DariSiapaMembeli = beliTanah.DariSiapaMembeli,
                        AlasanPenjualMenjual = beliTanah.AlasanPenjualMenjual,
                        CeritakanPenjual = beliTanah.CeritakanPenjual,
                        AlasanMembeliLahan = beliTanah.AlasanMembeliLahan,
                        CeritakanMembeli = beliTanah.CeritakanMembeli,
                        LuasTanahDibeli = beliTanah.LuasTanahDibeli,
                        LokasiLahanDibeli = beliTanah.LokasiLahanDibeli,
                        BentukLegalitasDibeli = beliTanah.BentukLegalitasDibeli,
                        DiusahakanTanahPembelian = beliTanah.DiusahakanTanahPembelian,
                        TanahBeliSubur = beliTanah.TanahBeliSubur,
                        HasilUsahaTaniTanah = beliTanah.HasilUsahaTaniTanah,
                        TenagaKerjaTanah = beliTanah.TenagaKerjaTanah,
                        JumlahAnggotaKeluarga = beliTanah.JumlahAnggotaKeluarga,
                        JumlahBuruhTani = beliTanah.JumlahBuruhTani,
                        AsalBuruhTani = beliTanah.AsalBuruhTani,
                        PernahMenjualTanah = beliTanah.PernahMenjualTanah,
                        KepadaSiapaMenjual = beliTanah.KepadaSiapaMenjual,
                        TahunMenjualTanah = beliTanah.TahunMenjualTanah,
                        LokasiLahanJual = beliTanah.LokasiLahanJual,
                        AlasanMenjualTanah = beliTanah.AlasanMenjualTanah,
                        CeritakanMenjual = beliTanah.CeritakanMenjual
                };

                    await _context.BeliTanah.AddAsync(data);
                }

                await _context.SaveChangesAsync();
                //r1
                return RedirectToAction("Create", "SewaTanahs", new { id = beliTanah.RespondenID });

            }

            return View(beliTanah);
        }
        // GET: BeliTanahs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beliTanah = await _context.BeliTanah.FindAsync(id);
            if (beliTanah == null)
            {
                return NotFound();
            }
            return View(beliTanah);
        }

        // POST: BeliTanahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BeliTanahID,RespondenID,DariHasilPembelian,TahunPembelian,DariSiapaMembeli,AlasanPenjualMenjual,CeritakanPenjual,AlasanMembeliLahan,CeritakanMembeli,LuasTanahDibeli,LokasiLahanDibeli,BentukLegalitasDibeli,DiusahakanTanahPembelian,TanahBeliSubur,HasilUsahaTaniTanah,TenagaKerjaTanah,JumlahAnggotaKeluarga,JumlahBuruhTani,AsalBuruhTani,PernahMenjualTanah,KepadaSiapaMenjual,TahunMenjualTanah,LokasiLahanJual,AlasanMenjualTanah,CeritakanMenjual")] BeliTanah beliTanah)
        {
            if (id != beliTanah.BeliTanahID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beliTanah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeliTanahExists(beliTanah.BeliTanahID))
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
            return View(beliTanah);
        }

        // GET: BeliTanahs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beliTanah = await _context.BeliTanah
                .FirstOrDefaultAsync(m => m.BeliTanahID == id);
            if (beliTanah == null)
            {
                return NotFound();
            }

            return View(beliTanah);
        }

        // POST: BeliTanahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var beliTanah = await _context.BeliTanah.FindAsync(id);
            _context.BeliTanah.Remove(beliTanah);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeliTanahExists(long id)
        {
            return _context.BeliTanah.Any(e => e.BeliTanahID == id);
        }
    }
}
