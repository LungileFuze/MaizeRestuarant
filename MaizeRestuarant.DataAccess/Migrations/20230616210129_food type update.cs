using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaizeRestuarant.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class foodtypeupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FoodTypes",
                newName: "FoodTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodTypeId",
                table: "FoodTypes",
                newName: "Id");
        }
    }
}
