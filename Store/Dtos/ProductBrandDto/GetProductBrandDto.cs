using Store.Entities;

namespace Store.Dtos.ProductBrandDto
{
    public class GetProductBrandDto
    {
        public GetProductBrandDto()
        {
            ProductBrands = new List<ProductBrand>();
            Code = 0;
            Status = string.Empty;
        }

        public List<ProductBrand> ProductBrands { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
