// File: Controllers/ActivityLogController.cs
using Manajemen_Peminjaman_Mobil.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ActivityLogController : Controller
{
    private readonly VehicleManagementDbContext _context;

    public ActivityLogController(VehicleManagementDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var logs = await _context.ActivityLogs
            .OrderByDescending(l => l.Timestamp)
            .ToListAsync();
        return View(logs);
    }
}