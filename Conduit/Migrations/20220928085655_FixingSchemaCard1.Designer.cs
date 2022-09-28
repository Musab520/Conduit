﻿// <auto-generated />
using System;
using Conduit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Conduit.Migrations
{
    [DbContext(typeof(ConduitDBContext))]
    [Migration("20220928085655_FixingSchemaCard1")]
    partial class FixingSchemaCard1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Conduit.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"), 1L, 1);

                    b.Property<string>("ArticleBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("ArticleTbls");

                    b.HasData(
                        new
                        {
                            ArticleId = 1,
                            ArticleBody = "",
                            ArticleTitle = "Untitled",
                            UserId = 1
                        },
                        new
                        {
                            ArticleId = 2,
                            ArticleBody = "",
                            ArticleTitle = "Untitled",
                            UserId = 2
                        },
                        new
                        {
                            ArticleId = 3,
                            ArticleBody = "",
                            ArticleTitle = "Untitled",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Conduit.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("BodyText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAchild")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("CommentId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentTbls");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            ArticleId = 1,
                            BodyText = "Ok",
                            UserId = 1,
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CommentId = 2,
                            ArticleId = 1,
                            BodyText = "Ok",
                            UserId = 1,
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CommentId = 3,
                            ArticleId = 2,
                            BodyText = "Ok",
                            UserId = 2,
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CommentId = 4,
                            ArticleId = 2,
                            BodyText = "Ok",
                            UserId = 2,
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CommentId = 5,
                            ArticleId = 3,
                            BodyText = "yes",
                            UserId = 3,
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CommentId = 6,
                            ArticleId = 3,
                            BodyText = "yes",
                            UserId = 3,
                            date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Conduit.Models.FavoriteArticles", b =>
                {
                    b.Property<int>("FavoriteArticlesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FavoriteArticlesId"), 1L, 1);

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteArticlesId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteArticlesTbls");

                    b.HasData(
                        new
                        {
                            FavoriteArticlesId = 1,
                            ArticleId = 1,
                            UserId = 1
                        },
                        new
                        {
                            FavoriteArticlesId = 2,
                            ArticleId = 2,
                            UserId = 1
                        },
                        new
                        {
                            FavoriteArticlesId = 3,
                            ArticleId = 3,
                            UserId = 1
                        },
                        new
                        {
                            FavoriteArticlesId = 4,
                            ArticleId = 1,
                            UserId = 2
                        },
                        new
                        {
                            FavoriteArticlesId = 5,
                            ArticleId = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Conduit.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("UserTbls");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FullName = "Admin",
                            Password = "Admin",
                            Username = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            FullName = "Admin1",
                            Password = "Admin1",
                            Username = "Admin1"
                        },
                        new
                        {
                            UserId = 3,
                            FullName = "Admin2",
                            Password = "Admin2",
                            Username = "Admin2"
                        });
                });

            modelBuilder.Entity("Conduit.Models.UserFollowers", b =>
                {
                    b.Property<int>("UserFollowersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFollowersId"), 1L, 1);

                    b.Property<int>("FollowerId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserFollowersId");

                    b.HasIndex("FollowerId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFollowersTbls");

                    b.HasData(
                        new
                        {
                            UserFollowersId = 1,
                            FollowerId = 2,
                            UserId = 1
                        },
                        new
                        {
                            UserFollowersId = 2,
                            FollowerId = 3,
                            UserId = 1
                        },
                        new
                        {
                            UserFollowersId = 3,
                            FollowerId = 3,
                            UserId = 2
                        },
                        new
                        {
                            UserFollowersId = 4,
                            FollowerId = 1,
                            UserId = 2
                        },
                        new
                        {
                            UserFollowersId = 5,
                            FollowerId = 1,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Conduit.Models.Article", b =>
                {
                    b.HasOne("Conduit.Models.User", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Models.Comment", b =>
                {
                    b.HasOne("Conduit.Models.Article", "Article")
                        .WithMany("comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduit.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Models.FavoriteArticles", b =>
                {
                    b.HasOne("Conduit.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduit.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Models.UserFollowers", b =>
                {
                    b.HasOne("Conduit.Models.User", "Follower")
                        .WithMany()
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Conduit.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Conduit.Models.Article", b =>
                {
                    b.Navigation("comments");
                });

            modelBuilder.Entity("Conduit.Models.User", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}