using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tablolardaDuzenlemelerYapıldı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "department",
                table: "Teachers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "department",
                table: "Teachers");
        }
    }
}
