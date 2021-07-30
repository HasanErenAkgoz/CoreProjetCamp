using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Images");

            migrationBuilder.AddColumn<DateTime>(
                name: "ImageDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Images",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
