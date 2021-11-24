using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class RemoveSeatsFromRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_MeetingRoom_MeetingRoomId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_MeetingRoomId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "MeetingRoomId",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeats",
                table: "MeetingRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSeats",
                table: "MeetingRoom");

            migrationBuilder.AddColumn<int>(
                name: "MeetingRoomId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_MeetingRoomId",
                table: "Seat",
                column: "MeetingRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_MeetingRoom_MeetingRoomId",
                table: "Seat",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
