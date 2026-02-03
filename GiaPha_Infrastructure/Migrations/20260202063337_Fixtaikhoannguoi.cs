using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiaPha_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixtaikhoannguoi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ThanhVienId",
                table: "TaiKhoanNguoiDungs",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoanNguoiDungs_ThanhVienId",
                table: "TaiKhoanNguoiDungs",
                column: "ThanhVienId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaiKhoanNguoiDungs_ThanhViens_ThanhVienId",
                table: "TaiKhoanNguoiDungs",
                column: "ThanhVienId",
                principalTable: "ThanhViens",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaiKhoanNguoiDungs_ThanhViens_ThanhVienId",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropIndex(
                name: "IX_TaiKhoanNguoiDungs_ThanhVienId",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropColumn(
                name: "ThanhVienId",
                table: "TaiKhoanNguoiDungs");
        }
    }
}
