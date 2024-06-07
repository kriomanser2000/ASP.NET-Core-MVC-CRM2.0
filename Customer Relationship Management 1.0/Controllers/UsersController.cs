using Customer_Relationship_Management_1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Customer_Relationship_Management_1._0.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ApplicationDbContext context, ILogger<UsersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        [Route("Edit/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInformation($"Loading user with id: {id}");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with id: {id} not found");
                return NotFound();
            }
            return View(user);
        }

        [Route("Edit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,FirstName,Country,PhoneNumber,Email,Password,IsApproved,Role")] User user)
        {
            _logger.LogInformation($"POST Edit called for UserId: {id}");

            if (id != user.UserId)
            {
                _logger.LogWarning($"UserId mismatch: {id} != {user.UserId}");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"User with UserId: {id} successfully updated");
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _logger.LogError(ex, $"Concurrency exception for UserId: {id}");
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        _logger.LogError($"Error with key {modelStateKey}: {error.ErrorMessage}");
                    }
                }
            }

            _logger.LogWarning($"ModelState is invalid for UserId: {id}");
            return View(user);
        }


        [Route("Delete/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Loading user with id: {id} for deletion");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with id: {id} not found");
                return NotFound();
            }
            return View(user);
        }

        [Route("Delete/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInformation($"Deleting user with id: {id}");
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}