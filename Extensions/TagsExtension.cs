using MyBlogApi.Domain;
using MyBlogApi.Repositories;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class TagsExtension
    {
        public static Tags ConvertToTags(this TagsDto tagDto)
        {
            return new Tags
            {
                Id = tagDto.Id,
                Title = tagDto.Title
            };
        }
        public static TagsDto ConvertToTagsDto(this Tags tag)
        {
            return new TagsDto
            {
                Id = tag.Id,
                Title = tag.Title
            };
        }
    }
}
