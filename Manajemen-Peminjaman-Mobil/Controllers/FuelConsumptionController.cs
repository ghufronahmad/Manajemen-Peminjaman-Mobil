using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class FuelConsumptionController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public FuelConsumptionController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: FuelConsumptions
        public async Task<IActionResult> Index()
        {
            var fuelConsumptions = _context.FuelConsumptions.Include(f => f.Vehicle);
            return View(await fuelConsumptions.ToListAsync());
        }

        // GET: FuelConsumptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelConsumptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Odometer,Biaya,Keterangan,VehicleId")] FuelConsumption fuelConsumption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuelConsumption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelConsumption);
        }

        // GET: FuelConsumptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelConsumption = await _context.FuelConsumptions.FindAsync(id);
            if (fuelConsumption == null)
            {
                return NotFound();
            }
            return View(fuelConsumption);
        }

        // POST: FuelConsumptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Odometer,Biaya,Keterangan,VehicleId")] FuelConsumption fuelConsumption)
        {
            if (id != fuelConsumption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelConsumption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelConsumptionExists(fuelConsumption.Id))
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
            return View(fuelConsumption);
        }

        private bool FuelConsumptionExists(int id)
        {
            return _context.FuelConsumptions.Any(e => e.Id == id);
        }
    }
}
