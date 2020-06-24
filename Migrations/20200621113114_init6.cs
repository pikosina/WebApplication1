using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Hashs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hashs_PictureId",
                table: "Hashs",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashs_Picture_PictureId",
                table: "Hashs",
                column: "PictureId",
                principalTable: "Picture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hashs_Picture_PictureId",
                table: "Hashs");

            migrationBuilder.DropIndex(
                name: "IX_Hashs_PictureId",
                table: "Hashs");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Hashs");

            migrationBuilder.AddColumn<int>(
                name: "hashId",
                table: "Picture",
                type: "int",
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
    }
}
