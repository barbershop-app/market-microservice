using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace microservice.Data.SQL.Migrations
{
    public partial class changes_in_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descreption",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSource",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descreption",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageSource",
                table: "Categories");
        }
    }
}
