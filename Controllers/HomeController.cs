using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Women_Empowerment.Models;

namespace Women_Empowerment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WomenEmpowerment _context;

        public HomeController(ILogger<HomeController> logger, WomenEmpowerment context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult LegislationAndPolicy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                user.isActive = true;
                _context.Update(user);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role) // Add role claim
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                _logger.LogInformation("User logged in successfully: {username}", username);

                switch (user.Role.ToLower())
                {
                    case "admin":
                        return RedirectToAction("AdminDashboard", "Admin");
                    case "step":
                        return RedirectToAction("STEPDashboard", "STEP");
                    case "ngos":
                        return RedirectToAction("NGOsDashboard", "NGOs");
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                _logger.LogError("Login failed for username: {username}", username);
                TempData["LoginErrorMessage"] = "Invalid username or password";
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == User.Identity.Name);
            if (user != null)
            {
                user.isActive = false;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Faq()
        {
            return View();
        }
    }
}
