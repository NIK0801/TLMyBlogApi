using MyBlogApi.Domain;
using MyBlogApi.Repositories;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class TagExtension
    {
        public static Tag ConvertToTags(this TagDto tagDto)
        {
            return new Tag
            {
                Id = tagDto.Id,
                Title = tagDto.Title
            };
        }
        public static TagDto ConvertToTagsDto(this Tag tag)
        {
            return new TagDto
            {
                Id = tag.Id,
                Title = tag.Title
            };
        }
    }
}
