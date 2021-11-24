using Microsoft.EntityFrameworkCore.Migrations;

namespace devops_project_web_t4.Migrations
{
    public partial class CustomMappingCustomerSubscription4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSubscription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSubscription",
                columns: table => new
                {
                    CustomersLinkCustomerId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsLinkSubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSubscription", x => new { x.CustomersLinkCustomerId, x.SubscriptionsLinkSubscriptionId });
                    table.ForeignKey(
                        name: "FK_CustomerSubscription_Customer_CustomersLinkCustomerId",
                        column: x => x.CustomersLinkCustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerSubscription_Subscription_SubscriptionsLinkSubscript~",
                        column: x => x.SubscriptionsLinkSubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "SubscriptionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSubscription_SubscriptionsLinkSubscriptionId",
                table: "CustomerSubscription",
                column: "SubscriptionsLinkSubscriptionId");
        }
    }
}
