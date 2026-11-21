using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dathomir.Backoffice.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class _20261121013903_Add_DateOfBirthAndDateOfDeath_Author : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<DateOnly>(
            name: "date_of_birth",
            table: "authors",
            type: "date",
            nullable: false,
            defaultValue: new DateOnly(1, 1, 1));

        migrationBuilder.AddColumn<DateOnly>(
            name: "date_of_death",
            table: "authors",
            type: "date",
            nullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "date_of_birth",
            table: "authors");

        migrationBuilder.DropColumn(
            name: "date_of_death",
            table: "authors");
    }
}
