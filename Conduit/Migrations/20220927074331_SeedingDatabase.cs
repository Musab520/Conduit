using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conduit.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTbls",
                columns: new[] { "UserId", "FullName", "Password", "Username" },
                values: new object[] { 1, "Admin", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "UserTbls",
                columns: new[] { "UserId", "FullName", "Password", "Username" },
                values: new object[] { 2, "Admin1", "Admin1", "Admin1" });

            migrationBuilder.InsertData(
                table: "UserTbls",
                columns: new[] { "UserId", "FullName", "Password", "Username" },
                values: new object[] { 3, "Admin2", "Admin2", "Admin2" });

            migrationBuilder.InsertData(
                table: "ArticleTbls",
                columns: new[] { "ArticleId", "ArticleBody", "ArticleTitle", "UserId" },
                values: new object[,]
                {
                    { 1, "", "Untitled", 1 },
                    { 2, "", "Untitled", 2 },
                    { 3, "", "Untitled", 3 }
                });

            migrationBuilder.InsertData(
                table: "UserFollowersTbls",
                columns: new[] { "UserFollowersId", "FollowerId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 1 },
                    { 3, 3, 2 },
                    { 4, 1, 2 },
                    { 5, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "CommentTbls",
                columns: new[] { "CommentId", "ArticleId", "BodyText", "IsAchild", "ParentCommentId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Ok", null, null, 1 },
                    { 2, 1, "Ok", null, null, 1 },
                    { 3, 2, "Ok", null, null, 2 },
                    { 4, 2, "Ok", null, null, 2 },
                    { 5, 3, "yes", null, null, 3 },
                    { 6, 3, "yes", null, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "FavoriteArticlesTbls",
                columns: new[] { "FavoriteArticlesId", "ArticleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentTbls",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CommentTbls",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CommentTbls",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CommentTbls",
                keyColumn: "CommentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CommentTbls",
                keyColumn: "CommentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CommentTbls",
                keyColumn: "CommentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FavoriteArticlesTbls",
                keyColumn: "FavoriteArticlesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FavoriteArticlesTbls",
                keyColumn: "FavoriteArticlesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FavoriteArticlesTbls",
                keyColumn: "FavoriteArticlesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FavoriteArticlesTbls",
                keyColumn: "FavoriteArticlesId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FavoriteArticlesTbls",
                keyColumn: "FavoriteArticlesId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserFollowersTbls",
                keyColumn: "UserFollowersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserFollowersTbls",
                keyColumn: "UserFollowersId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserFollowersTbls",
                keyColumn: "UserFollowersId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserFollowersTbls",
                keyColumn: "UserFollowersId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserFollowersTbls",
                keyColumn: "UserFollowersId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticleTbls",
                keyColumn: "ArticleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleTbls",
                keyColumn: "ArticleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleTbls",
                keyColumn: "ArticleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserTbls",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserTbls",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTbls",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
