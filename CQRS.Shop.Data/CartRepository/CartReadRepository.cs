using CQRS.Shop.Core.Abstractions.Models;
using CQRS.Shop.Data.Abstractions.CartRepository;
using Microsoft.Extensions.Caching.Memory;

namespace CQRS.Shop.Data.CartRepository
{
    public class CartReadRepository : ICartReadRepository
    {
        private readonly IMemoryCache _memoryCache;

        public CartReadRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public Cart GetCart(Guid id) => _memoryCache.Get(id) as Cart;
    }
}