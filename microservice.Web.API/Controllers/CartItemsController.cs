using AutoMapper;
using microservice.Core.IServices;
using microservice.Infrastructure.Entities.DB;
using microservice.Infrastructure.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace microservice.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ILogger<CartItemsController> _logger;
        private readonly ICartItemService _cartItemService;


        public CartItemsController(IMapper mapper, ILogger<CartItemsController> logger, ICartItemService cartItemService)
        {
            _mapper = mapper;
            _logger = logger;
            _cartItemService = cartItemService;
        }


        [HttpGet]
        [Route("GetAllCartItems")]
        public IActionResult GetAllCartItems()
        {
            var cartItems = _cartItemService.GetAllAsQueryable().ToList();
            if (cartItems != null)
                return Ok(cartItems);
            else
                return BadRequest("Empty carts");
        }

        [HttpGet]
        [Route("GetCartItemById/{Id}")]
        public IActionResult GetCartItemById(Guid Id)
        {
            var cartItem = _cartItemService.GetById(Id);
            if (cartItem != null)
                return Ok(cartItem);
            else
                return BadRequest("cart not found");
        }

        [HttpPost]
        [Route("CreateCartItem")]
        public IActionResult CreateCartItem([FromBody] CartItemDTOs.Create dto)
        {
            try
            {
                bool res = true;
                var cartItems = _cartItemService.GetAllAsQueryable();
                foreach (CartItem cartItem in cartItems)
                {
                    if (cartItem.Product.Id == dto.ProductId)
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                    return Ok("CartItem has been added.");

                return BadRequest("Failed to create a new cartItem.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to create a new cartItem.");
            }

        }

    }
}
