using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskV3.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STEEL_GRADE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    WEIGHT = table.Column<string>(type: "text", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STEEL_GRADE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TUBE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NUMBER = table.Column<int>(type: "integer", nullable: false),
                    IS_DEFECT = table.Column<bool>(type: "boolean", nullable: false),
                    ID_GRADE = table.Column<Guid>(type: "uuid", nullable: false),
                    WEIGHT = table.Column<decimal>(type: "numeric", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUBE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TUBE_STEEL_GRADE_ID_GRADE",
                        column: x => x.ID_GRADE,
                        principalTable: "STEEL_GRADE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PACK",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    NUMBER = table.Column<int>(type: "integer", nullable: false),
                    ID_TUBE = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PACK_TUBE_ID_TUBE",
                        column: x => x.ID_TUBE,
                        principalTable: "TUBE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PACK_ID_TUBE",
                table: "PACK",
                column: "ID_TUBE");

            migrationBuilder.CreateIndex(
                name: "IX_TUBE_ID_GRADE",
                table: "TUBE",
                column: "ID_GRADE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACK");

            migrationBuilder.DropTable(
                name: "TUBE");

            migrationBuilder.DropTable(
                name: "STEEL_GRADE");
        }
    }
}
