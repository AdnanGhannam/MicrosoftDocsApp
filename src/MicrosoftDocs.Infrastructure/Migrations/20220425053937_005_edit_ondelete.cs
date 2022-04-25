using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicrosoftDocs.Infrastructure.Migrations
{
    public partial class _005_edit_ondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sections_SectionId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_User_CreatorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_CreatorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_User_CreatorId",
                table: "Sections");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sections_SectionId",
                table: "Articles",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_User_CreatorId",
                table: "Articles",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_CreatorId",
                table: "Products",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_User_CreatorId",
                table: "Sections",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Sections_SectionId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_User_CreatorId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_User_CreatorId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_User_CreatorId",
                table: "Sections");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Sections_SectionId",
                table: "Articles",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_User_CreatorId",
                table: "Articles",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_User_CreatorId",
                table: "Products",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_User_CreatorId",
                table: "Sections",
                column: "CreatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
