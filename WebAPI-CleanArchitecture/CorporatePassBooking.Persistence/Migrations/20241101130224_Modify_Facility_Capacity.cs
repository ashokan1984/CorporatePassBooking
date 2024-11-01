using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorporatePassBooking.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Facility_Capacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Facilities",
                newName: "TotalCapacity");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCapacity",
                table: "Facilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCapacity",
                table: "Facilities");

            migrationBuilder.RenameColumn(
                name: "TotalCapacity",
                table: "Facilities",
                newName: "Capacity");
        }
    }
}
