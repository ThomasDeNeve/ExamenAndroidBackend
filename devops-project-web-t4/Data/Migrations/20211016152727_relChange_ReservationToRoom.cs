using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Data.Migrations
{
    public partial class relChange_ReservationToRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_MeetingRoom_RoomId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RoomId1",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId1",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                unique: true,
                filter: "[RoomId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_RoomId",
                table: "Reservation",
                column: "MeetingRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RoomId1",
                table: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId1",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_MeetingRoom_RoomId",
                table: "Reservation",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
