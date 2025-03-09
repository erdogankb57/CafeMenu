using Cafe.Menu.Business.Service;
using Cafe.Menu.Core.Model;
using Cafe.Menu.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Menu.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
        public IActionResult Index()
        {
            var result = categoryService.Find(v=> v.IsDeleted == false || v.IsDeleted == null);
            return View(result.Data);
        }

        public IActionResult Add(int? Id)
        {

            DataResult<Category> result = new DataResult<Category>();
            if (Id.HasValue)
            {
                result = categoryService.Get(v => v.CategoryId == Id);
            }
            else
            {
                result.Data = new Category();
            }
            
            return View(result.Data);
        }

        public IActionResult Save(Category category)
        {
            categoryService.Save(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var deletedData = categoryService.Get(v => v.CategoryId == Id);
            if (deletedData.Data != null)
            {
                categoryService.Delete(deletedData.Data);
            }
            return RedirectToAction("Index");
        }
    }
}
