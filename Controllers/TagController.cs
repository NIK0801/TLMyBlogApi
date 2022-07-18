using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Dto;
using MyBlogApi.Services;
using MyBlogApi.Domain;
using MyBlogApi.Extensions;
using MyBlogApi.Filter;
using Tags = MyBlogApi.Domain.Tags;

namespace MyBlogApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    [AllException]
    public class TagController : ControllerBase
    {
        private readonly IService<Tags, TagsDto> _tagsService;
        public TagController(IService<Tags, TagsDto> service)
        {
            _tagsService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tagsService.GetAll()
                    .ConvertAll(tag => tag.ConvertToTagsDto()));          
        }

        [HttpGet]
        [Route("{tagId}")]
        public IActionResult GetTag(int Id)
        {
            return Ok(_tagsService.GetById(Id).ConvertToTagsDto());
        }

        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] TagsDto tagsDto)
        {
            return Ok(_tagsService.Create(tagsDto));
        }

        [HttpDelete]
        [Route("{Id}/delete")]
        public IActionResult Delete(int Id)
        {
            _tagsService.Delete(Id);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] TagsDto tagsDto)
        {

            return Ok(_tagsService.Update(tagsDto));
        }
    }
}
