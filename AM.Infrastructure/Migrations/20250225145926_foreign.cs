using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class foreign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_passengersId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_Planes_PlaneId",
                table: "flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_passengersId",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "passengersId",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "flights",
                newName: "planeFK");

            migrationBuilder.RenameIndex(
                name: "IX_flights_PlaneId",
                table: "flights",
                newName: "IX_flights_planeFK");

            migrationBuilder.AlterColumn<string>(
                name: "passportnumber",
                table: "Passengers",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "passengerspassportnumber",
                table: "FlightPassenger",
                type: "nvarchar(7)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "passportnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "flightsFlightId", "passengerspassportnumber" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_passengerspassportnumber",
                table: "FlightPassenger",
                column: "passengerspassportnumber");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_passengerspassportnumber",
                table: "FlightPassenger",
                column: "passengerspassportnumber",
                principalTable: "Passengers",
                principalColumn: "passportnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_Planes_planeFK",
                table: "flights",
                column: "planeFK",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_passengerspassportnumber",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_flights_Planes_planeFK",
                table: "flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.DropIndex(
                name: "IX_FlightPassenger_passengerspassportnumber",
                table: "FlightPassenger");

            migrationBuilder.DropColumn(
                name: "passengerspassportnumber",
                table: "FlightPassenger");

            migrationBuilder.RenameColumn(
                name: "planeFK",
                table: "flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_flights_planeFK",
                table: "flights",
                newName: "IX_flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "passportnumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "passengersId",
                table: "FlightPassenger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passengers",
                table: "Passengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "flightsFlightId", "passengersId" });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPassenger_passengersId",
                table: "FlightPassenger",
                column: "passengersId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_passengersId",
                table: "FlightPassenger",
                column: "passengersId",
                principalTable: "Passengers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_flights_Planes_PlaneId",
                table: "flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
