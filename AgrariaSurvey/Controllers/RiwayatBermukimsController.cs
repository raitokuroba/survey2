using AgrariaSurvey.Data;
using AgrariaSurvey.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgrariaSurvey.Controllers
{
    public class RiwayatBermukimsController : Controller
    {
        private readonly AgrariaSurveyContext _context;

        public RiwayatBermukimsController(AgrariaSurveyContext context)
        {
            _context = context;
        }

        // GET: RiwayatBermukims
        public async Task<IActionResult> Index()
        {
            return View(await _context.RiwayatBermukim.ToListAsync());
        }

        // GET: RiwayatBermukims/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            var riwayatBermukim = await _context.RiwayatBermukim.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();
            if (riwayatBermukim == null)
            {
                riwayatBermukim = new RiwayatBermukim();
            }

            ViewBag.RespondenID = id;
            ViewBag.EtnisAyahDariSuami = _context.Etnis.Where(x => x.Kode == riwayatBermukim.EtnisAyahDariSuami).Select(x => x.Value).FirstOrDefault();
            ViewBag.EtnisIbuDariSuami = _context.Etnis.Where(x => x.Kode == riwayatBermukim.EtnisIbuDariSuami).Select(x => x.Value).FirstOrDefault();
            ViewBag.EtnisAyahDariIstri = _context.Etnis.Where(x => x.Kode == riwayatBermukim.EtnisAyahDariIstri).Select(x => x.Value).FirstOrDefault();
            ViewBag.EtnisIbuDariIstri = _context.Etnis.Where(x => x.Kode == riwayatBermukim.EtnisIbuDariIstri).Select(x => x.Value).FirstOrDefault();
            ViewBag.TempatLahirAyahDariSuamiProv = _context.Provinsi.Where(x => x.Kode == riwayatBermukim.TempatLahirAyahDariSuamiProv).Select(x => x.Value).FirstOrDefault();
            ViewBag.TempatLahirIbuDariSuamiProv = _context.Provinsi.Where(x => x.Kode == riwayatBermukim.TempatLahirIbuDariSuamiProv).Select(x => x.Value).FirstOrDefault();
            ViewBag.TempatLahirAyahDariIstriProv = _context.Provinsi.Where(x => x.Kode == riwayatBermukim.TempatLahirAyahDariIstriProv).Select(x => x.Value).FirstOrDefault();
            ViewBag.TempatLahirIbuDariIstriProv = _context.Provinsi.Where(x => x.Kode == riwayatBermukim.TempatLahirIbuDariIstriProv).Select(x => x.Value).FirstOrDefault();

            return View(riwayatBermukim);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(long id, Responden responden)
        {
            if (id != responden.RespondenID)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "AnggotaRumahTanggas", new { responden.RespondenID, act = "Details" });
        }

        // GET: RiwayatBermukims/Create
        public IActionResult Create(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.RespondenID = id;
            ViewBag.Etnis = new SelectList(_context.Etnis, "Kode", "Value");
            ViewBag.Provinsi = new SelectList(GetProvinsi(), "Kode", "Value");

            return View();
        }

        // POST: RiwayatBermukims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RiwayatBermukim riwayatBermukim)
        {
            if (ModelState.IsValid)
            {
                var data = await _context.RiwayatBermukim.FindAsync(riwayatBermukim.RespondenID);

                if (data != null)
                {
                    data.TempatLahirAyahDariSuami = riwayatBermukim.TempatLahirAyahDariSuami;
                    data.TempatLahirAyahDariSuamiProv = riwayatBermukim.TempatLahirAyahDariSuamiProv;
                    data.TempatLahirAyahDariSuamiKota = riwayatBermukim.TempatLahirAyahDariSuamiKota;
                    data.TempatLahirAyahDariSuamiKec = riwayatBermukim.TempatLahirAyahDariSuamiKec;
                    data.TempatLahirAyahDariSuamiDesa = riwayatBermukim.TempatLahirAyahDariSuamiDesa;
                    data.EtnisAyahDariSuami = riwayatBermukim.EtnisAyahDariSuami;
                    data.TahunKedatanganAyahDariSuamiKeDesa = riwayatBermukim.TahunKedatanganAyahDariSuamiKeDesa;
                    data.AlasanAyahDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanAyahDariSuamiDatangKeDesaIni;
                    data.TempatLahirIbuDariSuami = riwayatBermukim.TempatLahirIbuDariSuami;
                    data.TempatLahirIbuDariSuamiProv = riwayatBermukim.TempatLahirIbuDariSuamiProv;
                    data.TempatLahirIbuDariSuamiKota = riwayatBermukim.TempatLahirIbuDariSuamiKota;
                    data.TempatLahirIbuDariSuamiKec = riwayatBermukim.TempatLahirIbuDariSuamiKec;
                    data.TempatLahirIbuDariSuamiDesa = riwayatBermukim.TempatLahirIbuDariSuamiDesa;
                    data.EtnisIbuDariSuami = riwayatBermukim.EtnisIbuDariSuami;
                    data.TahunKedatanganIbuDariSuamiKeDesa = riwayatBermukim.TahunKedatanganIbuDariSuamiKeDesa;
                    data.AlasanIbuDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanIbuDariSuamiDatangKeDesaIni;
                    data.TempatLahirAyahDariIstri = riwayatBermukim.TempatLahirAyahDariIstri;
                    data.TempatLahirAyahDariIstriProv = riwayatBermukim.TempatLahirAyahDariIstriProv;
                    data.TempatLahirAyahDariIstriKota = riwayatBermukim.TempatLahirAyahDariIstriKota;
                    data.TempatLahirAyahDariIstriKec = riwayatBermukim.TempatLahirAyahDariIstriKec;
                    data.TempatLahirAyahDariIstriDesa = riwayatBermukim.TempatLahirAyahDariIstriDesa;
                    data.EtnisAyahDariIstri = riwayatBermukim.EtnisAyahDariIstri;
                    data.TahunKedatanganAyahDariIstriKeDesa = riwayatBermukim.TahunKedatanganAyahDariIstriKeDesa;
                    data.AlasanAyahDariIstriDatangKeDesaIni = riwayatBermukim.AlasanAyahDariIstriDatangKeDesaIni;
                    data.TempatLahirIbuDariIstri = riwayatBermukim.TempatLahirIbuDariIstri;
                    data.TempatLahirIbuDariIstriProv = riwayatBermukim.TempatLahirIbuDariIstriProv;
                    data.TempatLahirIbuDariIstriKota = riwayatBermukim.TempatLahirIbuDariIstriKota;
                    data.TempatLahirIbuDariIstriKec = riwayatBermukim.TempatLahirIbuDariIstriKec;
                    data.TempatLahirIbuDariIstriDesa = riwayatBermukim.TempatLahirIbuDariIstriDesa;
                    data.EtnisIbuDariIstri = riwayatBermukim.EtnisIbuDariIstri;
                    data.TahunKedatanganIbuDariIstriKeDesa = riwayatBermukim.TahunKedatanganIbuDariIstriKeDesa;
                    data.AlasanIbuDariIstriDatangKeDesaIni = riwayatBermukim.AlasanIbuDariIstriDatangKeDesaIni;
                }
                else
                {
                    data = new RiwayatBermukim()
                    {
                        RespondenID = riwayatBermukim.RespondenID,
                        TempatLahirAyahDariSuami = riwayatBermukim.TempatLahirAyahDariSuami,
                        TempatLahirAyahDariSuamiProv = riwayatBermukim.TempatLahirAyahDariSuamiProv,
                        TempatLahirAyahDariSuamiKota = riwayatBermukim.TempatLahirAyahDariSuamiKota,
                        TempatLahirAyahDariSuamiKec = riwayatBermukim.TempatLahirAyahDariSuamiKec,
                        TempatLahirAyahDariSuamiDesa = riwayatBermukim.TempatLahirAyahDariSuamiDesa,
                        EtnisAyahDariSuami = riwayatBermukim.EtnisAyahDariSuami,
                        TahunKedatanganAyahDariSuamiKeDesa = riwayatBermukim.TahunKedatanganAyahDariSuamiKeDesa,
                        AlasanAyahDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanAyahDariSuamiDatangKeDesaIni,
                        TempatLahirIbuDariSuami = riwayatBermukim.TempatLahirIbuDariSuami,
                        TempatLahirIbuDariSuamiProv = riwayatBermukim.TempatLahirIbuDariSuamiProv,
                        TempatLahirIbuDariSuamiKota = riwayatBermukim.TempatLahirIbuDariSuamiKota,
                        TempatLahirIbuDariSuamiKec = riwayatBermukim.TempatLahirIbuDariSuamiKec,
                        TempatLahirIbuDariSuamiDesa = riwayatBermukim.TempatLahirIbuDariSuamiDesa,
                        EtnisIbuDariSuami = riwayatBermukim.EtnisIbuDariSuami,
                        TahunKedatanganIbuDariSuamiKeDesa = riwayatBermukim.TahunKedatanganIbuDariSuamiKeDesa,
                        AlasanIbuDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanIbuDariSuamiDatangKeDesaIni,
                        TempatLahirAyahDariIstri = riwayatBermukim.TempatLahirAyahDariIstri,
                        TempatLahirAyahDariIstriProv = riwayatBermukim.TempatLahirAyahDariIstriProv,
                        TempatLahirAyahDariIstriKota = riwayatBermukim.TempatLahirAyahDariIstriKota,
                        TempatLahirAyahDariIstriKec = riwayatBermukim.TempatLahirAyahDariIstriKec,
                        TempatLahirAyahDariIstriDesa = riwayatBermukim.TempatLahirAyahDariIstriDesa,
                        EtnisAyahDariIstri = riwayatBermukim.EtnisAyahDariIstri,
                        TahunKedatanganAyahDariIstriKeDesa = riwayatBermukim.TahunKedatanganAyahDariIstriKeDesa,
                        AlasanAyahDariIstriDatangKeDesaIni = riwayatBermukim.AlasanAyahDariIstriDatangKeDesaIni,
                        TempatLahirIbuDariIstri = riwayatBermukim.TempatLahirIbuDariIstri,
                        TempatLahirIbuDariIstriProv = riwayatBermukim.TempatLahirIbuDariIstriProv,
                        TempatLahirIbuDariIstriKota = riwayatBermukim.TempatLahirIbuDariIstriKota,
                        TempatLahirIbuDariIstriKec = riwayatBermukim.TempatLahirIbuDariIstriKec,
                        TempatLahirIbuDariIstriDesa = riwayatBermukim.TempatLahirIbuDariIstriDesa,
                        EtnisIbuDariIstri = riwayatBermukim.EtnisIbuDariIstri,
                        TahunKedatanganIbuDariIstriKeDesa = riwayatBermukim.TahunKedatanganIbuDariIstriKeDesa,
                        AlasanIbuDariIstriDatangKeDesaIni = riwayatBermukim.AlasanIbuDariIstriDatangKeDesaIni
                    };

                    await _context.AddAsync(data);
                }

                await _context.SaveChangesAsync();
                //r1
                return RedirectToAction("Index", "AnggotaRumahTanggas", new { riwayatBermukim.RespondenID, act = "Create" });
               // return RedirectToAction("Create", "AnggotaRumahTanggas", new { respondenId = riwayatBermukim.RespondenID });
            }

            ViewBag.RespondenID = riwayatBermukim.RespondenID;

            ViewBag.Etnis = new SelectList(_context.Etnis, "Kode", "Value");
            ViewBag.Provinsi = new SelectList(GetProvinsi(), "Kode", "Value");
            return View(riwayatBermukim);
        }

        // GET: RiwayatBermukims/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            //return RedirectToAction("Create", "TanahWaris", new { id = id});
            var riwayatBermukim = await _context.RiwayatBermukim.Where(x => x.RespondenID == id).AsNoTracking().FirstOrDefaultAsync();

            if (riwayatBermukim == null)
            {
                riwayatBermukim = new RiwayatBermukim();
            }

            ViewBag.RespondenID = id;
            ViewBag.EtnisAyahDariSuami = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisAyahDariSuami);
            ViewBag.EtnisIbuDariSuami = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisIbuDariSuami);
            ViewBag.EtnisAyahDariIstri = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisAyahDariIstri);
            ViewBag.EtnisIbuDariIstri = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisIbuDariIstri);
            ViewBag.TempatLahirAyahDariSuamiProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirAyahDariSuamiProv);
            ViewBag.TempatLahirIbuDariSuamiProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirIbuDariSuamiProv);
            ViewBag.TempatLahirAyahDariIstriProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirAyahDariIstriProv);
            ViewBag.TempatLahirIbuDariIstriProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirIbuDariIstriProv);
            return View(riwayatBermukim);
        }

        // POST: RiwayatBermukims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, RiwayatBermukim riwayatBermukim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var data = await _context.RiwayatBermukim.FindAsync(riwayatBermukim.RespondenID);

                    if (data != null)
                    {
                        data.TempatLahirAyahDariSuami = riwayatBermukim.TempatLahirAyahDariSuami;
                        data.TempatLahirAyahDariSuamiProv = riwayatBermukim.TempatLahirAyahDariSuamiProv;
                        data.TempatLahirAyahDariSuamiKota = riwayatBermukim.TempatLahirAyahDariSuamiKota;
                        data.TempatLahirAyahDariSuamiKec = riwayatBermukim.TempatLahirAyahDariSuamiKec;
                        data.TempatLahirAyahDariSuamiDesa = riwayatBermukim.TempatLahirAyahDariSuamiDesa;
                        data.EtnisAyahDariSuami = riwayatBermukim.EtnisAyahDariSuami;
                        data.TahunKedatanganAyahDariSuamiKeDesa = riwayatBermukim.TahunKedatanganAyahDariSuamiKeDesa;
                        data.AlasanAyahDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanAyahDariSuamiDatangKeDesaIni;
                        data.TempatLahirIbuDariSuami = riwayatBermukim.TempatLahirIbuDariSuami;
                        data.TempatLahirIbuDariSuamiProv = riwayatBermukim.TempatLahirIbuDariSuamiProv;
                        data.TempatLahirIbuDariSuamiKota = riwayatBermukim.TempatLahirIbuDariSuamiKota;
                        data.TempatLahirIbuDariSuamiKec = riwayatBermukim.TempatLahirIbuDariSuamiKec;
                        data.TempatLahirIbuDariSuamiDesa = riwayatBermukim.TempatLahirIbuDariSuamiDesa;
                        data.EtnisIbuDariSuami = riwayatBermukim.EtnisIbuDariSuami;
                        data.TahunKedatanganIbuDariSuamiKeDesa = riwayatBermukim.TahunKedatanganIbuDariSuamiKeDesa;
                        data.AlasanIbuDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanIbuDariSuamiDatangKeDesaIni;
                        data.TempatLahirAyahDariIstri = riwayatBermukim.TempatLahirAyahDariIstri;
                        data.TempatLahirAyahDariIstriProv = riwayatBermukim.TempatLahirAyahDariIstriProv;
                        data.TempatLahirAyahDariIstriKota = riwayatBermukim.TempatLahirAyahDariIstriKota;
                        data.TempatLahirAyahDariIstriKec = riwayatBermukim.TempatLahirAyahDariIstriKec;
                        data.TempatLahirAyahDariIstriDesa = riwayatBermukim.TempatLahirAyahDariIstriDesa;
                        data.EtnisAyahDariIstri = riwayatBermukim.EtnisAyahDariIstri;
                        data.TahunKedatanganAyahDariIstriKeDesa = riwayatBermukim.TahunKedatanganAyahDariIstriKeDesa;
                        data.AlasanAyahDariIstriDatangKeDesaIni = riwayatBermukim.AlasanAyahDariIstriDatangKeDesaIni;
                        data.TempatLahirIbuDariIstri = riwayatBermukim.TempatLahirIbuDariIstri;
                        data.TempatLahirIbuDariIstriProv = riwayatBermukim.TempatLahirIbuDariIstriProv;
                        data.TempatLahirIbuDariIstriKota = riwayatBermukim.TempatLahirIbuDariIstriKota;
                        data.TempatLahirIbuDariIstriKec = riwayatBermukim.TempatLahirIbuDariIstriKec;
                        data.TempatLahirIbuDariIstriDesa = riwayatBermukim.TempatLahirIbuDariIstriDesa;
                        data.EtnisIbuDariIstri = riwayatBermukim.EtnisIbuDariIstri;
                        data.TahunKedatanganIbuDariIstriKeDesa = riwayatBermukim.TahunKedatanganIbuDariIstriKeDesa;
                        data.AlasanIbuDariIstriDatangKeDesaIni = riwayatBermukim.AlasanIbuDariIstriDatangKeDesaIni;
                    }
                    else
                    {
                        data = new RiwayatBermukim()
                        {
                            RespondenID = riwayatBermukim.RespondenID,
                            TempatLahirAyahDariSuami = riwayatBermukim.TempatLahirAyahDariSuami,
                            TempatLahirAyahDariSuamiProv = riwayatBermukim.TempatLahirAyahDariSuamiProv,
                            TempatLahirAyahDariSuamiKota = riwayatBermukim.TempatLahirAyahDariSuamiKota,
                            TempatLahirAyahDariSuamiKec = riwayatBermukim.TempatLahirAyahDariSuamiKec,
                            TempatLahirAyahDariSuamiDesa = riwayatBermukim.TempatLahirAyahDariSuamiDesa,
                            EtnisAyahDariSuami = riwayatBermukim.EtnisAyahDariSuami,
                            TahunKedatanganAyahDariSuamiKeDesa = riwayatBermukim.TahunKedatanganAyahDariSuamiKeDesa,
                            AlasanAyahDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanAyahDariSuamiDatangKeDesaIni,
                            TempatLahirIbuDariSuami = riwayatBermukim.TempatLahirIbuDariSuami,
                            TempatLahirIbuDariSuamiProv = riwayatBermukim.TempatLahirIbuDariSuamiProv,
                            TempatLahirIbuDariSuamiKota = riwayatBermukim.TempatLahirIbuDariSuamiKota,
                            TempatLahirIbuDariSuamiKec = riwayatBermukim.TempatLahirIbuDariSuamiKec,
                            TempatLahirIbuDariSuamiDesa = riwayatBermukim.TempatLahirIbuDariSuamiDesa,
                            EtnisIbuDariSuami = riwayatBermukim.EtnisIbuDariSuami,
                            TahunKedatanganIbuDariSuamiKeDesa = riwayatBermukim.TahunKedatanganIbuDariSuamiKeDesa,
                            AlasanIbuDariSuamiDatangKeDesaIni = riwayatBermukim.AlasanIbuDariSuamiDatangKeDesaIni,
                            TempatLahirAyahDariIstri = riwayatBermukim.TempatLahirAyahDariIstri,
                            TempatLahirAyahDariIstriProv = riwayatBermukim.TempatLahirAyahDariIstriProv,
                            TempatLahirAyahDariIstriKota = riwayatBermukim.TempatLahirAyahDariIstriKota,
                            TempatLahirAyahDariIstriKec = riwayatBermukim.TempatLahirAyahDariIstriKec,
                            TempatLahirAyahDariIstriDesa = riwayatBermukim.TempatLahirAyahDariIstriDesa,
                            EtnisAyahDariIstri = riwayatBermukim.EtnisAyahDariIstri,
                            TahunKedatanganAyahDariIstriKeDesa = riwayatBermukim.TahunKedatanganAyahDariIstriKeDesa,
                            AlasanAyahDariIstriDatangKeDesaIni = riwayatBermukim.AlasanAyahDariIstriDatangKeDesaIni,
                            TempatLahirIbuDariIstri = riwayatBermukim.TempatLahirIbuDariIstri,
                            TempatLahirIbuDariIstriProv = riwayatBermukim.TempatLahirIbuDariIstriProv,
                            TempatLahirIbuDariIstriKota = riwayatBermukim.TempatLahirIbuDariIstriKota,
                            TempatLahirIbuDariIstriKec = riwayatBermukim.TempatLahirIbuDariIstriKec,
                            TempatLahirIbuDariIstriDesa = riwayatBermukim.TempatLahirIbuDariIstriDesa,
                            EtnisIbuDariIstri = riwayatBermukim.EtnisIbuDariIstri,
                            TahunKedatanganIbuDariIstriKeDesa = riwayatBermukim.TahunKedatanganIbuDariIstriKeDesa,
                            AlasanIbuDariIstriDatangKeDesaIni = riwayatBermukim.AlasanIbuDariIstriDatangKeDesaIni
                        };

                        await _context.AddAsync(data);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RiwayatBermukimExists(riwayatBermukim.RiwayatBermukimID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index", "AnggotaRumahTanggas", new { riwayatBermukim.RespondenID, act = "Edit" });
                //r1
                //return RedirectToAction("Edit", "AnggotaRumahTanggas", new { id = riwayatBermukim.RespondenID });
            }

            ViewBag.RespondenID = riwayatBermukim.RespondenID;

            ViewBag.EtnisAyahDariSuami = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisAyahDariSuami);
            ViewBag.EtnisIbuDariSuami = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisIbuDariSuami);
            ViewBag.EtnisAyahDariIstri = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisAyahDariIstri);
            ViewBag.EtnisIbuDariIstri = new SelectList(_context.Etnis, "Kode", "Value", riwayatBermukim.EtnisIbuDariIstri);
            ViewBag.TempatLahirAyahDariSuamiProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirAyahDariSuamiProv);
            ViewBag.TempatLahirIbuDariSuamiProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirIbuDariSuamiProv);
            ViewBag.TempatLahirAyahDariIstriProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirAyahDariIstriProv);
            ViewBag.TempatLahirIbuDariIstriProv = new SelectList(GetProvinsi(), "Kode", "Value", riwayatBermukim.TempatLahirIbuDariIstriProv);
            return View(riwayatBermukim);
        }

        // GET: RiwayatBermukims/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var riwayatBermukim = await _context.RiwayatBermukim
                .FirstOrDefaultAsync(m => m.RiwayatBermukimID == id);
            if (riwayatBermukim == null)
            {
                return NotFound();
            }

            return View(riwayatBermukim);
        }

        // POST: RiwayatBermukims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var riwayatBermukim = await _context.RiwayatBermukim.FindAsync(id);
            _context.RiwayatBermukim.Remove(riwayatBermukim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RiwayatBermukimExists(long id)
        {
            return _context.RiwayatBermukim.Any(e => e.RiwayatBermukimID == id);
        }

        #region Get Data

        private List<Provinsi> GetProvinsi()
        {
            return _context.Provinsi.ToList();
        }

        public JsonResult GetKota(string prov)
        {
            List<Kabupaten> data = _context.Kabupaten.ToList();

            return new JsonResult(new SelectList(data.Where(x => x.KodeProvinsi == prov).ToList(), "Kode", "Value"));
        }

        public JsonResult GetKecamatan(string kota)
        {
            List<Kecamatans> data = _context.Kecamatans.ToList();

            return new JsonResult(new SelectList(data.Where(x => x.KodeKota == kota).ToList(), "Kode", "Value"));
        }

        public JsonResult GetDesa(string kec)
        {
            List<Kelurahan> data = _context.Kelurahans.ToList();

            return new JsonResult(new SelectList(data.Where(x => x.KodeKecamatan == kec).ToList(), "Kode", "Value"));
        }
        #endregion
    }
}
