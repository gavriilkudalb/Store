using Store.Entities;

namespace Store.Dtos.ProductDto
{
    public class GetProductDto
    {
        public GetProductDto()
        {
            Products = new List<Product>();
            Code = 0;
            Status = string.Empty;
        }

        public List<Product> Products { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
