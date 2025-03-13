using Cohorts_Homework_Week1.Models;

namespace Cohorts_Homework_Week1.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(string? name = null);
        Product? GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
