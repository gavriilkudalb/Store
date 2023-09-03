using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Dtos.UserDto;
using Store.Dtos.ProductDto;
using Store.Entities;
using Store.Interfaces;
using Store.Services;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly StoreDbContext _context;

        public ProductController(IProductService productService, StoreDbContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpGet]
        public Task<ICollection<Product>> GetAllProducts()
        {
            return _productService.GetProducts();
        }

        [HttpGet("{id:int}")]
        public async Task<GetSingleProductDto> GetProductId(int id)
        {
            GetSingleProductDto productDto = new GetSingleProductDto();
            try
            {
                if (id == 0)
                {
                    productDto.Status = "Id is empty";
                    productDto.Product = null;
                    productDto.Code = 400;
                }
                else
                {
                    var product = await _productService.GetProduct(id);
                    if(product == null)
                    {
                        productDto.Status = "Not Found";
                        productDto.Product = null;
                        productDto.Code = 404;
                    }
                    else
                    {
                        productDto.Status = "Succes";
                        productDto.Product = product;
                        productDto.Code = 200;
                    }
                }
            }
            catch (Exception ex)
            {
                productDto.Product = null;
                productDto.Status = ex.InnerException.ToString();
                productDto.Code = 0;
            }
            return productDto;

        }

        [HttpPost("Registration")]
        public async Task<IActionResult> ProductRegistration(Product product)
        {
            if(product == null)
            {
                return BadRequest("Invalid registration data");
            }
            

            try
            {
                var newProduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    ProductBrandId = product.ProductBrandId,
                    ProductTypeId = product.ProductTypeId,
                   
                };

                await _productService.ProductRegistration(newProduct);

                var createProductDto = new CreateProductDto
                {
                    IsCreated = true,
                    Status = "Created",
                    Code = 201
                };

                return CreatedAtAction(nameof(ProductRegistration), createProductDto);

            }
            catch(Exception ex)
            {
                var createProductDto = new CreateProductDto
                {
                    IsCreated = false,
                    Status = $"An error occurred: {ex.Message}",
                    Code = 0
                };

                return StatusCode(500, createProductDto);
            }

        }



    }
}
