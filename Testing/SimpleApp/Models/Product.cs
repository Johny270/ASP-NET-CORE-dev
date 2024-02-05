namespace SimpleApp.Models
{
    public class Product
    {
        public string Name { get; set; } = String.Empty;
        public decimal? Price { get; set; }        
 
    }

    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products => new Product[]
        {
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "LifeJacket", Price = 48.95M },
        };
    }
}
