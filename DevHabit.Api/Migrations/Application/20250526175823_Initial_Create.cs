using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabit.Api.Migrations.Application
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "devhabit");

            migrationBuilder.CreateTable(
                name: "Frequancy",
                schema: "devhabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TimesPerPeriod = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCompletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequancy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Target",
                schema: "devhabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCompletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Target", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Milesyone",
                schema: "devhabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    Current = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCompletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milesyone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milesyone_Target_TargetId",
                        column: x => x.TargetId,
                        principalSchema: "devhabit",
                        principalTable: "Target",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habits",
                schema: "devhabit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FrequancyId = table.Column<int>(type: "int", nullable: false),
                    TargetId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MilesyoneId = table.Column<int>(type: "int", nullable: true),
                    CreartedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastCompletedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habits_Frequancy_FrequancyId",
                        column: x => x.FrequancyId,
                        principalSchema: "devhabit",
                        principalTable: "Frequancy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Habits_Milesyone_MilesyoneId",
                        column: x => x.MilesyoneId,
                        principalSchema: "devhabit",
                        principalTable: "Milesyone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Habits_Target_TargetId",
                        column: x => x.TargetId,
                        principalSchema: "devhabit",
                        principalTable: "Target",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habits_FrequancyId",
                schema: "devhabit",
                table: "Habits",
                column: "FrequancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_MilesyoneId",
                schema: "devhabit",
                table: "Habits",
                column: "MilesyoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_Name",
                schema: "devhabit",
                table: "Habits",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habits_TargetId",
                schema: "devhabit",
                table: "Habits",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Milesyone_TargetId",
                schema: "devhabit",
                table: "Milesyone",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habits",
                schema: "devhabit");

            migrationBuilder.DropTable(
                name: "Frequancy",
                schema: "devhabit");

            migrationBuilder.DropTable(
                name: "Milesyone",
                schema: "devhabit");

            migrationBuilder.DropTable(
                name: "Target",
                schema: "devhabit");
        }
    }
}
