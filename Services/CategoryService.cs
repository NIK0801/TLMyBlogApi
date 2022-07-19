using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Repositories;

namespace MyBlogApi.Services
{
    public class CategoryService : IService<Category, CategoriesDto>
    {
        private readonly IRepository<Category> _categoriesRepository;

        public CategoryService(IRepository<Category> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public List<Category> GetAll()
        {
            return _categoriesRepository.GetAll();
        }

        public int Create(CategoriesDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception($"{nameof(categoryDto)} not found");
            }

            Category categoriesEntity = categoryDto.ConvertToCategories();

            return _categoriesRepository.Create(categoriesEntity);
        }

        public int Update(CategoriesDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception($"{nameof(categoryDto)} not found");
            }
            if (_categoriesRepository.Check(categoryDto.Id))
            {
                return _categoriesRepository.Update(categoryDto.ConvertToCategories());
            }
            else
            {
                throw new Exception($"{nameof(categoryDto)} not found with this id {categoryDto.Id}");
            }
        }

        public void Delete(int Id)
        {
            Category category = _categoriesRepository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"{nameof(category)} not found, #Id - {Id}");
            }

            _categoriesRepository.Delete(category);
        }

        public Category GetById(int Id)
        {
            Category category = _categoriesRepository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"{nameof(category)} not found, #Id - {Id}");
            }

            return category;
        }
    }
}
