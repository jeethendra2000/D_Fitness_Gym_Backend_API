using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_Fitness_Gym.Migrations
{
    /// <inheritdoc />
    public partial class updatedmembershipMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_MembershipId",
                table: "Subscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MembershipId",
                table: "Subscriptions",
                column: "MembershipId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_MembershipId",
                table: "Subscriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MembershipId",
                table: "Subscriptions",
                column: "MembershipId",
                unique: true);
        }
    }
}
