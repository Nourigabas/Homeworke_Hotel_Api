using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homeworke_Hotel_Api.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_First_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomType_RoomTypeId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "Id", "DOB", "Email", "FirstName", "IsDeleted", "LastName", "Phone" },
                values: new object[] { 1, new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3264), "anything@gmail.com", "nouri", false, "gabas", "4477889966" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "Email", "IsDeleted", "Name", "Phone" },
                values: new object[] { 1, "syria-idleb", "noury@aboalnour", false, "5 star", "00352681609145" });

            migrationBuilder.InsertData(
                table: "RoomType",
                columns: new[] { "Id", "IsDeleted", "NumOfBeds", "TypeName" },
                values: new object[] { 1, false, 5, "anything" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DOB", "Email", "FirstName", "HotelId", "IsDeleted", "LastName", "StartDate", "Title" },
                values: new object[] { 1, new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3194), "anything@gmail.com", "nouri", 1, false, "gabas", new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "mager" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "FloorNumber", "HotelId", "IsDeleted", "Number", "RoomTypeId", "Status" },
                values: new object[] { 1, 1, 1, false, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckinAt", "CheckoutAt", "EmployeeId", "GuestId", "IsDeleted", "Price", "RoomId" },
                values: new object[] { 1, new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3288), new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999), 1, 1, false, 100m, 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "BookingId", "CreatedDate", "IsDeleted", "TotalAmount" },
                values: new object[] { 1, 1, new DateTime(2024, 6, 14, 14, 38, 19, 73, DateTimeKind.Local).AddTicks(3324), false, 5m });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomType_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomType_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "RoomTypeId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomType_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "Id");
        }
    }
}
