﻿using Microsoft.AspNetCore.Mvc;
using MVC_2024.Services;
using System.Threading.Tasks;

namespace MVC_2024.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardData = await _dashboardService.GetDashboardDataAsync();
            return View(dashboardData); 
        }
    }
}
