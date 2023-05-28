using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class CvInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CvInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PortraitImage = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    JobTitle = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    BirthDate = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    LinkedinLink = table.Column<string>(nullable: false),
                    GithubLink = table.Column<string>(nullable: true),
                    PersonalLink = table.Column<string>(nullable: true),
                    SkypeId = table.Column<string>(nullable: true),
                    HackerRankLink = table.Column<string>(nullable: true),
                    QrCodeTitle = table.Column<string>(nullable: true),
                    QrCodeLink = table.Column<string>(nullable: true),
                    QrCodeImage = table.Column<string>(nullable: true),
                    Objective = table.Column<string>(nullable: true),
                    Margin = table.Column<int>(nullable: false),
                    Scale = table.Column<int>(nullable: false),
                    AgreePrivacy = table.Column<bool>(nullable: false),
                    AgreeSave = table.Column<bool>(nullable: false),
                    ThemeColor = table.Column<string>(nullable: true),
                    PaperSize = table.Column<string>(nullable: true),
                    TemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CvEducation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartYear = table.Column<int>(nullable: false),
                    EndYear = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    StillStudying = table.Column<bool>(nullable: false),
                    CvInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvEducation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CvEducation_CvInformation_CvInformationId",
                        column: x => x.CvInformationId,
                        principalTable: "CvInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CvEmployment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartYear = table.Column<int>(nullable: false),
                    EndYear = table.Column<int>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    StillWorking = table.Column<bool>(nullable: false),
                    CvInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvEmployment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CvEmployment_CvInformation_CvInformationId",
                        column: x => x.CvInformationId,
                        principalTable: "CvInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CvLanguageSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    CvInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvLanguageSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CvLanguageSkill_CvInformation_CvInformationId",
                        column: x => x.CvInformationId,
                        principalTable: "CvInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CvProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    TechStack = table.Column<string>(nullable: true),
                    CvInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CvProject_CvInformation_CvInformationId",
                        column: x => x.CvInformationId,
                        principalTable: "CvInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CvSkillSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false),
                    SkillsInAString = table.Column<string>(nullable: false),
                    CvInformationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CvSkillSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CvSkillSet_CvInformation_CvInformationId",
                        column: x => x.CvInformationId,
                        principalTable: "CvInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CvEducation_CvInformationId",
                table: "CvEducation",
                column: "CvInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CvEmployment_CvInformationId",
                table: "CvEmployment",
                column: "CvInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CvLanguageSkill_CvInformationId",
                table: "CvLanguageSkill",
                column: "CvInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CvProject_CvInformationId",
                table: "CvProject",
                column: "CvInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_CvSkillSet_CvInformationId",
                table: "CvSkillSet",
                column: "CvInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CvEducation");

            migrationBuilder.DropTable(
                name: "CvEmployment");

            migrationBuilder.DropTable(
                name: "CvLanguageSkill");

            migrationBuilder.DropTable(
                name: "CvProject");

            migrationBuilder.DropTable(
                name: "CvSkillSet");

            migrationBuilder.DropTable(
                name: "CvInformation");

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
    }
}
