using CP1Enterprise_EntityFramework_FIAP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CP1Enterprise_EntityFramework_FIAP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TermsOfUse()
        {
            return View();
        }

        public JsonResult TesteJson()
        {
            var JsonOutput = new
            {
                Texto = "Teste",
                Data = DateTime.UtcNow
            };

            return Json(JsonOutput);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}