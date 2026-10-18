using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResearchAdmin.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundingAgencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadResearchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadResearchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrantAwards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EthicsClearanceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundingAgencyId = table.Column<int>(type: "int", nullable: false),
                    LeadResearcherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrantAwards_FundingAgencies_FundingAgencyId",
                        column: x => x.FundingAgencyId,
                        principalTable: "FundingAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrantAwards_LeadResearchers_LeadResearcherId",
                        column: x => x.LeadResearcherId,
                        principalTable: "LeadResearchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrantAwards_FundingAgencyId",
                table: "GrantAwards",
                column: "FundingAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GrantAwards_LeadResearcherId",
                table: "GrantAwards",
                column: "LeadResearcherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrantAwards");

            migrationBuilder.DropTable(
                name: "FundingAgencies");

            migrationBuilder.DropTable(
                name: "LeadResearchers");
        }
    }
}
