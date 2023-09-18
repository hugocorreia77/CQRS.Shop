using CQRS.Shop.Core.Abstractions.Models;

namespace CQRS.Shop.Data.Abstractions.CartRepository
{
    public interface ICartWriteRepository 
    {
        Cart Create(Cart cart);
        Cart AddCartItem(Guid idCart, CartItem cartItem);
    }
}