using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Dtos.ProductBrandDto;
using Store.Entities;
using Store.Interfaces;

namespace Store.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly StoreDbContext _context;
        public ProductBrandService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<ProductBrand> GetProductBrand(int id)
        {
            return await _context.ProductBrand.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ProductBrand>> GetProductBrands()
        {
            return await _context.ProductBrand.ToListAsync();
        }

        

        public async Task ProductBrandRegistration(ProductBrand newProductBrand)
        {


            ProductBrand productBrand = new ProductBrand
            {
                Name = newProductBrand.Name
            };

            

            await _context.AddAsync(productBrand);
            await _context.SaveChangesAsync();
        }


    }
}
