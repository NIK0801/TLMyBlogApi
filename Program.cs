using MyBlogApi.Repositories;
using MyBlogApi.Services;
using MyBlogApi.Dto;
using MyBlogApi.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IRepository<Posts>>(s =>
    new PostsRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Posts, PostsDto>, PostsService>();


builder.Services.AddScoped<IRepository<Tags>>(s =>
    new TagsRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Tags, TagsDto>, TagsService>();

builder.Services.AddScoped<IRepository<Categories>>(s =>
    new CategoriesRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IService<Categories, CategoriesDto>, CategoriesService>();

var app = builder.Build();
app.MapControllers();
app.Run();
