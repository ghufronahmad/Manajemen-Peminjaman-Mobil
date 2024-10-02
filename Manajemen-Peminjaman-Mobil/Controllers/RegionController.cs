using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class RegionController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public RegionController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: Regions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regions.Include(r => r.Minings).ToListAsync());
        }

        // GET: Regions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Region_Name")] Region region)
        {
            if (ModelState.IsValid)
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(region);
        }
    }
}
