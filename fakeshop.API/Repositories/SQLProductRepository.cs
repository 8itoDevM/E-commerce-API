using fakeshop.API.Data;
using fakeshop.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace fakeshop.API.Repositories {
    public class SQLProductRepository : IProductRepository {
        private readonly FakeShopDbContext dbContext;
        public SQLProductRepository(FakeShopDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public FakeShopDbContext DbContext { get; }

        public async Task<List<Product>> GetallAsync() {
            var pro = await dbContext.Products
                .Include(p => p.Vendor)
                .ToListAsync();
            return pro;
        }
    }
}
