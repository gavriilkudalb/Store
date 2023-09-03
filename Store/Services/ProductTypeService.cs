using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Dtos.ProductTypeDto;
using Store.Entities;
using Store.Interfaces;

namespace Store.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly StoreDbContext _context;
        public ProductTypeService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<ProductType> GetProductType(int id)
        {
            return await _context.ProductType.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ProductType>> GetProductTypes()
        {
            return await _context.ProductType.ToListAsync();
        }

        public async Task ProductTypeRegistration(ProductType newProductType)
        {
            ProductType productType = new ProductType
            {
                Name = newProductType.Name
            };

            await _context.AddAsync(productType);
            await _context.SaveChangesAsync();
        }
    }
}