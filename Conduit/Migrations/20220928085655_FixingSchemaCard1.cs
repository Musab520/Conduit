using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conduit.Migrations
{
    public partial class FixingSchemaCard1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserTbls",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "CommentTbls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UserTbls_Username",
                table: "UserTbls",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTbls_Username",
                table: "UserTbls");

            migrationBuilder.DropColumn(
                name: "date",
                table: "CommentTbls");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserTbls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
