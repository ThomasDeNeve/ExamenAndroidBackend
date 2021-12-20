using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class updateMeetingroomReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingroomReservation_MeetingroomId_From",
                table: "MeetingroomReservation");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "MeetingroomReservation",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MeetingRoom",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "MeetingRoom",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingroomReservation_MeetingroomId_From_To",
                table: "MeetingroomReservation",
                columns: new[] { "MeetingroomId", "From", "To" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MeetingroomReservation_MeetingroomId_From_To",
                table: "MeetingroomReservation");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MeetingroomReservation");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MeetingRoom");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "MeetingRoom");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingroomReservation_MeetingroomId_From",
                table: "MeetingroomReservation",
                columns: new[] { "MeetingroomId", "From" },
                unique: true);
        }
    }
}
