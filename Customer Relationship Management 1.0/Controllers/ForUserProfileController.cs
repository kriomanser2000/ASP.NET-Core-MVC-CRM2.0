using Customer_Relationship_Management_1._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Customer_Relationship_Management_1._0.Controllers
{
    public class ForUserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}