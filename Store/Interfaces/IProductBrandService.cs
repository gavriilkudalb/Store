using Store.Dtos.ProductBrandDto;
using Store.Entities;

namespace Store.Interfaces
{
    public interface IProductBrandService
    {
        Task<ICollection<ProductBrand>> GetProductBrands();
        Task<ProductBrand> GetProductBrand(int id);
        Task ProductBrandRegistration(ProductBrand newProductBrand);
    }
}
