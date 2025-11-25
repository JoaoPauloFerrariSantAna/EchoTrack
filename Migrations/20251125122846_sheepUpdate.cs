using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EchoTrackV2.Migrations
{
    /// <inheritdoc />
    public partial class sheepUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmountEaten",
                table: "Sheep",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFull",
                table: "Sheep",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "MaxAmountToEat",
                table: "Sheep",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountEaten",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "IsFull",
                table: "Sheep");

            migrationBuilder.DropColumn(
                name: "MaxAmountToEat",
                table: "Sheep");
        }
    }
}
