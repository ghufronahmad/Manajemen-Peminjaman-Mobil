using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class VehicleBookingController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public VehicleBookingController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: VehicleBooking
        public IActionResult Index()
        {
            var vehicleBookings = _context.VehicleBookings
                .ToList();
            return View(vehicleBookings);
        }

        // GET: VehicleBooking/Details/5
        public IActionResult Details(int id)
        {
            var vehicleBooking = _context.VehicleBookings
                .FirstOrDefault(vb => vb.Id == id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // GET: VehicleBooking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleBooking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleBooking vehicleBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vehicleBooking);
        }

        // GET: VehicleBooking/Edit/5
        public IActionResult Edit(int id)
        {
            var vehicleBooking = _context.VehicleBookings.Find(id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // POST: VehicleBooking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleBooking vehicleBooking)
        {
            if (id != vehicleBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(vehicleBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(vehicleBooking);
        }

        // GET: VehicleBooking/Delete/5
        public IActionResult Delete(int id)
        {
            var vehicleBooking = _context.VehicleBookings.Find(id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // POST: VehicleBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleBooking = await _context.VehicleBookings.FindAsync(id);
            _context.VehicleBookings.Remove(vehicleBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
