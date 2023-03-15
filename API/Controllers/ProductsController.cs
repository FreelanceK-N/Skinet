
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;

        public ProductsController(
        IGenericRepository<Product> productsRepo, 
        IGenericRepository<ProductBrand> productBrandsRepo, 
        IGenericRepository<ProductType> productTypesRepo)
        {   
            this._productsRepo = productsRepo;
            this._productBrandsRepo = productBrandsRepo;
            this._productTypesRepo = productTypesRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts() 
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await this._productsRepo.ListAsync(spec);

            return products.Select(product => new ProductDto 
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name 
            }).ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await this._productsRepo.GetEntityWithSpecAsync(spec);

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PictureUrl = product.PictureUrl,
                Price = product.Price,
                ProductBrand = product.ProductBrand.Name,
                ProductType = product.ProductType.Name
            };

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await this._productBrandsRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await this._productTypesRepo.ListAllAsync());
        }
    }
}