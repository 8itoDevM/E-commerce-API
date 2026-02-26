using fakeshop.API.Models.Domain;

namespace fakeshop.API.Repositories {
    public interface IProductRepository {
        Task<List<Product>> GetallAsync();
    }
}
