using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StatisticsWebApp.Models;

namespace StatisticsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseConnection dbConnection;
        static List<int> chart_numbers = new List<int>();

        public HomeController(ILogger<HomeController> logger, DatabaseConnection dbConnection)
        {
            _logger = logger;
            this.dbConnection = dbConnection;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult SendStats(int[] stats_numbers)
        {
            ChartDrawing.saveChart(stats_numbers);
            chart_numbers = stats_numbers.ToList();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveToDb()
        {
            dbConnection.InsertDiagram(chart_numbers);
            TempData["DBSuccess"] = "Chart saved to database successfully!";
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
