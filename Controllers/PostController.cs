using Microsoft.AspNetCore.Mvc;
using MyBlogApi.Dto;
using MyBlogApi.Services;
using MyBlogApi.Domain;
using MyBlogApi.Extensions;
using MyBlogApi.Filter;
using Post = MyBlogApi.Domain.Post;

namespace MyBlogApi.Controllers
{
    [ApiController]
    [Route("rest/{controller}")]
    [AllException]
    public class PostController : ControllerBase
    {s
        private readonly IService<Post, PostDto> _postsService;
        public PostController(IService<Post, PostDto> service)
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

        public IActionResult Create([FromBody] PostDto postsDto)
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
        public IActionResult Update([FromBody] PostDto postsDto)
        {

            return Ok(_postsService.Update(postsDto));
        }
    }
}
