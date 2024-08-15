using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("6af16a91-000f-470c-882b-b7ba4471171b"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("acc37077-4745-437d-a80a-99e6bc6ac3cd"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "People",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "DaysOfWeek",
                table: "ChoreTemplates",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "ChoreTemplates",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "PersonId" },
                values: new object[,]
                {
                    { new Guid("d5c70454-b953-485a-8e8f-71b39d155813"), "Elijah", null },
                    { new Guid("d8167347-bc95-4210-bc22-07ffa489e914"), "Abigail", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonId",
                table: "People",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChoreTemplates_PersonId",
                table: "ChoreTemplates",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChoreTemplates_People_PersonId",
                table: "ChoreTemplates",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_PersonId",
                table: "People",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChoreTemplates_People_PersonId",
                table: "ChoreTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_PersonId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_ChoreTemplates_PersonId",
                table: "ChoreTemplates");

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("d5c70454-b953-485a-8e8f-71b39d155813"));

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: new Guid("d8167347-bc95-4210-bc22-07ffa489e914"));

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DaysOfWeek",
                table: "ChoreTemplates");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "ChoreTemplates");

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6af16a91-000f-470c-882b-b7ba4471171b"), "Abigail" },
                    { new Guid("acc37077-4745-437d-a80a-99e6bc6ac3cd"), "Elijah" }
                });
        }
    }
}
