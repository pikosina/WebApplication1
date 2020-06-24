using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdImage",
                table: "Hashs");

            migrationBuilder.AddColumn<int>(
                name: "Picture_Id",
                table: "Hashs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture_Id",
                table: "Hashs");

            migrationBuilder.AddColumn<int>(
                name: "IdImage",
                table: "Hashs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
