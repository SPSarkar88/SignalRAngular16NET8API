using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroBlog.API.Migrations
{
    /// <inheritdoc />
    public partial class disabledImageFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Image_ImageId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ImageId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Post",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "Image",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Post_ImageId",
                table: "Post",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Image_ImageId",
                table: "Post",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
