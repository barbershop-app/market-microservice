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
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            _mapper = mapper;
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAllAsQueryable().ToList();
            if (categories != null)
                return Ok(categories);
            else
                return BadRequest("Empty categories");
        }

        [HttpGet]
        [Route("GetCategoryById/{Id}")]
        public IActionResult GetCategoryById(Guid Id)
        {
            var category = _categoryService.GetById(Id);
            if (category != null)
                return Ok(category);
            else
                return BadRequest("Category not found");
        }

        [HttpPost]
        [Route("CreateCategory")]
        public IActionResult CreateCategory([FromBody] CategoryDTOs.Create dto)
        {
            try
            {
                bool res = true;
                var categories = _categoryService.GetAllAsQueryable();
                foreach (Category category in categories)
                {
                    if (category.Name == dto.Name)
                    {
                        res = false;
                        break;
                    }
                }
                if (res)
                {
                    var category = _mapper.Map<Category>(dto);

                    _categoryService.Create(category);
                    return Ok("Category has been added.");
                }

                return BadRequest("Failed to create a new category.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to create a new category.");
            }

        }

        [HttpPost]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] CategoryDTOs.Update dto)
        {
            try
            {
                bool res = false;
                var categories = _categoryService.GetAllAsQueryable();
                foreach (Category category in categories)
                {
                    if (category.Name == dto.Name)
                    {
                        res = true;
                        break;
                    }
                }
                if (res)
                {
                    var category = _mapper.Map<Category>(dto);
                    _categoryService.Edit(category, dto.Name);
                    return Ok("Category has been updated.");
                }



                return BadRequest("Failed to update the category.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to update the category.");
            }

        }
    }
}
