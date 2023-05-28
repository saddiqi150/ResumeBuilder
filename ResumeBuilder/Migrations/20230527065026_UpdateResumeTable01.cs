using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class UpdateResumeTable01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DoB",
                table: "Resume",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 11, 50, 25, 632, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 11, 50, 25, 632, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 11, 50, 25, 632, DateTimeKind.Local).AddTicks(4480));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 11, 50, 25, 632, DateTimeKind.Local).AddTicks(4482));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 11, 50, 25, 632, DateTimeKind.Local).AddTicks(4484));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DoB",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 10, 31, 33, 935, DateTimeKind.Local).AddTicks(1913));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 10, 31, 33, 935, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 10, 31, 33, 935, DateTimeKind.Local).AddTicks(2538));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 10, 31, 33, 935, DateTimeKind.Local).AddTicks(2541));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 10, 31, 33, 935, DateTimeKind.Local).AddTicks(2544));
        }
    }
}
