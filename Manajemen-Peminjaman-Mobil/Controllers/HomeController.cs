using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VehicleManagementDbContext _context;

        public HomeController(ILogger<HomeController> logger, VehicleManagementDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // File: Controllers/HomeController.cs

        [HttpGet]
        public JsonResult GetVehicleUsageData()
        {
            var year = DateTime.Now.Year;

            // Ambil SEMUA booking untuk tahun ini
            var bookings = _context.VehicleBookings
                .Where(vb => vb.Tanggal.Year == year)
                .ToList();

            // Kelompokkan berdasarkan bulan DAN status
            var monthlyBookings = bookings
                .GroupBy(b => new { b.Tanggal.Month, b.Status })
                .Select(group => new {
                    Month = group.Key.Month,
                    Status = group.Key.Status,
                    Count = group.Count()
                })
                .ToList();

            // Siapkan list data untuk setiap status
            var approvedData = Enumerable.Range(1, 12).Select(m => 0).ToList();
            var rejectedData = Enumerable.Range(1, 12).Select(m => 0).ToList();
            var pendingData = Enumerable.Range(1, 12).Select(m => 0).ToList();

            // Isi list data berdasarkan hasil query
            foreach (var item in monthlyBookings)
            {
                if (item.Status.Contains("Disetujui"))
                {
                    approvedData[item.Month - 1] += item.Count;
                }
                else if (item.Status.Contains("Ditolak"))
                {
                    rejectedData[item.Month - 1] += item.Count;
                }
                else // Status lain dianggap "Menunggu" (Menunggu Persetujuan, Eskalasi, dll)
                {
                    pendingData[item.Month - 1] += item.Count;
                }
            }

            var monthLabels = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames
                                .Take(12).ToArray();

            // Buat struktur data series yang baru untuk stacked chart
            var series = new object[]
            {
                new { name = "Disetujui", data = approvedData },
                new { name = "Ditolak", data = rejectedData },
                new { name = "Menunggu", data = pendingData }
            };

            return Json(new { labels = monthLabels, series = series });
        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
