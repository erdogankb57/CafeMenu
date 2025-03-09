using Cafe.Menu.Business.Service;
using Cafe.Menu.Core.Model;
using Cafe.Menu.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Menu.Admin.Controllers
{

    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        CategoryService categoryService = new CategoryService();
        PropertyService propertyService = new PropertyService();
        ProductPropertyService propertyPropertyService = new ProductPropertyService();
        public IActionResult Index()
        {
            var result = productService.Find(v => v.IsDeleted == false || v.IsDeleted == null);
            return View(result.Data);
        }

        public IActionResult Add(int? Id)
        {

            DataResult<Product> result = new DataResult<Product>();
            if (Id.HasValue)
            {
                result = productService.Get(v => v.ProductId == Id);

                ViewBag.SelectedId = propertyPropertyService.Find(v => v.ProductId == Id).Data;
            }
            else
            {
                result.Data = new Product();
            }

            List<Property> propertyDataList = new List<Property>();
            var propertyData = propertyService.Find().Data;
            if (propertyData != null)
            {
                propertyDataList = propertyData.ToList();
            }

            ViewBag.PropertyListData = propertyDataList;

            var category = categoryService.Find().Data;
            if (category != null)
                ViewBag.Categories = category.Select(s => new SelectListItem
                {
                    Text = s.CategoryName,
                    Value = s.CategoryId.ToString()
                }).ToList();

            return View(result.Data);
        }

        public IActionResult Save(Product product, IFormFile FileImage, List<string> Property)
        {
            if (FileImage != null)
            {
                //string filePath = Directory.GetCurrentDirectory().ToString() + "Upload";
                string uploads = Path.Combine(Directory.GetCurrentDirectory().ToString(), "wwwroot/Uploads");
                string extension = System.IO.Path.GetExtension(FileImage.FileName.ToLower());

                string random = Guid.NewGuid().ToString();
                if (FileImage.Length > 0)
                {
                    string filePath = Path.Combine(uploads, FileImage.FileName);
                    using (Stream fileStream = new FileStream(uploads + "\\" + random + extension, FileMode.Create))
                    {
                        FileImage.CopyToAsync(fileStream);
                    }
                }
                product.ImagePath = random + extension;

            }

            productService.Save(product);

            foreach (var item in Property)
            {
                if (propertyPropertyService.Get(g => g.ProductId == product.ProductId && g.PropertyId == Convert.ToInt32(item)).Data == null)
                {

                    propertyPropertyService.Save(new ProductProperty
                    {
                        ProductId = product.ProductId,
                        PropertyId = Convert.ToInt32(item)
                    });
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var deletedData = productService.Get(v => v.ProductId == Id);
            if (deletedData.Data != null)
            {
                productService.Delete(deletedData.Data);
            }
            return RedirectToAction("Index");
        }
    }
}
