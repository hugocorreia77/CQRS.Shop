using MediatR;

namespace CQRS.Shop.Core.Commands
{
    public class CreateCartCommand : IRequest
    {
        public Guid IdCart { get; set; }
        public int IdCustomer { get; set; }
    }
}
