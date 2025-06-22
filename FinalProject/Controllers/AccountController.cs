using FinalProject.Models.Entities;
using FinalProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {

        // Dependency injection for the application's database context
        private readonly ApplicationDbContext _dbContext;

        // Constructor to inject the database context into the controller
        public AccountController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Displays the landing page with options to login or register
        [HttpGet]
        public IActionResult Front()
        {
            return View();
        }

        // Displays the registration form
        [HttpGet]
        public IActionResult Register() => View();

        // Handles the registration logic
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {

            // Add new user to the database
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Redirect to login form after successful registration
            return RedirectToAction("Login");
        }

        // Displays the login form
        [HttpGet]
        public IActionResult Login() => View();

        // Handles the login process, and checks user credentials
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            // Look for a matching user in the database
            var existingUser = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {

                // If user is found, set session and redirect to inventory page
                HttpContext.Session.SetString("Username", user.Username);
                return RedirectToAction("Index", "Inventory");

            }

            // Display error when login fails
            ViewBag.Error = "Invalid username or password.";
            return View();

        }

        // Clears session and redirects back to the front page
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Front", "Account");
        }

    }
}
