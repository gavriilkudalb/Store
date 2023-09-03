using Store.Entities;

namespace Store.Dtos.ProductTypeDto
{
    public class GetSingleProductTypeDto
    {
        public GetSingleProductTypeDto()
        {
            ProductType = new ProductType();
            Code = 0;
            Status = string.Empty;
        }

        public ProductType ProductType { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
