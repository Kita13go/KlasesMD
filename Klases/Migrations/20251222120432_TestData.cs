using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Klases.Migrations
{
    /// <inheritdoc />
    public partial class TestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "UserID", "ContractDate", "Email", "IsActive", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.ozola@gmail.com", true, "Anna Ozola" },
                    { 2, new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "janis.berzins@gmail.com", true, "Jānis Bērziņš" }
                });

            migrationBuilder.InsertData(
                table: "ITSupports",
                columns: new[] { "UserID", "Email", "IsActive", "Specialization", "UserName" },
                values: new object[,]
                {
                    { 1, "marta.liepa@gmail.com", true, 2, "Marta Liepa" },
                    { 2, "edgars.kalnins@gmail.com", true, 1, "Edgars Kalniņš" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketID", "Description", "EmployeeID", "IsResolved", "Priority", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Printeris 2. stāvā neieslēdzas.", 1, false, 2, 0, "printeris nestrādā" },
                    { 2, "Excel nereaģē uz peles klikšķiem.", 2, false, 3, 1, "Programmas kļūda" }
                });

            migrationBuilder.InsertData(
                table: "Assignements",
                columns: new[] { "AssignementID", "AssignedAt", "Comment", "ITSupportID", "TicketID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pārbaudīt printera barošanu.", 1, 1 },
                    { 2, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Notestēt Excel atjauninājumu.", 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignements",
                keyColumn: "AssignementID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignements",
                keyColumn: "AssignementID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ITSupports",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ITSupports",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "UserID",
                keyValue: 2);
        }
    }
}
