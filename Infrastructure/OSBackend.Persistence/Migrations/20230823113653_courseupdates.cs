using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class courseupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "days",
                table: "Courses",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "endHours",
                table: "Courses",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "startHours",
                table: "Courses",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "days",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "endHours",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "startHours",
                table: "Courses");
        }
    }
}
