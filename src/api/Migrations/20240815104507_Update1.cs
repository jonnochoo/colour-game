using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("d5c70454-b953-485a-8e8f-71b39d155813"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("d8167347-bc95-4210-bc22-07ffa489e914"));

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ChoreTemplates",
                newName: "Summary");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PersonId" },
                values: new object[,]
                {
                    { new Guid("454263da-4782-4d99-91f6-647e081bfe83"), "Abigail", null },
                    { new Guid("7209e18e-8682-4258-aced-efa43f6ae6d0"), "Elijah", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("454263da-4782-4d99-91f6-647e081bfe83"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("7209e18e-8682-4258-aced-efa43f6ae6d0"));

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "ChoreTemplates",
                newName: "Description");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PersonId" },
                values: new object[,]
                {
                    { new Guid("d5c70454-b953-485a-8e8f-71b39d155813"), "Elijah", null },
                    { new Guid("d8167347-bc95-4210-bc22-07ffa489e914"), "Abigail", null }
                });
        }
    }
}
