using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Repositories;

namespace MyBlogApi.Services
{
    public class TagsService : IService<Tags, TagsDto>
    {
        private readonly IRepository<Tags> _tagsRepository;

        public TagsService(IRepository<Tags> tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public List<Tags> GetAll()
        {
            return _tagsRepository.GetAll();
        }

        public int Create(TagsDto tagDto)
        {
            if (tagDto == null)
            {
                throw new Exception($"{nameof(tagDto)} not found");
            }

            Tags tagsEntity = tagDto.ConvertToTags();

            return _tagsRepository.Create(tagsEntity);
        }

        public int Update(TagsDto tagDto)
        {
            if (tagDto == null)
            {
                throw new Exception($"{nameof(tagDto)} not found");
            }
            if (_tagsRepository.Check(tagDto.Id))
            {
                return _tagsRepository.Update(tagDto.ConvertToTags());
            }
            else
            {
                throw new Exception($"{nameof(tagDto)} not found with this id {tagDto.Id}");
            }
        }

        public void Delete(int Id)
        {
            Tags tag = _tagsRepository.GetById(Id);
            if (tag == null)
            {
                throw new Exception($"{nameof(tag)} not found, #Id - {Id}");
            }

            _tagsRepository.Delete(tag);
        }

        public Tags GetById(int Id)
        {
            Tags tag = _tagsRepository.GetById(Id);
            if (tag == null)
            {
                throw new Exception($"{nameof(tag)} not found, #Id - {Id}");
            }

            return tag;
        }
    }
}
