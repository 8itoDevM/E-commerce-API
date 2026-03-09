using AutoMapper;
using fakeshop.API.Data;
using fakeshop.API.Models.DTO;
using fakeshop.API.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pN = 1, [FromQuery] int pS = 10) {
            var (products, totalCount) = await productRepository.GetallAsync(pN, pS);

            var totalPages = (int)Math.Ceiling((double)totalCount / pS);

            return Ok(new {
                products,
                totalCount,
                pageNumber = pN,
                pageSize = pS,
                totalPages
            });
        }
    }
}
