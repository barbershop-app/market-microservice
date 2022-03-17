using AutoMapper;
using microservice.Core.IServices;
using microservice.Infrastructure.Entities.DB;
using microservice.Infrastructure.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

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
            try
            {
                var cartItems = _cartItemService.GetAllAsQueryable(false);

                if (cartItems != null)
                    return Ok(cartItems);

                return BadRequest(new { message = "Empty carts."});

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpGet]
        [Route("GetCartItemById/{Id}")]
        public IActionResult GetCartItemById(Guid Id)
        {
            try
            {
                var cartItem = _cartItemService.GetById(Id);
                return Ok(cartItem);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpPost]
        [Route("CreateCartItem")]
        public IActionResult CreateCartItem([FromBody] CartItemDTOs.Create dto)
        {
            try
            {
                var cartItem = _cartItemService.GetAllAsQueryable(false).Where(x => x.ProductId == dto.ProductId).FirstOrDefault();

                if (cartItem != null)
                    return BadRequest("A Cart item with a similiar product already exists.");

                cartItem = _mapper.Map<CartItem>(dto);

                var res = _cartItemService.Create(cartItem);

                if (res)
                    return Ok(new { message = "CartItem has been added." });


                return BadRequest(new { message = "Failed to create a new cartItem." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });

            }

        }

        [HttpPost]
        [Route("UpdateCartItem")]
        public IActionResult UpdateCartItem([FromBody] CartItemDTOs.Update dto)
        {
            try
            {
                var oldCartItem = _cartItemService.GetById(dto.Id);

                if (oldCartItem == null)
                    return BadRequest("Cart item does not exist.");

                var cartItem = _mapper.Map<CartItem>(dto);

                var res = _cartItemService.Update(oldCartItem, cartItem);

                if (res)
                    return Ok(new { message = "CartItem has been updated." });
               
                return BadRequest(new { message = "Failed to update the cartItem." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }

        }

    }
}
