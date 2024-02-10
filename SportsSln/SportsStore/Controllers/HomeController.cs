using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController: Controller
    {
        private IStoreRepository repository;
        public int PageSize = 3;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }

        // Index View uses the ProductsListViewModel class to provide the view with details of the products
        // to display on the page and with details on the pagination
        // In sum, we pass a ProductsListViewModel object as the model data to the view.
        public ViewResult Index(string? category, int productPage = 1) => 
            View(new ProductsListViewModel
            {
                Products = repository.Products.Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() :
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
