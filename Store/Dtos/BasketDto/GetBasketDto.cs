using Store.Entities;

namespace Store.Dtos.BasketDto
{
    public class GetBasketDto
    {
        public GetBasketDto()
        {
            Products = new List<Basket>();
            Code = 0;
            Status = string.Empty;
        }

        public List<Basket> Products { get; set; }
        public int Code { get; set; }

        public string Status { get; set; }
    }
}
