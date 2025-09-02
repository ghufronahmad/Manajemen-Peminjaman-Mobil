using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor(); 
builder.Services.AddScoped<IActivityLogService, ActivityLogService>();

builder.Services.AddDbContext<VehicleManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleManagementDbConnectionString")));

builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

    // Opsi lain yang sudah ada
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<VehicleManagementDbContext>()
    .AddDefaultTokenProviders();

// Konfigurasi cookie untuk Identity (mengatur halaman login)
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied"; // Halaman jika akses ditolak
    options.SlidingExpiration = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

await SeedInitialData(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();

async Task SeedInitialData(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var context = services.GetRequiredService<VehicleManagementDbContext>();

        // 1. Buat Roles
        if (!await roleManager.RoleExistsAsync("Admin")) await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
        if (!await roleManager.RoleExistsAsync("Approver")) await roleManager.CreateAsync(new IdentityRole<Guid>("Approver"));

        // 2. Buat Users
        // Admin
        if (await userManager.FindByEmailAsync("admin@gmail.com") == null)
        {
            var adminUser = new User { UserName = "admin@gmail.com", Email = "admin@gmail.com", Name = "Administrator", EmailConfirmed = true };
            var result = await userManager.CreateAsync(adminUser, "admin123");
            if (result.Succeeded) await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        if (await userManager.FindByEmailAsync("approver1@gmail.com") == null)
        {
            var approver1User = new User { UserName = "approver1@gmail.com", Email = "approver1@gmail.com", Name = "Approver Satu", EmailConfirmed = true };
            var result = await userManager.CreateAsync(approver1User, "approver123");
            if (result.Succeeded) await userManager.AddToRoleAsync(approver1User, "Approver");
        }

        if (await userManager.FindByEmailAsync("approver2@gmail.com") == null)
        {
            var approver2User = new User { UserName = "approver2@gmail.com", Email = "approver2@gmail.com", Name = "Approver Dua", EmailConfirmed = true };
            var result = await userManager.CreateAsync(approver2User, "approver456");
            if (result.Succeeded) await userManager.AddToRoleAsync(approver2User, "Approver");
        }

        if (!context.Approvers.Any())
        {
            var approver1 = await userManager.FindByEmailAsync("approver1@gmail.com");
            var approver2 = await userManager.FindByEmailAsync("approver2@gmail.com");

            if (approver1 != null && approver2 != null)
            {
                context.Approvers.AddRange(
                    new Approver { EmployeeId = 1, UserId = approver1.Id, ApprovalLevelId = 1 },
                    new Approver { EmployeeId = 2, UserId = approver2.Id, ApprovalLevelId = 2 },
                    new Approver { EmployeeId = 3, UserId = approver1.Id, ApprovalLevelId = 1 },
                    new Approver { EmployeeId = 4, UserId = approver2.Id, ApprovalLevelId = 2 }
                );
                await context.SaveChangesAsync();
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during seeding.");
    }
}