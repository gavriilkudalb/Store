namespace Store.Entities
{
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }

        public int ProductBrandId { get; set; }
        
        public Basket Basket { get; set; }
    }
}
