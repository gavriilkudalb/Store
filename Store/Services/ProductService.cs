using Microsoft.EntityFrameworkCore;
using Store.Context;
using Store.Dtos.ProductDto;
using Store.Entities;
using Store.Interfaces;

namespace Store.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreDbContext _context;

        public ProductService(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task ProductRegistration(Product newProduct)
        {

            Product product = new Product
            {
                Id = newProduct.Id,
                Name = newProduct.Name,
                ProductBrandId = newProduct.ProductBrandId,
                ProductTypeId = newProduct.ProductTypeId,
                
            };
            if (newProduct.ProductBrandId != null && newProduct.ProductTypeId != null)
            {
                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
