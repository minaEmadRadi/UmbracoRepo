using PocApp.Domain.Entities;

namespace PocApp.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        // Other repository methods...
    }
}
