using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveLife.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FitnessTrainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTrainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GymMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembershipType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalTrainingSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    SessionFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WorkoutFocus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerId = table.Column<int>(type: "int", nullable: false),
                    GymMemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalTrainingSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalTrainingSessions_FitnessTrainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "FitnessTrainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalTrainingSessions_GymMembers_GymMemberId",
                        column: x => x.GymMemberId,
                        principalTable: "GymMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainingSessions_GymMemberId",
                table: "PersonalTrainingSessions",
                column: "GymMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalTrainingSessions_TrainerId",
                table: "PersonalTrainingSessions",
                column: "TrainerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalTrainingSessions");

            migrationBuilder.DropTable(
                name: "FitnessTrainers");

            migrationBuilder.DropTable(
                name: "GymMembers");
        }
    }
}
