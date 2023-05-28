using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class UpdateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 26, 15, 15, 0, 163, DateTimeKind.Local).AddTicks(4772));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 26, 15, 15, 0, 163, DateTimeKind.Local).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 26, 15, 15, 0, 163, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 26, 15, 15, 0, 163, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 26, 15, 15, 0, 163, DateTimeKind.Local).AddTicks(5321));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 15, 8, 53, 265, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 15, 8, 53, 266, DateTimeKind.Local).AddTicks(375));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 15, 8, 53, 266, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 15, 8, 53, 266, DateTimeKind.Local).AddTicks(388));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 15, 8, 53, 266, DateTimeKind.Local).AddTicks(390));
        }
    }
}
