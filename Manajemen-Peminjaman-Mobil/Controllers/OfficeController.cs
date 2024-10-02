using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class OfficeController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public OfficeController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: Offices
        public async Task<IActionResult> Index()
        {
            var offices = _context.Offices.Include(o => o.Region);
            return View(await offices.ToListAsync());
        }

        // GET: Offices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Office_Name,RegionId,Unit")] Office office)
        {
            if (ModelState.IsValid)
            {
                _context.Add(office);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(office);
        }

        // GET: Offices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var office = await _context.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }
            return View(office);
        }

        // POST: Offices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Office_Name,RegionId,Unit")] Office office)
        {
            if (id != office.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(office);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeExists(office.Id))
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
            return View(office);
        }

        private bool OfficeExists(int id)
        {
            return _context.Offices.Any(e => e.Id == id);
        }
    }
}
