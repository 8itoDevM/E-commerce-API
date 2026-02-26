using AutoMapper;
using fakeshop.API.Data;
using fakeshop.API.Models.DTO;
using fakeshop.API.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fakeshop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper) {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var products = await productRepository.GetallAsync();

            //var productsDto = ;

            return Ok(mapper.Map<List<ProductDto>>(products));
        }
    }
}
