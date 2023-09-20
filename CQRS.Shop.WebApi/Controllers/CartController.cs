using CQRS.Shop.Core.Abstractions.Models;
using CQRS.Shop.Core.Commands;
using CQRS.Shop.Data.Abstractions.CartRepository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CQRS.Shop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private ICartReadRepository _cartRepository;
        private readonly IMediator _mediator;

        public CartController(ILogger<CartController> logger, ICartReadRepository cartRepository, IMediator mediator)
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _mediator = mediator;
        }

        [HttpGet("{idCart}")]
        public ActionResult Get(Guid idCart)
        {
            var cart = _cartRepository.GetCart(idCart);

            if(cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPut("{idCart}")]
        public ActionResult Create([FromQuery] Guid idCart, [FromBody] int idCustomer)
        {
            var cartRequest = new CreateCartCommand
            {
                IdCart = idCart,
                IdCustomer = idCustomer
            };

            try
            {
                _mediator.Send(cartRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("It was not possible to create the cart to the customer id: {idCart}; CartId: {idCart}; Exception: {exception}"
                                , idCart, idCart, ex.Message);
            }

            return BadRequest();
        }

        [HttpPost("{idCart}/item")]
        public async Task<ActionResult> Create(Guid idCart, CartItem cartItem)
        {
            var addCartItemRequest = new AddCartItemCommand()
            {
                IdCart = idCart,
                CartItem = cartItem
            };
            
            try
            {
                await _mediator.Send(addCartItemRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("It was not possible to add the item to the cart. Id: {idCart}; CartItem: {cartItem}; Exception: {exception}"
                                , idCart, JsonSerializer.Serialize(cartItem), ex.Message);
            }
            return BadRequest();
        }
    }
}