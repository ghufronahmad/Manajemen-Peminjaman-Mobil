using Manajemen_Peminjaman_Mobil.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using OfficeOpenXml;

public class ReportController : Controller
{
    private readonly VehicleManagementDbContext _context;

    public ReportController(VehicleManagementDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Tampilkan view di mana user bisa memilih rentang tanggal
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ExportToExcel(DateTime startDate, DateTime endDate)
    {
        var bookings = await _context.VehicleBookings
            .Include(b => b.Employee)
            .Include(b => b.Vehicle)
            .Where(b => b.Tanggal >= startDate && b.Tanggal <= endDate)
            .ToListAsync();

        var stream = new MemoryStream();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using (var package = new ExcelPackage(stream))
        {
            var worksheet = package.Workbook.Worksheets.Add("Laporan Peminjaman");

            // Header
            worksheet.Cells[1, 1].Value = "Tanggal";
            worksheet.Cells[1, 2].Value = "Pegawai";
            worksheet.Cells[1, 3].Value = "Kendaraan";
            worksheet.Cells[1, 4].Value = "Keperluan";
            worksheet.Cells[1, 5].Value = "Status";

            // Body
            int row = 2;
            foreach (var booking in bookings)
            {
                worksheet.Cells[row, 1].Value = booking.Tanggal.ToString("yyyy-MM-dd");
                worksheet.Cells[row, 2].Value = booking.Employee.Name;
                worksheet.Cells[row, 3].Value = booking.Vehicle.Name;
                worksheet.Cells[row, 4].Value = booking.Keperluan;
                worksheet.Cells[row, 5].Value = booking.Status;
                row++;
            }

            package.Save();
        }
        stream.Position = 0;
        string excelName = $"LaporanPeminjaman_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
    }
}