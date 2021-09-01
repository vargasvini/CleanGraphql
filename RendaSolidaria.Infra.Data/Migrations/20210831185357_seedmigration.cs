using Microsoft.EntityFrameworkCore.Migrations;

namespace RendaSolidaria.Infra.Data.Migrations
{
    public partial class seedmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "CreatedAt",
                 table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
             name: "CreatedBy",
             table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
