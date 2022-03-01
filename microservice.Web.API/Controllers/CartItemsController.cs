using AutoMapper;
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

        public CartItemsController(IMapper mapper, ILogger<CartItemsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
