using Customer_Relationship_Management_1._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Relationship_Management_1._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View("~/Views/Home/RegistrPage.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    Country = model.Country,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    IsApproved = false,
                    Role = "User"
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}