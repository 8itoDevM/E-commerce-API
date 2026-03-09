using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace fakeshop.API.Data {
    public class FakeShopAuthDbContext : IdentityDbContext {
        public FakeShopAuthDbContext(DbContextOptions<FakeShopAuthDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            var managerRoleId = "b1c2d3e4-5678-90ab-cdef-1234567890ab";
            var employeeRoleId = "a1e2c3d4-5678-90ab-cdef-1234567890ab";
            var userRoleId = "d1c8e5b0-9a7c-4f1e-9b3c-2a5e6f8c9d72";

            var roles = new List<IdentityRole> {
                new IdentityRole {
                    Id = managerRoleId,
                    ConcurrencyStamp = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole {
                    Id = employeeRoleId,
                    ConcurrencyStamp = employeeRoleId,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
