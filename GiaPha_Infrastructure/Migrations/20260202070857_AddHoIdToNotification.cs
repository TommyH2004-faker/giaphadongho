using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiaPha_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHoIdToNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HoId",
                table: "Notifications",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ChiHoId",
                table: "Notifications",
                column: "ChiHoId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_HoId",
                table: "Notifications",
                column: "HoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_ChiHos_ChiHoId",
                table: "Notifications",
                column: "ChiHoId",
                principalTable: "ChiHos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Hos_HoId",
                table: "Notifications",
                column: "HoId",
                principalTable: "Hos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_ChiHos_ChiHoId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Hos_HoId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ChiHoId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_HoId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "HoId",
                table: "Notifications");
        }
    }
}
