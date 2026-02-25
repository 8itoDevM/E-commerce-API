using fakeshop.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fakeshop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly FakeShopDbContext dbContext;

        public ProductsController(FakeShopDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll() {
            var products = dbContext.Products
                .Include(p => p.Vendor)
                .ToList();

            return Ok(products);
        }
    }
}
