namespace Basket.Api.Entities
{
    public class Cart
    {
        public string UserName { get; private set; }
        public IEnumerable<CartItem> Items { get; private set; }

        public Cart() { }

        public Cart(string userName, IEnumerable<CartItem> items)
        {
            UserName = userName;
            Items = items;
        }

        public void SetUserName(string username) => UserName = username;
        public void SetItems(IEnumerable<CartItem> items) => Items = items;

        public decimal TotalPrice => Items.Sum(item => item.Price * item.Quantity);
    }
}
