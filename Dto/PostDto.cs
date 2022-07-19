namespace MyBlogApi.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int IsPublished { get; set; }
        public int CategoryId { get; set; }
    }
}
