using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("454263da-4782-4d99-91f6-647e081bfe83"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("7209e18e-8682-4258-aced-efa43f6ae6d0"));

            migrationBuilder.AddColumn<int[]>(
                name: "TimeOfDays",
                table: "ChoreTemplates",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PersonId" },
                values: new object[,]
                {
                    { new Guid("5d778dd6-97cd-4234-8259-be2f96769587"), "Abigail", null },
                    { new Guid("e48293e3-7bdb-4c12-a2b0-3f04f4cb8a1a"), "Elijah", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("5d778dd6-97cd-4234-8259-be2f96769587"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("e48293e3-7bdb-4c12-a2b0-3f04f4cb8a1a"));

            migrationBuilder.DropColumn(
                name: "TimeOfDays",
                table: "ChoreTemplates");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PersonId" },
                values: new object[,]
                {
                    { new Guid("454263da-4782-4d99-91f6-647e081bfe83"), "Abigail", null },
                    { new Guid("7209e18e-8682-4258-aced-efa43f6ae6d0"), "Elijah", null }
                });
        }
    }
}
