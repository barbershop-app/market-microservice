using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace microservice.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
