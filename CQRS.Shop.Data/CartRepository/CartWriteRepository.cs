using CQRS.Shop.Core.Abstractions.Models;
using CQRS.Shop.Data.Abstractions.CartRepository;
using Microsoft.Extensions.Caching.Memory;

namespace CQRS.Shop.Data.CartRepository
{
    public class CartWriteRepository : ICartWriteRepository
    {
        private readonly IMemoryCache _memoryCache;

        public CartWriteRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Cart AddCartItem(Guid idCart, CartItem cartItem)
        {
            if(idCart ==  Guid.Empty)
            {
                return null;
            }

            var cart = _memoryCache.Get(idCart) as Cart;

            if (cart == null)
            {
                return null;
            }

            cart.Items.Add(cartItem);

            _memoryCache.Set(idCart, cart);

            return cart;
        }

        public Cart Create(Cart cart)
        {
            var cartInMemory = _memoryCache.Get(cart.Id) as Cart;

            if (cartInMemory != null)
            {
                return cart;
            }

            _memoryCache.Set(cart.Id, cart);
            return cart;
        }

    }
}