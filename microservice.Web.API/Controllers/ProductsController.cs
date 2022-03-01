using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace microservice.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ILogger<ProductsController> _logger;

        public ProductsController(IMapper mapper, ILogger<ProductsController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
