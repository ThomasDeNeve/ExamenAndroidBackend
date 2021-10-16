using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Data.Migrations
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Room_Id",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_MeetingRoomId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Room_RoomId1",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Room_MeetingRoomId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "CoworkRoom");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RoomId1",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceAfEnToe",
                table: "Seat",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceFixedDown",
                table: "Seat",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceFixedUp",
                table: "Seat",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceFulltime",
                table: "Seat",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceHalftime",
                table: "Seat",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceYear",
                table: "Seat",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MeetingRoom",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "MeetingRoom",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MeetingRoom",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PriceFullDay",
                table: "MeetingRoom",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceHalfDay",
                table: "MeetingRoom",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_LocationId",
                table: "Seat",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoom_LocationId",
                table: "MeetingRoom",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Location_LocationId",
                table: "MeetingRoom",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                table: "Reservation",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Location_LocationId",
                table: "Seat",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_MeetingRoom_MeetingRoomId",
                table: "Seat",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Location_LocationId",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Location_LocationId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_MeetingRoom_MeetingRoomId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_LocationId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_MeetingRoom_LocationId",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceAfEnToe",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceFixedDown",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceFixedUp",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceFulltime",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceHalftime",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceYear",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "PriceFullDay",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "PriceHalfDay",
                table: "MeetingRoom");

            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "MeetingRoom",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceFullDay = table.Column<double>(type: "float", nullable: false),
                    PriceHalfDay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoworkRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoworkRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoworkRoom_Room_Id",
                        column: x => x.Id,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RoomId1",
                table: "Reservation",
                column: "RoomId1",
                unique: true,
                filter: "[RoomId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Room_LocationId",
                table: "Room",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Room_Id",
                table: "MeetingRoom",
                column: "Id",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Room_MeetingRoomId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Room_MeetingRoomId",
                table: "Seat",
                column: "MeetingRoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
