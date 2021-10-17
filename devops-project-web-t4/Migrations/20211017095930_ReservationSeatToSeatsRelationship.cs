using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class ReservationSeatToSeatsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Seat_SeatId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_SeatId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SeatId",
                table: "Reservation",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Seat_SeatId",
                table: "Reservation",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
