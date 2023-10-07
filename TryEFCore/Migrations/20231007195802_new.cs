using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryEFCore.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "bookKey",
                schema: "blogging",
                table: "Books",
                newName: "BookKey");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                schema: "blogging",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                schema: "blogging",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookKey",
                schema: "blogging",
                table: "Books",
                newName: "bookKey");
        }
    }
}
