using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Dtos.ProductBrandDto;
using Store.Dtos.UserDto;
using Store.Entities;
using Store.Interfaces;
using Store.Services;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandService _productBrandService;
        private readonly StoreDbContext _context;
        public ProductBrandController(IProductBrandService productBrandService, StoreDbContext context)
        {
            _productBrandService = productBrandService;
            _context = context;
        }

        [HttpGet]
        public Task<ICollection<ProductBrand>> GetAllProductBrands()
        {
            return _productBrandService.GetProductBrands();
        }

        [HttpGet("{id:int}")]
        public async Task<GetSingleProductBrandDto> GetProductBrandId(int id)
        {
            GetSingleProductBrandDto productBrandDto = new GetSingleProductBrandDto();
            try
            {
                if (id == 0)
                {
                    productBrandDto.Status = "Id is empty";
                    productBrandDto.ProductBrand = null;
                    productBrandDto.Code = 400;
                }
                else
                {
                    var productBrand = await _productBrandService.GetProductBrand(id);
                    if (productBrand == null)
                    {
                        productBrandDto.Status = "Not found";
                        productBrandDto.ProductBrand = null;
                        productBrandDto.Code = 404;
                    }
                    else
                    {
                        productBrandDto.Status = "Success";
                        productBrandDto.ProductBrand = productBrand;
                        productBrandDto.Code = 200;
                    }
                }
            }
            catch (Exception ex)
            {
                productBrandDto.ProductBrand = null;
                productBrandDto.Status = ex.InnerException.ToString();
                productBrandDto.Code = 0;
            }

            return productBrandDto;
        }

        [HttpPost("PoductBrandRegistration")]
        public async Task<IActionResult> ProductBrandRegistration(ProductBrandRegistrationDto productBrandRegistrationDto)
        {
            if (productBrandRegistrationDto == null)
            {
                return BadRequest("Invalid registration data");
            }

            try
            {
                var newProductBrand = new ProductBrand
                {
                    Name = productBrandRegistrationDto.Name
                };

               

                await _productBrandService.ProductBrandRegistration(newProductBrand);

                var createProductBrandDto = new CreateProductBrandDto
                {
                    IsCreated = true,
                    Status = "Created",
                    Code = 201
                };

                return CreatedAtAction(nameof(ProductBrandRegistration), createProductBrandDto);
            }
            catch (Exception ex)
            {
                var createProductBrandDto = new CreateProductBrandDto
                {
                    IsCreated = false,
                    Status = $"An error occurred: {ex.Message}",
                    Code = 0
                };

                return StatusCode(500, createProductBrandDto);
            }
        }
    }
}
