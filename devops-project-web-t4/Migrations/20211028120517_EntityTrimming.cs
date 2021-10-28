using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class EntityTrimming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Price_PriceId",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Location_LocationId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Price_PriceId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "MeetingRoomPrice");

            migrationBuilder.DropTable(
                name: "SeatPrice");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Seat_LocationId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_PriceId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_MeetingRoom_PriceId",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "MeetingRoom");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Seat",
                newName: "CoworkRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat",
                newName: "IX_Seat_CoworkRoomId");

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
                name: "PriceOcasionally",
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

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceEvening",
                table: "MeetingRoom",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.AddColumn<double>(
                name: "PriceTwoHours",
                table: "MeetingRoom",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CoworkRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoworkRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoworkRoom_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SeatId",
                table: "Reservation",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_CoworkRoom_LocationId",
                table: "CoworkRoom",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Seat_SeatId",
                table: "Reservation",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_CoworkRoom_CoworkRoomId",
                table: "Seat",
                column: "CoworkRoomId",
                principalTable: "CoworkRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Seat_SeatId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_CoworkRoom_CoworkRoomId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "CoworkRoom");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_SeatId",
                table: "Reservation");

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
                name: "PriceOcasionally",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceYear",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "PriceEvening",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "PriceFullDay",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "PriceHalfDay",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "PriceTwoHours",
                table: "MeetingRoom");

            migrationBuilder.RenameColumn(
                name: "CoworkRoomId",
                table: "Seat",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_CoworkRoomId",
                table: "Seat",
                newName: "IX_Seat_ReservationId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "MeetingRoom",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evening = table.Column<int>(type: "int", nullable: false),
                    FixedDown = table.Column<int>(type: "int", nullable: false),
                    FixedUp = table.Column<int>(type: "int", nullable: false),
                    FullDay = table.Column<int>(type: "int", nullable: false),
                    Fulltime = table.Column<int>(type: "int", nullable: false),
                    HalfDay = table.Column<int>(type: "int", nullable: false),
                    Halftime = table.Column<int>(type: "int", nullable: false),
                    Ocasionally = table.Column<int>(type: "int", nullable: false),
                    TwoHours = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoomPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRoomPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingRoomPrice_Price_Id",
                        column: x => x.Id,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeatPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatPrice_Price_Id",
                        column: x => x.Id,
                        principalTable: "Price",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_LocationId",
                table: "Seat",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_PriceId",
                table: "Seat",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRoom_PriceId",
                table: "MeetingRoom",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Price_PriceId",
                table: "MeetingRoom",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Location_LocationId",
                table: "Seat",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Price_PriceId",
                table: "Seat",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Reservation_ReservationId",
                table: "Seat",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
