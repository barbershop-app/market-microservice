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
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllAsQueryable(false);

            return Ok(products);
        }

        [HttpGet]
        [Route("GetAllProductByCategoryId/{Id}")]
        public IActionResult GetAllProductByCategoryId(int id)
        {
            var products = _productService.GetAllAsQueryable(false).Where(x => x.CategoryId == id);

            var response = new List<object>();

            foreach (var product in products)
            {
                response.Add(new
                {
                    id = product.Id,
                    name = product.Name,
                    price = product.Price,
                    isAvailable = product.IsAvailable,
                    imageSource = product.ImageSource
                });
            }

            return Ok(new
            {
                categoryId = id,
                products = response
            });

        }

        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateProduct([FromBody] ProductDTOs.Create dto)
        {
            try
            {
                var product = _productService.GetAllAsQueryable(false).Where(x => x.Name == dto.Name).FirstOrDefault();

                if (product != null)
                    return BadRequest("Product with similiar name already exists.");

                 product = _mapper.Map<Product>(dto);

                var res = _productService.Create(product);

                if (res)
                    return Ok("Product has been created.");


                return BadRequest(new { message = "Failed to create new product." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }

        }

        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] ProductDTOs.Update dto)
        {
            try
            {
                var oldProduct = _productService.GetById(dto.Id);

                if (oldProduct == null)
                    return BadRequest("Product does not exist.");

                var product = _mapper.Map<Product>(dto);

                var res = _productService.Update(oldProduct, product);

                if (res)
                    return Ok(new { message = "Product has been updated."});


                return BadRequest(new { message = "Failed to update the Product." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            try
            {
                var product = _productService.GetById(id);

                if (product == null)
                    return BadRequest("Product does not exist.");

                var res = _productService.Delete(product);

                if (res)
                    return Ok(new { message = "Product has been deleted." });


                return BadRequest(new { message = "Failed to delete the Product." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });
            }
        }
    }
}
