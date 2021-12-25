using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace devops_project_web_t4.Migrations
{
    public partial class MeetingroomReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Location_LocationId",
                table: "MeetingRoom");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "MeetingRoom",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CoworkReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoworkReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoworkReservation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoworkReservation_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MeetingroomReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MeetingroomId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingroomReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingroomReservation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingroomReservation_MeetingRoom_MeetingroomId",
                        column: x => x.MeetingroomId,
                        principalTable: "MeetingRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CoworkReservation_CustomerId",
                table: "CoworkReservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CoworkReservation_SeatId_From",
                table: "CoworkReservation",
                columns: new[] { "SeatId", "From" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingroomReservation_CustomerId",
                table: "MeetingroomReservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingroomReservation_MeetingroomId_From",
                table: "MeetingroomReservation",
                columns: new[] { "MeetingroomId", "From" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Location_LocationId",
                table: "MeetingRoom",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingRoom_Location_LocationId",
                table: "MeetingRoom");

            migrationBuilder.DropTable(
                name: "CoworkReservation");

            migrationBuilder.DropTable(
                name: "MeetingroomReservation");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "MeetingRoom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MeetingRoomId = table.Column<int>(type: "int", nullable: true),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_MeetingRoom_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "MeetingRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerId",
                table: "Reservation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_MeetingRoomId",
                table: "Reservation",
                column: "MeetingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_SeatId_From",
                table: "Reservation",
                columns: new[] { "SeatId", "From" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingRoom_Location_LocationId",
                table: "MeetingRoom",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
