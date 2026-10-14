using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uber_Ride_Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class seedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FullName", "Password", "Phone", "Role" },
                values: new object[] { 1, "b@gmail.com", "Basil Mohamed", "123456", "12345678910", "Admin" });

            migrationBuilder.InsertData(
                table: "Rides",
                columns: new[] { "Id", "DriverId", "DropOffLocation", "Fare", "PickupLocation", "RiderId", "Status" },
                values: new object[] { 1, 1, "test", 1, "test", 1, "Pending" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Color", "DriverId", "Model", "PlateNumber" },
                values: new object[] { 1, "red", 1, "s3", "123" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentMethod", "RideId", "Status" },
                values: new object[] { 1, 54, new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", 1, "Pending" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Comment", "RideId" },
                values: new object[] { 1, "test", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
