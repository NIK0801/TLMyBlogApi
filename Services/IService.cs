using MyBlogApi.Domain;
using MyBlogApi.Dto;

namespace MyBlogApi.Services
{
    public interface IService<T,U>
    {
        List<T> GetAll();
        T GetById(int Id);
        int Create(U dto);
        int Update(U dto);
        void Delete(int Id);
    }
}
