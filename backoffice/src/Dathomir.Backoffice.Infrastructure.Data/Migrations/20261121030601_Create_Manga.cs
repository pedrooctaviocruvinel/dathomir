using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dathomir.Backoffice.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class _20261121030601_Create_Manga : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "mangas",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                title = table.Column<string>(type: "varchar(255)", nullable: false),
                author_id = table.Column<Guid>(type: "uuid", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_mangas", x => x.id);
                table.ForeignKey(
                    name: "FK_mangas_authors_author_id",
                    column: x => x.author_id,
                    principalTable: "authors",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_mangas_author_id",
            table: "mangas",
            column: "author_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "mangas");
    }
}
