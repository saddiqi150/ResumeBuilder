using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class ChangeIdToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "BankAccounts");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BankAccounts");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "BankAccountId");

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 17, 14, 24, 32, 257, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 17, 14, 24, 32, 257, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 17, 14, 24, 32, 257, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 17, 14, 24, 32, 257, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 17, 14, 24, 32, 257, DateTimeKind.Local).AddTicks(6905));
        }
    }
}
