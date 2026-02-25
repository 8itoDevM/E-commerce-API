using fakeshop.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace fakeshop.API.Data {
    public class FakeShopDbContext : DbContext{
        public FakeShopDbContext(DbContextOptions options) : base(options) {
        }

        public DbSet<Product> Products {  get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}
