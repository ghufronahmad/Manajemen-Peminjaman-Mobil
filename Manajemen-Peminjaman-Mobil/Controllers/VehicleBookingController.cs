using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class VehicleBookingController : Controller
    {
        private readonly VehicleManagementDbContext _context;
        private readonly ILogger<VehicleBookingController> _logger;
        private readonly IActivityLogService _activityLogService;

        public VehicleBookingController(VehicleManagementDbContext context, ILogger<VehicleBookingController> logger, IActivityLogService activityLogService)
        {
            _context = context;
            _logger = logger;
            _activityLogService = activityLogService;
        }

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

        public async Task<IActionResult> Details(int id)
        {
            // [DIPERBAIKI] Tambahkan .Include() agar data relasi tampil di view Details
            var vehicleBooking = await _context.VehicleBookings
                .Include(vb => vb.Vehicle)
                .Include(vb => vb.StartMining)
                .Include(vb => vb.EndMining)
                .Include(vb => vb.Employee)
                .Include(vb => vb.DriverName)
                .Include(vb => vb.ApprovalProcesses)
                    .ThenInclude(ap => ap.Approver)
                        .ThenInclude(a => a.Employee)
                .FirstOrDefaultAsync(vb => vb.Id == id);

            if (vehicleBooking == null)
            {
                return NotFound();
            }

            return View(vehicleBooking);
        }

        // [DIUBAH] Menggunakan ViewModel
        public IActionResult Create()
        {
            var viewModel = new CreateBookingViewModel
            {
                Tanggal = DateTime.Today
            };
            PopulateDropdowns(viewModel); 
            var drivers = new List<string> { "Budi", "Andi", "Charlie", "Dedi" };
            viewModel.Drivers = new SelectList(drivers);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookingViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropdowns(viewModel);
                return View(viewModel);
            }

            // [ATURAN BARU] Lakukan pengecekan posisi pegawai SEBELUM memulai transaksi
            var employee = await _context.Employees.FindAsync(viewModel.EmployeeId);
            if (employee == null)
            {
                ModelState.AddModelError("EmployeeId", "Pegawai yang dipilih tidak valid.");
                PopulateDropdowns(viewModel);
                return View(viewModel);
            }

            if (employee.EmployeePositionId == 2) // Asumsi 2 adalah ID untuk "Manager"
            {
                ModelState.AddModelError("", "Manager tidak diizinkan untuk membuat pemesanan kendaraan.");
                PopulateDropdowns(viewModel);
                return View(viewModel);
            }

            // Jika pengecekan lolos, baru mulai transaksi database
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var firstApprover = await _context.Approvers
                    .Include(a => a.Employee)
                    .FirstOrDefaultAsync(a => a.Employee.DepartementId == employee.DepartementId && a.ApprovalLevelId == 1);

                if (firstApprover == null)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", "Tidak dapat menemukan approver level 1 untuk departemen ini.");
                    PopulateDropdowns(viewModel);
                    return View(viewModel);
                }

                var newBooking = new VehicleBooking
                {
                    Keperluan = viewModel.Keperluan,
                    Durasi = viewModel.Durasi,
                    Tanggal = viewModel.Tanggal,
                    StartMiningId = viewModel.StartMiningId,
                    EndMiningId = viewModel.EndMiningId,
                    EmployeeId = viewModel.EmployeeId,
                    VehicleId = viewModel.VehicleId,
                    DriverName = viewModel.DriverName,
                    Status = "Menunggu Persetujuan" // Status awal selalu ini
                };

                // Buat tugas persetujuan untuk approver Level 1
                var initialApprovalProcess = new ApprovalProcess
                {
                    ApproverId = firstApprover.Id,
                    ApprovalLevelId = firstApprover.ApprovalLevelId,
                    Status = StatusApproval.Menunggu
                };

                // Hubungkan proses persetujuan dengan booking baru
                newBooking.ApprovalProcesses = new List<ApprovalProcess> { initialApprovalProcess };

                _context.Add(newBooking);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                await _activityLogService.LogActivityAsync("CREATE_BOOKING", $"Membuat booking baru #{newBooking.Id} untuk {employee.Name}.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError(ex, "Error saat membuat booking.");
                ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data.");
                PopulateDropdowns(viewModel);
                return View(viewModel);
            }
        }

        // File: Controllers/VehicleBookingController.cs

        // GET: VehicleBooking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.VehicleBookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            // Ubah dari Entity ke ViewModel
            var viewModel = new EditBookingViewModel
            {
                Id = booking.Id,
                Keperluan = booking.Keperluan,
                Durasi = booking.Durasi,
                Tanggal = booking.Tanggal,
                DriverName = booking.DriverName,
                StartMiningId = booking.StartMiningId,
                EndMiningId = booking.EndMiningId,
                EmployeeId = booking.EmployeeId,
                VehicleId = booking.VehicleId
            };

            PopulateEditDropdowns(viewModel);
            return View(viewModel);
        }

        // POST: VehicleBooking/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditBookingViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Ambil data asli dari database
                    var bookingInDb = await _context.VehicleBookings.FindAsync(id);
                    if (bookingInDb == null)
                    {
                        return NotFound();
                    }

                    // Update properti dari ViewModel
                    bookingInDb.Keperluan = viewModel.Keperluan;
                    bookingInDb.Durasi = viewModel.Durasi;
                    bookingInDb.Tanggal = viewModel.Tanggal;
                    bookingInDb.DriverName = viewModel.DriverName;
                    bookingInDb.StartMiningId = viewModel.StartMiningId;
                    bookingInDb.EndMiningId = viewModel.EndMiningId;
                    bookingInDb.EmployeeId = viewModel.EmployeeId;
                    bookingInDb.VehicleId = viewModel.VehicleId;

                    _context.Update(bookingInDb);
                    await _context.SaveChangesAsync();

                    // [LOGGING] Catat aktivitas edit booking
                    await _activityLogService.LogActivityAsync("EDIT_BOOKING", $"Mengubah data booking #{viewModel.Id}.");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleBookingExists(viewModel.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Jika tidak valid, siapkan lagi dropdown dan kembalikan ke view
            PopulateEditDropdowns(viewModel);
            return View(viewModel);
        }

        // Buat metode helper baru untuk populate dropdown di Edit
        private void PopulateEditDropdowns(EditBookingViewModel viewModel)
        {
            viewModel.Minings = new SelectList(_context.Minings, "Id", "Mining_Name");
            viewModel.Employees = new SelectList(_context.Employees, "Id", "Name");
            viewModel.Vehicles = new SelectList(_context.Vehicles, "Id", "Name");
            var drivers = new List<string> { "Budi", "Andi", "Charlie", "Dedi" };
            viewModel.Drivers = new SelectList(drivers);
        }

        // GET: VehicleBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBooking = await _context.VehicleBookings
                .Include(v => v.Employee)
                .Include(v => v.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);

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
            if (vehicleBooking != null)
            {
                string logDescription = $"Menghapus booking #{vehicleBooking.Id} (Keperluan: {vehicleBooking.Keperluan}).";

                _context.VehicleBookings.Remove(vehicleBooking);
                await _context.SaveChangesAsync();
                
                await _activityLogService.LogActivityAsync("DELETE_BOOKING", logDescription);
            }
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropdowns(CreateBookingViewModel viewModel)
        {
            viewModel.Minings = new SelectList(_context.Minings, "Id", "Mining_Name");
            viewModel.Employees = new SelectList(_context.Employees, "Id", "Name");
            viewModel.Vehicles = new SelectList(_context.Vehicles, "Id", "Name");
            var drivers = new List<string> { "Budi", "Andi", "Charlie", "Dedi" };
            viewModel.Drivers = new SelectList(drivers);
        }

        private bool VehicleBookingExists(int id)
        {
            return _context.VehicleBookings.Any(e => e.Id == id);
        }
    }
}