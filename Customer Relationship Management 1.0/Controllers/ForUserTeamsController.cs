using Customer_Relationship_Management_1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer_Relationship_Management_1._0.Controllers
{
    public class ForUserTeamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForUserTeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teams = _context.Teams.ToList();
            return View(teams);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,TeamName,Description")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}