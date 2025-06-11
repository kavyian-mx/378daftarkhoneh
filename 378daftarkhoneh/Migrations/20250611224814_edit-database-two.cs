using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _378daftarkhoneh.Migrations
{
    /// <inheritdoc />
    public partial class editdatabasetwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 13, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4617), new DateTime(2025, 5, 13, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4622) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 18, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4632), new DateTime(2025, 5, 18, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4633) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 23, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4639), new DateTime(2025, 5, 23, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4640) });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "PublishedAt" },
                values: new object[] { new DateTime(2025, 5, 28, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4645), new DateTime(2025, 5, 28, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4646) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4575));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 12, 2, 18, 13, 978, DateTimeKind.Local).AddTicks(4306));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
