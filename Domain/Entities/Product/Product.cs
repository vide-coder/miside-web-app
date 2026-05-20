using Domain.Enums;

namespace Domain.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string LogoImageUrl { get; set; } = string.Empty;
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}
