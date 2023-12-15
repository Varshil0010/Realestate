using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdateOn",
                table: "PropertyTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LastUpdateOn",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "LastUpdateOn",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "FurnishingTypes");

            migrationBuilder.DropColumn(
                name: "LastUpdateOn",
                table: "FurnishingTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastUpdateBy",
                table: "PropertyTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateOn",
                table: "PropertyTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastUpdateBy",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateOn",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastUpdateBy",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateOn",
                table: "Photos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastUpdateBy",
                table: "FurnishingTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateOn",
                table: "FurnishingTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
