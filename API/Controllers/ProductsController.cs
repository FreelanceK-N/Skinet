
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo;

        private readonly IMapper _mapper;

        public ProductsController(
        IGenericRepository<Product> productsRepo, 
        IGenericRepository<ProductBrand> productBrandsRepo, 
        IGenericRepository<ProductType> productTypesRepo,
        IMapper mapper)
        {   
            this._productsRepo = productsRepo;
            this._productBrandsRepo = productBrandsRepo;
            this._productTypesRepo = productTypesRepo;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts() 
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await this._productsRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await this._productsRepo.GetEntityWithSpecAsync(spec);

            return Ok(_mapper.Map<Product, ProductDto>(product));
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