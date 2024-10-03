using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class VehicleBookingController : Controller
    {
        private readonly VehicleManagementDbContext _context;
        private readonly ILogger<VehicleBookingController> _logger;

        public VehicleBookingController(VehicleManagementDbContext context, ILogger<VehicleBookingController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: VehicleBooking
        public async Task<IActionResult> Index()
        {
            var vehicleBookings = await _context.VehicleBookings
                .Include(vb => vb.Vehicle)
                .Include(vb => vb.StartMining)
                .Include(vb => vb.EndMining)
                .Include(vb => vb.Employee)
                .ToListAsync();
            return View(vehicleBookings);
        }

        // GET: VehicleBooking/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehicleBooking = await _context.VehicleBookings
                .FirstOrDefaultAsync(vb => vb.Id == id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // GET: VehicleBooking/Create
        public IActionResult Create()
        {
            _logger.LogInformation("Entering Create GET action");
            PopulateDropdowns();
            return View();
        }

        // POST: VehicleBooking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Keperluan,Durasi,Tanggal,StartMiningId,EndMiningId,EmployeeId,VehicleId")] VehicleBooking vehicleBooking)
        {
            _logger.LogInformation("Entering Create POST action");
            _logger.LogInformation($"Received VehicleBooking: {System.Text.Json.JsonSerializer.Serialize(vehicleBooking)}");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model state is valid");
                try
                {
                    _context.Add(vehicleBooking);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"VehicleBooking saved successfully with ID: {vehicleBooking.Id}");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error saving VehicleBooking: {ex.Message}");
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            else
            {
                _logger.LogWarning("Model state is invalid");
                foreach (var modelState in ViewData.ModelState)
                {
                    foreach (var error in modelState.Value.Errors)
                    {
                        _logger.LogWarning($"Validation error for {modelState.Key}: {error.ErrorMessage}");
                    }
                }
            }

            _logger.LogInformation("Repopulating dropdowns and returning to Create view");
            PopulateDropdowns();
            return View(vehicleBooking);
        }

        // GET: VehicleBooking/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleBooking = await _context.VehicleBookings.FindAsync(id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            PopulateDropdowns();
            return View(vehicleBooking);
        }

        // POST: VehicleBooking/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleBooking vehicleBooking)
        {
            if (id != vehicleBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleBookingExists(vehicleBooking.Id))
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

            PopulateDropdowns();
            return View(vehicleBooking);
        }

        // GET: VehicleBooking/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var vehicleBooking = await _context.VehicleBookings.FindAsync(id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // POST: VehicleBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleBooking = await _context.VehicleBookings.FindAsync(id);
            if (vehicleBooking == null)
            {
                return NotFound();
            }

            _context.VehicleBookings.Remove(vehicleBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropdowns()
        {
            ViewBag.Minings = new SelectList(_context.Minings, "Id", "Mining_Name");
            ViewBag.Employees = new SelectList(_context.Employees, "Id", "Name");
            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Name");
        }

        private bool VehicleBookingExists(int id)
        {
            return _context.VehicleBookings.Any(e => e.Id == id);
        }
    }
}
