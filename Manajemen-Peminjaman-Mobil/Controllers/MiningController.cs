using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class MiningController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public MiningController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: Minings
        public async Task<IActionResult> Index()
        {
            var minings = _context.Minings.Include(m => m.Region);
            return View(await minings.ToListAsync());
        }

        // GET: Minings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Minings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mining_Name,RegionId")] Mining mining)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mining);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mining);
        }
    }
}
