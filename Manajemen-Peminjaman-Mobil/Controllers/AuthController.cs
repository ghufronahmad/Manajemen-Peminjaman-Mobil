using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class AuthController : Controller
    {
        private readonly VehicleManagementDbContext vehicleManagementDbContext;

        public AuthController(VehicleManagementDbContext vehicleManagementDbContext)
        {
            this.vehicleManagementDbContext = vehicleManagementDbContext;
        }
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User modelLogin)
        {
            var user = vehicleManagementDbContext.Users.SingleOrDefault(u => u.Email == modelLogin.Email);

            // Check if the user exists and the password matches
            if (user != null && BCrypt.Net.BCrypt.Verify(modelLogin.Password, user.Password))
            {
                // Create claims
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            ViewData["ValidateMessage"] = "User not found or incorrect password";
            return View();
        }
    }
}
