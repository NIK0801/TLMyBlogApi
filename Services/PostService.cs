using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Repositories;
using MyBlogApi.Extensions;

namespace MyBlogApi.Services
{
    public class PostService : IService<Post, PostsDto>
    {
        private readonly IRepository<Post> _postsRepository;

        public PostService(IRepository<Post> postsRepository)
        {
            _postsRepository = postsRepository;
        }

        public List<Post> GetAll()
        {
            return _postsRepository.GetAll();
        }

        public int Create(PostsDto postDto)
        {
            if (postDto == null)
            {
                throw new Exception($"{nameof(postDto)} not found");
            }

            Post postsEntity = postDto.ConvertToPosts();

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
            Post post = _postsRepository.GetById(Id);
            if (post == null)
            {
                throw new Exception($"{nameof(post)} not found, #Id - {Id}");
            }

            _postsRepository.Delete(post);
        }

        public Post GetById(int Id)
        {
            Post post = _postsRepository.GetById(Id);
            if (post == null)
            {
                throw new Exception($"{nameof(post)} not found, #Id - {Id}");
            }

            return post;
        }
    }
}
