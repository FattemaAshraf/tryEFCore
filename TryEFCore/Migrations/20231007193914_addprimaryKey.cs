using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryEFCore.Migrations
{
    /// <inheritdoc />
    public partial class addprimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "blogging",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employees",
                newSchema: "blogging");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blogs",
                newSchema: "blogging");

            migrationBuilder.RenameTable(
                name: "AuditEntry",
                newName: "AuditEntry",
                newSchema: "blogging");

            migrationBuilder.RenameColumn(
                name: "Url",
                schema: "blogging",
                table: "Blogs",
                newName: "BlogUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "blogging",
                table: "Posts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Hello from Fluent API ",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BlogUrl",
                schema: "blogging",
                table: "Blogs",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                schema: "blogging",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "blogging",
                columns: table => new
                {
                    bookKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookKey);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books",
                schema: "blogging");

            migrationBuilder.DropColumn(
                name: "Rating",
                schema: "blogging",
                table: "Blogs");

            migrationBuilder.RenameTable(
                name: "Employees",
                schema: "blogging",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Blogs",
                schema: "blogging",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "AuditEntry",
                schema: "blogging",
                newName: "AuditEntry");

            migrationBuilder.RenameColumn(
                name: "BlogUrl",
                table: "Blogs",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "blogging",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Hello from Fluent API ");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "blogging",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }
    }
}
