using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicrosoftDocs.Infrastructure.Migrations
{
    public partial class _004_add_parentId_fk_product_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Products",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                newName: "IX_Products_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products",
                column: "ParentId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ParentId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Products",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                newName: "IX_Products_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
