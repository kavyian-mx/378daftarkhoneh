using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _378daftarkhoneh.Migrations
{
    /// <inheritdoc />
    public partial class editdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 13, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7290), new DateTime(2025, 5, 13, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7296) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 18, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7304), new DateTime(2025, 5, 18, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7308), new DateTime(2025, 5, 23, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7309) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7312), new DateTime(2025, 5, 28, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7255));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7257));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7258));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7260));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 13, 14, 465, DateTimeKind.Local).AddTicks(7064));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
