using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace News.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    id_section = table.Column<int>(type: "int", nullable: false),
                    name_section = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.id_section);
                });

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    id_author = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    surname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    document = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    id_section = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.id_author);
                    table.ForeignKey(
                        name: "FK_Author_Section",
                        column: x => x.id_section,
                        principalTable: "Section",
                        principalColumn: "id_section",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subsection",
                columns: table => new
                {
                    id_subsection_news = table.Column<int>(type: "int", nullable: false),
                    name_subsection = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    id_section = table.Column<int>(type: "int", nullable: false),
                    MetaTitle = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    MetaDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    MetaKeywords = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News_Name", x => x.id_subsection_news);
                    table.ForeignKey(
                        name: "FK_Subsection_Section",
                        column: x => x.id_section,
                        principalTable: "Section",
                        principalColumn: "id_section",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    id_article = table.Column<int>(type: "int", nullable: false),
                    id_subsection_news = table.Column<int>(type: "int", nullable: false),
                    id_author = table.Column<int>(type: "int", nullable: true),
                    short_description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    image_article = table.Column<byte[]>(type: "image", nullable: true),
                    add_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Text = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.id_article);
                    table.ForeignKey(
                        name: "FK_Article_Author",
                        column: x => x.id_author,
                        principalTable: "Author",
                        principalColumn: "id_author",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_News_Name",
                        column: x => x.id_subsection_news,
                        principalTable: "Subsection",
                        principalColumn: "id_subsection_news",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44546e06-8719-4ad8-b88a-f271ae9d6eab", "59f65c7d-f223-4ec6-b4ed-01c484511cdd", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3b62472e-4f66-49fa-a20f-e7685b9565d8", 0, "38a0ff9c-5d4a-4400-90a0-fd70250ae9f8", "my@email.com", true, false, null, "MY@EMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEEXJ5NYM7HQL2Krd/J+qhY0j4AGQeMmaEAmcFz8+pKt4ClcdnF9hTTA3PYYGaRmL/g==", null, false, "", false, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Article_id_author",
                table: "Article",
                column: "id_author");

            migrationBuilder.CreateIndex(
                name: "IX_Article_id_subsection_news",
                table: "Article",
                column: "id_subsection_news");

            migrationBuilder.CreateIndex(
                name: "IX_Author_id_section",
                table: "Author",
                column: "id_section");

            migrationBuilder.CreateIndex(
                name: "IX_Subsection_id_section",
                table: "Subsection",
                column: "id_section");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Subsection");

            migrationBuilder.DropTable(
                name: "Section");
        }
    }
}
