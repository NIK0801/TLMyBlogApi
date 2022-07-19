using MyBlogApi.Repositories;
using MyBlogApi.Services;
using MyBlogApi.Dto;
using MyBlogApi.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Post>>(s =>
    new PostRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Post, PostDto>, PostService>();


builder.Services.AddScoped<IRepository<Tag>>(s =>
    new TagRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Tag, TagDto>, TagService>();

builder.Services.AddScoped<IRepository<Category>>(s =>
    new CategoryRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Category, CategoryDto>, CategoryService>();

var app = builder.Build();
app.MapControllers();
app.Run();
