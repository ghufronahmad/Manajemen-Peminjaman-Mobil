using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

public class ActivityLogService : IActivityLogService
{
    private readonly VehicleManagementDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<User> _userManager;

    public ActivityLogService(VehicleManagementDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task LogActivityAsync(string action, string description)
    {
        var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        if (currentUser == null) return; // Jangan catat jika user tidak ditemukan

        var log = new ActivityLog
        {
            ActorUserId = currentUser.Id,
            ActorName = currentUser.Name, // Atau currentUser.UserName
            Action = action,
            Description = description,
            Timestamp = DateTime.Now
        };

        _context.ActivityLogs.Add(log);
        await _context.SaveChangesAsync();
    }
}