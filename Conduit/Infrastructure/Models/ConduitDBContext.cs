using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Conduit.Models
{
    public partial class ConduitDBContext : DbContext
    {
        public ConduitDBContext()
        {
        }

        public ConduitDBContext(DbContextOptions<ConduitDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> ArticleTbls { get; set; } = null!;
        public virtual DbSet<Comment> CommentTbls { get; set; } = null!;
        public virtual DbSet<FavoriteArticles> FavoriteArticlesTbls { get; set; } = null!;
        public virtual DbSet<UserArticles> UserArticlesTbls { get; set; } = null!;
        public virtual DbSet<UserFollowers> UserFollowersTbls { get; set; } = null!;
        public virtual DbSet<User> UserTbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ConduitDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, Username = "Admin", Password = "Admin", FullName = "Admin" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 2, Username = "Admin1", Password = "Admin1", FullName = "Admin1" });
            modelBuilder.Entity<User>().HasData(new User { UserId = 3, Username = "Admin2", Password = "Admin2", FullName = "Admin2" });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleId = 1 });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleId = 2 });
            modelBuilder.Entity<Article>().HasData(new Article { ArticleId = 3 });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 1, UserId = 1, ArticleId = 1, BodyText = "Ok" });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 2, UserId = 1, ArticleId = 1, BodyText = "Ok" });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 3, UserId = 2, ArticleId = 2, BodyText = "Ok" });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 4, UserId = 2, ArticleId = 2, BodyText = "Ok" });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 5, UserId = 3, ArticleId = 3, BodyText = "yes" });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentId = 6, UserId = 3, ArticleId = 3, BodyText = "yes" });
            modelBuilder.Entity<UserArticles>().HasData(new UserArticles { UserArticlesId = 1, UserId = 1, ArticleId = 1 });
            modelBuilder.Entity<UserArticles>().HasData(new UserArticles { UserArticlesId = 2, UserId = 2, ArticleId = 2 });
            modelBuilder.Entity<UserArticles>().HasData(new UserArticles { UserArticlesId = 3, UserId = 3, ArticleId = 3 });
            modelBuilder.Entity<UserFollowers>().HasData(new UserFollowers { UserFollowersId = 1, UserId = 1, FollowerId = 2 });
            modelBuilder.Entity<UserFollowers>().HasData(new UserFollowers { UserFollowersId = 2, UserId = 1, FollowerId = 3 });
            modelBuilder.Entity<UserFollowers>().HasData(new UserFollowers { UserFollowersId = 3, UserId = 2, FollowerId = 3 });
            modelBuilder.Entity<UserFollowers>().HasData(new UserFollowers { UserFollowersId = 4, UserId = 2, FollowerId = 1 });
            modelBuilder.Entity<UserFollowers>().HasData(new UserFollowers { UserFollowersId = 5, UserId = 3, FollowerId = 1 });
            modelBuilder.Entity<FavoriteArticles>().HasData(new FavoriteArticles { FavoriteArticlesId = 1, UserId = 1, ArticleId = 1 });
            modelBuilder.Entity<FavoriteArticles>().HasData(new FavoriteArticles { FavoriteArticlesId = 2, UserId = 1, ArticleId = 2 });
            modelBuilder.Entity<FavoriteArticles>().HasData(new FavoriteArticles { FavoriteArticlesId = 3, UserId = 1, ArticleId = 3 });
            modelBuilder.Entity<FavoriteArticles>().HasData(new FavoriteArticles { FavoriteArticlesId = 4, UserId = 2, ArticleId = 1 });
            modelBuilder.Entity<FavoriteArticles>().HasData(new FavoriteArticles { FavoriteArticlesId = 5, UserId = 2, ArticleId = 2 });
        }
        
    }
}
