using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dotnet_v8.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2f9b1cb4-0c72-42dc-a2b1-d052a8f80367"), "Medium" },
                    { new Guid("6d2d6b66-19ef-416d-b58b-d0fcabff8f0b"), "High" },
                    { new Guid("935bf6a2-2854-402c-af80-0ee1840db2f3"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2f9b1cb4-0c72-42dc-a2b1-d052a8f80367"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6d2d6b66-19ef-416d-b58b-d0fcabff8f0b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("935bf6a2-2854-402c-af80-0ee1840db2f3"));
        }
    }
}
