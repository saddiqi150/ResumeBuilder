using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class UpdateResumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Resume");

            migrationBuilder.AddColumn<string>(
                name: "Certificates",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkExperience",
                table: "Resume",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificates",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "WorkExperience",
                table: "Resume");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 9, 12, 34, 353, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 9, 12, 34, 354, DateTimeKind.Local).AddTicks(427));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 9, 12, 34, 354, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 9, 12, 34, 354, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 26, 9, 12, 34, 354, DateTimeKind.Local).AddTicks(450));
        }
    }
}
