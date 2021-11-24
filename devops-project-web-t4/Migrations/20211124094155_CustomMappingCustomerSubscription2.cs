using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class CustomMappingCustomerSubscription2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersLinkId",
                table: "CustomerSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsLinkId",
                table: "CustomerSubscription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subscription",
                newName: "SubscriptionId");

            migrationBuilder.RenameColumn(
                name: "SubscriptionsLinkId",
                table: "CustomerSubscription",
                newName: "SubscriptionsLinkSubscriptionId");

            migrationBuilder.RenameColumn(
                name: "CustomersLinkId",
                table: "CustomerSubscription",
                newName: "CustomersLinkCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSubscription_SubscriptionsLinkId",
                table: "CustomerSubscription",
                newName: "IX_CustomerSubscription_SubscriptionsLinkSubscriptionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customer",
                newName: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersLinkCustomerId",
                table: "CustomerSubscription",
                column: "CustomersLinkCustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsLinkSubscript~",
                table: "CustomerSubscription",
                column: "SubscriptionsLinkSubscriptionId",
                principalTable: "Subscription",
                principalColumn: "SubscriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Customer_CustomersLinkCustomerId",
                table: "CustomerSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSubscription_Subscription_SubscriptionsLinkSubscript~",
                table: "CustomerSubscription");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "Subscription",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubscriptionsLinkSubscriptionId",
                table: "CustomerSubscription",
                newName: "SubscriptionsLinkId");

            migrationBuilder.RenameColumn(
                name: "CustomersLinkCustomerId",
                table: "CustomerSubscription",
                newName: "CustomersLinkId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSubscription_SubscriptionsLinkSubscriptionId",
                table: "CustomerSubscription",
                newName: "IX_CustomerSubscription_SubscriptionsLinkId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customer",
                newName: "Id");

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
    }
}
