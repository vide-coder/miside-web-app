using Domain.Enums;

namespace Domain.Entities.Order
{
    public class Order
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public DateTime CreatedAt { get; set; }
    }
}
