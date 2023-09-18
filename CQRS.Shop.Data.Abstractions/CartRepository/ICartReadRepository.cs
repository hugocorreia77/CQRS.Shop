using CQRS.Shop.Core.Abstractions.Models;

namespace CQRS.Shop.Data.Abstractions.CartRepository
{
    public interface ICartReadRepository 
    {
        Cart GetCart(Guid id);
    }
}