using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class EmployeePositionController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public EmployeePositionController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: EmployeePositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeePositions.ToListAsync());
        }

        // GET: EmployeePositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeePositions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jabatan")] EmployeePosition employeePosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeePosition);
        }

        private bool EmployeePositionExists(int id)
        {
            return _context.EmployeePositions.Any(e => e.Id == id);
        }
    }
}