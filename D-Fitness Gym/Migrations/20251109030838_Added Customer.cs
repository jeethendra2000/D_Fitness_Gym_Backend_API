using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D_Fitness_Gym.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Gym_GymId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Gym_GymId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Gym_GymId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_Gym_GymId",
                table: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Gym");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_GymId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GymId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Customer_GymId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Admins_GymId",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "Admins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Subscriptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Customer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GymId",
                table: "Admins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Gym",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagedByFirebaseUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gym", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_GymId",
                table: "Subscriptions",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GymId",
                table: "Employees",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_GymId",
                table: "Customer",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_GymId",
                table: "Admins",
                column: "GymId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Gym_GymId",
                table: "Admins",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Gym_GymId",
                table: "Customer",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Gym_GymId",
                table: "Employees",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_Gym_GymId",
                table: "Subscriptions",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");
        }
    }
}
