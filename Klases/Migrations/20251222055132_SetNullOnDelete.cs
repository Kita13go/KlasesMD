using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klases.Migrations
{
    /// <inheritdoc />
    public partial class SetNullOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_ITSupports_ITSupportID",
                table: "Assignements");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_ITSupports_ITSupportID",
                table: "Assignements",
                column: "ITSupportID",
                principalTable: "ITSupports",
                principalColumn: "UserID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_ITSupports_ITSupportID",
                table: "Assignements");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_ITSupports_ITSupportID",
                table: "Assignements",
                column: "ITSupportID",
                principalTable: "ITSupports",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignements_Tickets_TicketID",
                table: "Assignements",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID");
        }
    }
}
