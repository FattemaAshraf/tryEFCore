using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ayaa7aga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Posts",
                schema: "blogging",
                newName: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blogging");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Posts",
                newSchema: "blogging");
        }
    }
}
