using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicrosoftDocs.Infrastructure.Migrations
{
    public partial class _003_add_CollectionsArticles_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Collections_CollectionId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CollectionId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Articles");

            migrationBuilder.CreateTable(
                name: "CollectionsArticles",
                columns: table => new
                {
                    ArticlesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SavedInId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionsArticles", x => new { x.ArticlesId, x.SavedInId });
                    table.ForeignKey(
                        name: "FK_CollectionsArticles_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CollectionsArticles_Collections_SavedInId",
                        column: x => x.SavedInId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectionsArticles_SavedInId",
                table: "CollectionsArticles",
                column: "SavedInId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionsArticles");

            migrationBuilder.AddColumn<string>(
                name: "CollectionId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CollectionId",
                table: "Articles",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Collections_CollectionId",
                table: "Articles",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
