﻿using Microsoft.AspNetCore.Mvc;

namespace Customer_Relationship_Management_1._0.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
