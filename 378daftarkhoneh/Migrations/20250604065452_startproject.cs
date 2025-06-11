using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _378daftarkhoneh.Migrations
{
    /// <inheritdoc />
    public partial class startproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 5, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1391), new DateTime(2025, 5, 5, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1397) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 10, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1404), new DateTime(2025, 5, 10, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 15, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1408), new DateTime(2025, 5, 15, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1409) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1412), new DateTime(2025, 5, 20, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1413) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1346));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1352));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1354));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1355));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 10, 24, 51, 242, DateTimeKind.Local).AddTicks(1135));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 5, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9430), new DateTime(2025, 5, 5, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9436) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 10, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9444), new DateTime(2025, 5, 10, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9445) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 15, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9449), new DateTime(2025, 5, 15, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9449) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 20, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9453), new DateTime(2025, 5, 20, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9454) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9358));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 4, 2, 48, 41, 878, DateTimeKind.Local).AddTicks(8893));
        }
    }
}
