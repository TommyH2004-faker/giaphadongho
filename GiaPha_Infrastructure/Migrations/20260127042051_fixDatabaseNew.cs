using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiaPha_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixDatabaseNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivationCode",
                table: "TaiKhoanNguoiDungs",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "TaiKhoanNguoiDungs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "TaiKhoanNguoiDungs",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "TaiKhoanNguoiDungs",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationCode",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "TaiKhoanNguoiDungs");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "TaiKhoanNguoiDungs");
        }
    }
}
