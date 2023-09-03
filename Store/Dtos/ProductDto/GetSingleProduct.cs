using Store.Entities;

namespace Store.Dtos.ProductDto
{
    public class GetSingleProductDto
    {
        public GetSingleProductDto()
        {
            Product = new Product();
            Code = 0;
            Status = string.Empty;
        }

        public Product Product { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
