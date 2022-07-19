using MyBlogApi.Domain;
using MyBlogApi.Repositories;
using MyBlogApi.Dto;

namespace MyBlogApi.Extensions
{
    public static class CategoryExtension
    {
        public static Category ConvertToCategories(this CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                Title = categoryDto.Title
            };
        }
        public static CategoryDto ConvertToCategoriesDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Title = category.Title
            };
        }
    }
}
