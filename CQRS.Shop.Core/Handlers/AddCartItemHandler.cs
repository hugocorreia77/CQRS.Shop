using CQRS.Shop.Core.Commands;
using CQRS.Shop.Data.Abstractions.CartRepository;
using MediatR;

namespace CQRS.Shop.Core.Handlers
{
    public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
    {
        private readonly ICartWriteRepository _repository;

        public AddCartItemHandler(ICartWriteRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            if(request.IdCart == Guid.Empty)
            {
                throw new Exception("Cart Id is not valid.");
            }

            if(request.CartItem == null)
            {
                throw new Exception("Cart item is null.");
            }

            _repository.AddCartItem(request.IdCart, request.CartItem);
            return Task.CompletedTask;
        }
    }
}
