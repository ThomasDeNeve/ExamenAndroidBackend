using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Data.Migrations
{
    public partial class initMappingsAdjustRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoworkRoom_Rooms_Id",
                table: "CoworkRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Rooms_Id",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Rooms_RoomId1",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Location_LocationId",
                table: "MeetingRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Rooms_RoomId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "MeetingRooms");

            migrationBuilder.RenameTable(
                name: "MeetingRooms",
                newName: "Room");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_LocationId",
                table: "Room",
                newName: "IX_Room_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoworkRoom_Room_Id",
                table: "CoworkRoom",
                column: "Id",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Room_Id",
                table: "MeetingRoom",
                column: "Id",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Location_LocationId",
                table: "Room",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Room_RoomId",
                table: "Seat",
                column: "MeetingRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoworkRoom_Room_Id",
                table: "CoworkRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Room_Id",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Location_LocationId",
                table: "Room");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Room_RoomId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "MeetingRooms");

            migrationBuilder.RenameIndex(
                name: "IX_Room_LocationId",
                table: "MeetingRooms",
                newName: "IX_Rooms_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "MeetingRooms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoworkRoom_Rooms_Id",
                table: "CoworkRoom",
                column: "Id",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Rooms_Id",
                table: "MeetingRoom",
                column: "Id",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Rooms_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Location_LocationId",
                table: "MeetingRooms",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Rooms_RoomId",
                table: "Seat",
                column: "MeetingRoomId",
                principalTable: "MeetingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
