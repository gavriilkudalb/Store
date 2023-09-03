using Store.Entities;

namespace Store.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task ProductRegistration(Product newProduct);
    }
}
