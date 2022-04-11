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
    public class CategoriesController : ControllerBase
    {
        readonly IMapper _mapper;
        readonly ILogger<CategoriesController> _logger;
        readonly ICategoryService _categoryService;
        readonly IProductService _productService;

        public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger, ICategoryService categoryService, IProductService productService)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAllAsQueryable(false);

                var response = new List<object>();

                foreach(var category in categories)
                {
                    var numberOfProductsInCategory = _productService.GetAllAsQueryable(false).Where(x => x.CategoryId == category.Id).Count();
                    response.Add(new
                    {
                        id = category.Id,
                        name = category.Name,
                        numberOfProductsInCategory = numberOfProductsInCategory
                    });
                }

                return Ok(new {categories = response});
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message.ToString());
                return BadRequest(new { message = "Something went wrong." });

            }
        }

        [HttpGet]
        [Route("GetCategoryById/{Id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _categoryService.GetById(id);

            if (category != null)
                return Ok(category);

            return BadRequest(new { message = "Category not found" });
        }

        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody] CategoryDTOs.Create dto)
        {
            try
            {
                var category = _categoryService.GetAllAsQueryable(false).Where(x => x.Name == dto.Name).FirstOrDefault();

                if (category != null)
                    return BadRequest("Category with a similiar name already exists.");

                category = _mapper.Map<Category>(dto);

                var res = _categoryService.Create(category);

                if (res)
                    return Ok(new { message = "Category has been added." });

                return BadRequest(new { message = "Failed to create a new category." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });

            }

        }

        [HttpPost]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] CategoryDTOs.Update dto)
        {
            try
            {
                var oldCategory = _categoryService.GetById(dto.Id);

                if (oldCategory == null)
                    return BadRequest("Category does not exist.");

                var category = _mapper.Map<Category>(dto);

                var res = _categoryService.Update(oldCategory, category);

                if (res)
                    return Ok(new { message = "Category has been updated." });


                return BadRequest(new { message = "Failed to update the category." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });

            }
        }

        [HttpPost]
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);

                if (category == null)
                    return BadRequest("Category does not exist.");

                var res = _categoryService.Delete(category);

                if (res)
                    return Ok(new { message = "Category has been deleted." });


                return BadRequest(new { message = "Failed to deleted the category." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new { message = "Something went wrong." });

            }
        }
    }
}
