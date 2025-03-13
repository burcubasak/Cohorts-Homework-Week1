using Cohorts_Homework_Week1.Models;

namespace Cohorts_Homework_Week1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Price = 500, Stock = 20 }
        };
        }



        public IEnumerable<Product> GetAll(String? name = null)
        {
            return string.IsNullOrEmpty(name)
                ? _products
                : _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Stock = product.Stock;

            }
        }
        public void Delete(int id) => _products.RemoveAll(p => p.Id == id);
    }
}
