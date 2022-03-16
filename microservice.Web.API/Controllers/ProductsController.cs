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
    public class ProductsController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, ILogger<ProductsController> logger, IProductService productService)
        {
            _mapper = mapper;
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllCartItems()
        {
            var products = _productService.GetAllAsQueryable().ToList();
            if (products != null)
                return Ok(products);
            else
                return BadRequest("Empty products.");
        }

        [HttpGet]
        [Route("GetProductById/{Id}")]
        public IActionResult GetProductById(Guid Id)
        {
            var products = _productService.GetById(Id);
            if (products != null)
                return Ok(products);
            else
                return BadRequest("product not found.");
        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateCartItem([FromBody] ProductDTOs.Create dto)
        {
            try
            {
                bool res = true;
                var products = _productService.GetAllAsQueryable();
                foreach (Product product in products)
                {
                    if (product.Name == dto.Name)
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    var product = _mapper.Map<Product>(dto);

                    _productService.Create(product);
                    return Ok("Product has been added.");
                }

                return BadRequest("Failed to create new product.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to create new product.");
            }

        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] ProductDTOs.Update dto)
        {
            try
            {
                bool res = false;
                var products = _productService.GetAllAsQueryable();
                Product oldProduct = new Product();
                foreach (Product product in products)
                {
                    if (product.Name == dto.Name)
                    {
                        res = true;
                        oldProduct = _productService.GetById(product.Id);
                        break;
                    }
                }
                if (res)
                {
                    var product = _mapper.Map<Product>(dto);
                    _productService.Edit(oldProduct, product);
                    return Ok("Product has been updated.");
                }



                return BadRequest("Failed to update the Product.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to update the Product.");
            }

        }

    }
}
