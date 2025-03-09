using Cafe.Menu.Business.Service;
using Cafe.Menu.Core.Model;
using Cafe.Menu.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Menu.Admin.Controllers
{

    public class PropertyController : Controller
    {
        PropertyService propertyService = new PropertyService();
        public IActionResult Index()
        {
            var result = propertyService.Find(v => v.IsDeleted == false || v.IsDeleted == null);
            return View(result.Data);
        }

        public IActionResult Add(int? Id)
        {

            DataResult<Property> result = new DataResult<Property>();
            if (Id.HasValue)
            {
                result = propertyService.Get(v => v.PropertyId == Id);
            }
            else
            {
                result.Data = new Property();
            }

            return View(result.Data);
        }

        public IActionResult Save(Property category)
        {
            propertyService.Save(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var deletedData = propertyService.Get(v => v.PropertyId == Id);
            if (deletedData.Data != null)
            {
                propertyService.Delete(deletedData.Data);
            }
            return RedirectToAction("Index");
        }
    }
}
