using MyBlogApi.Domain;
using MyBlogApi.Repositories;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class CategoriesExtension
    {
        public static Categories ConvertToCategories(this CategoriesDto categoryDto)
        {
            return new Categories
            {
                Id = categoryDto.Id,
                Title = categoryDto.Title
            };
        }
        public static CategoriesDto ConvertToCategoriesDto(this Categories category)
        {
            return new CategoriesDto
            {
                Id = category.Id,
                Title = category.Title
            };
        }
    }
}
