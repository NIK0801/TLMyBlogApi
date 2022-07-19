using MyBlogApi.Domain;
using MyBlogApi.Repositories;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class PostExtension
    {
        public static Post ConvertToPosts(this PostDto postDto)
        {
            return new Post
            {
                Id = postDto.Id,
                Title = postDto.Title,
                Content = postDto.Content,
                IsPublihed = postDto.IsPublished
            };
        }
        public static PostDto ConvertToPostsDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                IsPublished = post.IsPublihed
            };
        }
    }
}
