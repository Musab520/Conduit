using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conduit.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleTbls",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleBody = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTbls", x => x.ArticleId);
                });

            migrationBuilder.CreateTable(
                name: "UserTbls",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbls", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CommentTbls",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    IsAchild = table.Column<bool>(type: "bit", nullable: true),
                    BodyText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTbls", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentTbls_ArticleTbls_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "ArticleTbls",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentTbls_UserTbls_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTbls",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteArticlesTbls",
                columns: table => new
                {
                    FavoriteArticlesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteArticlesTbls", x => x.FavoriteArticlesId);
                    table.ForeignKey(
                        name: "FK_FavoriteArticlesTbls_ArticleTbls_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "ArticleTbls",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteArticlesTbls_UserTbls_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTbls",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserArticlesTbls",
                columns: table => new
                {
                    UserArticlesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArticlesTbls", x => x.UserArticlesId);
                    table.ForeignKey(
                        name: "FK_UserArticlesTbls_ArticleTbls_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "ArticleTbls",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserArticlesTbls_UserTbls_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTbls",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowersTbls",
                columns: table => new
                {
                    UserFollowersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FollowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowersTbls", x => x.UserFollowersId);
                    table.ForeignKey(
                        name: "FK_UserFollowersTbls_UserTbls_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "UserTbls",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserFollowersTbls_UserTbls_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTbls",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.Sql("ALTER TABLE UserFollowersTbls ADD CHECK(UserId!=FollowerId);");
            migrationBuilder.CreateIndex(
                name: "IX_CommentTbls_ArticleId",
                table: "CommentTbls",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTbls_UserId",
                table: "CommentTbls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticlesTbls_ArticleId",
                table: "FavoriteArticlesTbls",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticlesTbls_UserId",
                table: "FavoriteArticlesTbls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArticlesTbls_ArticleId",
                table: "UserArticlesTbls",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserArticlesTbls_UserId",
                table: "UserArticlesTbls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowersTbls_FollowerId",
                table: "UserFollowersTbls",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowersTbls_UserId",
                table: "UserFollowersTbls",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentTbls");

            migrationBuilder.DropTable(
                name: "FavoriteArticlesTbls");

            migrationBuilder.DropTable(
                name: "UserArticlesTbls");

            migrationBuilder.DropTable(
                name: "UserFollowersTbls");

            migrationBuilder.DropTable(
                name: "ArticleTbls");

            migrationBuilder.DropTable(
                name: "UserTbls");
        }
    }
}
