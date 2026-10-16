using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcCEMH.Migrations
{
    /// <inheritdoc />
    public partial class AddStaffHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateStaffs_CorporateStaffs_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "CorporateStaffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorporateStaffs_ManagerId",
                table: "CorporateStaffs",
                column: "ManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateStaffs");
        }
    }
}
