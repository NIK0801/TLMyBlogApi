using MyBlogApi.Domain;
using MyBlogApi.Dto;
using MyBlogApi.Extensions;
using MyBlogApi.Repositories;

namespace MyBlogApi.Services
{
    public class TagService : IService<Tag, TagDto>
    {
        private readonly IRepository<Tag> _tagsRepository;

        public TagService(IRepository<Tag> tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public List<Tag> GetAll()
        {
            return _tagsRepository.GetAll();
        }

        public int Create(TagDto tagDto)
        {
            if (tagDto == null)
            {
                throw new Exception($"{nameof(tagDto)} not found");
            }

            Tag tagsEntity = tagDto.ConvertToTags();

            return _tagsRepository.Create(tagsEntity);
        }

        public int Update(TagDto tagDto)
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
            Tag tag = _tagsRepository.GetById(Id);
            if (tag == null)
            {
                throw new Exception($"{nameof(tag)} not found, #Id - {Id}");
            }

            _tagsRepository.Delete(tag);
        }

        public Tag GetById(int Id)
        {
            Tag tag = _tagsRepository.GetById(Id);
            if (tag == null)
            {
                throw new Exception($"{nameof(tag)} not found, #Id - {Id}");
            }

            return tag;
        }
    }
}
