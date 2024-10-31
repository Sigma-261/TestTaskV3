using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTaskV3.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "TUBE",
                newName: "UPDATE_AT");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "TUBE",
                newName: "CREATE_AT");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "STEEL_GRADE",
                newName: "UPDATE_AT");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "STEEL_GRADE",
                newName: "CREATE_AT");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "PACK",
                newName: "UPDATE_AT");

            migrationBuilder.RenameColumn(
                name: "DateCreate",
                table: "PACK",
                newName: "CREATE_AT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UPDATE_AT",
                table: "TUBE",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "CREATE_AT",
                table: "TUBE",
                newName: "DateCreate");

            migrationBuilder.RenameColumn(
                name: "UPDATE_AT",
                table: "STEEL_GRADE",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "CREATE_AT",
                table: "STEEL_GRADE",
                newName: "DateCreate");

            migrationBuilder.RenameColumn(
                name: "UPDATE_AT",
                table: "PACK",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "CREATE_AT",
                table: "PACK",
                newName: "DateCreate");
        }
    }
}
