namespace Domain.Entities.Cart
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
