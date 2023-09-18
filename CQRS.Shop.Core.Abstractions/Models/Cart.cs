namespace CQRS.Shop.Core.Abstractions.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public int IdCustomer { get; set; }
        public List<CartItem> Items { get; set; }

        public Cart() { Items = new List<CartItem>(); }
    }
}
