using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Dtos.ProductTypeDto;
using Store.Dtos.UserDto;
using Store.Entities;
using Store.Interfaces;
using Store.Services;

namespace Store.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _productTypeService;
        private readonly StoreDbContext _context;
        public ProductTypeController(IProductTypeService productTypeService, StoreDbContext context)
        {
            _productTypeService = productTypeService;
            _context = context;
        }

        [HttpGet]
        public Task<ICollection<ProductType>> GetAllProductTypes()
        {
            return _productTypeService.GetProductTypes();
        }

        [HttpGet("{id:int}")]
        public async Task<GetSingleProductTypeDto> GetProductTypeId(int id)
        {
            GetSingleProductTypeDto productTypeDto = new GetSingleProductTypeDto();
            try
            {
                if (id == 0)
                {
                    productTypeDto.Status = "Id is empty";
                    productTypeDto.ProductType = null;
                    productTypeDto.Code = 400;
                }
                else
                {
                    var productType = await _productTypeService.GetProductType(id);
                    if (productType == null)
                    {
                        productTypeDto.Status = "Not found";
                        productTypeDto.ProductType = null;
                        productTypeDto.Code = 404;
                    }
                    else
                    {
                        productTypeDto.Status = "Succes";
                        productTypeDto.ProductType = productType;
                        productTypeDto.Code = 200;
                    }
                }
            }
            catch(Exception ex)
            {
                productTypeDto.Status = ex.InnerException.ToString();
                productTypeDto.ProductType = null;
                productTypeDto.Code = 0;
            }

            return productTypeDto;

        }

        [HttpPost("ProductTypeRegistration")]
        public async Task<IActionResult> ProductTypeRegistration(ProductTypeRegistrationDto productTypeRegistrationDto)
        {
            if(productTypeRegistrationDto == null)
            {
                return BadRequest("Invalid Registration Data");
            }

            try
            {
                var newProductType = new ProductType
                {
                    Name = productTypeRegistrationDto.Name
                };

                await _productTypeService.ProductTypeRegistration(newProductType);

                var createProductTypeDto = new CreateProductTypeDto
                {
                    IsCreated = true,
                    Status = "Created",
                    Code = 201
                };

                return CreatedAtAction(nameof(ProductTypeRegistration), createProductTypeDto);
            }
            catch (Exception ex)
            {
                var createProductTypeDto = new CreateProductTypeDto
                {
                    IsCreated = false,
                    Status = $"An error occurred: {ex.Message}",
                    Code = 0
                };

                return StatusCode(500, createProductTypeDto);
            }   
        
        
        }


    }
}
