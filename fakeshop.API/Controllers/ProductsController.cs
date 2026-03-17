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
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper) {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Authorize(Roles = "Manager,Employee,User")]
        public async Task<IActionResult> GetAllAsyncV1([FromQuery] int pN = 1, [FromQuery] int pS = 10) {
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

        [MapToApiVersion("2.0")]
        [HttpGet]
        [Authorize(Roles = "Manager,Employee,User")]
        public async Task<IActionResult> GetAllAsyncV2([FromQuery] int pN = 1, [FromQuery] int pS = 10) {
            var (products, totalCount) = await productRepository.GetallAsync(pN, pS);

            var totalPages = (int)Math.Ceiling((double)totalCount / pS);
            totalPages += 100;

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
