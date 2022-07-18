namespace MyBlogApi.Dto
{
    public class PostsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int is_Published { get; set; }
        public int Category_id { get; set; }
    }
}
