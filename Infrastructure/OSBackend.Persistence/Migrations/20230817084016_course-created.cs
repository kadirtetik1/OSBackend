using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class coursecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "max_student",
                table: "Courses",
                newName: "weeklyHours");

            migrationBuilder.RenameColumn(
                name: "field",
                table: "Courses",
                newName: "semester");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Courses",
                newName: "faculty");

            migrationBuilder.RenameColumn(
                name: "comments",
                table: "Courses",
                newName: "department");

            migrationBuilder.AddColumn<int>(
                name: "capacity",
                table: "Courses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "course_code",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "capacity",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "course_code",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "weeklyHours",
                table: "Courses",
                newName: "max_student");

            migrationBuilder.RenameColumn(
                name: "semester",
                table: "Courses",
                newName: "field");

            migrationBuilder.RenameColumn(
                name: "faculty",
                table: "Courses",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "department",
                table: "Courses",
                newName: "comments");
        }
    }
}
