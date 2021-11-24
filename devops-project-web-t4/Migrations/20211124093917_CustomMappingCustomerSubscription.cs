using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class CustomMappingCustomerSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersId",
                table: "CustomerSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsId",
                table: "CustomerSubscription");

            migrationBuilder.RenameColumn(
                name: "SubscriptionsId",
                table: "CustomerSubscription",
                newName: "SubscriptionsLinkId");

            migrationBuilder.RenameColumn(
                name: "CustomersId",
                table: "CustomerSubscription",
                newName: "CustomersLinkId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSubscription_SubscriptionsId",
                table: "CustomerSubscription",
                newName: "IX_CustomerSubscription_SubscriptionsLinkId");

            migrationBuilder.CreateTable(
                name: "CustomerSubscriptions",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    SubFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SubTo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSubscriptions", x => new { x.CustomerId, x.SubscriptionId });
                    table.ForeignKey(
                        name: "FK_CustomerSubscriptions_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSubscriptions_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSubscriptions_SubscriptionId",
                table: "CustomerSubscriptions",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersLinkId",
                table: "CustomerSubscription",
                column: "CustomersLinkId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsLinkId",
                table: "CustomerSubscription",
                column: "SubscriptionsLinkId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersLinkId",
                table: "CustomerSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsLinkId",
                table: "CustomerSubscription");

            migrationBuilder.DropTable(
                name: "CustomerSubscriptions");

            migrationBuilder.RenameColumn(
                name: "SubscriptionsLinkId",
                table: "CustomerSubscription",
                newName: "SubscriptionsId");

            migrationBuilder.RenameColumn(
                name: "CustomersLinkId",
                table: "CustomerSubscription",
                newName: "CustomersId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSubscription_SubscriptionsLinkId",
                table: "CustomerSubscription",
                newName: "IX_CustomerSubscription_SubscriptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersId",
                table: "CustomerSubscription",
                column: "CustomersId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsId",
                table: "CustomerSubscription",
                column: "SubscriptionsId",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
