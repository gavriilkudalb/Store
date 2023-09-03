using Store.Entities;

namespace Store.Dtos.ProductBrandDto
{
    public class GetSingleProductBrandDto
    {
        public GetSingleProductBrandDto()
        {
            ProductBrand = new ProductBrand();
            Code = 0;
            Status = string.Empty;
        }

        public ProductBrand ProductBrand { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
