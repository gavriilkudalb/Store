using Store.Dtos.ProductTypeDto;
using Store.Entities;

namespace Store.Interfaces
{
    public interface IProductTypeService
    {
        Task<ICollection<ProductType>> GetProductTypes();
        Task<ProductType> GetProductType(int id);
        Task ProductTypeRegistration(ProductType newProductType);
    }
}
