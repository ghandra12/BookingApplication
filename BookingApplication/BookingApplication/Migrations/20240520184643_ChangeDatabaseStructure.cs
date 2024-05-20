using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabaseStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "RestaurantReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CinemaReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "BarbershopReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BarbershopReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RestaurantReservations");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CinemaReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BarbershopReservations");

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "BarbershopReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id");
        }
    }
}
