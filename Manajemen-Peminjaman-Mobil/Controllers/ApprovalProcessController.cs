using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    [Authorize(Roles = "Approver")] // Hanya user dengan role "Approver" yang bisa akses
    public class ApprovalProcessController : Controller
    {
        private readonly VehicleManagementDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IActivityLogService _activityLogService;

        public ApprovalProcessController(VehicleManagementDbContext context, UserManager<User> userManager, IActivityLogService activityLogService)
        {
            _context = context;
            _userManager = userManager;
            _activityLogService = activityLogService;
        }

        // GET: Menampilkan daftar tugas persetujuan untuk user yang login
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge(); // Jika user tidak ditemukan
            }

            var approvalTasks = await _context.approvalProcesses
                .Include(ap => ap.VehicleBooking).ThenInclude(vb => vb.Employee)
                .Include(ap => ap.VehicleBooking).ThenInclude(vb => vb.Vehicle)
                .Include(ap => ap.ApprovalLevel)
                .Where(ap => ap.Approver.UserId == currentUser.Id && ap.Status == StatusApproval.Menunggu)
                .ToListAsync();

            return View(approvalTasks);
        }

        // POST: Aksi untuk menyetujui pemesanan
        // File: Controllers/ApprovalProcessController.cs

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id) // id di sini adalah Id dari ApprovalProcess
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // [DIPERBAIKI] Query sekarang memuat Employee dan ApprovalLevel terkait
                var approvalProcess = await _context.approvalProcesses
                    .Include(ap => ap.VehicleBooking).ThenInclude(vb => vb.Employee) // <-- Memuat Employee
                    .Include(ap => ap.Approver)
                    .Include(ap => ap.ApprovalLevel) // <-- Memuat ApprovalLevel saat ini
                    .FirstOrDefaultAsync(ap => ap.Id == id);

                // Validasi
                var currentUser = await _userManager.GetUserAsync(User);
                if (approvalProcess == null || approvalProcess.Approver.UserId != currentUser.Id)
                {
                    return Forbid(); // User mencoba menyetujui tugas yang bukan miliknya
                }

                // 1. Update status persetujuan saat ini
                approvalProcess.Status = StatusApproval.Disetujui;
                approvalProcess.ProcessedAt = DateTime.Now;

                var currentLevel = approvalProcess.ApprovalLevel;
                var nextApprover = await _context.Approvers
                    .Include(a => a.ApprovalLevel)
                    .Include(a => a.Employee) 
                    .FirstOrDefaultAsync(a => a.Employee.DepartementId == approvalProcess.VehicleBooking.Employee.DepartementId
                    && a.ApprovalLevel.Level == (currentLevel.Level + 1));

                if (nextApprover != null)
                {
                    var nextApprovalProcess = new ApprovalProcess
                    {
                        VehicleBookingId = approvalProcess.VehicleBookingId,
                        ApproverId = nextApprover.Id,
                        ApprovalLevelId = nextApprover.ApprovalLevelId,
                        Status = StatusApproval.Menunggu
                    };
                    _context.Add(nextApprovalProcess);
                    approvalProcess.VehicleBooking.Status = $"Disetujui Level {currentLevel.Level}";
                }
                else
                {
                    approvalProcess.VehicleBooking.Status = "Disetujui";
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                var booking = approvalProcess.VehicleBooking;
                await _activityLogService.LogActivityAsync("APPROVE_BOOKING", $"Menyetujui pemesanan #{booking.Id} untuk {booking.Employee.Name}.");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                TempData["ErrorMessage"] = "Terjadi kesalahan saat proses persetujuan.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Aksi untuk menolak pemesanan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, string remarks) // id dari ApprovalProcess
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var approvalProcess = await _context.approvalProcesses
                    .Include(ap => ap.VehicleBooking)
                    .Include(ap => ap.Approver)
                    .FirstOrDefaultAsync(ap => ap.Id == id);

                var currentUser = await _userManager.GetUserAsync(User);
                if (approvalProcess == null || approvalProcess.Approver.UserId != currentUser.Id)
                {
                    return Forbid();
                }

                // 1. Update status persetujuan saat ini menjadi Ditolak
                approvalProcess.Status = StatusApproval.Ditolak;
                approvalProcess.ProcessedAt = DateTime.Now;
                approvalProcess.Remarks = remarks;

                // 2. Update status booking utama menjadi Ditolak
                approvalProcess.VehicleBooking.Status = "Ditolak";

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                var booking = approvalProcess.VehicleBooking;
                await _activityLogService.LogActivityAsync("REJECT_BOOKING", $"Menolak pemesanan #{booking.Id} untuk {booking.Employee.Name} dengan alasan: {remarks}.");

                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }
}