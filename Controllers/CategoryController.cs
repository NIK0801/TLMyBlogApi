using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Dto;
using MyBlogApi.Services;
using MyBlogApi.Domain;
using MyBlogApi.Extensions;
using MyBlogApi.Filter;
using Category = MyBlogApi.Domain.Category;

namespace MyBlogApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    [AllException]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category, CategoryDto> _categoriesService;
        public CategoryController(IService<Category, CategoryDto> service)
        {
            _categoriesService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categoriesService.GetAll()
                    .ConvertAll(category => category.ConvertToCategoriesDto()));
        }

        [HttpGet]
        [Route("{categoryId}")]
        public IActionResult GetCategory(int Id)
        {
            return Ok(_categoriesService.GetById(Id).ConvertToCategoriesDto());
        }

        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] CategoryDto categoriesDto)
        {
            return Ok(_categoriesService.Create(categoriesDto));
        }

        [HttpDelete]
        [Route("{Id}/delete")]
        public IActionResult Delete(int Id)
        {
            _categoriesService.Delete(Id);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] CategoryDto categoriesDto)
        {

            return Ok(_categoriesService.Update(categoriesDto));
        }
    }
}
