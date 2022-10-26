using Conduit.Core.Services;
using Conduit.Core.Validators;
using Conduit.Infrastructure.Repositories;
using Conduit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Conduit
{
    public class Startup
    {
        public static WebApplication InitializeApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
            
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddDbContext<ConduitDBContext>(dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:ConduitDB"]).EnableSensitiveDataLogging());
            //builder.Services.AddScoped<ConduitDBContext>();
            builder.Services.AddDbContextFactory<ConduitDBContext>(options => options.EnableSensitiveDataLogging(), ServiceLifetime.Scoped);
            //builder.Services.AddSingleton<IDbContextFactory<ConduitDBContext>,DbContextFactory<ConduitDBContext>>();
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
            builder.Services.AddScoped<IUserFollowersService, UserFollowersServices>();
            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Authentication:Issuer"],
                    ValidAudience = builder.Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                };
            });
            builder.Services.AddControllersWithViews();
        }
        private static void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
