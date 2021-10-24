using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class ReservationFKmeetingroom_notreq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "FixedDown",
                table: "SeatPrice");

            migrationBuilder.DropColumn(
                name: "FixedUp",
                table: "SeatPrice");

            migrationBuilder.DropColumn(
                name: "Fulltime",
                table: "SeatPrice");

            migrationBuilder.DropColumn(
                name: "Halftime",
                table: "SeatPrice");

            migrationBuilder.DropColumn(
                name: "Ocasionally",
                table: "SeatPrice");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SeatPrice");

            migrationBuilder.DropColumn(
                name: "Evening",
                table: "MeetingRoomPrice");

            migrationBuilder.DropColumn(
                name: "FullDay",
                table: "MeetingRoomPrice");

            migrationBuilder.DropColumn(
                name: "HalfDay",
                table: "MeetingRoomPrice");

            migrationBuilder.DropColumn(
                name: "TwoHours",
                table: "MeetingRoomPrice");

            migrationBuilder.AlterColumn<int>(
                name: "MeetingRoomId",
                table: "Reservation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Evening",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FixedDown",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FixedUp",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FullDay",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fulltime",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HalfDay",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Halftime",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ocasionally",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwoHours",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Price",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                table: "Reservation",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Evening",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "FixedDown",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "FixedUp",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "FullDay",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Fulltime",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "HalfDay",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Halftime",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Ocasionally",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "TwoHours",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Price");

            migrationBuilder.AddColumn<int>(
                name: "FixedDown",
                table: "SeatPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FixedUp",
                table: "SeatPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fulltime",
                table: "SeatPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Halftime",
                table: "SeatPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ocasionally",
                table: "SeatPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SeatPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MeetingRoomId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Evening",
                table: "MeetingRoomPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FullDay",
                table: "MeetingRoomPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HalfDay",
                table: "MeetingRoomPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwoHours",
                table: "MeetingRoomPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                table: "Reservation",
                column: "MeetingRoomId",
                principalTable: "MeetingRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
