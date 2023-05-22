using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVideoPrime.API.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Plans_PlanId",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Users_UserId",
                table: "PaymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDetails_PlanId",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PaymentDetails",
                newName: "SubscriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_UserId",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_SubscriptionId");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Subscriptions_SubscriptionId",
                table: "PaymentDetails",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Subscriptions_SubscriptionId",
                table: "PaymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Users_UserId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SubscriptionId",
                table: "PaymentDetails",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_SubscriptionId",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_UserId");

            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "PaymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_PlanId",
                table: "PaymentDetails",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Plans_PlanId",
                table: "PaymentDetails",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Users_UserId",
                table: "PaymentDetails",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
