namespace Store.Dtos.BasketDto
{
    public class AddToBasketDto
    {
        public AddToBasketDto() 
            {
                IsAdded = false;
                Code = 0;
                Status = string.Empty;
            }
        public int Code { get; set; }
        public string Status { get; set; }
        public bool IsAdded { get; set; }
    

    }
}
