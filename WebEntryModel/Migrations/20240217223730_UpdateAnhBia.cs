using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEntryModel.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnhBia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnhBia",
                table: "Sachs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhBia",
                table: "Sachs");
        }
    }
}
