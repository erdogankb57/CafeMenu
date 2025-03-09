using Cafe.Menu.Admin.Models;
using Cafe.Menu.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Menu.Admin.Controllers
{
    public class ProductViewController : Controller
    {
        IMemoryCache _cache = null;
        public ProductViewController(IMemoryCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            var product = _cache.Get<List<ProductViewModel>>("ProductView");
            return View(product);
        }
    }
}
