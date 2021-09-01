using Microsoft.EntityFrameworkCore.Migrations;

namespace RendaSolidaria.Infra.Data.Migrations
{
    public partial class seedmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
