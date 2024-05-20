using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDatabaseStructure2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaReservations_Cinemas_CinemaId",
                table: "CinemaReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReservations_Restaurants_RestaurantId",
                table: "RestaurantReservations");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "RestaurantReservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "CinemaReservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "BarbershopReservations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "HotelReservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartHour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelReservations_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelReservations_HotelId",
                table: "HotelReservations",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaReservations_Cinemas_CinemaId",
                table: "CinemaReservations",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReservations_Restaurants_RestaurantId",
                table: "RestaurantReservations",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_CinemaReservations_Cinemas_CinemaId",
                table: "CinemaReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantReservations_Restaurants_RestaurantId",
                table: "RestaurantReservations");

            migrationBuilder.DropTable(
                name: "HotelReservations");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "RestaurantReservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "CinemaReservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BarbershopId",
                table: "BarbershopReservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BarbershopReservations_Barbershops_BarbershopId",
                table: "BarbershopReservations",
                column: "BarbershopId",
                principalTable: "Barbershops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaReservations_Cinemas_CinemaId",
                table: "CinemaReservations",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantReservations_Restaurants_RestaurantId",
                table: "RestaurantReservations",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
