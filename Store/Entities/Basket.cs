using System.Text.Json.Serialization;

namespace Store.Entities
{
	public class Basket:BaseEntity
	{
		
		[JsonIgnore]
		public ICollection<Product> Products { get; set;}

	}
}
