using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Repositories;

namespace MyBlogApi.Services
{
    public class CategoriesService : IService<Categories, CategoriesDto>
    {
        private readonly IRepository<Categories> _categoriesRepository;

        public CategoriesService(IRepository<Categories> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public List<Categories> GetAll()
        {
            return _categoriesRepository.GetAll();
        }

        public int Create(CategoriesDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception($"{nameof(categoryDto)} not found");
            }

            Categories categoriesEntity = categoryDto.ConvertToCategories();

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
            Categories category = _categoriesRepository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"{nameof(category)} not found, #Id - {Id}");
            }

            _categoriesRepository.Delete(category);
        }

        public Categories GetById(int Id)
        {
            Categories category = _categoriesRepository.GetById(Id);
            if (category == null)
            {
                throw new Exception($"{nameof(category)} not found, #Id - {Id}");
            }

            return category;
        }
    }
}
