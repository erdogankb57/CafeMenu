using Cafe.Menu.Admin.Models;
using Cafe.Menu.Business.DataContext;
using Cafe.Menu.Business.Service;
using Cafe.Menu.Entity;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();




var app = builder.Build();





var cache = app?.Services.GetService<IMemoryCache>();
var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromDays(1));

ProductService productService = new ProductService();
var product = productService.Find(null);
DefaultDataContext context = new DefaultDataContext();

var product2 = from p in context.Products
               join c in context.Categorys on p.CategoryId equals c.CategoryId
               select new ProductViewModel
               {
                   ImagePath = p.ImagePath,
                   ProductName = p.ProductName,
                   Price = p.Price,
                   CategoryName = c.CategoryName
               };
if (product.Data != null)
    cache.Set<List<ProductViewModel>>("ProductView", product2.ToList(), cacheEntryOptions);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
