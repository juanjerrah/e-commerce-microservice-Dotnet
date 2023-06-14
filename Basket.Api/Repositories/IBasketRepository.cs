using Basket.Api.Entities;

namespace Basket.Api.Repositories
{
    public interface IBasketRepository
    {
        Task<Cart?> GetCart(string userName);
        Task<Cart?> UpdateCart(Cart cart);
        Task DeleteCart(string userName);
    }
}
