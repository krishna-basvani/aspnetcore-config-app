using aspnetcore_config_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
// Added
using Microsoft.Extensions.Configuration;

namespace aspnetcore_config_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Added
        private readonly IConfiguration _config;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)// Added
        {
            _logger = logger;
            // Added
            _config = config;
        }

        public IActionResult Index()
        {
            // Added
            string currentAppEnviroment = _config["appEnviroment"];
            ViewData["envValue"] = currentAppEnviroment;
            return View(ViewData["envValue"]);
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
    }
}
