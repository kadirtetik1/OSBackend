using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dateCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_time",
                table: "Teachers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_time",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "created_time",
                table: "Courses",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_time",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "created_time",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "created_time",
                table: "Courses");
        }
    }
}
