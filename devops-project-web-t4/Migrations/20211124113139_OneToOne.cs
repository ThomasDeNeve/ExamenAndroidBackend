using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class OneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Subscription");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SubscriptionId",
                table: "Customer",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Subscription_SubscriptionId",
                table: "Customer",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Subscription_SubscriptionId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_SubscriptionId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Subscription",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CustomerId",
                table: "Subscription",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Customer_CustomerId",
                table: "Subscription",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
