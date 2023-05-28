using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class DeleteOnFundProject00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDonationComplete",
                table: "FundraisingProjs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 15, 7, 29, 88, DateTimeKind.Local).AddTicks(5207));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 15, 7, 29, 88, DateTimeKind.Local).AddTicks(5541));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 15, 7, 29, 88, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 15, 7, 29, 88, DateTimeKind.Local).AddTicks(5550));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 15, 7, 29, 88, DateTimeKind.Local).AddTicks(5552));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDonationComplete",
                table: "FundraisingProjs");

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 14, 0, 52, 175, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 14, 0, 52, 175, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 14, 0, 52, 175, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 14, 0, 52, 175, DateTimeKind.Local).AddTicks(4258));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 16, 14, 0, 52, 175, DateTimeKind.Local).AddTicks(4261));
        }
    }
}
