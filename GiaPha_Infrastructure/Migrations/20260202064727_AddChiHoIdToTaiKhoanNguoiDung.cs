using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiaPha_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChiHoIdToTaiKhoanNguoiDung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChiHoId",
                table: "TaiKhoanNguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanNguoiDungs_ChiHoId",
                table: "TaiKhoanNguoiDungs",
                column: "ChiHoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoanNguoiDungs_ChiHos_ChiHoId",
                table: "TaiKhoanNguoiDungs",
                column: "ChiHoId",
                principalTable: "ChiHos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoanNguoiDungs_ChiHos_ChiHoId",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoanNguoiDungs_ChiHoId",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropColumn(
                name: "ChiHoId",
                table: "TaiKhoanNguoiDungs");
        }
    }
}
