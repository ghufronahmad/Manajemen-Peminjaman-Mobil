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
        private readonly VehicleManagementDbContext _context;

        public AuthController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;

            if (claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(User modelLogin)
        {
            // Find user by email
            var user = _context.Users.SingleOrDefault(u => u.Email == modelLogin.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(modelLogin.Password, user.Password))
            {
                // Create user claims based on user information
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()), // Use Role enum and convert to string
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                };

                // Sign in the user with claims
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                return RedirectToAction("Index", "Home");
            }

            // If user login fails, show error message
            ViewData["ValidateMessage"] = "User not found or incorrect password";
            return View();
        }

        // POST: Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
