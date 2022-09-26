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

        public virtual DbSet<ArticleTbl> ArticleTbls { get; set; } = null!;
        public virtual DbSet<CommentTbl> CommentTbls { get; set; } = null!;
        public virtual DbSet<FavoriteArticlesTbl> FavoriteArticlesTbls { get; set; } = null!;
        public virtual DbSet<UserArticlesTbl> UserArticlesTbls { get; set; } = null!;
        public virtual DbSet<UserFollowersTbl> UserFollowersTbls { get; set; } = null!;
        public virtual DbSet<UserTbl> UserTbls { get; set; } = null!;

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
            modelBuilder.Entity<ArticleTbl>(entity =>
            {
                entity.HasKey(e => e.ArticleId)
                    .HasName("PK__ArticleT__9C6270E8285CD803");

                entity.ToTable("ArticleTbl");

                entity.Property(e => e.ArticleBody).HasColumnType("text");

                entity.Property(e => e.ArticleTitle)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Untitled')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArticleTbls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ArticleTb__UserI__48CFD27E");
            });

            modelBuilder.Entity<CommentTbl>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__CommentT__C3B4DFCA03CD38CA");

                entity.ToTable("CommentTbl");

                entity.Property(e => e.BodyText).HasColumnType("text");

                entity.Property(e => e.IsAchild)
                    .HasColumnName("IsAChild")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.CommentTbls)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CommentTb__Artic__4CA06362");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentTbls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CommentTb__UserI__4D94879B");
            });

            modelBuilder.Entity<FavoriteArticlesTbl>(entity =>
            {
                entity.HasKey(e => e.FavoriteArticlesId)
                    .HasName("PK__Favorite__0D08A5F162681EF2");

                entity.ToTable("FavoriteArticlesTbl");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.FavoriteArticlesTbls)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FavoriteA__Artic__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavoriteArticlesTbls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FavoriteA__UserI__5165187F");
            });

            modelBuilder.Entity<UserArticlesTbl>(entity =>
            {
                entity.HasKey(e => e.UserArticlesId)
                    .HasName("PK__UserArti__C2AC7C4C29831B5E");

                entity.ToTable("UserArticlesTbl");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.UserArticlesTbls)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserArtic__Artic__5441852A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserArticlesTbls)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserArtic__UserI__5535A963");
            });

            modelBuilder.Entity<UserFollowersTbl>(entity =>
            {
                entity.HasKey(e => e.UserFollowersId)
                    .HasName("PK__UserFoll__546F7852843AFDB5");

                entity.ToTable("UserFollowersTbl");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.UserFollowersTblFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserFollo__Follo__5812160E");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFollowersTblUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserFollo__UserI__59063A47");
            });

            modelBuilder.Entity<UserTbl>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserTbl__1788CC4C27AC690C");

                entity.ToTable("UserTbl");

                entity.Property(e => e.FullName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
