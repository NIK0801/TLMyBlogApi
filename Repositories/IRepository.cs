using MyBlogApi.Domain;

namespace MyBlogApi.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        int Create(T domain);
        void Delete(T domain);
        int Update(T domain);
        bool Check(int Id);
    }
}
