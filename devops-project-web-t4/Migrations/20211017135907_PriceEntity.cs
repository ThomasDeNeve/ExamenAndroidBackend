using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class PriceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRoomPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Evening = table.Column<int>(type: "int", nullable: false),
                    FullDay = table.Column<int>(type: "int", nullable: false),
                    HalfDay = table.Column<int>(type: "int", nullable: false),
                    TwoHours = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ocasionally = table.Column<int>(type: "int", nullable: false),
                    FixedDown = table.Column<int>(type: "int", nullable: false),
                    FixedUp = table.Column<int>(type: "int", nullable: false),
                    Fulltime = table.Column<int>(type: "int", nullable: false),
                    Halftime = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
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
                name: "FK_Seat_Price_PriceId",
                table: "Seat",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Price_PriceId",
                table: "MeetingRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Price_PriceId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "MeetingRoomPrice");

            migrationBuilder.DropTable(
                name: "SeatPrice");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropIndex(
                name: "IX_Seat_PriceId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_MeetingRoom_PriceId",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "MeetingRoom");

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
                nullable: true);
        }
    }
}
