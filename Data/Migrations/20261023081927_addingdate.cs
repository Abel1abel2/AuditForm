using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuditForm.Migrations
{
    /// <inheritdoc />
    public partial class addingdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Fraud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Fraud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ProvisionAmount",
                table: "Fraud",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Fraud",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "WrittenOffAmount",
                table: "Fraud",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "ProvisionAmount",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Fraud");

            migrationBuilder.DropColumn(
                name: "WrittenOffAmount",
                table: "Fraud");
        }
    }
}
