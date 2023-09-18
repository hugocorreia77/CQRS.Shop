using CQRS.Shop.Core.Abstractions.Models;
using MediatR;

namespace CQRS.Shop.Core.Commands
{
    public class AddCartItemCommand : IRequest
    {
        public Guid IdCart { get; set; }
        public CartItem CartItem { get; set; }

    }
}
