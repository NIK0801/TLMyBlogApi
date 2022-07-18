using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Repositories;
using MyBlogApi.Extensions;

namespace MyBlogApi.Services
{
    public class PostsService : IService<Posts, PostsDto>
    {
        private readonly IRepository<Posts> _postsRepository;

        public PostsService(IRepository<Posts> postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public List<Posts> GetAll()
        {
            return _postsRepository.GetAll();
        }

        public int Create(PostsDto postDto)
        {
            if (postDto == null)
            {
                throw new Exception($"{nameof(postDto)} not found");
            }

            Posts postsEntity = postDto.ConvertToPosts();

            return _postsRepository.Create(postsEntity);
        }

        public int Update(PostsDto postDto)
        {
            if (postDto == null)
            {
                throw new Exception($"{nameof(postDto)} not found");
            }
            if (_postsRepository.Check(postDto.Id))
            {
                return _postsRepository.Update(postDto.ConvertToPosts());
            }
            else
            {
                throw new Exception($"{nameof(postDto)} not found with this id {postDto.Id}");
            }
        }

        public void Delete(int Id)
        {
            Posts post = _postsRepository.GetById(Id);
            if (post == null)
            {
                throw new Exception($"{nameof(post)} not found, #Id - {Id}");
            }

            _postsRepository.Delete(post);
        }

        public Posts GetById(int Id)
        {
            Posts post = _postsRepository.GetById(Id);
            if (post == null)
            {
                throw new Exception($"{nameof(post)} not found, #Id - {Id}");
            }

            return post;
        }
    }
}
