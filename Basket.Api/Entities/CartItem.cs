namespace Basket.Api.Entities
{
    public class CartItem
    {
        public string ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public CartItem() { }

        public CartItem(string productId, string productName, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public void SetProductId(string productId) => ProductId = productId;
        public void SetProductName(string productName) => ProductName = productName;
        public void SetQuantity(int quantity) => Quantity = quantity;
        public void SetPrice(decimal price) => Price = price;


    }
}
