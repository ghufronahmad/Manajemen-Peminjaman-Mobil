using Manajemen_Peminjaman_Mobil.Models;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        // Inject UserManager dan SignInManager
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Auth/Login
        [HttpGet]
        public IActionResult Login()
        {
            // Buat dan kirim ViewModel yang kosong agar form bisa ditampilkan.
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        // POST: /Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Cari user berdasarkan email
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // Gunakan PasswordSignInAsync untuk login, ini akan membuat cookie yang benar
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Jika berhasil, arahkan ke halaman utama
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Login Gagal. Periksa kembali Email dan Password Anda.");
            return View(model);
        }

        // POST: /Auth/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}