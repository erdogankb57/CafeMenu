using Cafe.Menu.Business.Service;
using Cafe.Menu.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cafe.Menu.Web.Controllers
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
            CategoryService service = new CategoryService();
            service.Save(new Entity.Category
            {
                CategoryName = DateTime.Now.ToString()
            });
            return View();
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