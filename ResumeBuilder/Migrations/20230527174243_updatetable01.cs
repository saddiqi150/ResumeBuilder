using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class updatetable01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HackerRankLink",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "QrCodeImage",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "QrCodeLink",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "QrCodeTitle",
                table: "CvInformation");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "CvInformation",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CvInformation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "CvInformation",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CvInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "CvInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CvInformation",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 42, 42, 429, DateTimeKind.Local).AddTicks(2140));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 42, 42, 429, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 42, 42, 429, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 42, 42, 429, DateTimeKind.Local).AddTicks(2939));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 42, 42, 429, DateTimeKind.Local).AddTicks(2945));

            migrationBuilder.CreateIndex(
                name: "IX_CvInformation_UserId",
                table: "CvInformation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CvInformation_AspNetUsers_UserId",
                table: "CvInformation",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CvInformation_AspNetUsers_UserId",
                table: "CvInformation");

            migrationBuilder.DropIndex(
                name: "IX_CvInformation_UserId",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "CvInformation");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CvInformation");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "CvInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "HackerRankLink",
                table: "CvInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCodeImage",
                table: "CvInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCodeLink",
                table: "CvInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCodeTitle",
                table: "CvInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 9, 26, 63, DateTimeKind.Local).AddTicks(5314));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 9, 26, 63, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 9, 26, 63, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 9, 26, 63, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 27, 22, 9, 26, 63, DateTimeKind.Local).AddTicks(5870));
        }
    }
}
