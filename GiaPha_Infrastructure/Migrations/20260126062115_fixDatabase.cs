using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiaPha_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ThanhViens",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ThanhTuu",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TepTins",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TaiKhoanNguoiDungs",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SuKiens",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuanHeChaCons",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notifications",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Hos",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "HonNhans",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ChiHos",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AuditLogs",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Albums",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "(UUID())",
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ThanhViens",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ThanhTuu",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TepTins",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TaiKhoanNguoiDungs",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SuKiens",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuanHeChaCons",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Notifications",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Hos",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "HonNhans",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Comments",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ChiHos",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AuditLogs",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Albums",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldDefaultValueSql: "(UUID())")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
