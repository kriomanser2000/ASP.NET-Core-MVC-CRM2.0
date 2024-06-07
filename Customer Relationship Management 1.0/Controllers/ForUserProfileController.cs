using Customer_Relationship_Management_1._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Customer_Relationship_Management_1._0.Controllers
{
    [Authorize]
    public class ForUserProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForUserProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Отримання ідентифікатора користувача із токена
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return NotFound("User not found");
            }
            // Отримання інформації про користувача із бази даних
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId.ToString() == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }
            return View(user);
        }
    }
}