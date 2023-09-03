using Store.Entities;

namespace Store.Dtos.ProductTypeDto
{
    public class GetProductTypeDto
    {
        public GetProductTypeDto()
        {
            ProductTypes = new List<ProductType>();
            Code = 0;
            Status = string.Empty;
        }

        public List<ProductType> ProductTypes { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
