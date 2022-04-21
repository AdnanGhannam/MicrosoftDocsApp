using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicrosoftDocs.Infrastructure.Migrations
{
    public partial class _002_add_new_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsArticles_Products_ArticlesId",
                table: "ContributorsArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Products_ArticleId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Products_ArticleId",
                table: "Interactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Collections_CollectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CollectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ContentArea",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FullTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsApi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReadTimes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReadingTime",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsApi = table.Column<bool>(type: "bit", nullable: false),
                    ContentArea = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SectionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sections_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sections_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ReadingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReadTimes = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApi = table.Column<bool>(type: "bit", nullable: false),
                    ContentArea = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CollectionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_User_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CollectionId",
                table: "Articles",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatorId",
                table: "Articles",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_LanguageId",
                table: "Articles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ProductId",
                table: "Articles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SectionId",
                table: "Articles",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CreatorId",
                table: "Sections",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_LanguageId",
                table: "Sections",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ProductId",
                table: "Sections",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionId",
                table: "Sections",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsArticles_Articles_ArticlesId",
                table: "ContributorsArticles",
                column: "ArticlesId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Articles_ArticleId",
                table: "Feedbacks",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Articles_ArticleId",
                table: "Interactions",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsArticles_Articles_ArticlesId",
                table: "ContributorsArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Articles_ArticleId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Articles_ArticleId",
                table: "Interactions");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.AddColumn<string>(
                name: "CollectionId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContentArea",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullTitle",
                table: "Products",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApi",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Points",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReadTimes",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReadingTime",
                table: "Products",
                type: "time",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CollectionId",
                table: "Products",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsArticles_Products_ArticlesId",
                table: "ContributorsArticles",
                column: "ArticlesId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Products_ArticleId",
                table: "Feedbacks",
                column: "ArticleId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Products_ArticleId",
                table: "Interactions",
                column: "ArticleId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Collections_CollectionId",
                table: "Products",
                column: "CollectionId",
                principalTable: "Collections",
                principalColumn: "Id");
        }
    }
}
