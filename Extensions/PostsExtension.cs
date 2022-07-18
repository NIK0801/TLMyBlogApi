using MyBlogApi.Domain;
using MyBlogApi.Repositories;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class PostsExtension
    {
        public static Posts ConvertToPosts(this PostsDto postDto)
        {
            return new Posts
            {
                Id = postDto.Id,
                Title = postDto.Title,
                Content = postDto.Content,
                is_Published = postDto.is_Published
            };
        }
        public static PostsDto ConvertToPostsDto(this Posts post)
        {
            return new PostsDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                is_Published = post.is_Published
            };
        }
    }
}
