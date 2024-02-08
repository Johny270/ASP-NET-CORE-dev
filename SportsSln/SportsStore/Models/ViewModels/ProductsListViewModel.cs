namespace SportsStore.Models.ViewModels
{
    // This class represent an instance of the PagingInfo view model class that will be pass to the view
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory { get; set; }
    }
}
