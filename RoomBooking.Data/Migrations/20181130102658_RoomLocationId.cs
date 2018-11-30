using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBooking.Data.Migrations
{
    public partial class RoomLocationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Rooms",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LocationID",
                table: "Rooms",
                newName: "IX_Rooms_LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Rooms",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LocationId",
                table: "Rooms",
                newName: "IX_Rooms_LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationID",
                table: "Rooms",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
