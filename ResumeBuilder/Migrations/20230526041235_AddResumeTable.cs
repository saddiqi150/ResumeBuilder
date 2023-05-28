using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class AddResumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DoB = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    ResumeTemplateId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_ResumeTemplate_ResumeTemplateId",
                        column: x => x.ResumeTemplateId,
                        principalTable: "ResumeTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resume_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Resume_ResumeTemplateId",
                table: "Resume",
                column: "ResumeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Resume_UserId",
                table: "Resume",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 31, 17, 941, DateTimeKind.Local).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 31, 17, 941, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 31, 17, 941, DateTimeKind.Local).AddTicks(4803));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 31, 17, 941, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ProjCategorys",
                keyColumn: "ProjCategoryId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 25, 22, 31, 17, 941, DateTimeKind.Local).AddTicks(4807));
        }
    }
}
