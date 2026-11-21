using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dathomir.Backoffice.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class _20261121003452_InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "authors",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "varchar(100)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_authors", x => x.id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_authors_id",
            table: "authors",
            column: "id",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "authors");
    }
}
