using CQRS.Shop.Core.Abstractions.Models;
using CQRS.Shop.Core.Commands;
using CQRS.Shop.Data.Abstractions.CartRepository;
using MediatR;

namespace CQRS.Shop.Core.Handlers
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand>
    {
        private readonly ICartWriteRepository _repository;

        public CreateCartHandler(ICartWriteRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            _repository.Create(new Cart
            {
                Id = request.IdCart,
                IdCustomer = request.IdCustomer
            });

            return Task.CompletedTask;
        }
    }
}
