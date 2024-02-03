//using Microsoft.AspNetCore.Mvc;
//using LanguageFeatures.Models;

using System.Security.Cryptography.X509Certificates;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //bool FilterByPrice(Product? p)
        //{
        //    return (p?.Price ?? 0) >= 20;
        //}
        //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));
        //public async Task<ViewResult> Index()
        //{
        //    List<string> output = new List<string>();
        //    await foreach (long? len in MyAsyncMethods.GetPageLengths(output,
        //        "apress.com", "microsoft.com", "amazon.com"))
        //    {
        //        output.Add($"Page length: { len}");
        //    }
        //    return View(output);
        //}
        public ViewResult Index()
        {
            var products = new[]
            {
                new { Name = "Kayak", Price = 48.95M },
                new { Name = "LifeJacket", Price = 19.50M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name ="Corner Flag", Price = 34.95M }
            };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }
    }
}
