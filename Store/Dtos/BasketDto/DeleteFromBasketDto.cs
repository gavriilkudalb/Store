using Store.Entities;

namespace Store.Dtos.BasketDto
{
    public class DeleteFromBasketDto
    {
        public DeleteFromBasketDto()
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
