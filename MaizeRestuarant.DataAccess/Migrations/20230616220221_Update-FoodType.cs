using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaizeRestuarant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes");

            migrationBuilder.RenameTable(
                name: "FoodTypes",
                newName: "FoodType");

            migrationBuilder.RenameColumn(
                name: "FoodTypeId",
                table: "FoodType",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodType",
                table: "FoodType",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodType",
                table: "FoodType");

            migrationBuilder.RenameTable(
                name: "FoodType",
                newName: "FoodTypes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FoodTypes",
                newName: "FoodTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTypes",
                table: "FoodTypes",
                column: "FoodTypeId");
        }
    }
}
