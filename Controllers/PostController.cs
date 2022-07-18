using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Dto;
using MyBlogApi.Services;
using MyBlogApi.Domain;
using MyBlogApi.Extensions;
using MyBlogApi.Filter;
using Posts = MyBlogApi.Domain.Posts;

namespace MyBlogApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    [AllException]
    public class PostController : ControllerBase
    {
        private readonly IService<Posts, PostsDto> _postsService;
        public PostController(IService<Posts, PostsDto> service)
        {
            _postsService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_postsService.GetAll()
                    .ConvertAll(post => post.ConvertToPostsDto()));
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetPost(int Id)
        {
            return Ok(_postsService.GetById(Id).ConvertToPostsDto());
        }

        [HttpPost]
        [Route("create")]

        public IActionResult Create([FromBody] PostsDto postsDto)
        {
            return Ok(_postsService.Create(postsDto));
        }

        [HttpDelete]
        [Route("{Id}/delete")]
        public IActionResult Delete(int Id)
        {
            _postsService.Delete(Id);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update([FromBody] PostsDto postsDto)
        {

            return Ok(_postsService.Update(postsDto));
        }
    }
}
