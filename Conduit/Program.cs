using Conduit.Core.Services;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ConduitDBContext>(dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:ConduitDB"]).EnableSensitiveDataLogging());
builder.Services.AddScoped<ConduitDBContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UserForInsertValidator>();
builder.Services.AddScoped<UserForUpdateValidator>();
builder.Services.AddScoped<ArticleForUpdateValidator>();
builder.Services.AddScoped<CommentForInsertValidator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IFavoriteArticlesRepository, FavoriteArticlesRepository>();
builder.Services.AddScoped<IFollowRepository, FollowRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IFavoriteArticleService, FavoriteArticleService>();
builder.Services.AddScoped<IUserFollowersService,UserFollowersServices>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
