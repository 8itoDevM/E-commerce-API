using fakeshop.API.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace fakeshop.API.Repositories {
    public interface IProductRepository {
        Task<(List<Product> Items, int totalCount)> GetallAsync([FromQuery] int pN = 1, [FromQuery] int pS = 10);
    }
}
