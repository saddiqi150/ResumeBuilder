using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeBuilder.Migrations
{
    public partial class cleandbEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "DonationTranss");

            migrationBuilder.DropTable(
                name: "FundraisingFors");

            migrationBuilder.DropTable(
                name: "FundraisingProjs");

            migrationBuilder.DropTable(
                name: "ProjCategorys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<int>(type: "int", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    CardNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardTyp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOnCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundraisingFors",
                columns: table => new
                {
                    FundraisingForId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FundFor = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraisingFors", x => x.FundraisingForId);
                });

            migrationBuilder.CreateTable(
                name: "ProjCategorys",
                columns: table => new
                {
                    ProjCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjCategorys", x => x.ProjCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FundraisingProjs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FundCategoryId = table.Column<int>(type: "int", nullable: false),
                    GoalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsDonationComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraisingProjs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundraisingProjs_ProjCategorys_FundCategoryId",
                        column: x => x.FundCategoryId,
                        principalTable: "ProjCategorys",
                        principalColumn: "ProjCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundraisingProjs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonationTranss",
                columns: table => new
                {
                    DonationTransId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonationDuration = table.Column<int>(type: "int", nullable: false),
                    FundraisingProjId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationTranss", x => x.DonationTransId);
                    table.ForeignKey(
                        name: "FK_DonationTranss_FundraisingProjs_FundraisingProjId",
                        column: x => x.FundraisingProjId,
                        principalTable: "FundraisingProjs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonationTranss_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProjCategorys",
                columns: new[] { "ProjCategoryId", "CategoryName", "CreatedDate", "DisplayOrder" },
                values: new object[,]
                {
                    { 1, "NonProfit", new DateTime(2023, 5, 28, 11, 9, 38, 145, DateTimeKind.Local).AddTicks(4210), 0 },
                    { 2, "Education", new DateTime(2023, 5, 28, 11, 9, 38, 145, DateTimeKind.Local).AddTicks(4704), 0 },
                    { 3, "Medical", new DateTime(2023, 5, 28, 11, 9, 38, 145, DateTimeKind.Local).AddTicks(4719), 0 },
                    { 4, "Community", new DateTime(2023, 5, 28, 11, 9, 38, 145, DateTimeKind.Local).AddTicks(4722), 0 },
                    { 5, "Emmergency", new DateTime(2023, 5, 28, 11, 9, 38, 145, DateTimeKind.Local).AddTicks(4725), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationTranss_FundraisingProjId",
                table: "DonationTranss",
                column: "FundraisingProjId");

            migrationBuilder.CreateIndex(
                name: "IX_DonationTranss_UserId",
                table: "DonationTranss",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundraisingProjs_FundCategoryId",
                table: "FundraisingProjs",
                column: "FundCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundraisingProjs_UserId",
                table: "FundraisingProjs",
                column: "UserId");
        }
    }
}
