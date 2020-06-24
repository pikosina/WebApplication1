using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hashId",
                table: "Picture",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_hashId",
                table: "Picture",
                column: "hashId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Hashs_hashId",
                table: "Picture",
                column: "hashId",
                principalTable: "Hashs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Hashs_hashId",
                table: "Picture");

            migrationBuilder.DropIndex(
                name: "IX_Picture_hashId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "hashId",
                table: "Picture");
        }
    }
}
