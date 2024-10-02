using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class ServiceScheduleController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public ServiceScheduleController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: ServiceSchedules
        public async Task<IActionResult> Index()
        {
            var serviceSchedules = _context.ServiceSchedules.Include(s => s.Vehicle);
            return View(await serviceSchedules.ToListAsync());
        }

        // GET: ServiceSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceSchedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Biaya,Keterangan,Tanggal_Service,VehicleId")] ServiceSchedule serviceSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceSchedule);
        }

        // GET: ServiceSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceSchedule = await _context.ServiceSchedules.FindAsync(id);
            if (serviceSchedule == null)
            {
                return NotFound();
            }
            return View(serviceSchedule);
        }

        // POST: ServiceSchedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Biaya,Keterangan,Tanggal_Service,VehicleId")] ServiceSchedule serviceSchedule)
        {
            if (id != serviceSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceScheduleExists(serviceSchedule.Id))
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
            return View(serviceSchedule);
        }

        private bool ServiceScheduleExists(int id)
        {
            return _context.ServiceSchedules.Any(e => e.Id == id);
        }
    }
}
