using fakeshop.API.Data;
using fakeshop.API.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace fakeshop.API.Repositories {
    public class SQLProductRepository : IProductRepository {
        private readonly FakeShopDbContext dbContext;
        public SQLProductRepository(FakeShopDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public FakeShopDbContext DbContext { get; }

        public async Task<(List<Product> Items, int totalCount)> GetallAsync(int pN = 1, int pS = 10) {
            var pro = dbContext.Products
                .Include(p => p.Vendor).AsQueryable();

            int totalCount = await pro.CountAsync();

            var skipResults = (pN - 1) * pS;

            var items = await pro.Skip(skipResults).Take(pS).ToListAsync();

            return (items, totalCount);
        }
    }
}
